using UnityEngine;

//Player quests
public class TrashQuestManager : QuestManager
{
    private const int _finalScore = 300;
    void Start()
    {
        EventManager.CorrectRecycling += HandleCorrectRecycle;
        EventManager.WrongRecycling += HandleWrongRecycle;
    }

    protected void HandleCorrectRecycle(RecyclableObject.ObjID ID)
    {
        //when all the quests are done activates thee reward and sends the message
        foreach(Classes.Quest q in _quests.List)
        {
            if (  (q.ID.objectType == Enums.ObjectType.ANY && q.ID.trashType == ID.trashType) || q.ID.Equals(ID)   )
            {
                q.Increase();
                //every time a single object is recycled get points
                EventManager.FirePoints(CorrectPoints);
            }
            //every time the player completes a quest the mayor sends the message to congratulate and gets 300 pts
            if (q.IsComplete())
            {
                EventManager.FireDisplayMessageOnPanel(BuildMessage(q), 6);
                EventManager.FirePoints(_finalScore);
            }
        }

        if(_quests.AreQuestsComplete())
        {
            EventManager.FireDisplayMessageOnPanel(BuildMessage(null), 15);
            if(_reward != null)
                _reward.SetActive(true);
            if (_light != null)
                _light.SetActive(false); 
        }
    }

    protected void HandleWrongRecycle()
    {
        EventManager.FirePoints(WrongPoints);
    }

    private Classes.Message BuildMessage(Classes.Quest q)
    {
        Classes.Message m = new Classes.Message();
        m.title = "ALCADESA";
        if (q == null)
            m.message = "Espero que esta experiencia te haya ayudado a comprender mejor la importancia del reciclaje. Para agradecerte, ¡te regalaré una marioneta hecha completamente con material reciclado! Puedes encontrarlo en tu estantería de trofeos.";

        Constants.TrashDictionary.TryGetValue(q.ID.trashType, out string trashType);
        Constants.ObjectDictionary.TryGetValue(q.ID.objectType, out string objectType);
        m.message = "Bravo! Reciclaste " + q.CurrentQuantity + " " + trashType + " " + objectType;

        return m;
    }
}
