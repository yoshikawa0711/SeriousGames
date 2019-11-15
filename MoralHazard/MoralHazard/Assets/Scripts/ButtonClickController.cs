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

    public void OnClick() { 
        /* クイズの解答状態を更新してストーリーを読み込む */
        string suffix = "";
        string[ , ] ans = StoryController.getAnswers();
        int add = 0;
        switch(this.gameObject.name) {
            case "Answer":
                suffix =  "_ans1";
                add =  int.Parse(ans[0, 1]);
                break;
            case "Answer (1)":
                suffix =  "_ans2"; 
                add =  int.Parse(ans[1, 1]);
                break;
            case "Answer (2)":
                suffix =  "_ans3";   
                add =  int.Parse(ans[2, 1]);
                break;
            default:
                Debug.Log("クイズボタン名エラー");
                break;
        }
        StoryController.setQuizState(StoryController.getStoryState() + suffix);
        StoryController.addStress(add);
        SceneManager.LoadScene("StoryScene");
    }
}
