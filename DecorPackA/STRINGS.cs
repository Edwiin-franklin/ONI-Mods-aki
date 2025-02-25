﻿using DecorPackA.Buildings.GlassSculpture;
using DecorPackA.Buildings.StainedGlassTile;
using FUtility;
using KUI = STRINGS.UI;

namespace DecorPackA
{
    public class STRINGS
    {
        public class BUILDINGS
        {
            public class PREFABS
            {
                public class DECORPACKA_GLASSSCULPTURE
                {
                    public static LocString NAME = Utils.FormatAsLink("Glass Block", Buildings.GlassSculpture.GlassSculptureConfig.ID);
                    public static LocString DESC = "Duplicants who have learned art skills can produce more decorative sculptures.";
                    public static LocString EFFECT = "Majorly increases " + Utils.FormatAsLink("Decor") + ", contributing to " + Utils.FormatAsLink("Morale") + ".\n\nMust be sculpted by a Duplicant.";
                    public static LocString POORQUALITYNAME = "\"Abstract\" Glass Sculpture";
                    public static LocString AVERAGEQUALITYNAME = "Mediocre Glass Sculpture";
                    public static LocString EXCELLENTQUALITYNAME = "Genius Glass Sculpture";

                    public class FACADES
                    {
                        public class GOLEM
                        {
                            public static LocString NAME = Utils.FormatAsLink("Golem", GlassSculptureConfig.ID);
                            public static LocString DESCRIPTION = "From Fiend Folio: Reheated, from the hit mod for the hit game Binding of Isaac: Repentance.";
                        }

                        public class UNICORN
                        {
                            public static LocString NAME = Utils.FormatAsLink("Unicorn", GlassSculptureConfig.ID);
                            public static LocString DESCRIPTION = "Fabulus included.";
                        }

                        public class MUCKROOT
                        {
                            public static LocString NAME = Utils.FormatAsLink("Muckroot", GlassSculptureConfig.ID);
                            public static LocString DESCRIPTION = "A humble muckroot.";
                        }

                        public class SWAN
                        {
                            public static LocString NAME = Utils.FormatAsLink("Swan", GlassSculptureConfig.ID);
                            public static LocString DESCRIPTION = "A majestic swan.";
                        }

                        public class MEEP
                        {
                            public static LocString NAME = Utils.FormatAsLink("The creation of Meep", GlassSculptureConfig.ID);
                            public static LocString DESCRIPTION = "Historic piece. Very accurate.";
                        }

                        public class BROKEN
                        {
                            public static LocString NAME = Utils.FormatAsLink("Shattered dreams", GlassSculptureConfig.ID);
                            public static LocString DESCRIPTION = "An attempt was made.";
                        }

                        public class PIP
                        {
                            public static LocString NAME = Utils.FormatAsLink("Pip", GlassSculptureConfig.ID);
                            public static LocString DESCRIPTION = "Great guardian of the Acorns.";
                        }

                        public class POKESHELL
                        {
                            public static LocString NAME = Utils.FormatAsLink("Posh Pokeshell", GlassSculptureConfig.ID);
                            public static LocString DESCRIPTION = "Tribute to the true Daedric overloads of Oblicion: Posh Mudcrabs. (from the mod Posh Mudcrabs)";
                        }

                        public class HATCH
                        {
                            public static LocString NAME = Utils.FormatAsLink("Exquisite Chompers the 2nd", GlassSculptureConfig.ID);
                            public static LocString DESCRIPTION = "This time made of lasting glass!";
                        }
                    }
                }

                public class DECORPACKA_MOODLAMP
                {
                    public static LocString NAME = Utils.FormatAsLink("Mood Lamp", Buildings.MoodLamp.MoodLampConfig.ID);
                    public static LocString DESC = "Light reduces Duplicant stress and is required to grow certain plants.";
                    public static LocString EFFECT = "Provides " + Utils.FormatAsLink("Light") + " when " + Utils.FormatAsLink("Powered", "POWER") + ".\n\nDuplicants can operate buildings more quickly when the building is lit.";

                    public class VARIANT
                    {
                        public static LocString RANDOM = "Random";

