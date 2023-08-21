using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float speed = 5f;
    void Update()
    {
        Vector3 temp = transform.position;
        temp.x = temp.x + GameManager.Instance.playerDir.normalized.x * Time.deltaTime * speed;
        temp.z = temp.z + GameManager.Instance.playerDir.normalized.y * Time.deltaTime * speed;
        transform.position = temp;
    }
}
