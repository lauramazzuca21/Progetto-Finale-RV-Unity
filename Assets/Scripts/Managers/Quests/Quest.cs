using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Class that represents a single quest of the player's kind
public class ObjectsQuest : Dictionary<Enums.ObjectType, int>
{
    public bool UpdateQuest(Enums.ObjectType obj)
    {
        int value;
        if (TryGetValue(obj, out value))
        {
            --value;
            UnityEngine.Debug.Log("left to collect: " + value + " of " + obj);
            if (value <= 0) this.Remove(obj);
            else this[obj] = value;

            return true;
        }

        return false;
    }

    public bool IsQuestComplete()
    {
        if (Count > 0)
            return false;

        UnityEngine.Debug.Log("quest Completed!");
        return true;
    }
}