                        // v1.0
                        public static LocString UNICORN = "Unicorn";
                        public static LocString MORB = "Morb";
                        public static LocString DENSE = "Dense Puft";
                        public static LocString MOON = "Moon";
                        public static LocString BROTHGAR = "Brothgar Logo";
                        public static LocString SATURN = "Saturn";
                        public static LocString PIP = "Pip";
                        public static LocString D6 = "D6";
                        public static LocString OGRE = "Shrumal Ogre";
                        public static LocString TESSERACT = "Tesseract";
                        public static LocString CAT = "Cat";
                        public static LocString OWO = "OwO Slickster";
                        public static LocString STAR = "Star";

                        public static LocString ROCKET = "Rocket";

                        // v1.2
                        public static LocString LUMAPLAYS = "Luma Plays Logo";
                        public static LocString KONNY87 = "Konny87 Logo";
                        public static LocString REDSTONE_LAMP = "Redstone Lamp";
                        public static LocString ARCHIVE_TUBE = "Archive Tube";
                        public static LocString KLEI_MUG = "Klei Mug";
                        public static LocString DIAMONDHATCH = "Diamond Hatch";
                        public static LocString GLITTERPUFT = "Glitter Puft";
                        public static LocString AI = "AI in a jar";
                        public static LocString SLAGMITE = "Slagmite"; // Slag (material) + Mite (creature), also pun on stalagmite
                        public static LocString CUDDLE_PIP = "Cuddle Pip";

                        // v1.3
                        public static LocString ANNOYING_DOG = "Dog";
                        public static LocString MUSHROOM = "Mushroom";
                        public static LocString GLOMMER = "Glommer"; // Don't Starve creature
                        public static LocString MINECRAFT_FROG = "Frog";
                        public static LocString HEART_CRYSTAL = "Heart Crystal"; // Terraria
                        public static LocString CAN = "Can"; // just an actual tin can
                        public static LocString OSKURD = "Oskurd"; // Twitch Streamer
                        public static LocString GRIND_THIS_GAME = "Grind This Game"; // Youtuber
                        public static LocString ECHO_RIDGE_GAMING = "Echo Ridge Gaming"; // Twitch Streamer
                        public static LocString LIVE_ACTION_PIXEL = "Live Action Pixel"; // Twitch Streamer
                        public static LocString LIFEGROW = "Lifegrow"; // Twitch Streamer
                    }
                }

                public class DECORPACKA_DEFAULTSTAINEDGLASSTILE
                {
                    public static LocString NAME = Utils.FormatAsLink(Utils.FormatAsLink("Stained Glass Tile", DefaultStainedGlassTileConfig.DEFAULT_ID));
                    public static LocString STAINED_NAME = "{element} " + Utils.FormatAsLink("Stained Glass Tile", DefaultStainedGlassTileConfig.DEFAULT_ID);
                    public static LocString DESC = $"Stained glass tiles are transparent tiles that provide a fashionable barrier against liquid and gas.";
                    public static LocString EFFECT = $"Used to build the walls and floors of rooms.\n\n" +
                        $"Allows {Utils.FormatAsLink("Light")} and {Utils.FormatAsLink("Decor")} pass through.\n\n{Utils.FormatAsLink("Open Palette", PaletteCodexEntry.PALETTE)}";
                }
            }
        }

        public class UI
        {
            public class CODEX
            {
                public static LocString PALETTE = "Stained Glass Palette";

                public class CATEGORYNAMES
                {
                    public static LocString MODS = "Mods";
                }
            }

            public class UISIDESCREENS
            {
                public class MOODLAMP_SIDE_SCREEN
                {
                    public static LocString TITLE = "Lamp type";
                }
            }

            public class BUILDINGEFFECTS
            {
                public static LocString THERMALCONDUCTIVITYCHANGE = "Thermal Conductivity: {0}";

                public class TOOLTIP
                {
                    public static LocString HIGHER = "higher";
                    public static LocString LOWER = "lower";

                    public static LocString THERMALCONDUCTIVITYCHANGE = "The dye {dyeElement} has {higherOrLower} thermal conductivity than {baseElement}, modifying it by {percent}.";
                }
            }

            public class USERMENUACTIONS
            {
                public class FABULOUS
                {
                    public class ENABLED
                    {
                        public static LocString NAME = "Fabulous On";
                        public static LocString TOOLTIP = "Bring the magic!";
                    }
                    public class DISABLED
                    {
                        public static LocString NAME = "Fabulous Off";
                        public static LocString TOOLTIP = "Take away the magic.";
                    }
                }
            }
        }

        public class MISC
        {
            public class TAGS
            {
                public static LocString DECORPACKA_STAINEDGLASSMATERIAL = "Glass Dye";
            }
        }
    }
}
