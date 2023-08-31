using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesManager : Singleton<ResourcesManager>
{
    private GameObject goblin;
    public GameObject Goblin
    {
        get { return goblin; }
    }
    private GameObject orc;
    public GameObject Orc
    {
        get { return orc; }
    }
    private void Start()
    {
        goblin = Resources.Load<GameObject>("ExampleMonsterCube");
        orc = Resources.Load<GameObject>("ExampleMonsterSphere");
    }
}
