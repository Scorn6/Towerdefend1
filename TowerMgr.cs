using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TowerMgr : MonoBehaviour
{
    public TowerDate Tower1;
    public TowerDate Tower2;
    public TowerDate Tower3;
    public TowerDate Tower4;
    public TowerDate Tower5;
    //表示被选择的塔类型
    private TowerDate selectedTower;
    //表示当前选择的炮台(场景中的游戏物体)
    private Gird selectedGird;
    //升级面板
    public GameObject GirdupgradeCanvas;

    public GameObject buildEffect;//建造特效

    [SerializeField] private Animator upgradeCanvasAnimator;


    //等金钱类设计完更改
    //public int money = 1000;
    Gold gold;
    //改变钱

   

    private void Start()
    {
        gold=Gold.instance;
        upgradeCanvasAnimator = upgradeCanvasAnimator.GetComponent<Animator>();
    }
    //添加面板显示动画

    //塔建设
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(1);
            if (EventSystem.current.IsPointerOverGameObject() == false)
            {
                Debug.Log(1.2);
                //开发炮台的建造,gird类：监测gird上是否有炮台和建设炮台
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                Debug.Log(1.7);
                bool isCollider = Physics.Raycast(ray, out hit, 1000, LayerMask.GetMask("Gird"));
                if (isCollider)
                {
                    Debug.Log(2);
                    Gird gird = hit.collider.gameObject.GetComponent<Gird>();//有问题，待解决
                    if (selectedTower != null && gird.tower == null)
                    {
                        Debug.Log(3);
                        //可以建造
                        if (gold.currentGold >= selectedTower.cost)
                        {
                            //改变金钱，待改动
                            gold.AddGold(-selectedTower.cost);
                            Debug.Log(4);
                            Vector3 temp = gird.Build(selectedTower);//Gird中的建设方法
                            
                            //GameObject gameObject = selectedGird.huster;
                            gird.huster.SetActive(false);
                            gird.state0.SetActive(true);
                            gird.state1.SetActive(false);
                            gird.state2.SetActive(false);
                            Quaternion sb = new Quaternion();
                            sb = Quaternion.Euler(-90f, 0f, 0f);
                            GameObject effect = GameObject.Instantiate(buildEffect, temp, sb);

                           // Destroy(effect, 1);
                            Debug.Log(7);
                            //建筑特效
                        }
                        else
                        {
                            //钱不够,播放钱不够的动画
                        }
                    }
                    else if (gird.tower != null)
                    {
                        //当Gird上已有炮台，点击生成Canvas面板，再次点击升级面板隐藏
                        if (gird == selectedGird && GirdupgradeCanvas.activeInHierarchy)
                        {
                            StartCoroutine(HideUpgradeUi());
                        }
                        else
                        {
                            //显示升级UI面板
                            selectedGird = gird;
                            ShowUpgradeUi(gird.transform.position, gird.isUpgraded, gird.isUpgradedPro);
                        }
                        selectedGird = gird;
                    }
                }
            }
        }
    }

    //监测被选择的塔类型selectedTower
    public void OnTower1Selected(bool isOn)
    {
        Debug.Log(9);
        if (isOn)
        {
            if (selectedTower == Tower1)
            {
                selectedTower = null;
            }
            else if (selectedTower != Tower1)
            {
                selectedTower = Tower1;
            }
        }
    }
    public void OnTower2Selected(bool isOn)
    {
        if (isOn)
        {
            if (selectedTower == Tower2)
            {
                selectedTower = null;
            }
            else if (selectedTower != Tower2)
            {
                selectedTower = Tower2;
            }
        }
    }
    public void OnTower3Selected(bool isOn)
    {
        if (isOn)
        {
            if (selectedTower == Tower3)
            {
                selectedTower = null;
            }
            else if (selectedTower != Tower3)
            {
                selectedTower = Tower3;
            }
        }
    }

    public void OnTower4Selected(bool isOn)
    {
        if (isOn)
        {
            if (selectedTower == Tower4)
            {
                selectedTower = null;
            }
            else if (selectedTower != Tower4)
            {
                selectedTower = Tower4;
            }
        }
    }

    public void OnTower5Selected(bool isOn)
    {
        if (isOn)
        {
            if (selectedTower == Tower5)
            {
                selectedTower = null;
            }
            else if (selectedTower != Tower5)
            {
                selectedTower = Tower5;
            }
        }
    }

    //升级和拆除
    public Button buttonUpgrade; //升级按钮
    public Button buttonjineng1;
    public Button buttonjineng2;


    //显示升级面板
    void ShowUpgradeUi(Vector3 pos, bool isUpgraded = false, bool isUpgradedPro = false)
    {
        StopCoroutine("HideUpgradeUi");
        GirdupgradeCanvas.SetActive(false);
        GirdupgradeCanvas.SetActive(true);
        GirdupgradeCanvas.transform.position = pos;
        UpgradeUIText upgradeUIText = GirdupgradeCanvas.GetComponent<UpgradeUIText>();
        if (upgradeUIText != null )
        {
            upgradeUIText.upgradeText.text=selectedGird.towerDate.costPro.ToString();
            upgradeUIText.destroyText.text = (selectedGird.towerDate.cost*0.8).ToString();
            upgradeUIText.skillOneText.text = selectedGird.gridSkillOneCost.ToString();
            upgradeUIText.skillTwoText.text = selectedGird.gridSkillTwoCost.ToString();
        }
        Debug.Log("isUpgrade,isUpgradePro的值分别为" + isUpgraded + isUpgradedPro);
        buttonUpgrade.interactable = !isUpgradedPro;
        buttonjineng1.interactable = isUpgraded;
        buttonjineng2.interactable = isUpgradedPro;
    }

    //隐藏升级面板

    //void HideUpgradeUi(){
    //selectedGird.towerDate.upgradeCanvas.SetActive(false);
    //}
    IEnumerator HideUpgradeUi()
    {
        Debug.Log(2);
        upgradeCanvasAnimator.SetTrigger("Hide");
        yield return new WaitForSeconds(0.8f);
        GirdupgradeCanvas.SetActive(false);
    }
    //升级按钮的响应事件
    public void OnUpgradeButtonDown()
    {
        //第一次升级
        if (selectedGird.isUpgraded == false && selectedGird.isUpgradedPro == false)
        {
            if (gold.currentGold >= selectedGird.towerDate.costPro)
            {
                //改变金钱
                gold.ReduceGold(selectedGird.towerDate.costPro);
                selectedGird.UpgradeTower();
                //启动技能1，待商酌
                buttonjineng1.interactable = true;

                selectedGird.huster.SetActive(false);
                selectedGird.state0.SetActive(false);
                selectedGird.state1.SetActive(true);
                selectedGird.state2.SetActive(false);//设置塔底座特效

               

                //升级特效，未完成
            }
            else
            {
                //钱不够
            }

            //StartCoroutine(HideUpgradeUi());//不知道这行是干嘛用的
        }
        //第二次升级
        else if (selectedGird.isUpgraded == true && selectedGird.isUpgradedPro == false)
        {
            if (gold.currentGold >= selectedGird.towerDate.costPro)
            {
                //改变金钱，待改动
                gold.ReduceGold(selectedGird.towerDate.costPro);
                selectedGird.UpgradeProTower();
                //启动技能2，待商酌
                buttonjineng2.interactable = true;


                selectedGird.huster.SetActive(false);
                selectedGird.state0.SetActive(false);
                selectedGird.state1.SetActive(false);
                selectedGird.state2.SetActive(true);
                //升级特效，未完成
            }
            else
            {
                //钱不够
            }

            //StartCoroutine(HideUpgradeUi());//同上
        }
    }
    //拆毁按钮的响应事件
    public void OnDestroyButtonDown()
    {
        //Debug.Log(0);
        StartCoroutine(HideUpgradeUi());
        //Debug.Log(1);
        TowerDate dateTemp = selectedGird.towerDate;
        selectedGird.DestroyTower();

        selectedGird.huster.SetActive(true);
        selectedGird.state0.SetActive(false);
        selectedGird.state1.SetActive(false);
        selectedGird.state2.SetActive(false);

        gold.currentGold += (int)(0.8 * dateTemp.cost);

        //Debug.Log(3);
        //拆毁特效，未完成
    }
    //技能1按钮的响应事件
    public void Onjineng1ButtonDown()
    {
        if (gold.currentGold >= selectedGird.gridSkillOneCost)
        {
            if (selectedGird.towerDate.type == Tower1.type)
            {
                selectedGird.Tower1jineng1();
            }
            else if (selectedGird.towerDate.type == Tower2.type)
            {
                selectedGird.Tower2jineng1();
            }
            else if (selectedGird.towerDate.type == Tower3.type)
            {
                selectedGird.Tower3jineng1();
            }
            else if (selectedGird.towerDate.type == Tower4.type)
            {
                selectedGird.Tower4jineng1();
            }
            else if (selectedGird.towerDate.type == Tower5.type)
            {
                selectedGird.Tower5jineng1();
            }
            //改变金钱，待改动
            gold.AddGold((int)-selectedGird.gridSkillOneCost);
            selectedGird.gridSkillOneCost *= 2;
            UpgradeUIText upgradeUIText = GirdupgradeCanvas.GetComponent<UpgradeUIText>();
            if (upgradeUIText != null)
            {
                upgradeUIText.skillOneText.text = selectedGird.gridSkillOneCost.ToString();
            }
            //更改技能消耗文本显示
        }
        else
        {
            //钱不够
        }

    }
    //技能2按钮的响应事件
    public void Onjineng2ButtonDown()
    {
        if (gold.currentGold >= selectedGird.gridSkillTwoCost)
        {
            if (selectedGird.towerDate.type == Tower1.type)
            {
                selectedGird.Tower1jineng2();
            }
            else if (selectedGird.towerDate.type == Tower2.type)
            {
                selectedGird.Tower2jineng2();
            }
            else if (selectedGird.towerDate.type == Tower3.type)
            {
                selectedGird.Tower3jineng2();
            }
            else if (selectedGird.towerDate.type == Tower4.type)
            {
                selectedGird.Tower4jineng1();
            }
            else if (selectedGird.towerDate.type == Tower5.type)
            {
                selectedGird.Tower5jineng1();
            }
            //改变金钱，待改动
            gold.AddGold((int)-selectedGird.gridSkillTwoCost);
            selectedGird.gridSkillTwoCost *= 2;
            UpgradeUIText upgradeUIText = GirdupgradeCanvas.GetComponent<UpgradeUIText>();
            if (upgradeUIText != null)
            {
                upgradeUIText.skillTwoText.text = selectedGird.gridSkillTwoCost.ToString();
            }
            //更改技能消耗文本显示
        }
        else
        {
            //钱不够
        }
    }
}
