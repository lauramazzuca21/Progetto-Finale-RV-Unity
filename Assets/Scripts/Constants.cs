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
public static class Constants
{
    public static Dictionary<Enums.AudioClips,string> Clips = new Dictionary<Enums.AudioClips, string> {
            {Enums.AudioClips.CORRECT, "correctAction" },
            {Enums.AudioClips.WRONG, "wrongAction" }
        };

    public static ObjectsQuest CosplayerObjQuest = new ObjectsQuest
    {
        {Enums.ObjectType.NEWSPAPER, 2 },
        {Enums.ObjectType.BOOK, 1 },
        {Enums.ObjectType.BOX, 1 }
    };

    public static ObjectsQuest ArtesanObjQuest = new ObjectsQuest
    {
        {Enums.ObjectType.BAG, 2 }
    };

    public static ObjectsQuest DoctorObjQuest = new ObjectsQuest
    {
        {Enums.ObjectType.CAN, 3 },
        {Enums.ObjectType.CASE, 2 }
    };

    public static ObjectsQuest EcoIslanderObjQuest = new ObjectsQuest
    {
        {Enums.ObjectType.GLASS, 2 },
        {Enums.ObjectType.BOTTLE, 2 }
    };

}
