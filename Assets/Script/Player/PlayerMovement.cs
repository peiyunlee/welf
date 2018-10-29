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

    //移動速度
    public float moveSpeed = 10;
    public float jumpSpeed = 10;

    //設定按鍵
    private float keyVertical;
    private float keyHorizontal;
    private bool keyJump;
    public bool keyMenu;

    //條件判斷
    private bool isWalking = false;
    private bool isJumping = false;
    private bool onGround = true;

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
        Vector2 transformValue = new Vector2();

        if (keyHorizontal == 1)
        {
            SetPlayerState(State.playerRight);
            transformValue = Vector2.right * moveSpeed;
        }

        if (keyHorizontal == -1)
        {
            SetPlayerState(State.playerLeft);
            transformValue = Vector2.left * moveSpeed;
        }

        if (keyHorizontal == 0)
        {
            isWalking = false;
        }
        
        playerRigidbody.velocity = transformValue;
    }

    void Jump()
    {
        if (keyJump == true)
        {
            Debug.Log("Jump");
            Vector2 jump = new Vector2(0f, jumpSpeed);
            playerRigidbody.AddForce(jump);
            isJumping = true;
        }
    }

    //判斷轉向
    void SetPlayerState(State newState)
    {
        isWalking = true;

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

       // playerAnim.SetBool("isJumping", isJumping);
    }
}
