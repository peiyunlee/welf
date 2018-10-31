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
    public bool keyMenu;

    //條件判斷
    private bool isWalking = false;
    private bool isGround = true;
    private bool canJumping = true;

    Rigidbody2D playerRigidbody;
    Animator playerAnim;

	// Use this for initialization
	void Start () {
        state = State.playerRight;

        playerRigidbody = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        GetKey();

        ToJump();

        Animating();
	}

    void FixedUpdate()
    {
        Move();

        Jump();
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
            SetPlayerState(State.playerRight);
        }

        if (keyHorizontal == -1)
        {
            SetPlayerState(State.playerLeft);
        }

        if (keyHorizontal == 0)
        {
            isWalking = false;
        }

        playerRigidbody.velocity = transformValue;
    }

    void ToJump()
    {
        if (jumpCount >= jumpNum)
        {
            canJumping = false;
        }
    }

    void Jump()
    {
        if (keyJump && canJumping)
        {
            Debug.Log("Jump");
            playerRigidbody.AddForce(new Vector2(0f, jumpSpeed));
            jumpCount++;
        }
    }

    private void OnCollisionEnter2D(Collision2D floor)
    {
        if (floor.gameObject.CompareTag("Floor"))
        {
            canJumping=true;

            jumpCount = 0;
        }
    }

    private void OnCollisionStay2D(Collision2D floor)
    {
        if (floor.gameObject.CompareTag("Floor"))
        {
            isGround = true;
        }
    }

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
