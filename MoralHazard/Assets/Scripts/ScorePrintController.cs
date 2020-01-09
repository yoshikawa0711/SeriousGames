using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScorePrintController : MonoBehaviour
{

    public Text stress_score;

    void Start()
    {
        stress_score = this.GetComponent<Text>();
        stress_score.text = StoryController.getStress().ToString();

    }

    void Update()
    {
        stress_score.text = StoryController.getStress().ToString();
    }
}
