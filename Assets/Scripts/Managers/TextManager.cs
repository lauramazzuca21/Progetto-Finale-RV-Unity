using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _panel;
    [SerializeField]
    private TMPro.TextMeshPro _titlePanel;
    [SerializeField]
    private TMPro.TextMeshPro _messagePanel;
    [SerializeField]
    private TMPro.TextMeshPro _messageLabel;
    [SerializeField]
    private TMPro.TextMeshPro _pointsLabel;

    Vector3 offsetVector = new Vector3(0, 1.3f, 1.45f);

    private int _score = 0;
    private List<TMPro.TextMeshPro> _totalScoreLabels = new List<TMPro.TextMeshPro>();
    private Queue<KeyValuePair<Classes.Message, int>> _messagesQueue = new Queue<KeyValuePair<Classes.Message, int>>();
    private Queue<int> _pointsQueue = new Queue<int>();

    private void Awake()
    {
        foreach(GameObject g in GameObject.FindGameObjectsWithTag("Score"))
        {
            if(g.GetComponent<TMPro.TextMeshPro>() != null)
                _totalScoreLabels.Add(g.GetComponent<TMPro.TextMeshPro>());
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        EventManager.Points += DisplayScore;
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
        else
        {
            _panel.SetActive(true);
            ShowPanel(msg, lastInSec);
        }
    }

    private void DisplayScore(int pts)
    {
        if (_pointsLabel.text.Length == 0 && _pointsQueue.Count == 0)
            UpdateScore(pts);
        else
            _pointsQueue.Enqueue(pts);
    }

    private void UpdateScore(int pts)
    {
        if (pts >= 0)
        {
            _pointsLabel.text = "+" + pts.ToString();
            _pointsLabel.color = new Color(13.0f / 255.0f, 159.0f / 255.0f, 4.0f / 255.0f, 1.0f);
        }
        else
        {
            _pointsLabel.text = pts.ToString();
            _pointsLabel.color = new Color(159.0f / 255.0f, 7.0f / 255.0f, 4 / 255.0f, 1.0f);
        }

        _score += pts;

        foreach (TMPro.TextMeshPro t in _totalScoreLabels)
            t.text = _score.ToString();

        _ = StartCoroutine(ClearLabel(_pointsLabel, 3, CheckScoreQueue));
    }

    void CheckScoreQueue()
    {
        if (_pointsQueue.Count > 0)
            UpdateScore(_pointsQueue.Dequeue());
    }

    private IEnumerator ClearLabel(TMPro.TextMeshPro label, int seconds, Action finalize = null)
    {
        yield return new WaitForSeconds(seconds);
        label.text = "";
        yield return new WaitForSeconds(1);
        finalize?.Invoke();
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
        _titlePanel.text = msg.title;
        _messagePanel.text = msg.message;
        _ = StartCoroutine(ClearPanel(lastInSec));
    }
}
