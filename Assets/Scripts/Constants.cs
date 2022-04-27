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
public static class Constants
{
    public static Dictionary<Enums.AudioClips,string> Clips = new Dictionary<Enums.AudioClips, string> {
            {Enums.AudioClips.CORRECT, "correctAction" },
            {Enums.AudioClips.WRONG, "wrongAction" }
        };
}
