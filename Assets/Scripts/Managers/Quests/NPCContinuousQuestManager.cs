using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCContinuousQuestManager : QuestManager
{
    [SerializeField]
    private Enums.TrashType _trashType;
    [SerializeField]
    //FIXME: horrid code to handle stupid exception for librarian in a very quick way
    private List<Enums.ObjectType> _objectTypes = new List<Enums.ObjectType>();
    [SerializeField]
    private int _maxObjects = 0;

    private int _countInstances = 0;
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
            if (k.trashType == this._trashType && CheckObjectType(k.objectType))
            {
                inv.GetInventory.TryGetValue(k, out int value);

                int completedQuest = Mathf.FloorToInt((_countInstances + value) / _maxObjects * 1.0f); //counts the times the quest has been acheived thanks to the stored items
                _countInstances = (_countInstances + value) - completedQuest * _maxObjects;

                inv.UpdateInventory(k, value);

                if (completedQuest > 0) 
                    EventManager.FirePointsEvent(CorrectPoints * completedQuest);
            }
        }

        UpdateScore();
    }

    private bool CheckObjectType(Enums.ObjectType objectType)
    {
        return (_objectTypes.Count > 0 && _objectTypes.Contains(objectType)) || _objectTypes.Count == 0;
    }

    private void UpdateScore()
    {
        string str = _trashType + ":\t\t" + _countInstances + "/" + _maxObjects + "\n";
        for (int i = 0; i < _objectTypes.Count; i++)
        {
            str = _objectTypes[i] + ":\t\t" + _countInstances + "/" + _maxObjects + "\n";
        }
        _score.text = str;
    }

}
