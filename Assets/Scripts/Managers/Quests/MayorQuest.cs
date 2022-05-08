using UnityEngine;

//Player quests
public class MayorQuest : QuestManager
{
    //this is the score that the player receives every time a quest is completed
    private const int _finalScore = 300;
    private bool _isActive = true;
    void Start()
    {
        //the mayor needs to handle the event fired by the TrashCans so that it registeres the update in the quests
        EventManager.CorrectRecycling += HandleCorrectRecycle;
    }

    protected void HandleCorrectRecycle(RecyclableObject.ObjID ID)
    {
        if (!_isActive)
            return;
        //when all the quests are done activates thee reward and sends the message
        foreach(Classes.Quest q in _quests.List)
        {
            if (  !q.IsComplete() && (  (q.ID.objectType == Enums.ObjectType.ANY && q.ID.trashType == ID.trashType) || q.ID.Equals(ID)  ) )
            {
                q.Increase();
                //every time a single object is recycled get points
                //the mayor doesn't need to fire this event because it is the trashcan that gives points to the player for recicling correctly
                //**EventManager.FirePoints(CorrectPoints);
                //every time the player completes a quest the mayor sends the message to congratulate and gets 300 pts
                if (q.IsComplete())
                {
                    EventManager.FireQuestCompleted();
                    EventManager.FireDisplayMessageOnPanel(BuildMessage(q), 6);
                    EventManager.FirePoints(_finalScore);
                }
            }
        }

        if(_quests.AreQuestsComplete())
        {
            _isActive = false;
            EventManager.FireQuestCompleted();
            EventManager.FireDisplayMessageOnPanel(BuildMessage(null), 15);
            if(_reward != null)
                _reward.SetActive(true);
            if (_spotLight != null)
                _spotLight.SetActive(false);
        }
    }

    private Classes.Message BuildMessage(Classes.Quest q)
    {
        Classes.Message m = new Classes.Message();
        m.title = "ALCALDESA";
        if (q == null)
            m.message = "Espero que esta experiencia te haya ayudado a comprender mejor la importancia del reciclaje. Para agradecerte, ¡te regalaré una marioneta hecha completamente con material reciclado! Puedes encontrarlo en tu estantería de trofeos.";

        Constants.TrashDictionary.TryGetValue(q.ID.trashType, out string trashType);
        Constants.ObjectDictionary.TryGetValue(q.ID.objectType, out string objectType);
        m.message = "Bravo! Reciclaste " + q.CurrentQuantity + " " + objectType + " " + trashType;

        return m;
    }
}
