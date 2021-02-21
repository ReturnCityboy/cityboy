using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Home : MonoBehaviour
{
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void ClickPlayButton()
    {
        //저장할 데이터를 저장(game Manager가 처리)
        //홈 씬 이동
        SceneManager.LoadScene("InGame");
    }
}


