﻿using System.Collections.Generic;
using System.Linq;
using TUNING;
using UnityEngine;

namespace PrintingPodRecharge
{
    public class DupeGenHelper
    {
        private static readonly HashSet<string> forbiddenNames = new HashSet<string>()
        {
           "Pener",
           "Pee"
        };

        public static readonly int[] allowedHairIds = new[]
        {
            1,
            2,
            3,
            4,
            5,
            6,
            7,
            8,
            9,
            10,
            11,
            12,
            13,
            14,
            15,
            16,
            17,
            18,
            19,
            30,
            36,
            37,
            43,
            44
        };

        public static Personality GetRandomPersonality()
        {
            var skin = Random.Range(1, 5);
            return new Personality(
                    "shook_",
                    "Doesntmatter",
                    Random.value > 0.5f ? "female" : "male",
                    "",
                    DUPLICANTSTATS.STRESSTRAITS.GetRandom().id,
                    DUPLICANTSTATS.JOYTRAITS.GetRandom().id,
                    "",
                    "",
                    skin,
                    skin,
                    1,
                    Random.Range(1, 6),
                    DupeGenHelper.allowedHairIds.GetRandom(),
                    Random.Range(0, 5),
                    "desc",
                    false);
        }

        public static int AddRandomTraits(MinionStartingStats __instance, int min, int max, List<DUPLICANTSTATS.TraitVal> pool)
        {
            if (max <= 0)
            {
                return 0;
            }

            var traitDb = Db.Get().traits;

            var list = new List<DUPLICANTSTATS.TraitVal>(pool);
            list.RemoveAll(l => __instance.Traits.Any(t => IsTraitExclusive(l, t.Id)));

            var traitPool = list
                .Select(t => traitDb.Get(t.id))
                .Except(__instance.Traits)
                .ToList();

            traitPool.Shuffle();

            var randomExtra = Random.Range(min, max);
            randomExtra = Mathf.Min(traitPool.Count, randomExtra);

            for (var i = 0; i < randomExtra; i++)
            {
                __instance.Traits.Add(traitPool[i]);
            }

            return randomExtra;
        }

        private static bool IsTraitExclusive(DUPLICANTSTATS.TraitVal l, string trait)
        {
            if (l.mutuallyExclusiveTraits == null)
            {
                return false;
            }
            foreach (var exclusiveTrait in l.mutuallyExclusiveTraits)
            {
                if (exclusiveTrait == trait)
                {
                    return true;
                }
            }

            return false;
        }

        public static void SetRandomName(MinionStartingStats __instance)
        {
            var name = GetRandomName();
            if (!name.IsNullOrWhiteSpace())
            {
                __instance.Name = name;
                var key = "PrintingPodRecharge.STRINGS.DUPLICANTS.PERSONALITIES." + name.ToUpperInvariant().Replace("-", "");
                Strings.Add(key, name);
                __instance.NameStringKey = key;
            }
        }

        public static string GetRandomName()
        {
            var name = "";
            var maxAttempts = 16;

            var prefixes = STRINGS.MISC.NAME_PREFIXES.text.Split(',');
            var suffixes = STRINGS.MISC.NAME_SUFFIXES.text.Split(',');

            if (prefixes.Length == 0 || suffixes.Length == 0)
            {
                return null;
            }

            while ((name.IsNullOrWhiteSpace() || forbiddenNames.Contains(name)) && maxAttempts-- > 0)
            {
                name = prefixes.GetRandom() + suffixes.GetRandom();
            }

            return name;
        }

        public static Color GetRandomHairColor()
        {
            return Random.ColorHSV(0, 1, 0f, 0.9f, 0.1f, 1f);
        }
    }
}
