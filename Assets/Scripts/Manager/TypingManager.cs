using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TypingManager : MonoBehaviour
{
    public static TypingManager Instance;
    public float slowSpeed;
    public float fastSpeed;
    public float speed;

    string[] text;
    TextMeshProUGUI tmp;

    public static bool isTextEnd;
    bool isTypingEnd = false;
    int textNumber = 0;

    float timer;
    private void Awake()
    {
        if (Instance == null) Instance = this;
        timer = slowSpeed;
        speed = slowSpeed;
    }

    public bool GetTouchDown()
    {
        if(text != null)
        {
            if (isTypingEnd)
            {
                tmp.text = "";
                return Typing(text, tmp);
            }
            else
            {
                speed = fastSpeed;
            }
        }
        return true;
    }
    public void GetTouchUp()
    {
        if(text != null)
        {
            speed = slowSpeed;
        }
    }
    public bool Typing(string[] _text, TextMeshProUGUI _tmp)
    {
        isTextEnd = false;
        text = _text;
        tmp = _tmp;
        if (textNumber < text.Length)
        {
            char[] stringToChar = text[textNumber].ToCharArray();
            StartCoroutine(Typer(stringToChar, tmp));
            return true;
        }
        else
        {
            tmp.text = string.Empty;
            tmp = null;
            isTextEnd = true;
            text = null;
            textNumber = 0;
            return false;
        }
    }
    IEnumerator Typer(char[] _char, TextMeshProUGUI _tmp)
    {
        int currentText = 0;
        int length = _char.Length;
        isTypingEnd = false;
        while (currentText < length)
        {
            if(timer >= 0)
            {
                yield return null;
                timer -= Time.deltaTime;
            }
            else
            {
                _tmp.text += _char[currentText].ToString();
                currentText++;
                timer = speed;
            }
        }
        if(currentText >= length)
        {
            isTypingEnd = true;
            textNumber++;
            yield break;
        }
        
    }
}
