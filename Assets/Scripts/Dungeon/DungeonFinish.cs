using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonFinish : MonoBehaviour
{


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Player.Instance.IsSpawn = false;
            GameManager.Instance.LoadScene("TownScene");
        }
    }
}
