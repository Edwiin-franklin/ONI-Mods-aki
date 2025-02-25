﻿using TUNING;
using UnityEngine;

namespace DecorPackA.Buildings.MoodLamp
{
    public class MoodLampConfig : IBuildingConfig
    {
        public static string ID = Mod.PREFIX + "MoodLamp";

        public override BuildingDef CreateBuildingDef()
        {
            var def = BuildingTemplates.CreateBuildingDef(
               ID,
               1,
               2,
               "moodlamp_kanim",
               BUILDINGS.HITPOINTS.TIER2,
               BUILDINGS.CONSTRUCTION_TIME_SECONDS.TIER4,
               BUILDINGS.CONSTRUCTION_MASS_KG.TIER2,
               MATERIALS.TRANSPARENTS,
               BUILDINGS.MELTING_POINT_KELVIN.TIER1,
               BuildLocationRule.OnFloor,
               new EffectorValues(Mod.Settings.MoodLamp.Decor.Amount, Mod.Settings.MoodLamp.Decor.Range),
               NOISE_POLLUTION.NONE
           );

            def.Floodable = false;
            def.Overheatable = false;
            def.AudioCategory = "Glass";
            def.BaseTimeUntilRepair = -1f;
            def.ViewMode = OverlayModes.Light.ID;
            def.DefaultAnimState = "slab";
            def.PermittedRotations = PermittedRotations.FlipH;

            def.RequiresPowerInput = true;
            def.ExhaustKilowattsWhenActive = Mod.Settings.MoodLamp.PowerUse.ExhaustKilowattsWhenActive;
            def.EnergyConsumptionWhenActive = Mod.Settings.MoodLamp.PowerUse.EnergyConsumptionWhenActive;
            def.SelfHeatKilowattsWhenActive = Mod.Settings.MoodLamp.PowerUse.SelfHeatKilowattsWhenActive;

            def.DefaultAnimState = "variant_1_off";

            return def;
        }

        public override void DoPostConfigurePreview(BuildingDef def, GameObject go)
        {
            var lightShapePreview = go.AddComponent<LightShapePreview>();
            lightShapePreview.lux = Mod.Settings.MoodLamp.Lux.Amount;
            lightShapePreview.radius = Mod.Settings.MoodLamp.Lux.Range;
            lightShapePreview.shape = LightShape.Circle;
        }

        public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
        {
            go.AddTag(RoomConstraints.ConstraintTags.LightSource);
            go.AddTag(RoomConstraints.ConstraintTags.Decor20);
            go.AddTag(ModAssets.Tags.noPaint);
            go.AddTag(GameTags.Decoration);
            go.AddOrGet<CopyBuildingSettings>().copyGroupTag = ID;
        }

        public override void DoPostConfigureComplete(GameObject go)
        {
            go.AddOrGet<EnergyConsumer>();
            go.AddOrGet<LoopingSounds>();

            var light2d = go.AddOrGet<Light2D>();
            light2d.overlayColour = LIGHT2D.FLOORLAMP_OVERLAYCOLOR;
            light2d.Color = Color.white;
            light2d.Range = Mod.Settings.MoodLamp.Lux.Range;
            light2d.Lux = Mod.Settings.MoodLamp.Lux.Amount;
            light2d.shape = LightShape.Circle;
            light2d.Offset = new Vector2(0, 1f);
            light2d.drawOverlay = true;

            go.AddComponent<MoodLamp>();
            go.AddOrGetDef<PoweredController.Def>();
        }
    }
}
