using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCOneShotQuestManager : QuestManager
{
    [SerializeField]
    private Enums.OneShotQuestNPCs _npc;
    private bool _isActive = true;
    private ObjectsQuest _quest;
    
    void Start()
    {
        _quest = QuestFactory.GetQuest(_npc);

        EventManager.CorrectRecycling += HandleCorrectRecycle;
        EventManager.WrongRecycling += HandleWrongRecycle;

        CorrectPoints = 10;
        WrongPoints = -10;
    }

    protected override void HandleCorrectRecycle(Enums.TrashType trashType, Enums.ObjectType objectType)
    {
        if (!_isActive)
            return;

        UnityEngine.Debug.Log("handling correct recycle");
        _quest.UpdateQuest(objectType);
        if (_quest.IsQuestComplete())
        {
            _isActive = false;
            //TODO: add what happens when quest is completed
        }
        else
            EventManager.FirePointsEvent(CorrectPoints);
    }

    protected override void HandleWrongRecycle()
    {
       
    }
}
