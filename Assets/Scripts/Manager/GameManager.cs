using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public enum MONSTER
{
    NONE = 10000,
    Skeleton
}
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public string nextScene = "";
    public Image loadingBar;
    public Vector3 playerDir = Vector3.zero;
    public Vector3 camDir = Vector3.zero;
    public float camZoom = 0f;
    [SerializeField]
    private HPSubject hpSubject;
    public HPSubject HpSubject { get { return hpSubject; } }
    public MonsterHp monsterObserver;
    public bool isNew = true;

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }
    public void LoadScene(string sceneName)
    {
        Player.Instance.IsSpawn = false;
        nextScene = sceneName;
        SceneManager.LoadScene("LoadingScene");
    }
}
