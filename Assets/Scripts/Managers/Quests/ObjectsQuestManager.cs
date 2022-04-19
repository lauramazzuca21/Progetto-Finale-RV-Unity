using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsQuestManager : QuestManager
{

    void Start()
    {
    }

    protected override void HandleCorrectRecycle(Enums.TrashType trashType, Enums.ObjectType objectType)
    {
        EventManager.FirePointsEvent(CorrectPoints);
    }

    protected override void HandleWrongRecycle()
    {
        EventManager.FirePointsEvent(WrongPoints);
    }
}
