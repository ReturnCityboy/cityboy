using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using UnityEngine.UI;

public class PlayerAni : MonoBehaviour
{
    public SkeletonAnimation playerAni;
    public enum ANI
    {
        IDLE,
        ATTACK,
        DIE,
        RUN


    }
    ANI ani = ANI.IDLE;


    void Start()
    {
        playerAni = gameObject.GetComponent<SkeletonAnimation>();
        ChangeAni(ANI.IDLE );
    }


    void Update()
    {

    }


    public void ClickRunBTN()
    {
        ChangeAni(ANI.RUN);
        //이동
    }
    public void ClickRunATT()
    {       //이동을 멈춤
        ChangeAni(ANI.ATTACK );

        
        //적이 피격을 받은게 확인되고 
        //맞으면 적이 데미지를 입고
        //idle로 돌아감

        


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
                playerAni.AnimationName = "idle";
                playerAni.timeScale = 1f;
                break;

            case ANI.DIE:
                playerAni.AnimationName = "die";
                playerAni.timeScale = 1f;
                break;

            case ANI.ATTACK:
                playerAni.AnimationName = "attack";
                playerAni.timeScale = 1f;
                break;

            case ANI.RUN:
                playerAni.AnimationName = "run";
                playerAni.timeScale = 1f;
                break;

        }
    }
   
}
