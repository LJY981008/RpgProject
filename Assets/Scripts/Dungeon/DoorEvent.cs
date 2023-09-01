using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorEvent : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            switch (Player.Instance.isGetKey)
            {
                case true:
                    {

                    }
                    break;
                case false:
                    {

                    }
                    break;
            }
        }
    }
}
