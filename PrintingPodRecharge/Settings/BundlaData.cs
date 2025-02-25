﻿namespace PrintingPodRecharge.Settings
{
    public class BundlaData
    {
        public Rando rando;
        public Rando ActiveRando() => Mod.errorOverrides ?? rando;
        public Vacillating vacillating;
        public Egg egg;

        public class Egg
        {
            public int EggCycle { get; set; } = 225;

            public int RainbowEggCycle { get; internal set; } = 250;
        }

        public class Rando
        {
            public int MinimumSkillBudgetModifier { get; set; }

            public int MaximumSkillBudgetModifier { get; set; }

            public int MaximumTotalBudget { get; set; }

            public int MaxBonusPositiveTraits { get; set; }

            public int MaxBonusNegativeTraits { get; set; }

            public float ChanceForVacillatorTrait { get; set; }

            public float ChanceForNoNegativeTraits { get; set; }
        }

        public class Vacillating
        {
            public int ExtraSkillBudget { get; set; }
        }
    }
}
