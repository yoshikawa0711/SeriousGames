using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndCaseController : MonoBehaviour
{

    public GameObject end_text_obj;

    void Start()
    {
        Text end_text = end_text_obj.GetComponent<Text>();
        Debug.Log(StoryController.getEndState());
        switch (StoryController.getEndState())
        {
            case "sasshite":
                end_text.text = "｢察してちゃんモラタイプ｣";
                break;
            default:
                end_text.text = "モラ夫タイプ";
                Debug.Log("エンディングエラー");
                break;
        }
    }

    void Update()
    {
        /* クリックをしたときの処理 */
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("StartScene");
        }
    }

}
