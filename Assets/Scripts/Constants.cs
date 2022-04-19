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
        PANTS
    }

    public enum AudioClips
    {
        CORRECT,
        WRONG
    }
}
public static class Constants
{
    public static Dictionary<Enums.AudioClips,string> Clips = new Dictionary<Enums.AudioClips, string> {
            {Enums.AudioClips.CORRECT, "correctAction" },
            {Enums.AudioClips.WRONG, "wrongAction" }
        };

    public static ObjectsQuest PaperObjQuest = new ObjectsQuest
    {
        {Enums.ObjectType.NEWSPAPER, 2 },
        {Enums.ObjectType.BOOK, 1 },
        {Enums.ObjectType.BOX, 1 }
    };

    public static ObjectsQuest PlasticObjQuest = new ObjectsQuest
    {
        {Enums.ObjectType.BAG, 2 }
    };

    public static ObjectsQuest TinObjQuest = new ObjectsQuest
    {
        {Enums.ObjectType.CAN, 3 },
        {Enums.ObjectType.CASE, 2 }
    };

    public static ObjectsQuest GlassObjQuest = new ObjectsQuest
    {
        {Enums.ObjectType.GLASS, 2 },
        {Enums.ObjectType.BOTTLE, 2 }
    };

}
