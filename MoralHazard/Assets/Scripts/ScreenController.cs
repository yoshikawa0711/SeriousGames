﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScreenController : MonoBehaviour
{
    public GameObject speach_object = null;
    public GameObject background_object = null;
    public GameObject person_object = null;
    public GameObject name_text_obj = null;
    public GameObject name_windows_obj = null;
    private Image change_background;
    private Image change_person;
    public Sprite living_sprite = null;
    public Sprite entrance_sprite = null;
    public Sprite wife_sprite = null;
    public Sprite wife_angry_sprite = null;
    public Sprite wife_sad_sprite = null;
    private Text name_text;

    private int text_index = 0;
    private string[,] speaches;

    void Start()
    {
        /* 背景の設定 */
        change_background = background_object.GetComponent<Image>();
        change_person = person_object.GetComponent<Image>();

        /* テキストの設定 */
        speaches = StoryController.getSpeaches();
        text_index = 0;

        name_text = name_text_obj.GetComponent<Text>();

    }

    void Update()
    {
        /* テキストを進めるための処理 */
        Text speach_text = speach_object.GetComponent<Text>();
        speach_text.text = speaches[text_index, 1];

        /* 名前を表示するための処理 */
        switch (speaches[text_index, 0])
        {
            case "妻":
            case "俺":
                name_text_obj.SetActive(true);
                name_windows_obj.SetActive(true);
                name_text.text = speaches[text_index, 0];
                break;
            default:
                name_text_obj.SetActive(false);
                name_windows_obj.SetActive(false);
                break;

        }

        /* 人物を変更するための処理 */
        switch (speaches[text_index, 3])
        {
            case "none":
                person_object.SetActive(false);
                break;
            case "wife":
                person_object.SetActive(true);
                change_person.sprite = wife_sprite;
                break;
            case "wife_angry":
                person_object.SetActive(true);
                change_person.sprite = wife_angry_sprite;
                break;
            case "wife_sad":
                person_object.SetActive(true);
                change_person.sprite = wife_sad_sprite;
                break;
            default:
                Debug.Log("キャラ画像表示エラー");
                break;
        }

        /* 背景を変更するための処理 */
        switch (speaches[text_index, 2])
        {
            case "entrance":
                change_background.sprite = entrance_sprite;
                break;
            case "living":
                change_background.sprite = living_sprite;
                break;
            default:
                Debug.Log("背景画像表示エラー");
                break;
        }

        /* クリックをしたときの処理 */
        if (Input.GetMouseButtonDown(0))
        {

            // テキストを読み終わった後の処理
            if (text_index >= speaches.GetLength(0) - 1)
            {
                string end_status;
                if ((end_status = StoryController.getEndState()) != "")
                {
                    if (end_status == "normal")
                    {
                        SceneManager.LoadScene("NormalEndScene");
                    }
                    else
                    {
                        SceneManager.LoadScene("EndScene");
                    }
                }
                else if (StoryController.getQuizState() == "")
                {
                    SceneManager.LoadScene("StoryScene");
                }
                else
                {
                    SceneManager.LoadScene("QuizScene");
                }

            }

            if (text_index < speaches.GetLength(0) - 1)
            {
                text_index++;
            }
        }

    }
}
