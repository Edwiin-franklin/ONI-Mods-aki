﻿using FUtility;
using SpookyPumpkinSO.Content;
using SpookyPumpkinSO.Content.Foods;
using SpookyPumpkinSO.Content.GhostPip;
using SpookyPumpkinSO.Content.Plants;

namespace SpookyPumpkinSO
{
    public class STRINGS
    {
        public static class BUILDINGS
        {
            public static class PREFABS
            {
                public static class SP_SPOOKYPUMPKIN
                {
                    public static LocString NAME = "Jack O' Lantern";
                    public static LocString DESC = "A spooky lamp for spooky times.";
                    public static LocString EFFECT = $"Provides Light and Decor. Spooks duplicants that come nearby.";
                }

                public static class SP_FRIENDLYPUMPKIN
                {
                    public static LocString NAME = "Friendly Pumpkin Lantern";
                    public static LocString DESC = "A friendly lamp that does not spook duplicants.";
                    public static LocString EFFECT = $"Provides Light and Decor.";
                }
            }
        }

        public class DUPLICANTS
        {
            public class STATUSITEMS
            {
                public class SPOOKED
                {
                    public static LocString NAME = "Spooked!";
                    public static LocString TOOLTIP = "This Duplicant saw something super scary!";
                }

                public class SP_GHASTLYLITBONUS
                {
                    public static LocString NAME = "Otherwordly Focus";
                    public static LocString TOOLTIP = "{0} Work Speed\n{1} Stress";
                }


                public class HOLIDAY_SPIRIT
                {
                    public static LocString NAME = "Holiday Spirit";
                    public static LocString TOOLTIP = "This Duplicant is excited for this time of year. (All stats up!)";
                }

                public class GHASTLY
                {
                    public static LocString NAME = "Ghastly";
                    public static LocString TOOLTIP = "";
                }
            }

            public class MODIFIERS
            {
                public class AHM_HOLIDAYSPIRIT
                {
                    public static LocString NAME = "Holiday Spirit";
                    public static LocString DESCRIPTION = "This Duplicant is excited for this time of year. (All stats up!)";
                }
            }
        }

        public class EQUIPMENT
        {
            public class PREFABS
            {
                public class SP_HALLOWEENCOSTUME
                {
                    public static LocString GENERICNAME = "Halloween Costume";
                    public static LocString NAME = "Halloween Costume";

                    public class FACADES
                    {
                        public static LocString SP_VAMPIRECOSTUME = "Vampire Costume"; 
                        public static LocString SP_SCARECROWCOSTUME = "Scarecrow Costume"; 
                        public static LocString SP_JACKSKELLINGTONCOSTUME = "Skellington Costume"; 
                    }
                }
            }
        }

        public class ITEMS
        {
            public class SPICES
            {
                public class SP_PUMPKIN_SPICE
                {
                    public static LocString NAME = Utils.FormatAsLink("Pumpkin Spice", SPSpices.PUMPKIN_SPICE_ID);
                    public static LocString DESC = $"It's that season of the year!";
                }
            }

            public class FOOD
            {
                public class SP_PUMPKIN
                {
                    public static LocString NAME = Utils.FormatAsLink("Pumpkin", PumpkinConfig.ID);
                    public static LocString DESC = $"Bland tasting fruit of a Pumpkin plant.";
                }

                public class SP_PUMPKINPIE
                {
                    public static LocString NAME = Utils.FormatAsLink("Pumpkin Pie", PumkinPieConfig.ID);
                    public static LocString DESC = "A delicious seasonal treat.";
                }

                public class SP_TOASTEDPUMPKINSEED
                {
                    public static LocString NAME = Utils.FormatAsLink("Roasted Pumpkin Seeds", ToastedPumpkinSeedConfig.ID);
                    public static LocString DESC = "Tasty snack.";
                }
            }
        }

        public class CREATURES
        {
            public class SPECIES
            {
                public class SP_GHOSTPIP
                {
                    public static LocString NAME = Utils.FormatAsLink("Suspicious Pip", GhostSquirrelConfig.ID);
                    public static LocString DESC = "Seems suspicious. It looks like it would love some treats.\n\n" +
                        "<smallcaps>The Suspicious Pip will offer to trade for Pumpkin Seeds. The required item will change daily and after each trade.</smallcaps>";
                }
                public class SP_PUMPKIN
                {
                    public static LocString NAME = Utils.FormatAsLink("Pumpkin", PumpkinPlantConfig.ID);
                    public static LocString DECOR_NAME = Utils.FormatAsLink("Decorative Pumpkin", PumpkinPlantConfig.ID);
                    public static LocString DESC = $"Pumpkins are pretty neat. They grow enormous fruits also called Pumpkins.";
                    public static LocString DOMESTICATEDDESC = DESC;
                }

                public class SEEDS
                {
                    private static readonly LocString seeds = Utils.FormatAsLink("Seed", "PLANTS");

                    public class SP_PUMPKIN
                    {
                        public static LocString NAME = Utils.FormatAsLink("Pumpkin Seed", PumpkinPlantConfig.ID);
                        public static LocString DESC = $"The {seeds} of a {SPECIES.SP_PUMPKIN.NAME} plant.\n\nIt can be planted to grow more Pumpkins, or toasted for snacks.";
                    }
                }
            }
        }

        public class UI
        {
            public static LocString RECARVE = "Recarve";
            public static LocString ROTATE = "Rotate";

            public class UISIDESCREENS
            {
                public class GHOSTSIDESCREEN
                {
                    public static LocString TITLE = "Suspicious Pip"; // STRINGS.UI.UISIDESCREENS.GHOSTSIDESCREEN.TITLE
                    public static LocString TREATBUTTON = "Deliver Treat";
                    public static LocString CANCELBUTTON = "Cancel";
                    public static LocString SHOO = "Shoo Away";
                    public static LocString CONFIRM = "Are you sure?";
                    public static LocString MESSAGE = "This suspicious pip looks like it wants some treats.";
                    public static LocString LABEL = "Wants one ";
                    public static LocString LABEL2 = "Delivering ";
                }

                public class GHOSTPIP_SPAWNER
                {
                    public static LocString TEXT_ACTIVE = "Answer mysterious call";
                    public static LocString TEXT_INACTIVE = "Pip called";
                    public static LocString TOOLTIP = "Spooky squeaks are whispered through the receiver... ";
                    public static LocString TOOLTIP_INACTIVE = "Pip spawned.";
                }
            }

            public class MODSETTINGS
            {
                public class ROT
                {
                    public static LocString TITLE = "Use rot for fertilizer";
                    public static LocString TOOLTIP = "If true, pumpkin plants will use Rot along Dirt for fertilization.";
                }

                public class GHOSTPIP_LIGHT
                {
                    public static LocString TITLE = "Suspicious Pip emits Light";
                    public static LocString TOOLTIP = "If true, the Suspicious Pip will emit some light.";
                }

                public class GHASTLY_LOOKS
                {
                    public static LocString TITLE = "Ghastly look";
                    public static LocString TOOLTIP = "Should ghastly dupes look ghastly.";
                }

                public class GHASTLY_BONUS
                {
                    public static LocString TITLE = "Ghastly efficiency bonus (%)";
                    public static LocString TOOLTIP = "Work speed bonus while in ghastly form.";
                }

                public class GHASTLY_STRESS_BONUS
                {
                    public static LocString TITLE = "Ghastly stress relief (%)";
                    public static LocString TOOLTIP = "Stress reduction bonus while in ghastly form";
                }
            }
        }
    }
}
