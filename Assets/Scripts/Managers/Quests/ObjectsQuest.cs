using Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Class that represents a single quest of the player's kind
public class ObjectsQuest : Dictionary<Enums.ObjectType, int>
{
    public ObjectsQuest(Dictionary<Enums.ObjectType, int> settings)
    {
        foreach (KeyValuePair< Enums.ObjectType, int> p in settings)
        {
            this.Add(p.Key, p.Value);
        }
    }

    public ObjectsQuest(List<ObjectType> questObjects, List<int> questQuantities)
    {
        for (int i = 0; i < questObjects.Count; i++)
        {
            this.Add(questObjects[i], questQuantities[i]);
        }
    }

    public int UpdateQuest(Enums.ObjectType obj, int qts = 1)
    {
        if (TryGetValue(obj, out int value))
        {
            this[obj] = value - qts < 0 ? 0 : value-qts;

            return qts - value < 0 ? qts : qts - value;
        }

        return 0;
    }

    public bool IsQuestComplete()
    {
        int result = 0;
        foreach (KeyValuePair<Enums.ObjectType, int> p in this)
            result += p.Value;

        UnityEngine.Debug.Log("quest Completed!");
        return result == 0;
    }
}
