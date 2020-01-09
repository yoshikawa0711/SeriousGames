using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScreenController : MonoBehaviour
{
    public GameObject speach_object = null;
    public GameObject background_object = null;
    public GameObject person_object = null;
    private Image change_background;
    private Image change_person;
    public Sprite living_sprite = null;
    public Sprite entrance_sprite = null;
    public Sprite wife_sprite = null;

    private int text_index = 0;
    private string[,] speaches;

    void Start()
    {
        change_background = background_object.GetComponent<Image>();
        change_person = person_object.GetComponent<Image>();

        speaches = StoryController.getSpeaches();
        text_index = 0;

        Debug.Log("妻のストレス: " + StoryController.getStress());
    }

    void Update()
    {
        /* テキストを進めるための処理 */
        Text speach_text = speach_object.GetComponent<Text>();
        speach_text.text = speaches[text_index, 0];

        /* 人物を変更するための処理 */
        switch (speaches[text_index, 2])
        {
            case "none":
                person_object.SetActive(false);
                break;
            case "wife":
                person_object.SetActive(true);
                change_person.sprite = wife_sprite;
                break;
            default:
                Debug.Log("キャラ画像表示エラー");
                break;
        }

        /* 背景を変更するための処理 */
        switch (speaches[text_index, 1])
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
                if (StoryController.getStoryState() == "" && StoryController.getQuizState() == "")
                {

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
