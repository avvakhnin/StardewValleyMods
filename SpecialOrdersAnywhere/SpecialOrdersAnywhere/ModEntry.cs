using System;
using Microsoft.Xna.Framework;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;
using StardewValley.Menus;

namespace SpecialOrdersAnywhere
{
    /// <summary>The mod entry point.</summary>
    public class ModEntry : Mod
    {
        private ModConfig config;

        /*********
        ** Public methods
        *********/
        /// <summary>The mod entry point, called after the mod is first loaded.</summary>
        /// <param name="helper">Provides simplified APIs for writing mods.</param>
        public override void Entry(IModHelper helper)
        {
            this.config = helper.ReadConfig<ModConfig>();

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
            // ignore if the world isn't loaded
            if (!Context.IsWorldReady)
                return;

            // ActivateKey
            if (e.Button == this.config.ActivateKey)
            {
                if (Context.CanPlayerMove)
                    Game1.activeClickableMenu = new Billboard();
                else if (Game1.activeClickableMenu is SpecialOrdersBoard || Game1.activeClickableMenu is Billboard)
                    Game1.exitActiveMenu();
            }
            // CycleRight
            else if (e.Button == this.config.CycleRightKey && !Context.IsPlayerFree)
            {
                if (Game1.activeClickableMenu is Billboard)
                {
                    if ((Game1.activeClickableMenu as Billboard).calendarDays != null)
                        Game1.activeClickableMenu = new Billboard(true);
                    else
                    {
                        if (this.config.SpecialOrdersBeforeUnlocked || SpecialOrder.IsSpecialOrdersBoardUnlocked())
                        {
                            Game1.activeClickableMenu = new SpecialOrdersBoard();
                        }
                        else if (this.config.QiBeforeUnlocked || Game1.netWorldState.Value.GoldenWalnutsFound.Value >= 100)
                        {
                            Game1.activeClickableMenu = new SpecialOrdersBoard("Qi");
                        }
                        else
                            Game1.activeClickableMenu = new Billboard();
                    }
                }
                else if (Game1.activeClickableMenu is SpecialOrdersBoard)
                {
                    if ((Game1.activeClickableMenu as SpecialOrdersBoard).boardType == "")
                    {
                        if (this.config.QiBeforeUnlocked || Game1.netWorldState.Value.GoldenWalnutsFound.Value >= 100)
                        {
                            Game1.activeClickableMenu = new SpecialOrdersBoard("Qi");
                            return;
                        }
                    }
                    Game1.activeClickableMenu = new Billboard();
                }
            }
            // Cycleleft
            else if (e.Button == this.config.CycleLeftKey && !Context.IsPlayerFree)
            {
                if (Game1.activeClickableMenu is Billboard)
                {
                    if ((Game1.activeClickableMenu as Billboard).calendarDays != null)
                    {
                        if (this.config.SpecialOrdersBeforeUnlocked || SpecialOrder.IsSpecialOrdersBoardUnlocked())
                            Game1.activeClickableMenu = new SpecialOrdersBoard();
                        else if (this.config.QiBeforeUnlocked || Game1.netWorldState.Value.GoldenWalnutsFound.Value >= 100)
                            Game1.activeClickableMenu = new SpecialOrdersBoard("Qi");
                        else
                            Game1.activeClickableMenu = new Billboard(true);
                    }
                    else
                        Game1.activeClickableMenu = new Billboard();
                }
                else if (Game1.activeClickableMenu is SpecialOrdersBoard)
                {
                    if ((Game1.activeClickableMenu as SpecialOrdersBoard).boardType == "Qi")
                    {
                        if (this.config.SpecialOrdersBeforeUnlocked || SpecialOrder.IsSpecialOrdersBoardUnlocked())
                        {
                            Game1.activeClickableMenu = new SpecialOrdersBoard();
                            return;
                        }
                    }
                    Game1.activeClickableMenu = new Billboard(true);
                }
            }
        }
    }
}
