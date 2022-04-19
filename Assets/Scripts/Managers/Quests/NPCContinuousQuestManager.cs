using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCContinuousQuestManager : QuestManager
{
    [SerializeField]
    private Enums.TrashType _trashType;
    [SerializeField]
    private List<Enums.ObjectType> _objectTypes = new List<Enums.ObjectType>();
    [SerializeField]
    private int _maxObjects = 0;

    private int _countInstances = 0;
    private void Start()
    {
        _countInstances = _maxObjects;
    }

    protected override void HandleCorrectRecycle(Enums.TrashType trashType, Enums.ObjectType objectType)
    {
        if (_trashType == trashType && CheckObjectType(objectType))
        {
            --_countInstances;
            if (_countInstances <= 0)
            {
                EventManager.FirePointsEvent(CorrectPoints);
                _countInstances = _maxObjects;
            }
        }

    }

    private bool CheckObjectType(Enums.ObjectType objectType)
    {
        return (_objectTypes.Count > 0 && _objectTypes.Contains(objectType)) || _objectTypes.Count == 0;
    }

    protected override void HandleWrongRecycle()
    {
        EventManager.FirePointsEvent(WrongPoints);
    }
}
