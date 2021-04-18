using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrossButton : MonoBehaviour
{
    [Header("방향키")]
    public Button[] buttons;//0;up 1;down 3;right 4;left

    void Start()
    {
        
    }
    
    void Update()
    {
        
    }

    public void ClickButton(int num)
    {
        if (true)
        {

        }
        switch (num)
        {
            case 0:
                //위로 올라가고 점프모션
                Debug.Log("위로");
                break;
            case 1:
                Debug.Log("아래로");
                //아래로 내려가고 점프모션
                break;
            case 2:
                Debug.Log("우로");
                //오른쪽으로가고 점프모션
                break;
            case 3:
                Debug.Log("좌로");
                //왼쪽으로가고 점프모션
                break;
        }

    }

}
