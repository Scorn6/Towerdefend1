using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuList : MonoBehaviour
{
    public GameObject menuList;//�˵��б�
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
                Time.timeScale = 0;//ʱ����ͣ
                bgmSound.Pause();
            }
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            menuList.SetActive(false);
            menuKeys = true;
            Time.timeScale = 1;//ʱ��ָ�����
            bgmSound.Play();
        }
    }
    public void Return()//������Ϸ
    {
        menuList.SetActive(false);
        menuKeys = true;
        Time.timeScale = 1;//ʱ��ָ�����
        bgmSound.Play();

    }
    public void Restart()//���¿�ʼ
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }
    public void Exit()//�˳���Ϸ
    {
        Application.Quit();
    }
    public void Pause()
    {
        menuList.SetActive(true);
        menuKeys = false;
        Time.timeScale = 0;//ʱ����ͣ
        bgmSound.Pause();
    }
}
