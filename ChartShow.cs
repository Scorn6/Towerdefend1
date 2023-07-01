using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChartShow : MonoBehaviour
{
    public GameObject[] panels; // 存储所有图鉴面板的数组
    private GameObject previousPanel; // 存储前一个图鉴面板的变量

    private void Start()
    {
        previousPanel = panels[0]; // 初始情况下，将第一个图鉴面板赋值给previousPanel变量
    }

    public void ShowPanel(int panelIndex)
    {
        // 隐藏前一个图鉴面板
        previousPanel.SetActive(false);

        // 显示当前选择的图鉴面板
        panels[panelIndex].SetActive(true);

        // 更新前一个图鉴面板为当前选择的图鉴面板
        previousPanel = panels[panelIndex];
    }
}

