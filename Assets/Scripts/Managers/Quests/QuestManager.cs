using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class QuestManager : MonoBehaviour
{
    [SerializeField]
    private int _correctPoints = 0;
    [SerializeField]
    private int _wrongPoints = 0;
    [SerializeField]
    protected TMPro.TextMeshPro _score;
    //"Select an object in the Quest Objects list and its respective quantity in Quest Quantities.They will be matched by position.";
    [SerializeField]
    protected QuestList _quests = new QuestList();

    protected int CorrectPoints { get { return _correctPoints; } set { _correctPoints = value; } }
    protected int WrongPoints { get { return _wrongPoints; } set { _wrongPoints = value; } }

    protected void UpdateScore()
    {
        string str = "";

        foreach (Structs.Quest q in _quests.List) 
        {
            str += q.ID.trashType + " " + q.ID.objectType + ":\t" + q.CurrentQuantity + "/" + q.Quantity + "\n";
        }
        _score.text = str;
    }
}
