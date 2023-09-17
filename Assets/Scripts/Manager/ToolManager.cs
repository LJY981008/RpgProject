using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolManager : MonoBehaviour
{
    public static ToolManager Instance;
    public GameObject selectedSlotToIcon = null;
    public bool isSelected = false;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }
}
