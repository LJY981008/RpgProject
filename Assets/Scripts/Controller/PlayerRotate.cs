using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerRotate : MonoBehaviour
{
    public RectTransform stick;
    float speed = 1f;
    float yAngle = 0f;
    Vector3 playerRotate = Vector3.zero;
    Vector3 stickRotate = Vector3.zero;
    private void FixedUpdate()
    {
    }
}
