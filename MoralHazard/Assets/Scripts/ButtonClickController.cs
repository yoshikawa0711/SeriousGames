using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonClickController : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {

    }

    public void OnClick()
    {
        /* ストーリー状態を更新 */
        StoryController.setStoryState("comment_opening");

        /* クイズの解答状態を更新してストーリーを読み込む */
        switch (this.gameObject.name)
        {
            case "Answer":
                StoryController.setQuizState(StoryController.getStoryState() + "_ans1");
                break;
            case "Answer (1)":
                StoryController.setQuizState(StoryController.getStoryState() + "_ans2");
                break;
            case "Answer (2)":
                StoryController.setQuizState(StoryController.getStoryState() + "_ans3");
                break;
            default:
                Debug.Log("クイズボタン名エラー");
                break;
        }

        SceneManager.LoadScene("StoryScene");
    }
}
