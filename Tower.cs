using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Tower : MonoBehaviour
{
    //监测进入防御塔攻击范围的敌人
    public List<GameObject> enemys = new List<GameObject>();
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            enemys.Add(other.gameObject);
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            enemys.Remove(other.gameObject);
        }
    }

    void Awake()
    {
        damageToSet = zidang.GetComponent<zidan>().damage;
        speedToSet = zidang.GetComponent<zidan>().speed;
    }
    public float attackRateTime = 1; //多少秒攻击一次
    private float timer = 0;

    public GameObject zidang;       //发射子弹的Prefab
    public Transform Firepoint;     //发射子弹的位置
    public float damageToSet = 0f;
    public float speedToSet = 0f;
    public float speedUp = 0.11f;

    public int count = 0;
    public bool countSwitch = false;

    public bool en = false; //Towerjineng2的开关
    public float a = 1.8f;          //子弹伤害倍增值

    //设置攻速（防御塔发射子弹的速率）
    public void setAttackspeed(float attackRateTime)
    {
        this.attackRateTime = attackRateTime;
    }

    public void preSetDamege(float damage)
    {
        damageToSet = damage;
    }
    public void preSetSpeed(float speed)
    {
        speedToSet = speed;
    }
    private void Start()
    {
        timer = attackRateTime;
    }
    public void speedLimit()
    {
        speedUp /= 1.5f;
    }
    private void Update()
    {
        timer += Time.deltaTime;
        if (enemys.Count > 0 && timer >= attackRateTime)
        {
            timer = 0;
            Attack();
        }
    }


    //攻击，向敌人发射子弹
    void Attack()
    {
        if (enemys.Count == 0) { return; }
        enemy e = enemys[0].GetComponent<enemy>();
        if (e == null) { return; }
        if (e.EnemyHealth.isDead)
        {
            UpdateEnemys();
        }
        GameObject zidan = GameObject.Instantiate(zidang, Firepoint.position, Firepoint.rotation);
        zidan.GetComponent<zidan>().setDamage(damageToSet);

        if (countSwitch == true)
        {
            count++;

            if (count % 5 == 1)
            {
                zidan.GetComponent<zidan>().setDamage(damageToSet * 5);
                Debug.Log("我已翻倍");
            }
            else
            {
                zidan.GetComponent<zidan>().setDamage(damageToSet);
            }
        }
        zidan.GetComponent<zidan>().setSpeed(speedToSet);
        if (enemys.Count == 0)
        {
            Debug.Log("count = 0");
            return;
        }
        if (enemys.Count == 0 || enemys[0] == null) { return; }
        zidan z = zidan.GetComponent<zidan>();
        if (z == null)
        {
            Debug.Log("zidan is null");
            return;
        }
        if (z != null)
        {

            z.SetTarget(enemys[0].transform);
        }
        if (en == true)
        {
            Debug.Log("我已进入");
            if (zidan.GetComponent<zidan>().target != null)
            {
                damageToSet *= a;
                zidan.GetComponent<zidan>().setDamage(damageToSet);
                Debug.Log("demege=" + zidan.GetComponent<zidan>().damage);
            }
            else if (zidan.GetComponent<zidan>().target = null)
            {
                damageToSet = 105f;
                zidan.GetComponent<zidan>().setDamage(damageToSet);
            }
        }
        void UpdateEnemys()
        {
            //enemys.RemoveAll(i=>i==null);不知道这个方法行不行，暂且用下面的
            List<int> enemyIndex = new List<int>();
            for (int index = 0; index < enemys.Count; index++)
            {
                enemy temp = enemys[index].GetComponent<enemy>();
                if (temp.EnemyHealth.isDead)
                {
                    enemyIndex.Add(index);
                }
            }
            for (int i = 0; i < enemyIndex.Count; i++)
            {
                enemys.RemoveAt(enemyIndex[i] - i);
            }
        }


        //Towerjineng2


    }



}
