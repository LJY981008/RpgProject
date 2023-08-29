using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    public string nextScene = "";
    public Image loadingBar;
    public Vector3 playerDir = Vector3.zero;
    public Vector3 camDir = Vector3.zero;


    private void Update()
    {
    }

    public void LoadScene(string sceneName)
    {
        nextScene = sceneName;
        SceneManager.LoadScene("LoadingScene");
    }
}
