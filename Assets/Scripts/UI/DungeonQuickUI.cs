using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class DungeonQuickUI : MonoBehaviour
{
    public List<Transform> quickList;
    private void Awake()
    {
        ToolManager.Instance.dungeonQuickUI = this;
        UpdateSlot(ToolManager.Instance.quicks);
    }
    public void UpdateSlot(Item[] items)
    {
        Transform icon = null;
        for(int i = 0; i < items.Length; i++)
        {
            if(items[i] is CountableItem ci)
            {
                icon = Utill.FindTransform(quickList[i], "Icon");
                if (ci.Amount > 0)
                {
                    icon.gameObject.SetActive(true);
                    icon.GetComponent<Image>().sprite = ci.Data.ItemIcon;
                    icon.GetChild(0).GetComponent<TextMeshProUGUI>().text = ci.Amount.ToString();
                }
                else
                {
                    icon.gameObject.SetActive(false);
                }
            }
        }
    }
}
