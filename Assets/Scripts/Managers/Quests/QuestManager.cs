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
    protected TextMesh _score;

    protected int CorrectPoints { get { return _correctPoints; } set { _correctPoints = value; } }
    protected int WrongPoints { get { return _wrongPoints; } set { _wrongPoints = value; } }
}
