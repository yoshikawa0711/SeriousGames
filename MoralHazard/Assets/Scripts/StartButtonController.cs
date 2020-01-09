using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButtonController : MonoBehaviour
{
    void Start()
    {
        StoryController.setStoryState("opening");
        StoryController.setQuizState("opening");
        StoryController.setEndState("");
        StoryController.resetStress();
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
