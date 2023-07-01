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
    //��ʾ��ѡ���������
    private TowerDate selectedTower;
    //��ʾ��ǰѡ�����̨(�����е���Ϸ����)
    private Gird selectedGird;
    //�������
    public GameObject GirdupgradeCanvas;

    public GameObject buildEffect;//������Ч

    [SerializeField] private Animator upgradeCanvasAnimator;


    //�Ƚ�Ǯ����������
    //public int money = 1000;
    Gold gold;
    //�ı�Ǯ

   

    private void Start()
    {
        gold=Gold.instance;
        upgradeCanvasAnimator = upgradeCanvasAnimator.GetComponent<Animator>();
    }
    //��������ʾ����

    //������
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(1);
            if (EventSystem.current.IsPointerOverGameObject() == false)
            {
                Debug.Log(1.2);
                //������̨�Ľ���,gird�ࣺ���gird���Ƿ�����̨�ͽ�����̨
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                Debug.Log(1.7);
                bool isCollider = Physics.Raycast(ray, out hit, 1000, LayerMask.GetMask("Gird"));
                if (isCollider)
                {
                    Debug.Log(2);
                    Gird gird = hit.collider.gameObject.GetComponent<Gird>();//�����⣬�����
                    if (selectedTower != null && gird.tower == null)
                    {
                        Debug.Log(3);
                        //���Խ���
                        if (gold.currentGold >= selectedTower.cost)
                        {
                            //�ı��Ǯ�����Ķ�
                            gold.AddGold(-selectedTower.cost);
                            Debug.Log(4);
                            Vector3 temp = gird.Build(selectedTower);//Gird�еĽ��跽��
                            
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
                            //������Ч
                        }
                        else
                        {
                            //Ǯ����,����Ǯ�����Ķ���
                        }
                    }
                    else if (gird.tower != null)
                    {
                        //��Gird��������̨���������Canvas��壬�ٴε�������������
                        if (gird == selectedGird && GirdupgradeCanvas.activeInHierarchy)
                        {
                            StartCoroutine(HideUpgradeUi());
                        }
                        else
                        {
                            //��ʾ����UI���
                            selectedGird = gird;
                            ShowUpgradeUi(gird.transform.position, gird.isUpgraded, gird.isUpgradedPro);
                        }
                        selectedGird = gird;
                    }
                }
            }
        }
    }

    //��ⱻѡ���������selectedTower
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

    //�����Ͳ��
    public Button buttonUpgrade; //������ť
    public Button buttonjineng1;
    public Button buttonjineng2;


    //��ʾ�������
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
        Debug.Log("isUpgrade,isUpgradePro��ֵ�ֱ�Ϊ" + isUpgraded + isUpgradedPro);
        buttonUpgrade.interactable = !isUpgradedPro;
        buttonjineng1.interactable = isUpgraded;
        buttonjineng2.interactable = isUpgradedPro;
    }

    //�����������

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
    //������ť����Ӧ�¼�
    public void OnUpgradeButtonDown()
    {
        //��һ������
        if (selectedGird.isUpgraded == false && selectedGird.isUpgradedPro == false)
        {
            if (gold.currentGold >= selectedGird.towerDate.costPro)
            {
                //�ı��Ǯ
                gold.ReduceGold(selectedGird.towerDate.costPro);
                selectedGird.UpgradeTower();
                //��������1��������
                buttonjineng1.interactable = true;

                selectedGird.huster.SetActive(false);
                selectedGird.state0.SetActive(false);
                selectedGird.state1.SetActive(true);
                selectedGird.state2.SetActive(false);//������������Ч

               

                //������Ч��δ���
            }
            else
            {
                //Ǯ����
            }

            //StartCoroutine(HideUpgradeUi());//��֪�������Ǹ����õ�
        }
        //�ڶ�������
        else if (selectedGird.isUpgraded == true && selectedGird.isUpgradedPro == false)
        {
            if (gold.currentGold >= selectedGird.towerDate.costPro)
            {
                //�ı��Ǯ�����Ķ�
                gold.ReduceGold(selectedGird.towerDate.costPro);
                selectedGird.UpgradeProTower();
                //��������2��������
                buttonjineng2.interactable = true;


                selectedGird.huster.SetActive(false);
                selectedGird.state0.SetActive(false);
                selectedGird.state1.SetActive(false);
                selectedGird.state2.SetActive(true);
                //������Ч��δ���
            }
            else
            {
                //Ǯ����
            }

            //StartCoroutine(HideUpgradeUi());//ͬ��
        }
    }
    //��ٰ�ť����Ӧ�¼�
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
        //�����Ч��δ���
    }
    //����1��ť����Ӧ�¼�
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
            //�ı��Ǯ�����Ķ�
            gold.AddGold((int)-selectedGird.gridSkillOneCost);
            selectedGird.gridSkillOneCost *= 2;
            UpgradeUIText upgradeUIText = GirdupgradeCanvas.GetComponent<UpgradeUIText>();
            if (upgradeUIText != null)
            {
                upgradeUIText.skillOneText.text = selectedGird.gridSkillOneCost.ToString();
            }
            //���ļ��������ı���ʾ
        }
        else
        {
            //Ǯ����
        }

    }
    //����2��ť����Ӧ�¼�
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
            //�ı��Ǯ�����Ķ�
            gold.AddGold((int)-selectedGird.gridSkillTwoCost);
            selectedGird.gridSkillTwoCost *= 2;
            UpgradeUIText upgradeUIText = GirdupgradeCanvas.GetComponent<UpgradeUIText>();
            if (upgradeUIText != null)
            {
                upgradeUIText.skillTwoText.text = selectedGird.gridSkillTwoCost.ToString();
            }
            //���ļ��������ı���ʾ
        }
        else
        {
            //Ǯ����
        }
    }
}
