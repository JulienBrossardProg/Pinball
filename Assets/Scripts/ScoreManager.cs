using System;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class ScoreManager : MonoBehaviour
{
    public float score;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text lastScoreText;
    [SerializeField] private TMP_Text bestScoreText;
    [SerializeField] private float bestScore;
    [SerializeField] private TMP_Text[] scoreArrayText;
    public float[] scoreArray;
    private float changePlaceScore;
    private float memoryScore;

    void Start()
    {
        scoreText.text += score;
        bestScore = score;
        scoreArray = new float[5];
    }
    


    public void ScoreCount(float points)
    {
        score += points;
        scoreText.text ="Score : " + score;
        DisplayScoreArray(points);
    }

    public void LastScore()
    {
        lastScoreText.text = "Last Score : " + score;
    }

    public void BestScore()
    {
        if (score > bestScore)
        {
            bestScore = score;
            bestScoreText.text = "Best Score : " + bestScore;
        }
    }

    void DisplayScoreArray(float points)
    {
        memoryScore = scoreArray[0];
        for (int i = 0; i < scoreArray.Length - 1; i++)
        {
            
            changePlaceScore = memoryScore;
            memoryScore = scoreArray[i + 1];
            scoreArray[i + 1] = changePlaceScore;
        }
        scoreArray[0] = points;

        for (int i = 0; i < scoreArray.Length; i++)
        {
            if (scoreArray[i] !=0)
            {
                scoreArrayText[i].text = "+" + scoreArray[i];
            }
        } 
    }

    public void ResetScore()
    {
        LastScore();
        score = 0;
        ScoreCount(0);
        scoreArray = new float[5];
        for (int i = 0; i < scoreArrayText.Length; i++)
        {
            scoreArrayText[i].text = "";
        }
    }
    
    
}
