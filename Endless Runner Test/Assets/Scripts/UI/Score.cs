using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] public Text scoreText;

    private int totalScore;
    public int scoreMultiplier;

    private void FixedUpdate()
    {
        totalScore += scoreMultiplier;
        scoreText.text = totalScore.ToString();
    }
}
