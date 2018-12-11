using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    //方向狀態
    enum State
    {
        playerUp,
        playerDown,
        playerLeft,
        playerRight
    }

    State state;

    //數值設定
    public float moveSpeed = 10;
    public float jumpSpeed = 5000;
    public int jumpNum = 2;
    public int jumpCount = 0;

    //設定按鍵
    private float keyVertical;
    private float keyHorizontal;
    private bool keyJump;

    //條件判斷
    private bool isWalking = false;
    public bool isGround = true;
    private bool canJumping = true;
    public static bool isMenu = false;

    PlayerAttack playerAttack;
    Rigidbody2D playerRigidbody;
    Animator playerAnim;

	// Use this for initialization
	void Start () {
        state = State.playerRight;

        playerAttack = GetComponent<PlayerAttack>();
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        GetKey();

        Animating();
	}

    void FixedUpdate()
    {
        if (!isMenu)
        {
            Move();

            Jump();
        }
    }

    //讀取按鍵
    void GetKey()
    {
        keyHorizontal = Input.GetAxisRaw("Horizontal");
        keyJump = Input.GetButtonDown("Jump");
    }

    //移動
    void Move()
    {
        Vector2 transformValue = new Vector2(keyHorizontal * moveSpeed, playerRigidbody.velocity.y);

        if (keyHorizontal == 1)
        {
            playerAnim.SetTrigger("IdWa");
            SetPlayerState(State.playerRight);
        }

        if (keyHorizontal == -1)
        {
            playerAnim.SetTrigger("IdWa");
            SetPlayerState(State.playerLeft);
        }

        if (keyHorizontal == 0)
        {
            playerAnim.SetTrigger("WaId");
            isWalking = false;
        }

        playerRigidbody.velocity = transformValue;
    }

    //跳躍
    void Jump()
    {
        if (keyJump && canJumping)
        {
            Debug.Log("Jump");
            playerRigidbody.AddForce(new Vector2(0f, jumpSpeed));
            jumpCount++;
            if (playerRigidbody.velocity.y < 0)
            {
                playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, 0);
            }
            canJumping = false;
        }
        if (jumpCount < jumpNum)
        {
            canJumping = true;
        }
    }

    //進入地面
    private void OnCollisionEnter2D(Collision2D floor)
    {
        if (floor.gameObject.CompareTag("Floor"))
        {
            canJumping=true;

            playerAnim.SetTrigger("WaId");

            jumpCount = 0;
        }
    }

    //在地面上
    private void OnCollisionStay2D(Collision2D floor)
    {
        if (floor.gameObject.CompareTag("Floor"))
        {
            isGround = true;
        }
    }

    //離開地面
    private void OnCollisionExit2D(Collision2D floor)
    {
        if (floor.gameObject.CompareTag("Floor"))
        {
            isGround = false;
        }
    }

    //判斷轉向
    void SetPlayerState(State newState)
    {
        //判斷是否在地上
        if (isGround == true)
        {
            isWalking = true;
        }
        else isWalking = false;

        if (newState != state)
        {
            Vector2 temp = transform.localScale;
            temp.x *= -1;
            transform.localScale = temp;
            state = newState;
        }
    }

    //動畫
    void Animating()
    {       
          playerAnim.SetBool("isWalking", isWalking);

          //playerAnim.SetBool("isJumping", !isGround);
    }
}
