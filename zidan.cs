using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class zidan : MonoBehaviour
{

    public float damage = 50f;   //子弹的伤害
    public float speed = 50f;    //子弹的速度
    public Transform target;    //子弹的目标（即敌人）的位置
    public GameObject explosionEffectPrefab;    //子弹销毁钱的特效
    private float distanceArriveTarget = 1f;    //当子弹与敌人的距离小于distanceArriveTarget时，认为子弹打到敌人

    //以下变量与Tower3jineng2有关

    public float damage_ = 50f; //子弹原始伤害，用于复原

    private float rotationSpeed = 50f;



    //设置子弹damage
    public void setDamage(float damage)
    {
        this.damage = damage;
        // Debug.Log("damage=" + damage);
    }
    //设置子弹speed
    public void setSpeed(float speed)
    {
        this.speed = speed;
    }


    //设置子弹攻击目标（敌人）
    public void SetTarget(Transform _target)
    {
        target = _target;
    }



    private void Update()
    {

        if (target == null)
        {
            die();
            return;
        }
        //使子弹移向敌人
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        //使子弹指向敌人攻击,试用
        Vector3 dir_ = target.position - transform.position;
        float angle = Vector3.SignedAngle(Vector3.right, dir_, Vector3.forward);
        transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, new Vector3(0, 0, angle), rotationSpeed * Time.deltaTime);

        /* transform.LookAt(target.position);
         transform.Translate(Vector3.forward*speed*Time.deltaTime);*/

        Vector3 dir = target.position - transform.position;

        if (dir.magnitude < distanceArriveTarget)
        {
            enemy e = target.GetComponent<enemy>();//敌人减血,未完成
            if (e != null)
            {
                enemyHealth h = e.GetComponent<enemyHealth>();
                if (h != null && !h.isDead)
                {
                    h.DealDamage(damage);
                }
            }
            die();
        }
        void die()
        {
            Quaternion sb = new Quaternion();
            sb = Quaternion.Euler(-90f, 0f, 0f);
            GameObject effect = GameObject.Instantiate(explosionEffectPrefab, transform.position, sb);//爆炸特效
            Destroy(effect, 0.1f);//销毁特效
            Destroy(this.gameObject);//坠毁子弹
        }
    }

}

