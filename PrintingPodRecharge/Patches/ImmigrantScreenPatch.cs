﻿using HarmonyLib;
using PrintingPodRecharge.Cmps;
using System.Collections;
using UnityEngine;

namespace PrintingPodRecharge.Patches
{
    public class ImmigrantScreenPatch
    {
        [HarmonyPatch(typeof(ImmigrantScreen), "OnRejectionConfirmed")]
        public class ImmigrantScreen_OnRejectionConfirmed_Patch
        {
            public static void Postfix()
            {
                CustomDupe.rolledData.Clear();
            }
        }

        [HarmonyPatch(typeof(CarePackageContainer), "GenerateCharacter")]
        public class CarePackageContainer_GenerateCharacter_Patch
        {
            public static void Postfix(CarePackageContainer __instance)
            {
                __instance.StartCoroutine(TintCarePackageColorCoroutine(("Details/PortraitContainer/BG", __instance)));
            }
        }

        // need to wait just a little, or something goes wrong and the background will be offset and weird
        public static IEnumerator TintCarePackageColorCoroutine((string Path, KScreen Instance) args)
        {
            yield return new WaitForEndOfFrame();
            TintBG(args.Instance, args.Path);
        }

        private static void TintBG(KScreen __instance, string path)
        {
            if (!ImmigrationModifier.Instance.IsOverrideActive)
            {
                return;
            }

            var activeBundle = ImmigrationModifier.Instance.GetActiveCarePackageBundle();

            if (activeBundle == null || !activeBundle.replaceAnim)
            {
                return;
            }

            var animBg = __instance.transform.Find(path);

            if (animBg == null)
            {
                return;
            }

            var kbac = animBg.GetComponent<KBatchedAnimController>();

            if (kbac == null)
            {
                return;
            }

            if (activeBundle.bgAnim != null)
            {
                kbac.SwapAnims(activeBundle.bgAnim);
            }

            var bg = activeBundle.printerBgTint;
            var glow = activeBundle.printerBgTintGlow;

            if (ImmigrationModifier.Instance.randomColor && CustomDupe.rolledData.TryGetValue((__instance as CharacterContainer).Stats, out var data))
            {
                bg = GetComplementaryColor(data.hairColor);
                glow = GetComplementaryColor(data.hairColor);
            }

            kbac.SetSymbolTint("forever", bg);
            kbac.SetSymbolTint("grid_bloom", glow);
            kbac.SetSymbolTint("inside_rough", glow);

            kbac.SetDirty();
            kbac.UpdateAnim(1);
            kbac.Play("crewSelect_bg", KAnim.PlayMode.Loop);
        }

        private static Color GetComplementaryColor(Color color)
        {
            Color.RGBToHSV(color, out var h, out _, out _);

            h = (h + 0.5f) % 1f; // invert hue
            var s = 0.55f; // not too saturated. against the blue of the window this looks vibrant enough
            var v = 0.75f; // bright

            return Color.HSVToRGB(h, s, v);
        }
    }
}
