using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using Spine.Unity;

public class Enemy : MonoBehaviour
{
    private Transform transform;
    private NavMeshAgent nvAgent;


    public Player player;//공격대상
    public float range = 10f;//추적용
    public float attackrange = 5f;//공격용
    public bool playerDir = true;//공격대상이 범위에들어왓는지
    public bool isPlayer = true;//플레이어 생사 여부

    public int hp = 100;//enemy hp
    public int power = 100;//enemy power
    public float speed = 10f;//enemy speed

    public enum CurrentState { IDLE, MOVE, ATTACK, DIE,RUN,JUMP, JUMPATTACK, SPECIAL,WALK };//적 애니상태
    public CurrentState currentState = CurrentState.IDLE;
    public SkeletonAnimation EnemyAni;

    private void Awake()
    {
        transform = this.gameObject.GetComponent<Transform>();
        player = GameObject.FindWithTag
            ("Player").GetComponent <Player >();
        nvAgent = this.gameObject.GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        nvAgent.destination = player.transform.position;
        StartCoroutine (CheckState());
        StartCoroutine(CheckStateToAction());
    }

    void Update()
    {
       
    }
    IEnumerator CheckState()
    {
        while (isPlayer)
        {
            yield return new WaitForSeconds(0.1f);
            float dis = Vector3.Distance(player.transform.position, transform.position);
            if (dis <= attackrange)
            {
                currentState = CurrentState.ATTACK;
            }
            else if (dis <= range)
            {
                currentState = CurrentState.MOVE;
            }
            else
            {
                currentState = CurrentState.IDLE;

            }
        }
       
    }
    IEnumerator CheckStateToAction()
    {
        while (isPlayer)
        {
            switch (currentState)
            {
                case CurrentState.IDLE:
                   // nvAgent.Stop();
                    break;

                case CurrentState.MOVE:
                    nvAgent.destination = player.transform.position;
                   // nvAgent.Resume();
                    break;

                case CurrentState.ATTACK:
                    break;

            }

            yield return null;
        }
    }

    public void ChangeAni(CurrentState cur)
    {
        if (this.currentState == cur)
        {
            return;
        }

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

            case CurrentState.RUN:
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
