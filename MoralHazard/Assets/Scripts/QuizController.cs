using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizController : MonoBehaviour
{
    public GameObject answer1_object = null;
    public GameObject answer2_object = null;
    public GameObject answer3_object = null;

    void Start()
    {
        string[,] answers = StoryController.getAnswers();
        /* ボタンに選択肢を反映 */
        answer1_object.GetComponentInChildren<Text>().text = answers[0, 0];
        answer2_object.GetComponentInChildren<Text>().text = answers[1, 0];
        answer3_object.GetComponentInChildren<Text>().text = answers[2, 0];

    }

    void Update()
    {

    }

}
