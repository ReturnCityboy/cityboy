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
    public Text mylog;

    //public Text text;
    //public Button[] buttons;
    //public string[] logs;//로그라는 이름의 배열을 사용하겠다
    List<string> logs = new List<string>();

    private void Awake()
    {
        // logs = new string [4] { "안녕", "뭐해", "어디가", "잘가" };
        
        logs.Add("안녕");
        logs.Add("뭐해");
        logs.Add("어디가");
        logs.Add("잘가");

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


        for (int i = 0; i < logs.Count; i++)
        {
            Debug.Log(logs[i]);
            mylog.text = logs[i];
            //text.text=string
        }
    }

    public void PrintText()
    {
       // text.text = string(logs[i]);
    }

    /*public void ButtonAction(int i)
    {
        if (true)
        {
           
        }
        switch (i)
        {
            case 0:
                text.text = "u";
                break;
            case 1:
                text.text = "l";
                break;
            case 2:
                text.text = "r";
                break;
            case 3:
                text.text = "d";
                break;
        }*/
    }

   

    


