using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class Gird : MonoBehaviour
{
    [HideInInspector]
    public GameObject tower;
    [HideInInspector]
    public TowerDate towerDate;
    public float gridSkillOneCost;
    public float gridSkillTwoCost;
    [HideInInspector]
    public bool isUpgraded = false;
    [HideInInspector]
    public bool isUpgradedPro = false;

    public GameObject huster;
    public GameObject state0;
    public GameObject state1;
    public GameObject state2;


    //��Gird�Ͻ���������
    public Vector3 Build(TowerDate TowerDate)
    {
        Debug.Log(5);
        this.towerDate = TowerDate;
        gridSkillOneCost = TowerDate.costjineng1;
        gridSkillTwoCost = TowerDate.costjineng2;
        isUpgraded = false;
        isUpgradedPro = false;
        tower = GameObject.Instantiate(TowerDate.TowerPrefab, transform.position, Quaternion.identity);
        Debug.Log(6);
        return (transform.position);
    }


    //������ť

    //����1
    public void UpgradeTower()
    {
        isUpgraded = true;
        isUpgradedPro = false;

    }
    //����2
    public void UpgradeProTower()
    {
        isUpgraded = true;
        isUpgradedPro = true;

    }
    //���Gird�ϵķ�����
    public void DestroyTower()
    {
        Destroy(tower);
        isUpgraded = false;
        tower = null;
        towerDate = null;
    }


    //�������ļ���
    public void Tower1jineng1()    //�����ӵ��˺�����
    {
        tower.GetComponent<Tower>().preSetDamege(tower.GetComponent<Tower>().damageToSet + 65f);
    }
    public void Tower1jineng2()    //����ӵ��˺��ٷֱ�
    {
        tower.GetComponent<Tower>().preSetDamege(tower.GetComponent<Tower>().damageToSet * 1.1f);
    }
    public void Tower2jineng1()    //�������٣��д���������
    {
        Tower t = tower.GetComponent<Tower>();
        t.setAttackspeed(tower.GetComponent<Tower>().attackRateTime - t.speedUp);
        t.speedLimit();
    }
    public void Tower2jineng2()    //�����ӵ��˺�����
    {
        tower.GetComponent<Tower>().preSetDamege(tower.GetComponent<Tower>().damageToSet + 1f);
    }
    public void Tower3jineng1()    //���ӹ�����Χ
    {
        tower.GetComponent<Tower>().GetComponent<CircleCollider2D>().radius *= 1.5f;
    }

    public void Tower3jineng2()  //�����ӵ��˺�����
    {
        tower.GetComponent<Tower>().preSetDamege(tower.GetComponent<Tower>().damageToSet + 30f);
    }
    public void Tower4jineng1()//ÿ5��һ���˵�
    {
        tower.GetComponent<Tower>().countSwitch = true;
        tower.GetComponent<Tower>().count = 6;
    }
    public void Tower4jineng2()//���ӹ�����Χ
    {
        tower.GetComponent<Tower>().GetComponent<CircleCollider2D>().radius *= 1.5f;
    }
    public void Tower5jineng1()    //�´��˺���ͬ���������a���˺��������˼��ܴ�a��Ϊa+0.1��
    {
        tower.GetComponent<Tower>().en = true;
        Debug.Log("en==true");
        tower.GetComponent<Tower>().a = tower.GetComponent<Tower>().a + 0.1f;
    }
    public void Tower5jineng2() //�����ӵ������ٶ�
    {
        tower.GetComponent<Tower>().GetComponent<Tower>().preSetSpeed(tower.GetComponent<Tower>().speedToSet * 2.1f);
    }


    /* public float damage_;
     public void Tower3jineng2()    //�´��˺���ͬ���������1.8���˺�
     {
         if(tower.GetComponent<Tower>().zidang.GetComponent<zidan>().target!=null)
         {
             damage_ = tower.GetComponent<Tower>().zidang.GetComponent<zidan>().damage;
             tower.GetComponent<Tower>().zidang.GetComponent<zidan>().setDamage(tower.GetComponent<Tower>().zidang.GetComponent<zidan>().damage*1.8f);
         }
         else if(tower.GetComponent<Tower>().zidang.GetComponent<zidan>().target = null)
         {
             tower.GetComponent<Tower>().zidang.GetComponent<zidan>().setDamage(damage_);
         }
     }*/
}
