using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuList : MonoBehaviour
{
    public GameObject menuList;//菜单列表
    [SerializeField] private bool menuKeys = true;
    [SerializeField] private AudioSource bgmSound;
    void Start()
    {
        
    }

    
    void Update()
    {
        if (menuKeys)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                menuList.SetActive(true);
                menuKeys = false;
                Time.timeScale = 0;//时间暂停
                bgmSound.Pause();
            }
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            menuList.SetActive(false);
            menuKeys = true;
            Time.timeScale = 1;//时间恢复正常
            bgmSound.Play();
        }
    }
    public void Return()//返回游戏
    {
        menuList.SetActive(false);
        menuKeys = true;
        Time.timeScale = 1;//时间恢复正常
        bgmSound.Play();

    }
    public void Restart()//重新开始
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }
    public void Exit()//退出游戏
    {
        Application.Quit();
    }
    public void Pause()
    {
        menuList.SetActive(true);
        menuKeys = false;
        Time.timeScale = 0;//时间暂停
        bgmSound.Pause();
    }
}
