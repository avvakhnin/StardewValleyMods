using System;
namespace SpecialOrdersAnywhere
{
    public class SpecialOrdersAnywhereConfig
    {
        public StardewModdingAPI.SButton CalendarHotKey { get; set; } = StardewModdingAPI.SButton.N;
        public Boolean EnableCalendarHotkey { get; set; } = true;

        public StardewModdingAPI.SButton DailyQuestHotKey { get; set; } = StardewModdingAPI.SButton.B;
        public Boolean EnableDailyQuestHotKey { get; set; } = true;

        public StardewModdingAPI.SButton SpecialOrdersHotKey { get; set; } = StardewModdingAPI.SButton.H;
        public Boolean EnableSpecialOrdersHotKey { get; set; } = true;
        public Boolean UseSpecialOrdersBeforeUnlocked { get; set; } = false;

        public StardewModdingAPI.SButton QiSpecialOrdersHotKey { get; set; } = StardewModdingAPI.SButton.J;
        public Boolean EnableQiSpecialOrdersHotKey { get; set; } = true;
        public Boolean UseQiSpecialOrdersBeforeUnlocked { get; set; } = false;
    }
}
