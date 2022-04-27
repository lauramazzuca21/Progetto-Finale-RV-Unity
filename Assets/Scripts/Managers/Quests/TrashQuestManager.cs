using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Player quests
public class TrashQuestManager : QuestManager
{
    private Dictionary<Enums.TrashType, int> _genericQuests = new Dictionary<Enums.TrashType, int>()
    {
        { Enums.TrashType.PAPER, 5 },
        { Enums.TrashType.PLASTIC, 5 },
        { Enums.TrashType.TIN, 5 },
        { Enums.TrashType.GLASS, 5 }
    };

    private Dictionary<Enums.ObjectType, int> _specificQuests = new Dictionary<Enums.ObjectType, int>()
    {
        { Enums.ObjectType.BOOK, 1 },
        { Enums.ObjectType.NEWSPAPER, 2 },
        { Enums.ObjectType.BOX, 1 },
        { Enums.ObjectType.GLASS, 5 }
    };

    void Start()
    {
        EventManager.CorrectRecycling += HandleCorrectRecycle;
        EventManager.WrongRecycling += HandleWrongRecycle;

        CorrectPoints = 10;
        WrongPoints = -10;
    }

    protected override void HandleCorrectRecycle(Enums.TrashType trashType, Enums.ObjectType objectType)
    {
        if (_genericQuests.TryGetValue(trashType, out int count))
        {
            --count;
            if (count <= 0)
            {
                _genericQuests.Remove(trashType);
                EventManager.FirePointsEvent(CorrectPoints);
            }
            else _genericQuests[trashType] = count;
        }

        if (_specificQuests.TryGetValue(objectType, out int cnt))
        {
            --cnt;
            if (cnt <= 0)
            {
                _specificQuests.Remove(objectType);
                EventManager.FirePointsEvent(CorrectPoints);
            }
            else _specificQuests[objectType] = cnt;

        }

    }

    protected override void HandleWrongRecycle()
    {
        EventManager.FirePointsEvent(WrongPoints);
    }
}
