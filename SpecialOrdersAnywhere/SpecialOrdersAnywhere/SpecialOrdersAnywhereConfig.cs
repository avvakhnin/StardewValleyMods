using System;
namespace SpecialOrdersAnywhere
{
    public class SpecialOrdersAnywhereConfig
    {
        public StardewModdingAPI.SButton CalendarHotKey { get; set; } = StardewModdingAPI.SButton.V;
        public StardewModdingAPI.SButton DailyQuestHotKey { get; set; } = StardewModdingAPI.SButton.B;
        public StardewModdingAPI.SButton SpecialOrdersHotKey { get; set; } = StardewModdingAPI.SButton.N;
        public Boolean UseSpecialOrdersBeforeUnlocked { get; set; } = false;
    }
}
