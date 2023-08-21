using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GPUInstancing : MonoBehaviour
{
    public List<GameObject> objects;

    private void Awake()
    {
        objects = new List<GameObject>();
    }
    void Start()
    {
        Debug.Log(transform.childCount);
        for(int i = 0; i < transform.childCount; i++)
        {
            objects.Add(transform.GetChild(i).GetChild(0).gameObject);
        }
        MaterialPropertyBlock props = new MaterialPropertyBlock();
        MeshRenderer renderer;

        foreach (GameObject obj in objects)
        {
            renderer = obj.GetComponent<MeshRenderer>();
            renderer.SetPropertyBlock(props);
        }
    }
}
