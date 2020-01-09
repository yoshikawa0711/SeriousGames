using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NormalEndingcontroller : MonoBehaviour
{
    public GameObject score_text_obj;
    public GameObject text_obj;
    void Start()
    {
        int score = StoryController.getStress();
        score_text_obj.GetComponent<Text>().text = "あなたと1日暮らした妻のストレス度数は｢" + score + "点｣でした！";

        /* 中央寄せにする */
        text_obj.GetComponent<Text>().alignment = TextAnchor.MiddleLeft;

        if (score <= 30)
        {
            text_obj.GetComponent<Text>().text = "あなたは妻と共存できる夫です。モラ夫の可能性は低いです。\nこれからも妻に寄り添う姿勢を保てば、妻もあなたを支えてくれるでしょう。";
        }
        else if (score >= 80)
        {
            text_obj.GetComponent<Text>().text = "妻はあなたと共存することは不可能だと考えているかもしれません。\nモラハラ気質なところがないか、妻への言動を振り返ってみてはいかがでしょうか。";
        }
        else
        {
            text_obj.GetComponent<Text>().text = "ちょっとしたあなたの言動により、妻はストレスを日々募らせているかもしれません。\n自分の世話は自分でできるくらいの余裕を持ちましょう。";
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
