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
    private void Start()
    {
        skeleton = Resources.Load<GameObject>("Skeleton/LowPolySkeleton");
        orc = Resources.Load<GameObject>("ExampleMonsterSphere");
    }
}
