using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

static class QuestFactory
{
    public static ObjectsQuest GetQuest(Enums.OneShotQuestNPCs npc)
    {
        switch(npc)
        {
            case Enums.OneShotQuestNPCs.COSPLAYER:
                return Constants.CosplayerObjQuest;
            case Enums.OneShotQuestNPCs.ARTESAN:
                return Constants.ArtesanObjQuest;
            case Enums.OneShotQuestNPCs.DOCTOR:
                return Constants.DoctorObjQuest;
            case Enums.OneShotQuestNPCs.ECOISLANDER:
                return Constants.EcoIslanderObjQuest;
        }

        return null;
    }
}
