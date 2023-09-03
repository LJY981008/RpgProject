using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum MyQuest
{
    NONE = 100,
    MAIN,
    SUB
}
public class NpcData : MonoBehaviour
{
    public CharacterData myData;
    
    private int myUID;
    public int GetUID { get { return myUID; } }
    private void Awake()
    {
        myUID = myData.UID;
    }
}
