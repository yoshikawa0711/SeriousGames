using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoryController : MonoBehaviour
{
    private static string[,] speaches_opening = {
        {"俺｢ただいまー。｣", "entrance", "none"},
        {"仕事から帰ってきた俺。3年前に結婚した妻がソファで寝ている。", "living", "wife"},
        {"俺｢おい、起きろ。｣", "living", "wife"},
        {"妻｢ん…あぁ、おかえりなさい、俺さん。｣", "living", "wife"},
        {"妻はまだ眠そうにしている。", "living", "wife"},
        {"俺｢飯は？｣", "living", "wife"},
        {"妻｢…あ、仕事から帰ってきてすぐ寝ちゃったから…今から作るね｣", "living", "wife"}
    };

    private static string[,] answers_opening = {
        {"1  まだできてないの？", "20"},
        {"2  疲れてるの？", "-10"},
        {"3  晩酌しながら待つ", "10"}
    };

    private static string[,] comment_opening_ans1 = {
        {"俺｢まだできてないの？俺が帰ってくる時間わかるよね？飯くらい用意しとけよ｣", "living", "wife"},
        {"妻(こちとら仕事で疲れてるのにお前の帰宅時間を考える余裕ねぇよ…)", "living", "wife"},
        {"妻｢ごめんなさい、気をつけるね。｣", "living", "wife"}
    };

    private static string[,] comment_opening_ans2 = {
        {"俺｢疲れてるの？大丈夫？｣", "living", "wife"},
        {"妻｢うん、大丈夫。ありがとう｣", "living", "wife"}
    };

    private static string[,] comment_opening_ans3 = {
        {"俺｢ふーん｣", "living", "wife"},
        {"妻(なんかイラつく)", "living", "wife"}

    };

    private static string[,] speaches_bear = {
        {"ーーーーーーーーー", "living", "none"},
        {"妻はキッチンで晩飯を作っている。", "living", "wife"},
        {"俺は晩酌しながら待つことにした。", "living", "wife"},
        {"毎晩ビールを飲むことは、俺の日課になっている。", "living", "wife"}
    };

    private static string[,] answers_bear = {
        {"1 ビールを取りに行く", "0"},
        {"2 ビールを取ってもらう", "10"},
        {"3 ビールを待つ", "50"}
    };


    private static string[,] comment_bear_ans1 = {
        {"俺は冷蔵庫からビールを取り出し、飲み始めた。", "living", "none"},
    };

    private static string[,] comment_bear_ans2 = {
        {"妻｢自分で取ってよ｣", "living", "wife"},
        {"俺｢ついでに取ってくれても良いじゃん｣", "living", "wife"},
        {"妻(何のついでだよ、今飯作ってるのわかんないの？？)", "living", "wife"},
        {"妻はビールを取ってくれた。", "living", "wife"},
        {"妻｢…はい。｣", "living", "wife"}
    };

    private static string[,] comment_bear_ans3 = {
        {"俺｢...｣", "living", "none"},
        {"妻｢...｣", "living", "wife"},
        {"俺｢..........｣", "living", "none"},
        {"妻｢..........｣", "living", "wife"},
        {"俺｢..........｣", "living", "none"},
        {"俺｢........................おい。｣", "living", "none"},
        {"妻｢なに？｣", "living", "wife"},
        {"俺｢待ってるんだけど？｣", "living", "wife"},
        {"妻｢...ご飯？今作ってるから｣", "living", "wife"},
        {"俺｢ビールだよ、何で気づかないかな｣", "living", "wife"},
        {"俺｢俺がここに座った時点で飲むってわかるでしょ？」", "living", "wife"},
        {"俺｢つまみの1つも出さないで飯も作れないとかお前家で何してんの？」", "living", "wife"},
        {"俺｢家事できないなら仕事辞めれば？｣", "living", "wife"},
        {"妻(私はお前の奴隷じゃねーよ！！！！てかお前の収入私の半分だろが！！)", "living", "wife"},
        {"妻(私が仕事辞めたらどうやって食っていくんだよ！！！)", "living", "wife"},
        {"妻(共働きなのに家事は全部私がやらなきゃいけないのおかしいだろが！！！)", "living", "wife"},
        {"妻｢もう無理。離婚しよう。｣", "living", "wife"},
        {"妻｢あんたの存在を見るだけでウンザリする。｣", "living", "wife"},
        {"妻は出ていった。働かせてやってる立場で何が不満なのか、全く理解できなかった。", "living", "none"}
    };

    private static string[,] speaches_diner = {
        {"ーーーーーーーーーーーー", "living", "none"},
        {"妻が何かを作り終えたようだ。", "living", "wife"},
        {"ｺﾞﾄｯ", "living", "wife"},
        {"俺の目の前にチャーハンが置かれた。", "living", "wife"},
        {"俺(チャーハンかぁ…気分じゃないなぁ。)", "living", "wife"}
    };

    private static string[,] answers_diner = {
        {"1 つまみを食べる", "20"},
        {"2 チャーハンを食べる", "-20"},
        {"3 別のものを食べる", "50"}
    };

    private static string[,] comment_diner_ans1 = {
        {"俺はひとしきり飲んだ後、テーブルを立った。", "living", "none"},
        {"妻｢チャーハン食べないの？？｣", "living", "wife"},
        {"俺｢...うん｣", "living", "wife"},
        {"妻「...｣", "living", "wife"},
        {"妻(食べないなら作らせるなよ！！！！！)", "living", "wife"}
    };

    private static string[,] comment_diner_ans2 = {
        {"気分じゃないけど、作ってもらったんだし食べなきゃな。", "living", "wife"},
        {"俺｢ありがとう。いただきます。｣", "living", "wife"},
        {"妻(ありがとうって言われると、作りがいあるんだよな)", "living", "wife"},
        {"妻｢美味しい？｣", "living", "wife"},
        {"俺｢まぁまぁ(適当)｣", "living", "wife"},
        {"妻｢そっか。明日は作って待ってるね。｣", "living", "wife"}
    };

    private static string[,] comment_diner_ans3 = {
        {"俺｢チャーハン？疲れてるからって手抜き過ぎじゃない？｣", "living", "wife"},
        {"俺｢俺はお前よりも疲れてるのに自分だけ楽してさぁ、俺を労わってあげようとかないの？｣", "living", "wife"},
        {"俺｢しかもこれ冷凍でしょ？俺に冷凍食べさせる気？俺を殺そうとしてんの？｣", "living", "wife"},
        {"妻｢...ごめん。｣", "living", "wife"},
        {"妻｢じゃあもう自分で作ってよ！！！｣", "living", "wife"},
        {"妻は泣き出した。", "living", "wife"},
        {"妻｢何で共働きなのに私に家事全部押し付けるの！！？もう無理！！！｣", "living", "wife"},
        {"妻｢実家に帰ってママに手料理食べさせてもらえば？｣", "living", "wife"},
        {"妻｢さよなら｣", "living", "wife"},
        {"妻は出ていった。妻の役割を放棄しておいて逆ギレした妻が1つも理解できなかった。", "living", "none"}
    };

    private static string story_state = "opening";
    private static string quiz_state = "opening";
    private static string end_state = "";
    private static int stress = 50;

    void Start()
    {

    }

    void Update()
    {

    }

    public static string[,] getSpeaches()
    {
        /* ストーリーの状態から，次のストーリーを渡す(更新が必要な場合はクイズの状態を変更する) */
        switch (story_state)
        {
            case "opening":
                /* ストーリー状態を更新 */
                StoryController.setStoryState("comment_opening");
                return speaches_opening;
            case "comment_opening":
                story_state = "bear";
                if (quiz_state == "comment_opening_ans1")
                {
                    quiz_state = "";
                    return comment_opening_ans1;
                }
                else if (quiz_state == "comment_opening_ans2")
                {
                    quiz_state = "";
                    return comment_opening_ans2;
                }
                else if (quiz_state == "comment_opening_ans3")
                {
                    quiz_state = "";
                    return comment_opening_ans3;
                }

                Debug.Log("ストーリー結合エラー");
                return null;
            case "bear":
                StoryController.setStoryState("comment_bear");
                quiz_state = "bear";
                return speaches_bear;
            case "comment_bear":
                story_state = "diner";
                if (quiz_state == "comment_bear_ans1")
                {
                    quiz_state = "";
                    return comment_bear_ans1;
                }
                else if (quiz_state == "comment_bear_ans2")
                {
                    quiz_state = "";
                    return comment_bear_ans2;
                }
                else if (quiz_state == "comment_bear_ans3")
                {
                    quiz_state = "";
                    end_state = "sasshite";
                    return comment_bear_ans3;
                }
                Debug.Log("ストーリー結合エラー");
                return null;

            case "diner":
                story_state = "comment_diner";
                quiz_state = "diner";
                return speaches_diner;

            case "comment_diner":
                story_state = "";
                if (quiz_state == "comment_diner_ans1")
                {
                    quiz_state = "";
                    end_state = "normal";
                    return comment_diner_ans1;
                }
                else if (quiz_state == "comment_diner_ans2")
                {
                    quiz_state = "";
                    end_state = "normal";
                    return comment_diner_ans2;
                }
                else if (quiz_state == "comment_diner_ans3")
                {
                    quiz_state = "";
                    end_state = "kodomo";
                    return comment_diner_ans3;
                }
                Debug.Log("ストーリー結合エラー");
                return null;

            default:
                Debug.Log("ストーリー取得エラー");
                break;
        }
        return null;
    }

    public static string[,] getAnswers()
    {
        switch (quiz_state)
        {
            case "opening":
                return answers_opening;
            case "bear":
                return answers_bear;
            case "diner":
                return answers_diner;
            default:
                Debug.Log("クイズ取得エラー");
                break;
        }

        return null;
    }

    /* 状態・ストレスに対するゲッター，セッター */
    public static void setStoryState(string state)
    {
        story_state = state;
    }

    public static string getStoryState()
    {
        return story_state;
    }

    public static void setQuizState(string state)
    {
        quiz_state = state;
    }

    public static string getQuizState()
    {
        return quiz_state;
    }

    public static string getEndState()
    {
        return end_state;
    }

    public static void setEndState(string state)
    {
        end_state = state;
    }

    public static int getStress()
    {
        return stress;
    }

    public static void addStress(int plus)
    {
        stress += plus;
    }

    public static void resetStress()
    {
        stress = 50;
    }

}
