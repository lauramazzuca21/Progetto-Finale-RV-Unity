using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCContinuousQuestManager : QuestManager
{
    [SerializeField]
    private Enums.ContinuousQuestNPCs _npc;

    private void Start()
    {
        EventManager.PlayerInteraction += HandlePlayerInteraction;
        UpdateScore();
    }

    protected void HandlePlayerInteraction(GameObject gameObject)
    {
        if (gameObject != this.gameObject)
            return;

        Inventory inv = FindObjectOfType<Inventory>();
        List<RecyclableObject.ObjID> keys = new List<RecyclableObject.ObjID>(inv.GetInventory.Keys);

        foreach (RecyclableObject.ObjID k in keys)
        {
            //if (_objects.Contains(k))
            //{
            //    inv.GetInventory.TryGetValue(k, out int value);

            //    int completedQuest = Mathf.FloorToInt((_countInstances + value) / _maxObjects * 1.0f); //counts the times the quest has been acheived thanks to the stored items
            //    _countInstances = (_countInstances + value) - completedQuest * _maxObjects;

            //    inv.UpdateInventory(k, value);

            //    if (completedQuest > 0) 
            //        EventManager.FirePointsEvent(CorrectPoints * completedQuest);
            //}
        }

        UpdateScore();
    }

    private void UpdateScore()
    {
        string str = "";
        //for (int i = 0; i < _questObjects.Count; i++)
        //{
        //    str += _objects[i] + ":\t" + _countInstances + "/" + _maxObjects + "\n";
        //}
        _score.text = str;
    }

}
