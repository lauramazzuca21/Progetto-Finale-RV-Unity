using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class QuestManager : MonoBehaviour
{
    private int _correctPoints = 0;
    private int _wrongPoints = 0;
    protected int CorrectPoints { get { return _correctPoints; } set { _correctPoints = value; } }
    protected int WrongPoints { get { return _wrongPoints; } set { _wrongPoints = value; } }

    protected abstract void HandleCorrectRecycle(Enums.TrashType trashType, Enums.ObjectType objectType);
    protected abstract void HandleWrongRecycle();
}
