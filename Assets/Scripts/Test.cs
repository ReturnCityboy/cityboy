using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    public Button button;
    public int length = 10;
    public int a = 1;
  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Click()
    {
        for (int i = 0; i < length; i++)
        {
            
            a += 1;
            Debug.Log(a);
        }
        
    }

}
