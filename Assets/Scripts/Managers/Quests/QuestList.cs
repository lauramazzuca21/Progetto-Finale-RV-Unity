using Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Class that represents a single quest
public class QuestList : List<Structs.Quest>
{
    public int UpdateQuest(RecyclableObject.ObjID obj, int qts = 1)
    {
        if (Contains(obj, out int value))
        {
            this[obj] = value - qts < 0 ? 0 : value-qts;

            return qts - value < 0 ? qts : qts - value;
        }

        return 0;
    }

    public bool IsQuestComplete()
    {
        int result = 0;
        foreach (KeyValuePair<RecyclableObject.ObjID, int> p in this)
            result += p.Value;

        return result == 0; 
    }
}
