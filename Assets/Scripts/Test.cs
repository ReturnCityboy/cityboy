using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    /*public Button button;
    public int length = 10;
    public int a = 1;*/

    public Button button;//버튼사용하겠다
    public string[] logs;//로그라는 이름의 배열을 사용하겠다


    private void Awake()
    {
        logs = new string [4] { "안녕", "뭐해", "어디가", "잘가" };
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /* public void Click()
     {
         for (int i = 0; i < length; i++)
         {

             a += 1;
             Debug.Log(a);
         }

     }*/

    

    public void LogsButton()
    {


        for (int i = 0; i < logs.Length; i++)
        {
            Debug.Log(logs[i]);
        }
    }
    


}
