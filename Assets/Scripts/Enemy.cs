using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public Player player;//player
    public float range = 10f;//range
    public int hp = 100;//enemy hp
    public int power = 100;//enemy power
    public float speed = 10f;//enemy speed
    public bool playerDir = true;//player 방향
    public float attackrange = 5f;//attackrange 
    public bool isPlayer = true;//플레이어 생사 여부
    public enum CurrentState { idle, move, attack, dead };//적 애니상태

   void Start()
    {
        
    }

    void Update()
    {
        
    }

    
}
