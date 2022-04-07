﻿using FUtility.FUI;
using UnityEngine;

namespace TrueTiles
{
    internal class ModAssets
    {
        public static class Prefabs
        {
            public static GameObject settingsDialog;
        }

        public static void LateLoadAssets()
        {
            AssetBundle bundle = FUtility.Assets.LoadAssetBundle("truetilesassets");

            Prefabs.settingsDialog = bundle.LoadAsset<GameObject>("SettingsDialog");
            TMPConverter tmp = new TMPConverter();
            tmp.ReplaceAllText(Prefabs.settingsDialog);
        }
    }
}
