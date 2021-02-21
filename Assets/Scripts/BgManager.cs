using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgManager : MonoBehaviour
{
    private static BgManager _instance;
    public static BgManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new BgManager();
            }
            return _instance;
        }
    }

    public GameObject[] nodes; //어디로 갈지 위치값

    private void Awake()
    {
        _instance = this;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

}
