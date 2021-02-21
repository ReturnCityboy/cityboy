using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Ui : MonoBehaviour
{
    private static Ui _instance;
    public static Ui Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new Ui();
            }
            return _instance;
        }
    }
    public Slider hpSlider;
    public GameObject result;

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
    //호출 시점: 게임시작, 캐릭터 데미지
    public void UpdateHpbar(float hp, float hpMax)
    {
        hpSlider.value = hp / hpMax;
    }

    public void OnOffResult(bool on)
    {
        result.SetActive(on);
    }

    public void ClickHomeButton()
    {
        //저장할 데이터를 저장(game Manager가 처리)
        //홈 씬 이동
        SceneManager.LoadScene("Home");
    }
    public void ClickContinueButton()
    {
        //캐릭터 선택창 나옴
    }
}
