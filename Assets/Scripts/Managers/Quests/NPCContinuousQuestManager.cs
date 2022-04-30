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
            if (inv.GetInventory.TryGetValue(k, out int value))
            {
                int completedQuest = 0;
                int used;
                while ((used = _questList.UpdateQuest(k, value)) > 0) //until there are objects to consume
                {
                    inv.UpdateInventory(k, used);
                    if (_questList.IsQuestComplete())
                    {
                        EventManager.FirePoints(CorrectPoints * completedQuest);
                    }

                } 

                //int completedQuest = Mathf.FloorToInt((_countInstances + value) / _maxObjects * 1.0f); //counts the times the quest has been acheived thanks to the stored items
                //_countInstances = (_countInstances + value) - completedQuest * _maxObjects;


                if (completedQuest > 0)
                    EventManager.FirePoints(CorrectPoints * completedQuest);
            }
        }

        UpdateScore();
    }
}
