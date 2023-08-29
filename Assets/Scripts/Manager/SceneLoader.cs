using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    private float loadSpeed = 3f;
    private string nextScene = "";
    public Image bar;
    private void Start()
    {
        nextScene = GameManager.Instance.nextScene;
        bar.fillAmount = 0f;
        StartCoroutine(LoadingScene());
    }
    IEnumerator LoadingScene()
    {
        yield return null;
        AsyncOperation op = SceneManager.LoadSceneAsync(nextScene);
        op.allowSceneActivation = false;
        float timer = 0.0f;
        while (!op.isDone)
        {
            yield return null;
            timer += (Time.deltaTime * loadSpeed);
            if (op.progress < 0.9f)
            {
                bar.fillAmount = Mathf.Lerp(bar.fillAmount, op.progress, timer);
                if (bar.fillAmount >= op.progress)
                {
                    timer = 0f;
                }
            }
            else
            {
                bar.fillAmount = Mathf.Lerp(bar.fillAmount, 1f, timer);
                if (bar.fillAmount == 1.0f)
                {
                    op.allowSceneActivation = true;
                    yield break;
                }
            }
        }
    }
}
