using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesManager : MonoBehaviour
{
    public static ResourcesManager Instance;
    private GameObject skeleton;
    public GameObject Skeleton
    {
        get { return skeleton; }
    }
    private GameObject orc;
    public GameObject Orc
    {
        get { return orc; }
    }
    private List<Dictionary<string, object>> csv_QuestTable;
    public List<Dictionary<string, object>> Csv_QuestTable { get { return csv_QuestTable; } }
    private Object[] questDataObject;
    private List<QuestData> questDataList;
    public List<QuestData> QuestDataList { get { return questDataList; } }
    private void Awake()
    {
        if (Instance == null) Instance = this;
    }
    private void Start()
    {
        skeleton = Resources.Load<GameObject>("Skeleton/LowPolySkeleton");
        orc = Resources.Load<GameObject>("ExampleMonsterSphere");
        csv_QuestTable = CSVReader.Read("CSV/QuestTable");
        questDataObject = Resources.LoadAll("Scrabtable/Quest");
        questDataList = new List<QuestData>();
        for(int i = 0; i < questDataObject.Length; i++)
        {
            questDataList.Add(questDataObject[i] as QuestData);
        }

    }
}
