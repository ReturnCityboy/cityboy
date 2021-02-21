using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Joystic : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    RectTransform joystickBg_Rect; //조이스틱 배경
    [SerializeField] RectTransform joystick_Rect; //조이스틱
    [SerializeField] Transform player; //캐릭위치
    Vector3 pos; //움직이는 방향
    float range; //조이스틱 이동범위
    bool touchFlag = false; //현재 드래그 중인가? 체크

    void Start()
    {
        joystickBg_Rect = gameObject.GetComponent<RectTransform>();
        range = joystickBg_Rect.rect.width * 0.5f; //조이스틱 기준 구형태의 움직임임으로 반씩나눔
    }

    void Update()
    {
        if (GameManager.Instance.isFail == false)
        {
            if (touchFlag)
            {
                player.position += pos.normalized * Time.deltaTime;
            }
        }
    }
    public void OnDrag(PointerEventData eventData)
    {
        pos = new Vector3(eventData.position.x - (joystickBg_Rect.position.x), eventData.position.y - (joystickBg_Rect.position.y), 0);
        pos = Vector3.ClampMagnitude(pos, range); //조이스틱배경을 넘지 안게 위치 보정

        joystick_Rect.localPosition = pos;
        player.eulerAngles = new Vector3(0, 0, (Mathf.Atan2(pos.normalized.y, pos.normalized.x) * Mathf.Rad2Deg - 90));
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        touchFlag = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        touchFlag = false;
        joystick_Rect.localPosition = Vector3.zero;
    }
}
