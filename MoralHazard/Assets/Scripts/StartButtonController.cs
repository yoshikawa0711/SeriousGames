using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButtonController : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {

    }

    public void OnClick()
    {
        Debug.Log("スタートボタンをクリックした");
        SceneManager.LoadScene("StoryScene");
    }
}
