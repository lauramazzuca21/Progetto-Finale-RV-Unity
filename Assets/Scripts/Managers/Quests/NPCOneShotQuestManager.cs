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
        if (gameObject != this.gameObject || !_isActive)
            return;

        Inventory inv = FindObjectOfType<Inventory>();
        List<RecyclableObject.ObjID> keys = new List<RecyclableObject.ObjID>(inv.GetInventory.Keys);

        foreach (RecyclableObject.ObjID k in keys)
        {
            if (inv.GetInventory.TryGetValue(k, out int value))
            {
                int used = _quest.UpdateQuest(k.objectType, value);
                inv.UpdateInventory(k, used);                  
            }
        }

        UpdateScore();

        if (_quest.IsQuestComplete())
        {
            _isActive = false;
            EventManager.FirePointsEvent(CorrectPoints);
        }
    }

    private void UpdateScore()
    {
        string str = "";

        for (int i = 0; i < _questObjects.Count; i++)
        {
            _quest.TryGetValue(_questObjects[i], out int count);
            count = _questQuantities[i] - count;

            str += _questObjects[i] + ":\t\t"+ count +"/" + _questQuantities[i] + "\n";
        }
        _score.text = str;
    }
}
