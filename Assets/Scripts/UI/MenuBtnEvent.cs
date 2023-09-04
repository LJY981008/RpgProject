using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class MenuBtnEvent : MonoBehaviour, IBtnEvent
{
    private List<RectCheck> btnList;
    private RectCheck selectedBtn;

    [Header("Canvas")]
    public GameObject playerCanvas;
    public GameObject toolCanvas;

    [Header("ToolObj")]
    public TextMeshProUGUI toolName;
    public GameObject toolMenu;
    public List<GameObject> toolList;
    
    private void Awake()
    {
        selectedBtn = null;
        btnList = new List<RectCheck>();

        RectCheck rectCheck = null;
        for (int i = 0; i < transform.childCount; i++)
        {
            rectCheck = transform.GetChild(i).GetComponent<RectCheck>();
            if(rectCheck != null)
                btnList.Add(rectCheck);
            rectCheck = null;
        }
    }
    public void OnClickUp(BaseEventData _eventData)
    {
        PointerEventData eventData = (PointerEventData)_eventData;
        foreach (RectCheck btn in btnList)
        {
            if (btn.IsInRect(eventData.position))
            {
                selectedBtn = btn;
            }
        }
        if (!toolCanvas.activeSelf)
        {
            playerCanvas.SetActive(false);
            toolCanvas.SetActive(true);
        }
        if (selectedBtn != null)
        {
            ChangeTool(selectedBtn);   
        }
        selectedBtn = null;
    }

    private void ChangeTool(RectCheck _selectedBtn)
    {
        string toolType = string.Empty;
        switch (_selectedBtn.iconType)
        {
            case IconType.Equipment:
                {
                    toolName.text = "장비";
                    toolType = "Equipment";
                }
                break;
            case IconType.Inventory:
                {
                    toolName.text = "가방";
                    toolType = "Inventory";
                }
                break;
            case IconType.Skill:
                {
                    toolName.text = "스킬";
                    toolType = "Skill";
                }
                break;
            case IconType.Setting:
                {
                    toolName.text = "세팅";
                    toolType = "Setting";
                }
                break;
            case IconType.Exit:
                {
                    playerCanvas.SetActive(true);
                    toolCanvas.SetActive(false);
                }
                break;
            default:
                break;
        }
        foreach (GameObject toolObj in toolList)
        {
            if(toolObj.name == toolType)
            {
                toolObj.SetActive(true);
            }
            else
            {
                toolObj.SetActive(false);
            }
        }
    }

    public void OnDrag(BaseEventData _eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnClickDown(BaseEventData _eventData)
    {
        PointerEventData eventData = (PointerEventData)_eventData;
    }

}
