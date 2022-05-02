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
            int used;
            do
            {
                inv.GetInventory.TryGetValue(k, out int value);

                used = _quests.UpdateQuest(k, value);
                if (used > 0) inv.UpdateInventory(k, used);

                if (_quests.AreQuestsComplete())
                {
                    if (_completionPartycles != null)
                    {
                        _completionPartycles.SetActive(false);
                        _completionPartycles.SetActive(true);
                    }
                    EventManager.FireDisplayMessageOnPanel(BuildMessage(), 12);
                    EventManager.FirePoints(CorrectPoints);
                }
            } while (used > 0);
        }

        UpdateScore();
    }
    private Classes.Message BuildMessage()
    {
        Classes.Message m = new Classes.Message();
        Constants.ContinuousDictionary.TryGetValue(_npc, out m.title);
        m.message = "¡Gracias! Has sido de gran ayuda. Sería genial si pudieras traerme artículos como estos :)";

        return m;
    }
}
