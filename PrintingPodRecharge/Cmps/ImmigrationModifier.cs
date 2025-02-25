﻿using FUtility;
using KSerialization;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;
using Klei.CustomSettings;

namespace PrintingPodRecharge.Cmps
{
    [SerializationConfig(MemberSerialization.OptIn)]
    public class ImmigrationModifier : KMonoBehaviour
    {
        [Serialize]
        private Bundle selectedBundle;

        [Serialize]
        public Bundle refundBundle;

        public bool IsOverrideActive;

        public Bundle ActiveBundle => IsOverrideActive ? selectedBundle : Bundle.None;

        public CarePackageBundle GetActiveCarePackageBundle()
        {
            var bundle = ActiveBundle;
            return bundle != Bundle.None && bundles.TryGetValue(ActiveBundle, out var result) ? result : null;
        }

        public int maxItems = 4;
        public int dupeCount = 1;
        public int itemCount = 3;

        public bool randomColor = false;

        public static ImmigrationModifier Instance { get; private set; }

        private Dictionary<Bundle, CarePackageBundle> bundles = new Dictionary<Bundle, CarePackageBundle>();

        protected override void OnPrefabInit()
        {
            base.OnPrefabInit();
            Instance = this;
        }

        public bool IsBundleAvailable(Bundle bundle)
        {
            return true;
            /* 
            // half done attempt to make non dupe packages not appear if care packages were disabled
            return bundle == Bundle.None || 
                (bundles.TryGetValue(bundle, out var package) && package.alwaysAvailable) || 
                CustomGameSettings.Instance.GetCurrentQualitySetting(CustomGameSettingConfigs.CarePackages).id == "Enabled";
            */
        }

        protected override void OnSpawn()
        {
            base.OnSpawn();

            if (selectedBundle != Bundle.None)
            {
                SetModifier(selectedBundle);
            }
        }

        public void LoadBundles()
        {
            BundleLoader.LoadBundles(ref bundles);
        }

        public void SetRefund(Bundle bundle)
        {
            Log.Debuglog("set refund to " + bundle);
            refundBundle = bundle;
        }

        public void SetModifier(Bundle bundle)
        {
            Log.Debuglog("Set modifier to " + bundle.ToString());
            selectedBundle = bundle;

            if (bundle == Bundle.None)
            {
                IsOverrideActive = false;
                return;
            }

            SetRefund(bundle);
            IsOverrideActive = true;

            var current = bundles[selectedBundle];

            randomColor = selectedBundle == Bundle.Shaker;

            dupeCount = current.GetDupeCount();
            itemCount = current.GetItemCount();
        }

        public int GetDupeCount(int otherwise)
        {
            return IsOverrideActive ? dupeCount : otherwise;
        }

        public int GetItemCount(int otherwise)
        {
            return IsOverrideActive ? itemCount : otherwise;
        }

        protected override void OnCleanUp()
        {
            base.OnCleanUp();
            Instance = null;
        }

        public CarePackageInfo GetRandomPackage()
        {
            if (bundles[selectedBundle]?.info == null)
            {
                return null;
            }

            var infos = bundles[selectedBundle].info.Where(i => i.requirement == null || i.requirement.Invoke()).ToList();

            if (infos == null)
            {
                return null;
            }

            Log.Debuglog("Selecting package from " + infos.Count);

            return infos.GetRandom();
        }

        public class CarePackageBundle
        {
            public List<CarePackageInfo> info;
            private int dupeCountMin;
            private int dupeCountMax;
            private int packageCountMin;
            private int packageCountMax;
            public Color printerBgTint;
            public Color printerBgTintGlow;
            public bool replaceAnim;
            public KAnimFile[] bgAnim;
            public bool alwaysAvailable;

            public CarePackageBundle(List<CarePackageInfo> info, int dupeCountMin, int dupeCountMax, int packageCountMin, int packageCountMax, Color bg, Color fx, bool alwaysAvailable, string bgAnim = "rpp_greyscale_dupeselect_kanim") : this(info, dupeCountMin, dupeCountMax, packageCountMin, packageCountMax, alwaysAvailable)
            {
                printerBgTint = bg;
                printerBgTintGlow = fx;
                replaceAnim = true;
                this.bgAnim = new KAnimFile[] { Assets.GetAnim(bgAnim) };
            }

            public CarePackageBundle(List<CarePackageInfo> info, int dupeCountMin, int dupeCountMax, int packageCountMin, int packageCountMax, bool alwaysAvailable)
            {
                this.info = info;
                this.dupeCountMin = dupeCountMin;
                this.dupeCountMax = dupeCountMax;
                this.packageCountMin = packageCountMin;
                this.packageCountMax = packageCountMax;
                this.alwaysAvailable = alwaysAvailable;
            }

            public int GetItemCount()
            {
                Log.Debuglog("rolling random from", packageCountMin, packageCountMax);
                return UnityEngine.Random.Range(packageCountMin, packageCountMax + 1);
            }

            public int GetDupeCount()
            {
                return UnityEngine.Random.Range(dupeCountMin, dupeCountMax + 1);
            }
        }

        private int selection = 0;

#if true
        private void OnGUI()
        {
            if(!Mod.Settings.DebugTools)
            {
                return;
            }

            GUILayout.BeginArea(new Rect(10, 300, 200, 500));

            GUILayout.Box("Modifiers");

            GUILayout.Label("Current Modifier: " + selectedBundle.ToString());

            selection = GUILayout.SelectionGrid(selection, Enum.GetNames(typeof(Bundle)), 2);

            if (GUILayout.Button("Set Bundle"))
            {
                if((Bundle)selection == Bundle.Twitch)
                {
                    return;
                }

                SetModifier((Bundle)selection);
            }

            if (GUILayout.Button($"Force Print {(Bundle)selection}"))
            {
                if ((Bundle)selection == Bundle.Twitch)
                {
                    return;
                }

                SetModifier((Bundle)selection);

                ImmigrantScreen.InitializeImmigrantScreen(GameUtil.GetActiveTelepad().GetComponent<Telepad>());
                Game.Instance.Trigger((int)GameHashes.UIClear);
            }

            GUILayout.EndArea();
        }
#endif
    }
}
