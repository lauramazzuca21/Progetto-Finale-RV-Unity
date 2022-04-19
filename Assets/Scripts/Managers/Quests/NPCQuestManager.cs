using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCQuestManager : ObjectsQuestManager
{
    private Dictionary<Enums.TrashType, ObjectsQuest> _quests = new Dictionary<Enums.TrashType, ObjectsQuest>()
    {
        { Enums.TrashType.PAPER, Constants.PaperObjQuest },
        { Enums.TrashType.PLASTIC, Constants.PlasticObjQuest },
        { Enums.TrashType.TIN, Constants.TinObjQuest },
        { Enums.TrashType.GLASS, Constants.GlassObjQuest }
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
        UnityEngine.Debug.Log("handling correct recycle");

        if (_quests.TryGetValue(trashType, out ObjectsQuest quest))
        {
            quest.UpdateQuest(objectType);

            if (quest.IsQuestComplete())
            {
                _quests.Remove(trashType);
                //TODO: add what happens when quest is completed
            }
            else
                EventManager.FirePointsEvent(CorrectPoints);
        }
    }

    protected override void HandleWrongRecycle()
    {
        EventManager.FirePointsEvent(WrongPoints);
    }
}
