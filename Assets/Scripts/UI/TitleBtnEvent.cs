using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TitleBtnEvent : MonoBehaviour,IBtnEvent
{
    private List<RectCheck> btnList;
    private Image selectBtn;

    public Sprite imageBtnUp;
    public Sprite imageBtnDown;


    public void OnClickDown(BaseEventData _eventData)
    {
        PointerEventData eventData = (PointerEventData)_eventData;
        foreach (var btn in btnList)
        {
            if (btn.IsInRect(eventData.position))
            {
                selectBtn = btn.GetComponent<Image>();
            }
        }
        if(selectBtn != null)
        {
            selectBtn.sprite = imageBtnDown;
            switch (selectBtn.name)
            {
                case "Btn_Start":
                    {
                        Debug.Log("스타트");
                        GameManager.Instance.LoadScene("TownScene");
                    }
                    break;
                case "Btn_Exit":
                    {
                        Debug.Log("종료");
                    }
                    break;
                default:
                    {
                        Debug.Log("버튼없음");
                    }
                    break;
            }
            
        }
    }

    public void OnClickUp(BaseEventData _eventData)
    {
        PointerEventData eventData = (PointerEventData)_eventData;
        if (selectBtn != null)
        {
            selectBtn.sprite = imageBtnUp;
            selectBtn = null;
        }
    }

    private void Awake()
    {
        selectBtn = null;
        btnList = new List<RectCheck>();
        for (int i = 0; i < transform.childCount; i++)
        {
            btnList.Add(transform.GetChild(i).GetComponent<RectCheck>());
        }
    }
}
