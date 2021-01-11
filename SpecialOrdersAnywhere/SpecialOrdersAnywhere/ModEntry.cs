using System;
using Microsoft.Xna.Framework;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;

namespace SpecialOrdersAnywhere
{
    /// <summary>The mod entry point.</summary>
    public class ModEntry : Mod
    {
        private SpecialOrdersAnywhereConfig config;

        /*********
        ** Public methods
        *********/
        /// <summary>The mod entry point, called after the mod is first loaded.</summary>
        /// <param name="helper">Provides simplified APIs for writing mods.</param>
        public override void Entry(IModHelper helper)
        {
            this.config = helper.ReadConfig<SpecialOrdersAnywhereConfig>();

            helper.Events.Input.ButtonPressed += this.OnButtonPressed;
        }


        /*********
        ** Private methods
        *********/
        /// <summary>Raised after the player presses a button on the keyboard, controller, or mouse.</summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event data.</param>
        private void OnButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            // ignore if player hasn't loaded a save yet
            if (!Context.IsWorldReady)
                return;

            // open the special orders board
            if (e.Button == this.config.SpecialOrdersHotKey)
            {
                var date = SDate.Now();
                if (this.config.UseSpecialOrdersBeforeUnlocked || date.DaysSinceStart >= 57)
                {
                    Game1.activeClickableMenu = new StardewValley.Menus.SpecialOrdersBoard();
                }
            }
            else if (e.Button == this.config.CalendarHotKey)
            {
                Game1.activeClickableMenu = new StardewValley.Menus.Billboard();
            }
            else if (e.Button == this.config.DailyQuestHotKey)
            {
                Game1.activeClickableMenu = new StardewValley.Menus.Billboard(true);
            }
        }
    }
}
