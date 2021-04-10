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
    //public Slider hpSlider;
    //public GameObject result;
    public Player player; //컨트롤 대상
    private void Awake()
    {
        _instance = this;
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    void Start()
    {

    }

    void Update()
    {

    }
    //호출 시점: 게임시작, 캐릭터 데미지
    //Todo: 당장 쓰지 않아서 막아둠
    public void UpdateHpbar(float hp, float hpMax)
    {
        // hpSlider.value = hp / hpMax;
    }

    public void OnOffResult(bool on)
    {
        //result.SetActive(on);
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

    public void ClickRunBTN()
    {
        player.ChangeAni(Player.ANI.RUN);
        Debug.Log("런");
        //이동
    }
    public void ClickAttackBTN()
    {
        //이동을 멈춤
        player.ChangeAni(Player.ANI.ATTACK);
        //player클래스에 Attack메소드 호출
    }
}