using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveUpdate : MonoBehaviour
{
   
    public Text waveText;
    [SerializeField]private levelmanager levelmanager;

    void Update()
    {
        if(levelmanager.CurrentWave > levelmanager.MaxWave)
        {
            waveText.text = levelmanager.MaxWave.ToString() + "/" + levelmanager.MaxWave.ToString();
        }
        else
        {
            waveText.text = levelmanager.CurrentWave.ToString() + "/" + levelmanager.MaxWave.ToString();
        }
       
    }
   
}