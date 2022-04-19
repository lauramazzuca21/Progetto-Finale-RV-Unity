using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private TMPro.TextMeshProUGUI scoreLabel;

    private int points = 0;
    // Start is called before the first frame update
    void Start()
    {
        EventManager.Points += UpdateScore;
    }

    void UpdateScore(int pts)
    {
        points += pts;
        UpdateScoreLabel();
    }

    private void UpdateScoreLabel()
    {
        scoreLabel.text = points.ToString();
    }
}
