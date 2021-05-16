using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Dialogue : MonoBehaviour
{

    public Text mylog;
    public Button[] buttons;//버튼
    public string[] logs;//대답내용

    

    
    void Start()
    {
        SetLog();
    }

    //대사가 선택되고나면 버튼클릭이 막힌다
    //선택한 대사는 저장이된다
    //대사내용이 바뀐다
    //데이터 테이블 구조
    //대사가 전부 고갈되면 씬이 바뀐다

    void Update()
    {

    }


    public void SetLog()
    {
        logs = new string[4] { "a", "b", "c", "d" };
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].GetComponentInChildren<Text>().text = logs[i];
        }

    }
 

    public void ClickLog(int n)
    {
        Debug.Log(logs[n]);


    }


}

