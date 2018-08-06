using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    //設定方向狀態
    public const int player_Up = 0;
    public const int player_Right = 1;
    public const int player_Down = 2;
    public const int player_Left = 3;

    //當前方向狀態
    public int state;
    //移動速度
    public int moveSpeed = 2;

    //設定按鍵
    private float keyVertical;
    private float keyHorizontal;
    private bool keyRoll;
    public bool keyMenu;

    //動畫/事件條件判斷
    private bool isWalking = false;
    /*private bool isRoll = false;
    public bool isMenu = false;*/

    Rigidbody playerRigibody;
    Animator playerAnim;

    public void Awake()
    {
        state = player_Up;

        playerRigibody = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void FixedUpdate()
    {
        GetKey();

        /*Menu();*/

        Move();

        /*Roll();*/

        Ainimating();
    }

    void GetKey()
    {
        keyVertical = Input.GetAxis("Vertical");
        keyHorizontal = Input.GetAxis("Horizontal");
        /*keyRoll = Input.GetButtonDown("Roll");*/
        /*keyMenu = Input.GetButtonDown("Menu");*/
    }

    //判斷是否開啟選單
    /*void Menu()
    {        
        if (keyMenu)
        {
            isMenu = !isMenu;
        }        
    }*/

    void Move()
    {
        //if (!isMenu)//沒有開啟選單才能移動
        //{
            if (keyVertical == 1)
            {
                SetPlayerState(player_Up);
            }
            else if (keyVertical == -1)
            {
                SetPlayerState(player_Down);
            }
            if (keyHorizontal == 1)
            {
                SetPlayerState(player_Right);
            }
            else if (keyHorizontal == -1)
            {
                SetPlayerState(player_Left);
            }
        //}
        //else isWalking = false;

            if (keyHorizontal == 0 && keyVertical == 0)
            {
                //設定初始動畫
                isWalking = false;
            }
        
    }

    void SetPlayerState(int newState)
    {
        //計算旋轉角度
        int rotateValue = (newState - state) * 90;
        Vector3 transformValue = new Vector3();

        //設定Walk動畫
        isWalking = true;

        //移動的位置數值
        switch (newState)
        {
            case player_Up:
                transformValue = Vector3.forward * Time.deltaTime;
                break;
            case player_Down:
                transformValue = (-Vector3.forward) * Time.deltaTime;
                break;
            case player_Left:
                transformValue = Vector3.left * Time.deltaTime;
                break;
            case player_Right:
                transformValue = (-Vector3.left) * Time.deltaTime;
                break;
        }

        playerRigibody.transform.Rotate(Vector3.up, rotateValue);

        //移動人物
        playerRigibody.transform.Translate(transformValue * moveSpeed, Space.World);
        state = newState;
    }

    /*void Roll()
    {
        if ((keyVertical != 0 || keyHorizontal != 0) && keyRoll)
        {
            isRoll = true;
        }
        else isRoll = false;
    }*/

    void Ainimating()
    {
        playerAnim.SetBool("IsRun", isWalking);


        /*playerAnim.SetBool("IsJump", isRoll);//翻滾(暫時用Jump代替)*/

    }
}
