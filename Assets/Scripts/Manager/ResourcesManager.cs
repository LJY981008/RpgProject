using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesManager : Singleton<ResourcesManager>
{
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

private void Start()
    {
        skeleton = Resources.Load<GameObject>("Skeleton/LowPolySkeleton");
        orc = Resources.Load<GameObject>("ExampleMonsterSphere");
        csv_QuestTable = CSVReader.Read("CSV/QuestTable");
        for (int i = 0; i < csv_QuestTable.Count; i++)
        {
            Debug.Log(csv_QuestTable[i]["Content"].ToString());
        }
    }
}
