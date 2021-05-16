using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    
    

    public float speed = 5f;

    public SkeletonAnimation playerAni;
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

    private void Awake()
    {
        
    }
    
    
    void Start()
    {
        playerAni = gameObject.GetComponent<SkeletonAnimation>();
        ChangeAni(ANI.IDLE);
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

        if (playerAni == null)
        {
            Debug.Log("애니없음");
            return;
        }

        switch (ani)
        {

            case ANI.IDLE:
                if (!playerAni.state.GetCurrent(0).IsComplete)
                    return;
                playerAni.state.SetAnimation(0,"idle",true);
                playerAni.timeScale = 1f;       
                break;

            case ANI.DIE:
                playerAni.state.SetAnimation(0, "die", false);
                playerAni.timeScale = 1f; 

                break;

            case ANI.ATTACK:
                playerAni.state.SetAnimation(0, "attack", false);
                playerAni.timeScale = 1f; 
                
                break;

            case ANI.RUN:
                playerAni.state.SetAnimation(0, "run", true);
                playerAni.timeScale = 1f;
                break;

            case ANI.JUMP:
                playerAni.state.SetAnimation(0, "jump", false);
                playerAni.timeScale = 1f;
                break;

            case ANI.JUMPATTACK:
                playerAni.state.SetAnimation(0, "jumpattack", false);
                playerAni.timeScale = 1f;
                break;

            case ANI.DAMAGE:
                playerAni.state.SetAnimation(0, "damage", false);
                playerAni.timeScale = 1f;
                break;

            case ANI.DOWN:
                playerAni.state.SetAnimation(0, "down", false);
                playerAni.timeScale = 1f;
                break;

            case ANI.SPECIAL:
                playerAni.state.SetAnimation(0, "special", false);
                playerAni.timeScale = 1f;
                break;

            case ANI.WALK:
                playerAni.state.SetAnimation(0, "walk", false);
                playerAni.timeScale = 1f;
                break;


        }
        //this.ani = ani;
    }

    public void Attack()
    {
        //적이 피격을 받은게 확인되고 
        //맞으면 적이 데미지를 입고
        //idle로 돌아감
    }
}
