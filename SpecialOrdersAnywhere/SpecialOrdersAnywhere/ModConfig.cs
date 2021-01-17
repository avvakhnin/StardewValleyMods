using System;
namespace SpecialOrdersAnywhere
{
    public class ModConfig
    {
        public StardewModdingAPI.SButton ActivateKey { get; set; } = StardewModdingAPI.SButton.P;
        public StardewModdingAPI.SButton CycleLeftKey { get; set; } = StardewModdingAPI.SButton.OemOpenBrackets;
        public StardewModdingAPI.SButton CycleRightKey { get; set; } = StardewModdingAPI.SButton.OemCloseBrackets;

        public Boolean SpecialOrdersBeforeUnlocked { get; set; } = false;
        public Boolean QiBeforeUnlocked { get; set; } = false;

        public Boolean enableCalendar { get; set; } = true;
        public Boolean enableDailyQuests { get; set; } = true;
    }
}
