using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCOneShotQuestManager : QuestManager
{
    [SerializeField]
    private Enums.OneShotQuestNPCs _npc;

    [SerializeField]
    private GameObject _reward;


    private bool _isActive = true;
    
    void Start()
    {
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
                int used = _quests.UpdateQuest(k, value);
                inv.UpdateInventory(k, used);
            }
        }

        UpdateScore();

        if (_quests.AreQuestsComplete())
        {
            _isActive = false;
            EventManager.FirePoints(CorrectPoints);
            EventManager.FireDisplayMessage(BuildMessage(), 8);
            StartCoroutine(ActivateReward());
        }

    }

    IEnumerator ActivateReward()
    {
        yield return new WaitForFixedUpdate();
        _reward.SetActive(true);
    }

    private Classes.Message BuildMessage()
    {
        Classes.Message m = new Classes.Message();
        Constants.OneShotDictionary.TryGetValue(_npc, out m.title);
        m.message = "¡Gracias! Has sido de gran ayuda. Te dejé un regalo sobre el estanteria de trofeos en la plaza principal.";

        return m;
    }
}
