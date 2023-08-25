using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestUI : MonoBehaviour
{
    public GameObject qusetItem;
    private List<GameObject> listQusetItem;
    private GameObject thisItem;
    private TextMeshProUGUI textTarget;
    private TextMeshProUGUI textNum;
    private void Awake()
    {
        listQusetItem = new List<GameObject>();
        thisItem = null;
        textTarget = null;
        textNum = null;
    }
    public void AddQuset(string target, string num)
    {
        thisItem = Instantiate(qusetItem, Utill.FindTransform(transform, "QusetContent"));
        textTarget = thisItem.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        textNum = thisItem.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        textTarget.text = $"{target}";
        textNum.text = $"(0 / {num})";
        listQusetItem.Add(thisItem);

    }
}
