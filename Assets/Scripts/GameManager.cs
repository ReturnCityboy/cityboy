using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
        private static GameManager _instance;
        public static GameManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new GameManager();
                }
                return _instance;
            }
        }

    public bool isFail = false;
    private void Awake()
        {
            _instance = this;
        }
        // Todo:게임의 시작,게임실패(실패시ui처리)
        void Start()
    {
        isFail = false;
        Ui.Instance.OnOffResult(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Fail()
    {
        isFail = true;
        Ui.Instance.OnOffResult(true);
        //Todo: 실패시 필요한것
        //게임멈춤 플레이정지 적정지
        //사망연출 - ui-ok
        //재시작 홈으로 플로우차트
    }
    public void Win()
    { 
    //todo: 이겼을때
    //이기는 조건- 스ㅏ테이지 마지막 지점까지 도착,라이프가 1이상있을경우 마지막적이 사망
    //처리하는것-승리연출->로딩연출->다음스테이지 이동
    }
}
