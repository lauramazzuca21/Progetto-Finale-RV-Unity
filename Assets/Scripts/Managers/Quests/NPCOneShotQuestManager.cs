using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCOneShotQuestManager : QuestManager
{
    [SerializeField]
    private Enums.OneShotQuestNPCs _npc;

    //"Select an object in the Quest Objects list and its respective quantity in Quest Quantities.They will be matched by position.";
    [SerializeField]
    private List<Enums.ObjectType> _questObjects = new List<Enums.ObjectType>();
    [SerializeField]
    private List<int> _questQuantities = new List<int>();

    private bool _isActive = true;
    private ObjectsQuest _quest;
    
    void Start()
    {
        if (_questQuantities.Count != _questObjects.Count)
        {
            UnityEngine.Debug.LogError("The quest objects count does not match the quest quantities count!");
            return;
        }

        _quest = new ObjectsQuest(_questObjects, _questQuantities);
        EventManager.PlayerInteraction += HandlePlayerInteraction;

        UpdateScore();
    }

    protected void HandlePlayerInteraction(GameObject gameObject)
    {
        if (gameObject != this.gameObject)
            return;


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

    private void UpdateScore()
    {
        string str = "";

        for (int i = 0; i < _questObjects.Count; i++)
        {
            if (!_quest.TryGetValue(_questObjects[i], out int count))
                count = 0;

            str = _questObjects[i] + ":\t\t"+ count +"/" + _questQuantities[i] + "\n";
        }
        _score.text = str;
    }
}
