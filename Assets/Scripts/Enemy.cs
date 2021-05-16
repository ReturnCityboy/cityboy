using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using Spine.Unity;

public class Enemy : MonoBehaviour
{
    
    public Player player;//공격대상
    public float range = 10f;//추적용
    public float attackrange = 5f;//공격용
    public bool playerDir = true;//공격대상이 범위에들어왓는지
    public bool isPlayer = true;//플레이어 생사 여부
    public float step = 0.1f;
    public int hp = 100;//enemy hp
    public int power = 100;//enemy power
    public float speed = 10f;//enemy speed

    public enum CurrentState { IDLE, MOVE, ATTACK, DIE,RUN,JUMP, JUMPATTACK, SPECIAL,WALK };//적 애니상태
    public CurrentState currentState = CurrentState.IDLE;
    public SkeletonAnimation EnemyAni;

    private void Awake()
    {
       
        player = GameObject.FindWithTag
            ("Player").GetComponent <Player >();
        EnemyAni = gameObject.GetComponent<SkeletonAnimation>();

        
    }

    void Start()
    {
        
        StartCoroutine (CheckState());
        
    }

    void Update()
    {
        if (currentState == CurrentState.IDLE )
        {
            ChangeAni(currentState);
        }
    }
    IEnumerator CheckState()
    {
        while (isPlayer)
        {
            yield return new WaitForSeconds(0.1f);
            float dis = Vector3.Distance(player.transform.position, transform.position);
            if (dis <= attackrange)//공격범위 세분화해서 원거리근거리를 나눌수있다
            {
                //멈춤,공격시작
                currentState = CurrentState.ATTACK;
                
                Debug.Log("공격");
            }
            else if (dis <= range)
            {
                currentState = CurrentState.MOVE;
                
               //Debug.Log("탐색");
                //팀섹 플레이어에게 갈수있게
            }
            else
            {
                currentState = CurrentState.IDLE;
                RandomIdle();
                Debug.Log("정지");
                //할일찾기


            }
            ChangeAni(currentState);
        }
       
    }

    public void EnemyMove()
    {
       transform.position += Vector3.left * speed * step; 

    }


    
    public void RandomIdle()
    { 
    
    }

    public void ChangeAni(CurrentState cur)
    {
       

        if (EnemyAni == null)
        {
            Debug.Log("애니없음");
            return;
        }

        switch (cur)
        {

            case CurrentState.IDLE:
                EnemyAni.AnimationName = "idle";
                EnemyAni.timeScale = 1f;
                break;

            case CurrentState.DIE:
                EnemyAni.AnimationName = "die";
                EnemyAni.timeScale = 1f;
                break;

            case CurrentState.ATTACK:
                EnemyAni.AnimationName = "attack";
                EnemyAni.timeScale = 1f;
                break;

            case CurrentState.MOVE:

                /*int r = Random.Range(0, 3);
                if (r == 0)
                {
                    EnemyAni.AnimationName = "run";
                }
                else (r == 1)
                {
                    EnemyAni.AnimationName = "walk";
                }
                else if ()
                {
                    EnemyAni.AnimationName = "jump";
                }*/


                EnemyAni.AnimationName = "run";
                EnemyAni.timeScale = 1f;
                break;

            /*case CurrentState.JUMP:
                player.AnimationName = "jump";
                player.timeScale = 1f;
                break;

            case CurrentState.JUMPATTACK:
                player.AnimationName = "jumpattack";
                player.timeScale = 1f;
                break;

            case CurrentState.DAMAGE:
                player.AnimationName = "damage";
                player.timeScale = 1f;
                break;

            case CurrentState.DOWN:
                player.AnimationName = "down";
                player.timeScale = 1f;
                break;

            case CurrentState.SPECIAL:
                player.AnimationName = "special";
                player.timeScale = 1f;
                break;

            case CurrentState.WALK:
                player.AnimationName = "walk";
                player.timeScale = 1f;
                break;*/


        }
    }
}
