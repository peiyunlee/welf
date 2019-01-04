using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //方向狀態
    public enum State
    {
        playerUp,
        playerDown,
        playerLeft,
        playerRight
    }

    public State state;

    //數值設定
    public float moveSpeed = 10;
    public float jumpSpeed = 5000;
    public int jumpNum = 2;
    public static int jumpCount = 0;
    public Vector2 transformValue;

    //設定按鍵
    private float keyVertical;
    private float keyHorizontal;
    private bool keyJump;
    private bool keyMenu;

    //條件判斷
    public static bool faceRight = true;
    private bool isTop = false;
    private bool isFall = false;
    public static bool isJumping = false;
    private bool isWalking = false;
    public bool isGround = true;
    private bool canJumping = true;
    public static bool isMenu = false;
    public static bool canMove = true;
    private bool change = false;

    PlayerHealth playerHealth;
    PlayerAttack playerAttack;
    Rigidbody2D playerRigidbody;
    Animator playerAnim;

    // Use this for initialization
    void Start()
    {
        state = State.playerRight;

        playerHealth = GetComponent<PlayerHealth>();
        playerAttack = GetComponent<PlayerAttack>();
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        GetKey();

        Animating();

        //if (Input.GetKey(KeyCode.M))
        //{
        //    playerAnim.SetTrigger("change");
        //}
        //if (keyMenu)
        //{
        //    isMenu = !isMenu;
        //}
    }

    void FixedUpdate()
    {
        if (!isMenu && !SkillSet.isSkill)
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
        keyMenu = Input.GetKeyDown(KeyCode.B);
    }

    //移動
    void Move()
    {
            transformValue = new Vector2(keyHorizontal * moveSpeed, playerRigidbody.velocity.y);

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
        if (jumpCount < jumpNum)
        {
            if (playerRigidbody.velocity.y < 11.5f)
            {
                canJumping = true;
            }
        }

        if (keyJump && canJumping)
        {
            isJumping = true;
            //Debug.Log("Jump");
            
            playerRigidbody.AddForce(new Vector2(0f, jumpSpeed * 2f));
            jumpCount++;
            if (playerRigidbody.velocity.y < -1)
            {
                playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, 0);
            }
            isFall = false;
        }
        canJumping = false;

        if ((playerRigidbody.velocity.y > -3 && playerRigidbody.velocity.y < 20) && !isGround && isJumping)
        {
            isTop = true;
            playerAnim.SetBool("isTop",isTop);
            Debug.Log("top");
            //playerAnim.SetBool("isTop", isTop);
        }
        if (playerRigidbody.velocity.y < -3)
        {
            isTop = false;
            isFall = true;
            playerAnim.SetBool("isFall",isFall);
            playerAnim.SetBool("isTop", isTop);
            Debug.Log("fall");
            //playerAnim.SetBool("isTop", isTop);
            //playerAnim.SetBool("isFall", isFall);
        }
        if (isGround)
        {
            isFall = false;
        }
        //isFall = false;
        //Debug.Log(jumpCount);
    }

    //進入地面
    private void OnCollisionEnter2D(Collision2D floor)
    {
        if (floor.gameObject.CompareTag("Floor"))
        {
            isGround = true;

            canJumping = true;

            //playerAnim.SetTrigger("WaId");

            jumpCount = 0;

            isJumping = false;

            isTop = false;
        }
    }

    //在地面上
    private void OnCollisionStay2D(Collision2D floor)
    {
        if (floor.gameObject.CompareTag("Floor"))
        {
            isGround = true;
            isTop = false;
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
            faceRight = !faceRight;
        }
    }

    //動畫
    void Animating()
    {
        if (isMenu)
        {
            isWalking = false;
        }
        playerAnim.SetBool("isWalking", isWalking);

        playerAnim.SetBool("isJumping", isJumping);

        playerAnim.SetBool("isFall", isFall);

        //playerAnim.SetBool("isTop", isTop);
    }
}
