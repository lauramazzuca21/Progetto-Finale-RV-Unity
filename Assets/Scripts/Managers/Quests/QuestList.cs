using Enums;
using Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Class that represents a single quest
[System.Serializable]
public class QuestList
{
    [UnityEngine.SerializeField]
    List<Structs.Quest> _questList = new List<Structs.Quest>();

    public List<Structs.Quest> List { get { return _questList; }}

    public int UpdateQuest(RecyclableObject.ObjID obj, int qts = 1)
    {
        foreach(Structs.Quest q in _questList)
        {
            if (q.ID.Equals(obj))
            {
                int used = q.Increase(qts);
                return used;
            }
        }
        return 0;
    }

    public bool IsQuestComplete()
    {
        bool result = false;
        foreach (Structs.Quest q in _questList)
            result = q.IsComplete() && result;

        return result; 
    }

    public void Reset()
    {
        foreach (Structs.Quest q in _questList)
            q.Reset();
    }
}
