using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : Singleton<GameManager>
{
    public Vector3 playerDir = Vector3.zero;
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
