using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private static Player _instance;
    public static Player Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new Player();
            }
            return _instance;
        }
    }
    private void Awake()
    {
        _instance = this;
    }
    
    public SkeletonAnimation player;
    public enum ANI
    {
        IDLE,
        ATTACK,
        DAMAGE,
        DOWN,
        DIE,
        RUN,
        JUMP,
        JUMPATTACK,
        SPECIAL,
        WALK
    }
    ANI ani = ANI.IDLE;


    void Start()
    {

    }

    void Update()
    {

    }
    public void ChangeAni(ANI ani)
    {
        if (this.ani == ani)
        {
            return;
        }

        if (player == null)
        {
            Debug.Log("애니없음");
            return;
        }

        switch (ani)
        {

            case ANI.IDLE:
                player.AnimationName = "idle";
                player.timeScale = 1f;
                break;

            case ANI.DIE:
                player.AnimationName = "die";
                player.timeScale = 1f;
                break;

            case ANI.ATTACK:
                player.AnimationName = "attack";
                player.timeScale = 1f;
                break;

            case ANI.RUN:
                player.AnimationName = "run";
                player.timeScale = 1f;
                break;

            case ANI.JUMP:
                player.AnimationName = "jump";
                player.timeScale = 1f;
                break;

            case ANI.JUMPATTACK:
                player.AnimationName = "jumpattack";
                player.timeScale = 1f;
                break;

            case ANI.DAMAGE:
                player.AnimationName = "damage";
                player.timeScale = 1f;
                break;

            case ANI.DOWN:
                player.AnimationName = "down";
                player.timeScale = 1f;
                break;

            case ANI.SPECIAL:
                player.AnimationName = "special";
                player.timeScale = 1f;
                break;

            case ANI.WALK:
                player.AnimationName = "walk";
                player.timeScale = 1f;
                break;


        }
    }

    public void Attack()
    {
        //적이 피격을 받은게 확인되고 
        //맞으면 적이 데미지를 입고
        //idle로 돌아감
    }
}
