using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
// score provavelmente vai ser a vida

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public TMP_Text scoreText;
    public TMP_Text highScoreText;

    int score =0;
    int highScore =0;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = score.ToString()+"points";
        highScoreText.text = "Highscore" + highScore.ToString();
    }

    public void AddPoint(){
        score++;
        scoreText.text = score.ToString()+"points";
        if(score > highScore){
            highScore = score;
            highScoreText.text = "Highscore" + highScore.ToString();
        }
    }
    void Awake(){
        instance = this;
    }
}
