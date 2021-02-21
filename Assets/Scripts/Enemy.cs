using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    //죽음체크용
    public float hp = 100; //변화하는 값 = 죽음 체크 기준
    public float hpMax = 100; // 설정 값
    
    //적 이동
    public float speed = 0.1f; //움직이는 속도
    public float range = 10f;
    Collider[] colliders = new Collider[1];

    private int nodeIndex; //몇번 노드인지
    private Vector3 direction; //현재 위치

    public Slider hpSlider;
    private bool die;

    //플레이어 보면 이동하기 위한 변수선언
    private Player target;
    private float power = 10f;

    void Start()
    {
        hpSlider.gameObject.SetActive(true);
        hp = 100;
        if (die == true)
        {
            return;
        }
    }

    void Update()
    {
        if (GameManager.Instance.isFail == false)
        {
            FindPlayer();
            CheckTargetDistance();

            if (target)
            {
                MoveToTarget();
            }
            else
            {
                Move();
            }
        }
        else
        {
            hpSlider.gameObject.SetActive(false);
        }
    }

    private void FindPlayer()
    {
        if (target)
        {
            return;
        }
        //layerMask로 해당 Enemy라는 레이어를 찾음
        int layerMask = 1 << LayerMask.NameToLayer("Player");
        //range만큼의 radius/ collider에 위 layerMask한 것을 Physics물리계산
        Physics.OverlapSphereNonAlloc(transform.position, range, colliders, layerMask);
        if (colliders[0])
        {
            Player p = colliders[0].gameObject.GetComponent<Player>();
            if (p)
            {
                float distance = Vector3.Distance(transform.position, p.transform.position);

                if (distance < range)
                {
                    target = p;
                }
            }
        }
    }
    private void CheckTargetDistance()
    {
        if (target == null)
        {
            return;
        }
        float distance = Vector3.Distance(transform.position, target.transform.position);

        if (distance > range)
        {
            target = null;
        }
    }
    public void MoveToTarget()
    {
        if (target == null)
        {
            return;
        }

        float errorRange = 0.1f;
        Vector3 end = target.transform.position;
        direction = end - transform.position;
        transform.position += (direction.normalized * speed * Time.deltaTime);

        direction = end - transform.position;
        float distance = direction.magnitude;
        if (distance <= errorRange)
        {
            //Todo: 근접시 바로 player의 hp를 달게 하는 것이 아니라 공격 ai작업 필
            target.Hit(power);
        }

    }

    //public void MoveToTarget()
    //{
    //    target = GameObject.Find("Player").transform;
    //    direction = (target.position - transform.position).normalized;
    //    accelaration = 0.001f;
    //    velocity = (velocity + accelaration * Time.deltaTime);
    //    float distance = Vector3.Distance(target.position, transform.position);
    //    if (distance <= 10.0f)
    //    {
    //        this.transform.position = new Vector3(transform.position.x + (direction.x * velocity), transform.position.y + (direction.y * velocity), transform.position.z);
    //    }
    //    else
    //    {
    //        velocity = 0.0f;
    //    }
    //}

    public void Move()
    {
        if (nodeIndex < 9)
        {
            float errorRange = 0.3f; //오차범위
            Vector3 end = BgManager.Instance.nodes[nodeIndex].transform.position; //이동 목적지
            direction = end - transform.position; //이동 거리

            transform.position += (direction.normalized * speed * Time.deltaTime);

            direction = end - transform.position;
            float distance = direction.magnitude;

            if (distance <= errorRange)
            {
                nodeIndex++;
            }
        }
    }

    public void Hit(float damage)
    {
        if (die == true)
        {
            return;
        }
       
        hp -= damage;
        UpdateHpbar();

        if (hp <= 0)
        {
            die = true;
            Die();
        }
    }

    public void UpdateHpbar()
    {
        hpSlider.value = hp / hpMax;
    }

    private void Die()
    {
        if (die)
        {
            Destroy(gameObject);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, range);

        if (target)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(target.transform.position, range);
        }
    }
}
