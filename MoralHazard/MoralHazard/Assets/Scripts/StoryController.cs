using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryController : MonoBehaviour
{
    private static string[ , ] speaches_opening = {
        {"俺｢ただいまー。｣", "entrance", "none"},
        {"仕事から帰ってきた俺。3年前に結婚した妻がソファで寝ている。", "living", "wife"},
        {"俺｢おい、起きろ。｣", "living", "wife"},
        {"妻｢ん…あぁ、おかえりなさい、俺さん。｣", "living", "wife"},
        {"妻はまだ眠そうにしている。", "living", "wife"},
        {"俺｢飯は？｣", "living", "wife"},
        {"妻｢…あ、仕事から帰ってきてすぐ寝ちゃったから…今から作るね｣", "living", "wife"}
    };

    private static string[ , ] answers_opening = {
        {"1  まだできてないの？", "20"},
        {"2  疲れてるの？", "-10"},
        {"3  晩酌しながら待つ", "10"}
    };

    private static string[ , ] comment_opening_ans1 = {
        {"俺｢まだできてないの？俺が帰ってくる時間わかるよね？飯くらい用意しとけよ｣", "living", "wife"},
        {"妻(こちとら仕事で疲れてるのにお前の帰宅時間を考える余裕ねぇよ…)", "living", "wife"},
        {"妻｢ごめんなさい、気をつけるね。｣", "living", "wife"}
    };

    private static string[ , ] comment_opening_ans2 = {
        {"俺｢疲れてるの？大丈夫？｣", "living", "wife"},
        {"妻｢うん、大丈夫。ありがとう｣", "living", "wife"}
    };

    private static string[ , ] comment_opening_ans3 = {
        {"俺｢ふーん｣", "living", "wife"},
        {"妻(なんかイラつく)", "living", "wife"}

    };

    private static string[ , ] speaches_bear = {
        {"ーーーーーーーーー", "living", "none"}, 
        {"妻はキッチンで晩飯を作っている。", "living", "wife"},
        {"俺は晩酌しながら待つことにした。", "living", "wife"},
        {"毎晩ビールを飲むことは、俺の日課になっている。", "living", "wife"}
    };

    private static string story_state = "opening";
    private static string quiz_state = "opening";

    private static int stress = 70;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public static string[ , ] getSpeaches() {
        /* ストーリーの状態から，次のストーリーを渡す(更新が必要な場合はクイズの状態を変更する) */
        switch (story_state) {
            case "opening":
                /* ストーリー状態を更新 */
                StoryController.setStoryState("comment_opening");
                return speaches_opening;
            case "comment_opening":
                story_state = "bear";
                if (quiz_state == "comment_opening_ans1"){ 
                    quiz_state = "";
                    return comment_opening_ans1;
                }
                else if (quiz_state == "comment_opening_ans2") {
                    quiz_state = "";
                    return comment_opening_ans2;
                }
                else if (quiz_state == "comment_opening_ans3") {
                    quiz_state = "";
                    return comment_opening_ans3;
                }
                
                Debug.Log("ストーリー結合エラー");
                return null;
            case "bear":
                story_state = "";
                return speaches_bear;
            default:
                Debug.Log("ストーリー取得エラー");
                break;
        }
        return null;
    }

    public static string[ , ] getAnswers() {
        return answers_opening;
    }

    /* 状態・ストレスに対するゲッター，セッター */
    public static void setStoryState(string state) {
        story_state = state;
    }

    public static string getStoryState() {
        return story_state;
    }

    public static void setQuizState(string state) {
        quiz_state = state;
    }

    public static string getQuizState() {
        return quiz_state;
    }

    public static int getStress() {
        return stress;
    }

    public static void addStress(int plus) {
        stress += plus;
    }

}
