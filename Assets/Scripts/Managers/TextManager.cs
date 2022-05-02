using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _panel;
    [SerializeField]
    private GameObject _player;
    [SerializeField]
    private TMPro.TextMeshPro _titlePanel;
    [SerializeField]
    private TMPro.TextMeshPro _messagePanel;
    [SerializeField]
    private TMPro.TextMeshPro _messageLabel;
    [SerializeField]
    private TMPro.TextMeshPro _scoreLabel;

    Vector3 offsetVector = new Vector3(0, 1.3f, 1.45f);

    private int points = 0;
    private List<TMPro.TextMeshPro> _totalScoreLabels = new List<TMPro.TextMeshPro>();
    private Queue<KeyValuePair<Classes.Message, int>> _messagesQueue = new Queue<KeyValuePair<Classes.Message, int>>();
    private void Awake()
    {
        int i = 0;
        foreach(GameObject g in GameObject.FindGameObjectsWithTag("Score"))
        {
            if(g.GetComponent<TMPro.TextMeshPro>() != null)
                _totalScoreLabels.Add(g.GetComponent<TMPro.TextMeshPro>());
            ++i;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        EventManager.Points += UpdateScore;
        EventManager.DisplayMessage += DisplayMessage;
        EventManager.DisplayMessageOnPanel += DisplayMessageOnPanel;

        _panel.SetActive(false);
    }

    private void DisplayMessage(string msg)
    {
        _messageLabel.text = msg;
    }

    private void DisplayMessageOnPanel(Classes.Message msg, int lastInSec)
    {
        if (_panel.activeSelf)//if the panel is active it means that a message is already being shown so we need to enqueue the incoming message
        {
            _messagesQueue.Enqueue(new KeyValuePair<Classes.Message, int>(msg, lastInSec));
        }
        _panel.SetActive(true);
        ShowPanel(msg, lastInSec);
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
            t.text = points.ToString();

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
        if (_messagesQueue.Count > 0)
        {
            KeyValuePair<Classes.Message, int> msg = _messagesQueue.Dequeue();
            ShowPanel(msg.Key, msg.Value);
        }
        else
            _panel.SetActive(false);
    }

    private void ShowPanel(Classes.Message msg, int lastInSec)
    {
        _panel.transform.position = _player.transform.position + offsetVector;
        _panel.transform.rotation = _player.transform.rotation;
        _titlePanel.text = msg.title;
        _messagePanel.text = msg.message;
        _ = StartCoroutine(ClearPanel(lastInSec));
    }
}
