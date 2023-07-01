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


    //在Gird上建筑防御塔
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


    //升级按钮

    //升级1
    public void UpgradeTower()
    {
        isUpgraded = true;
        isUpgradedPro = false;

    }
    //升级2
    public void UpgradeProTower()
    {
        isUpgraded = true;
        isUpgradedPro = true;

    }
    //拆除Gird上的防御塔
    public void DestroyTower()
    {
        Destroy(tower);
        isUpgraded = false;
        tower = null;
        towerDate = null;
    }


    //防御塔的技能
    public void Tower1jineng1()    //提升子弹伤害基数
    {
        tower.GetComponent<Tower>().preSetDamege(tower.GetComponent<Tower>().damageToSet + 65f);
    }
    public void Tower1jineng2()    //提高子弹伤害百分比
    {
        tower.GetComponent<Tower>().preSetDamege(tower.GetComponent<Tower>().damageToSet * 1.1f);
    }
    public void Tower2jineng1()    //提升攻速，有待调试完善
    {
        Tower t = tower.GetComponent<Tower>();
        t.setAttackspeed(tower.GetComponent<Tower>().attackRateTime - t.speedUp);
        t.speedLimit();
    }
    public void Tower2jineng2()    //提升子弹伤害基数
    {
        tower.GetComponent<Tower>().preSetDamege(tower.GetComponent<Tower>().damageToSet + 1f);
    }
    public void Tower3jineng1()    //增加攻击范围
    {
        tower.GetComponent<Tower>().GetComponent<CircleCollider2D>().radius *= 1.5f;
    }

    public void Tower3jineng2()  //增加子弹伤害基数
    {
        tower.GetComponent<Tower>().preSetDamege(tower.GetComponent<Tower>().damageToSet + 30f);
    }
    public void Tower4jineng1()//每5发一发核弹
    {
        tower.GetComponent<Tower>().countSwitch = true;
        tower.GetComponent<Tower>().count = 6;
    }
    public void Tower4jineng2()//增加攻击范围
    {
        tower.GetComponent<Tower>().GetComponent<CircleCollider2D>().radius *= 1.5f;
    }
    public void Tower5jineng1()    //下次伤害对同个敌人造成a倍伤害，升级此技能从a变为a+0.1倍
    {
        tower.GetComponent<Tower>().en = true;
        Debug.Log("en==true");
        tower.GetComponent<Tower>().a = tower.GetComponent<Tower>().a + 0.1f;
    }
    public void Tower5jineng2() //增加子弹发射速度
    {
        tower.GetComponent<Tower>().GetComponent<Tower>().preSetSpeed(tower.GetComponent<Tower>().speedToSet * 2.1f);
    }


    /* public float damage_;
     public void Tower3jineng2()    //下次伤害对同个敌人造成1.8倍伤害
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
