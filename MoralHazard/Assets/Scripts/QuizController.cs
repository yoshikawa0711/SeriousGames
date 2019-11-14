using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizController : MonoBehaviour
{
    public GameObject answer1_object = null;
    public GameObject answer2_object = null;
    public GameObject answer3_object = null;

    private string[] answers = {
        "1  まだできてないの？",
        "2  疲れてるの？",
        "3  晩酌しながら待つ"
    };

    void Start()
    {
        /* ボタンに選択肢を反映 */
        answer1_object.GetComponentInChildren<Text>().text = answers[0];
        answer2_object.GetComponentInChildren<Text>().text = answers[1];
        answer3_object.GetComponentInChildren<Text>().text = answers[2];

    }

    void Update()
    {
        
    }

}
