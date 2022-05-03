using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCanQuest : QuestManager
{
    private void OnTriggerEnter(Collider other)
    {
        RecyclableObject obj = other.gameObject.GetComponent<RecyclableObject>();
        
        if (obj == null)
            return;

        bool found = false;

        foreach(Classes.Quest q in _quests.List)
        {
            if (q.ID.trashType == obj.ID.trashType)
            {
                EventManager.FirePoints(CorrectPoints);
                EventManager.FireCorrectRecycling(q.ID);
                found = true;
                break;
            }
        }

        if (!found) 
        {
            EventManager.FirePoints(WrongPoints);
            EventManager.FireWrongRecycling();
        }

        Destroy(other.gameObject);
    }
}
