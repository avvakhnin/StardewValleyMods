using System;
using StardewModdingAPI;
using StardewModdingAPI.Utilities;

namespace AcidicNic.SpecialOrdersAnywhere {
    public class ModConfig {
        public SButton ActivateKey { get; set; } = SButton.P;
        public SButton CycleLeftKey { get; set; } = SButton.OemOpenBrackets;
        public SButton CycleRightKey { get; set; } = SButton.OemCloseBrackets;

        public bool enableCalendar { get; set; } = true;
        public bool enableDailyQuests { get; set; } = true;
        public bool enableSpecialOrders { get; set; } = true;
        public bool enableQiSpecialOrders { get; set; } = true;
        public bool enableJournal { get; set; } = false;


        public bool enableRSVVillageDailyQuests { get; set; } = true;
        public bool enableRSVNinjaDailyQuests { get; set; } = true;
        public bool enableRSVTownSpecialOrder { get; set; } = true;
        public bool enableRSVNinjaSpecialOrder { get; set; } = true;

        public bool SpecialOrdersBeforeUnlocked { get; set; } = false;
        public bool QiBeforeUnlocked { get; set; } = false;

        internal int MenuLen;

        public ModConfig()
        {
            this.MenuLen = 0;

            if (enableCalendar)
                this.MenuLen++;
            if (enableDailyQuests)
                this.MenuLen++;
            if (enableSpecialOrders)
                this.MenuLen++;
            if (enableQiSpecialOrders)
                this.MenuLen++;
            if (enableQiSpecialOrders)
                this.MenuLen++;
            if (enableRSVVillageDailyQuests)
                this.MenuLen++;
            if (enableRSVNinjaDailyQuests)
                this.MenuLen++;
            if (enableRSVTownSpecialOrder)
                this.MenuLen++;
            if (enableRSVNinjaSpecialOrder)
                this.MenuLen++;
        }
    }
}

