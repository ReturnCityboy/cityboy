﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using UnityEngine.UI;

public class PlayerAni : MonoBehaviour
{

    private static PlayerAni _instance;
    public static PlayerAni Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new PlayerAni();
            }
            return _instance;
        }
    }
    private void Awake()
    {
        _instance = this;
    }

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

            case ANI.JUMP:
                playerAni.AnimationName = "jump";
                playerAni.timeScale = 1f;
                break;

            case ANI.JUMPATTACK:
                playerAni.AnimationName = "jumpattack";
                playerAni.timeScale = 1f;
                break;

            case ANI.DAMAGE:
                playerAni.AnimationName = "damage";
                playerAni.timeScale = 1f;
                break;

            case ANI.DOWN:
                playerAni.AnimationName = "down";
                playerAni.timeScale = 1f;
                break;

            case ANI.SPECIAL:
                playerAni.AnimationName = "special";
                playerAni.timeScale = 1f;
                break;

            case ANI.WALK:
                playerAni.AnimationName = "walk";
                playerAni.timeScale = 1f;
                break;


        }
    }

}
