using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrossButton : MonoBehaviour
{
    private Player player;
    //public LayerMask layerMask
    public float speed = 1f;//크로스버튼 클래스안에 메소드를 돌릴려고 쓴 변수
    //public bool canMove = false;
    public float step = 0.3f;//버튼누를때마다 적용시키기위한 (Time.deltataime대신)

    public float lange = 1f;

    [Header("방향키")]
    public Button[] buttons;//0;up 1;down 3;right 4;left


    private void Awake()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();//플레이어태그를 찾아서 그안의 플레이어의 컴퍼넌트를 가져와
        speed = player.speed;


    }
    void Start()
    {
        
    }
    
    void Update()
    {
        
    }

    public void ClickButton(int num)
    {
        if (true)
        {

        }
        switch (num)
        {
            case 0:
                player.transform.position += Vector3.up * speed * step;
                player.ChangeAni(Player.ANI.RUN);
                //플레이어위치 벡터에 위로 얼마만큼 더해라
                //Debug.Log("위로");
                break;
            case 1:
                //player.transform.position += Vector3.down * speed * step;
                Debug.Log("d");//내려갈맵이아니라서 일단 디버그찍음
                //아래로 내려가고 점프모션
                break;
            case 2:
                player.transform.position += Vector3.right * speed * step;
                player.transform.localScale = new Vector3(1, 1, 0);
                player.ChangeAni(Player.ANI.RUN);
                //Debug.Log("우로");
                //오른쪽으로가고 점프모션
                break;
            case 3:
                player.transform.position += Vector3.left * speed * step;
                player.transform.localScale = new Vector3(-1,1,0);
                player.ChangeAni(Player.ANI.RUN);
                
                //Debug.Log("좌로");
                //왼쪽으로가고 점프모션
                break;
        }

    }

}
