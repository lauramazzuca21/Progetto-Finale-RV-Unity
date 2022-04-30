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
        WALKIE,
        RAZER,
        MUG,
        SILICON
        
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
        [UnityEngine.SerializeField]
        RecyclableObject.ObjID _objID;
        [UnityEngine.SerializeField]
        int _quantity;
        int _currentQuantity;

        public RecyclableObject.ObjID ID { get { return _objID; } }
        public int Quantity { get { return _quantity; } }
        public int CurrentQuantity { get { return _currentQuantity; } }

        public Quest(RecyclableObject.ObjID objID, int quantity)
        {
            _objID = objID;
            _quantity = quantity;
            _currentQuantity = 0;
        }

        public int Increase(int qt = 1)
        {
            int used = qt + _currentQuantity > _quantity ? qt - (_quantity - _currentQuantity) : qt;
            _currentQuantity += used;
            return used;
        }

        public bool IsComplete()
        {
            if (_currentQuantity >= _quantity)
                return true;
            return false;
        }

        public void Reset()
        {
            _currentQuantity = 0;
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
