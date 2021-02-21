using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //1.적 체크 
    //1-1. 적이라는 것을 찾자
    //1-2. 어떻게 찾나
    //1-3. 사거리
    //1-4. 사거리 안에 들어왔는가
    //1-5. 들어오면 >2번으로 가시오
    //1-6. 안들어왔으면 대기 (반복)
    //2.적 공격
    private Enemy target;
    public float range = 1f;
    Collider[] colliders = new Collider[1];

    //공격시간
    public float attackTime = 0;
    public float attackDelay = 0.2f;

    public float attackPower = 10f;
    public List<Bullet> bullets = new List<Bullet>();
    public GameObject bulletPrefab;

    public float hp = 100f;
    public float hpMax = 100f;
    public bool die = false;

    void Start()
    {
        
    }

    void Update()
    {
        if (GameManager.Instance.isFail == false)
        {
            FindEnemy();
            CheckTargetDistance();
            Attack();
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);

        if (target)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(target.transform.position, range);
        }
    }
   
    private void FindEnemy()
    {
        if (target)
        {
            return;
        }

        //layerMask로 해당 Enemy라는 레이어를 찾음
        int layerMask = 1 << LayerMask.NameToLayer("Enemy");
        //range만큼의 radius/ collider에 위 layerMask한 것을 Physics물리계산
        Physics.OverlapSphereNonAlloc(transform.position, range, colliders, layerMask);
        if (colliders[0])
        {
            Enemy e = colliders[0].gameObject.GetComponent<Enemy>();
            if (e)
            {
                float distance = Vector3.Distance(transform.position, e.transform.position);

                if (distance < range)
                {
                    target = e;
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

    //Todo: 공격시에 공격방식을 근접과 원거리로 분리하여 작업이 필요함
    private void Fire()
    {
        if (target == null)
        {
            return;
        }
        
        GameObject bulletObj = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        Bullet bullet = bulletObj.GetComponent<Bullet>();
        bullets.Add(bullet); //나중에 총알들을 일괄처리해야 할수 있음으로 미리 list로 관리
        bullet.Init(this ,target, attackPower);
    }

    private void Attack()
    {
        //공격시간은 프레임 단위로 시간은 흐르게 만듬
        attackTime += Time.deltaTime;

        //공격타이밍 체크: 공격시간이 공격딜레이 준것보다 크거나 같으면
        if (attackTime >= attackDelay)
        {
            //공격
            Fire();
            //공격 시간은 다시 카운트할수 있도록 0으로 만들어줌
            attackTime = 0;
        }
    }
    
    //Todo: 총알 관리하는 메소드
    public void CleanBullet(Bullet bullet)
    {
       // bullets.Remove(bullet);
        Destroy(bullet.gameObject);
    }

    public void Hit(float damage)
    {
        if (die == true)
        {
            return;
        }

        hp -= damage;
        Ui.Instance.UpdateHpbar(hp, hpMax);

        if (hp <= 0)
        {
            die = true;
            GameManager.Instance.Fail();
        }
    }
}
