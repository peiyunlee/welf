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
    public int moveSpeed = 2;

    //設定按鍵
    private float keyVertical;
    private float keyHorizontal;
    private bool keyJump;
    public bool keyMenu;

    //條件判斷
    private bool isWalking = false;

    Rigidbody2D playerRigidbody;
    Animator playerAnim;


	// Use this for initialization
	void Start () {
        state = State.playerRight;

        playerRigidbody = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {

        GetKey();
	}

    void FixedUpdate()
    {
        Move();
    }

    //讀取按鍵
    void GetKey()
    {
        keyHorizontal = Input.GetAxisRaw("Horizontal");
    }

    void Move()
    {
        if (keyHorizontal == 1)
        {
            SetPlayerState(State.playerRight);
            Debug.Log("Right");
        }
        if (keyHorizontal == -1)
        {
            SetPlayerState(State.playerLeft);
            Debug.Log("Left");
        }
    }

    void SetPlayerState(State newState)
    {
        if (newState != state)
        {
            Debug.Log("y");
            //Vector2 temp = 
            //temp.x *= -1;
            //state = newState;
        }
    }

}
