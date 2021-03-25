using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Home : MonoBehaviour
{
    public GameObject characterPopup;
    void Start()
    {
        characterPopup.SetActive(false);
    }

    
    void Update()
    {
        
    }

    public void ClickPlayButton()
    {
        //저장할 데이터를 저장(game Manager가 처리)
        //홈 씬 이동
        SceneManager.LoadScene("InGame");
        //깃테스트
    }
    public void ClickStartButton()
    {
    
            characterPopup.SetActive(true);
   
       
    }
}


