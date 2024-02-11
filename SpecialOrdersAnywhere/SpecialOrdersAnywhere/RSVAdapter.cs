using System;
using System.Reflection;
using Microsoft.Xna.Framework;
namespace SpecialOrdersAnywhere
{
    internal class RSVAdapter
    {

        static internal Boolean isRSVQuestBoardType(Object rsvQuestBoard)
        {
            return "RidgesideVillage.Questing.RSVQuestBoard".Equals(
                rsvQuestBoard.GetType().ToString());
        }

        static internal Boolean isRSVSpecialOrderBoardType(Object rsvSpecialOrderBoard)
        {
            return "RidgesideVillage.Questing.RSVSpecialOrderBoard".Equals(
                rsvSpecialOrderBoard.GetType().ToString());
        }

        //For RidgesideVillage.Questing.RSVQuestBoard
        static internal string getRSVQuestBoardType(Object rsvQuestBoard)
        {
            return (string)rsvQuestBoard.GetType().GetField("boardType",
                BindingFlags.NonPublic | BindingFlags.Instance)
                .GetValue(rsvQuestBoard);
        }

        //For RidgesideVillage.Questing.RSVSpecialOrderBoard
        static internal string getRSVSpecialOrderBoardType(Object rsvSpecialOrderBoard)
        {
            return (string)rsvSpecialOrderBoard.GetType().GetField("boardType")
                                .GetValue(rsvSpecialOrderBoard);
        }

        static internal void activateVillageQuestBoard()
        {
            activateQuestBoard("OpenQuestBoard", "VillageQuestBoard");
        }

        static internal void activateNijaQuestBoard()
        {
            activateQuestBoard("OpenQuestBoard", "RSVNinjaBoard");
        }

        static internal void activateTownSpecialOrderBoard()
        {
            activateQuestBoard("OpenSOBoard", "RSVTownSO");
        }

        static internal void activateNinjaSpecialOrderBoard()
        {
            activateQuestBoard("OpenSOBoard", "RSVNinjaSO");
        }

        static private void activateQuestBoard(String boardKind, String boardType)
        {
            Assembly assembly = Assembly.GetAssembly(typeof(RidgesideVillage.ModEntry));
            Type type = assembly.GetType("RidgesideVillage.Questing.QuestController");
            type.GetMethod(boardKind, BindingFlags.NonPublic | BindingFlags.Static)
                .Invoke(null, new object[] { boardType, Vector2.Zero });
        }

    }
}