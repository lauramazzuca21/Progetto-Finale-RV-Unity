using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextManager : MonoBehaviour
{
    [SerializeField]
    private TMPro.TextMeshPro _titleLabel;
    [SerializeField]
    private TMPro.TextMeshPro _messageLabel;
    [SerializeField]
    private TMPro.TextMeshPro _scoreLabel;
    [SerializeField]
    private GameObject _panel;

    private int points = 0;
    private TMPro.TextMeshPro[] _totalScoreLabels; 

    private void Awake()
    {
        int i = 0;
        foreach(GameObject g in GameObject.FindGameObjectsWithTag("Score"))
        {
            _totalScoreLabels[i] = g.GetComponent<TMPro.TextMeshPro>();
            ++i;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        EventManager.Points += UpdateScore;
        EventManager.DisplayMessage += DisplayMessage;

        _panel.SetActive(false);
    }

    private void DisplayMessage(Classes.Message msg, int lastInSec)
    {
        _panel.SetActive(true);
        _titleLabel.text = msg.title;
        _messageLabel.text = msg.message;
        _ = StartCoroutine(ClearLabel(_messageLabel, lastInSec));
        _ = StartCoroutine(ClearPanel(lastInSec));
    }

    private void UpdateScore(int pts)
    {
        if(pts >= 0)
        {
            _scoreLabel.text = "+" + pts.ToString();
            _scoreLabel.color = new Color(13, 159, 4);
        }
        else
        {
            _scoreLabel.text = pts.ToString();
            _scoreLabel.color = new Color(159, 7, 4);
        }

        points += pts;
        
        foreach(TMPro.TextMeshPro t in _totalScoreLabels)
            _scoreLabel.text = points.ToString();

        _ = StartCoroutine(ClearLabel(_scoreLabel, 3));
    }

    private IEnumerator ClearLabel(TMPro.TextMeshPro label, int seconds)
    {
        yield return new WaitForSeconds(seconds);
        label.text = "";
    }

    private IEnumerator ClearPanel(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        _panel.SetActive(false);
    }

}
