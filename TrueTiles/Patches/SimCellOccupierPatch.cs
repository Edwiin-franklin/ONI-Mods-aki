﻿using HarmonyLib;

namespace TrueTiles.Patches
{
    public class SimCellOccupierPatch
    {
        [HarmonyPatch(typeof(SimCellOccupier), "OnSpawn")]
        public class SimCellOccupier_OnSpawn_Patch
        {
            public static void Postfix(SimCellOccupier __instance)
            {
                var cell = Grid.PosToCell(__instance);

                if (__instance.GetComponent<PrimaryElement>() is PrimaryElement primaryElement)
                {
                    ElementGrid.Add(cell, primaryElement.ElementID);
                }

                if(!__instance.doReplaceElement)
                {
                    TileVisualizer.RefreshCell(cell, ObjectLayer.FoundationTile, ObjectLayer.ReplacementTile);
                }
            }
        }

        [HarmonyPatch(typeof(SimCellOccupier), "OnModifyComplete")]
        public class SimCellOccupier_OnModifyComplete_Patch
        {
            public static void Postfix(SimCellOccupier __instance)
            {
                if(!__instance.doReplaceElement)
                {
                    return;
                }

                // TODO: check if tile is relevant to me

                var cell = Grid.PosToCell(__instance);

                TileVisualizer.RefreshCell(cell, ObjectLayer.FoundationTile, ObjectLayer.ReplacementTile);
            }
        }

        [HarmonyPatch(typeof(SimCellOccupier), "OnCleanUp")]
        public class SimCellOccupier_OnCleanup_Patch
        {
            public static void Prefix(SimCellOccupier __instance)
            {
                ElementGrid.Remove(Grid.PosToCell(__instance));
            }
        }
    }
}
