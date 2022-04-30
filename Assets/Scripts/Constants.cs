using System.Collections.Generic;

namespace Enums
{
    public enum TrashType
    {
        PAPER,
        PLASTIC,
        ORGANIC,
        GLASS,
        TIN,
        NONRECYCLABLE,
        ELECTRONICS,
        FABRICS,
        SPECIAL
    }


    public enum ObjectType
    {
        OTHER, //cosi i specificano solo quelli necesari
        ANY,
        DRUG,
        CAN,
        CASE,
        BOOK,
        BOX,
        NEWSPAPER,
        BAG,
        BOTTLE,
        GLASS,
        BATTERY,
        TIRE,
        WOOD,
        SHOES,
        SHIRTS,
        PANTS,
        TV,
        WALKIE
        
    }

    public enum AudioClips
    {
        CORRECT,
        WRONG
    }

    public enum ContinuousQuestNPCs
    {
        MILKMAN,
        LIBRARIAN,
        GARDENER,
        BARMAN
    }

    public enum OneShotQuestNPCs
    {
        COSPLAYER,
        ARTESAN,
        DOCTOR,
        ECOISLANDER
    }
}

namespace Structs
{
    [System.Serializable]
    public struct Quest
    {
        public RecyclableObject.ObjID _objID;
        public int _quantity;

        int _currentQuantity;

        public Quest(RecyclableObject.ObjID objID, int quantity)
        {
            _objID = objID;
            _quantity = quantity;
            _currentQuantity = 0;
        }

        public void Add(int qt = 1)
        {
            _currentQuantity += qt;
        }
    }
}
public static class Constants
{
    public static Dictionary<Enums.AudioClips,string> Clips = new Dictionary<Enums.AudioClips, string> {
            {Enums.AudioClips.CORRECT, "correctAction" },
            {Enums.AudioClips.WRONG, "wrongAction" }
        };
}
