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

namespace Classes
{
    public class Message
    {
        public string title;
        public string message;
    }

    [System.Serializable]
    public class Quest
    {
        [UnityEngine.SerializeField]
        RecyclableObject.ObjID _objID;
        [UnityEngine.SerializeField]
        int _quantity;
        int _currentQuantity = 0;

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
            int used = qt + _currentQuantity > _quantity ? _quantity - _currentQuantity : qt;
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

    public static Dictionary<Enums.TrashType, string> TrashDictionary = new Dictionary<Enums.TrashType, string> {
            {Enums.TrashType.PAPER, "PAPEL" },
            {Enums.TrashType.PLASTIC, "PLASTICO" },
            {Enums.TrashType.ORGANIC, "ORGANICO" },
            {Enums.TrashType.SPECIAL, "ESPECIALES" },
            {Enums.TrashType.TIN, "LATA" },
            {Enums.TrashType.NONRECYCLABLE, "NO RECICLABLE" },
            {Enums.TrashType.GLASS, "VIDRIO" },
            {Enums.TrashType.FABRICS, "TEXTIL" },
            {Enums.TrashType.ELECTRONICS, "APARATOS ELECTRONICOS" }
        };

    public static Dictionary<Enums.ObjectType, string> ObjectDictionary = new Dictionary<Enums.ObjectType, string> {
            {Enums.ObjectType.ANY, "CUALQUIER" },
            {Enums.ObjectType.BAG, "BOLSA" },
            {Enums.ObjectType.BATTERY, "BATERIA" },
            {Enums.ObjectType.BOOK, "LIBRO" },
            {Enums.ObjectType.BOTTLE, "BOTELLA" },
            {Enums.ObjectType.BOX, "CAJA" },
            {Enums.ObjectType.CAN, "LATA" },
            {Enums.ObjectType.CASE, "CAJON" },
            {Enums.ObjectType.DRUG, "FARMACO" },
            {Enums.ObjectType.GLASS, "VIDRIO" },
            {Enums.ObjectType.MUG, "TAZA" },
            {Enums.ObjectType.NEWSPAPER, "PERIODICO" },
            {Enums.ObjectType.OTHER, "OTRO" },
            {Enums.ObjectType.PANTS, "PANTALONES" },
            {Enums.ObjectType.RAZER, "AFEITADOR" },
            {Enums.ObjectType.SHIRTS, "CAMISETA" },
            {Enums.ObjectType.SHOES, "ZAPATOS" },
            {Enums.ObjectType.SILICON, "SILICONA" },
            {Enums.ObjectType.TIRE, "NEUMATICO" },
            {Enums.ObjectType.TV, "TV" },
            {Enums.ObjectType.WALKIE, "WALKIE" },
            {Enums.ObjectType.WOOD, "MADERA" }
        };

    public static Dictionary<Enums.OneShotQuestNPCs, string> OneShotDictionary = new Dictionary<Enums.OneShotQuestNPCs, string> {
            {Enums.OneShotQuestNPCs.ARTESAN, "ARTESANA" },
            {Enums.OneShotQuestNPCs.COSPLAYER, "COSPLAYER" },
            {Enums.OneShotQuestNPCs.DOCTOR, "DOCTOR" },
            {Enums.OneShotQuestNPCs.ECOISLANDER, "Técnico de reciclaje" }
        };

    public static Dictionary<Enums.ContinuousQuestNPCs, string> ContinuousDictionary = new Dictionary<Enums.ContinuousQuestNPCs, string> {
            {Enums.ContinuousQuestNPCs.BARMAN, "CAMARERO" },
            {Enums.ContinuousQuestNPCs.GARDENER, "JARDINERO" },
            {Enums.ContinuousQuestNPCs.LIBRARIAN, "BIBLIOTECARIA" },
            {Enums.ContinuousQuestNPCs.MILKMAN, "LECHERO" }
        };
}
