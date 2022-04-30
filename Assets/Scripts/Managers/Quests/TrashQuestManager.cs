using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Player quests
public class TrashQuestManager : QuestManager
{
    [SerializeField]
    private GameObject _reward;

    void Start()
    {
        EventManager.CorrectRecycling += HandleCorrectRecycle;
        EventManager.WrongRecycling += HandleWrongRecycle;
    }

    protected void HandleCorrectRecycle(RecyclableObject.ObjID ID)
    {


        //if (_genericQuests.TryGetValue(trashType, out int count))
        //{
        //    --count;
        //    if (count <= 0)
        //    {
        //        _genericQuests.Remove(trashType);
        //        EventManager.FirePointsEvent(CorrectPoints);
        //    }
        //    else _genericQuests[trashType] = count;
        //}

        //if (_specificQuests.TryGetValue(objectType, out int cnt))
        //{
        //    --cnt;
        //    if (cnt <= 0)
        //    {
        //        _specificQuests.Remove(objectType);
        //        EventManager.FirePointsEvent(CorrectPoints);
        //    }
        //    else _specificQuests[objectType] = cnt;

        //}



    }

    protected void HandleWrongRecycle()
    {
        EventManager.FirePoints(WrongPoints);
    }
}
