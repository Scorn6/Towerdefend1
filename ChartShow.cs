using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChartShow : MonoBehaviour
{
    public GameObject[] panels; // �洢����ͼ����������
    private GameObject previousPanel; // �洢ǰһ��ͼ�����ı���

    private void Start()
    {
        previousPanel = panels[0]; // ��ʼ����£�����һ��ͼ����帳ֵ��previousPanel����
    }

    public void ShowPanel(int panelIndex)
    {
        // ����ǰһ��ͼ�����
        previousPanel.SetActive(false);

        // ��ʾ��ǰѡ���ͼ�����
        panels[panelIndex].SetActive(true);

        // ����ǰһ��ͼ�����Ϊ��ǰѡ���ͼ�����
        previousPanel = panels[panelIndex];
    }
}

