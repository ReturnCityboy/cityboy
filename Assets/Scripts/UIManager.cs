using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Button button;
    public Toggle toggle;

    public Button buttonA;
    public Button buttonB;
    public Toggle toggle_;

    public Button buttonP;
    public Text text;

    public int num = 5;
    public int num_ = 0;

    public Text text_;
    public Button buttonD;

    public string a = "시러";
    public string b = "오";
    public string c = "그만할까";

    public int logCount = 0;

    void Start()
    {
        num = 5;
        //num_ = 0;
        logCount = 0;
    }

    void Update()
    {
        for (int n = 0; num_ <= num; n++)
        {
            num_ = n;
            Debug.Log("넘_:" + num_);
        }
    }

    public void PauseButton()
    {
        Debug.Log("클릭");
        //만약 토글의 isOn이 참이면 버튼의 기능을 일시정지하고
        //참이 아니라면 버튼의 기능을 활성화 시켜라
        if (toggle.isOn == true)
        {
            button.interactable = false;
        }
        else
        {
            button.interactable = true;
            Debug.Log("버튼 비활성화");
        }
    }

    public void ClickA()
    {
        toggle_.isOn = false;
    }
    public void ClickB()
    {
        toggle_.isOn = true;
    }

    public void IncreaseNumber()
    {
        num++;
    }

    public void SetText()
    {
        if (logCount == 0)
        {
            text.text = a;
            logCount++;
        }
        else if (logCount == 1)
        {
            text.text = b;
            logCount++;
        }
        else
        {
            text.text = c;
            logCount = 0;
        }
    }
}
