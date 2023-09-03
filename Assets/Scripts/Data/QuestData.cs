using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Quest Data", menuName = "Scriptable Object/Quest Data", order = int.MaxValue)]

public class QuestData : ScriptableObject
{
    [Header("퀘스트 정보"), Space(10f)]
    [SerializeField]
    private int type;
    public int Type { get { return type; } }
    [SerializeField]
    private int uid;
    public int Uid { get { return uid; } }
    [SerializeField]
    private string questCode;
    public string QuestCode { get { return questCode; } }
    [SerializeField]
    private string summeryName;
    public string SummeryName { get { return summeryName; } }
    [SerializeField]
    private string description;
    public string Description { get { return description; } }

    [Header("퀘스트 목표"), Space(10f)]
    [SerializeField]
    private MonsterType monsterType;
    public MonsterType MonsterType { get { return monsterType; } }
    [SerializeField]
    private string monsterName;
    public string MonsterName { get { return monsterName; } }
    [SerializeField]
    private int num;
    public int Num { get { return num; } }
    /*[Header("퀘스트 보상"), Space(10f)]
    [Header("출현조건"), Space(10f)]*/
}
