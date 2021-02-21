using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 30f;
    private Vector3 direction;
    private Player owner;
    private Enemy target;
    private float attackPower;

    public void Init(Player owner, Enemy target, float attackPower)
    {
        this.owner = owner;
        this.target = target;
        this.attackPower = attackPower;
    }

    void Update()
    {
        if (target)
        {
            float errorRange = 0.1f;
            Vector3 end = target.transform.position;
            direction = end - transform.position;
            transform.position += (direction.normalized * speed * Time.deltaTime);

            direction = end - transform.position;
            float distance = direction.magnitude;

            if (distance <= errorRange)
            {
                //적은 데미지
                target.Hit(attackPower);
                Destroy(gameObject);
                //총알 없어짐
               // owner.CleanBullet(this);
            }
        }
    }
}
