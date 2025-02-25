﻿using HarmonyLib;
using PrintingPodRecharge.Cmps;
using PrintingPodRecharge.Items;

namespace PrintingPodRecharge.Patches
{
    public class ImmigrationPatches
    {
        [HarmonyPriority(Priority.Last)]
        [HarmonyPatch(typeof(Immigration), "OnPrefabInit")]
        public class Immigration_OnPrefabInit_Patch
        {
            public static void Postfix(Immigration __instance)
            {
                __instance.gameObject.AddOrGet<ImmigrationModifier>().LoadBundles();
            }
        }

        [HarmonyPatch(typeof(Immigration), "RandomCarePackage")]
        public class Immigration_RandomCarePackage_Patch
        {
            public static void Postfix(ref CarePackageInfo __result)
            {
                if (ImmigrationModifier.Instance.IsOverrideActive)
                {
                    __result = ImmigrationModifier.Instance.GetRandomPackage();
                }
            }
        }

        [HarmonyPatch(typeof(Immigration), "EndImmigration")]
        public class Immigration_EndImmigration_Patch
        {
            public static void Postfix()
            {
                ImmigrationModifier.Instance.SetModifier(Bundle.None);
            }
        }

        [HarmonyPatch(typeof(Immigration))]
        [HarmonyPatch("ConfigureCarePackages")]
        public static class Immigration_ConfigureCarePackages_Patch
        {
            public static void Postfix(ref CarePackageInfo[] ___carePackages)
            {
                if(Mod.IsSomeRerollModHere)
                {
                    ___carePackages = ___carePackages.AddToArray(new CarePackageInfo(BioInkConfig.DEFAULT, 2f, null));
                }
            }
        }
    }
}
