﻿using Klei.AI;
using UnityEngine;
using static SpookyPumpkinSO.STRINGS.CREATURES.SPECIES.SP_GHOSTPIP;

namespace SpookyPumpkinSO.Content.GhostPip
{
    public class GhostSquirrelConfig : IEntityConfig
    {
        public const string ID = "SP_GhostSquirrel";
        public const string BASE_TRAIT_ID = "SP_GhostSquirrelBaseTrait";

        public GameObject CreatePrefab()
        {
            var placedEntity = EntityTemplates.CreatePlacedEntity(
                id: ID,
                name: NAME,
                desc: DESC,
                mass: 1f,
                anim: Assets.GetAnim("sp_ghostpip_kanim"),
                initialAnim: "idle_loop",
                sceneLayer: Grid.SceneLayer.Creatures,
                width: 1,
                height: 1,
                decor: TUNING.DECOR.BONUS.TIER1,
                noise: new EffectorValues());

            var trait = Db.Get().CreateTrait(BASE_TRAIT_ID, NAME, DESC, null, true, null, true, true);
            trait.Add(new AttributeModifier(Db.Get().Amounts.HitPoints.maxAttribute.Id, float.PositiveInfinity));
            trait.Add(new AttributeModifier(Db.Get().Amounts.Age.maxAttribute.Id, float.PositiveInfinity));

            placedEntity.AddTag(GameTags.Creatures.Walker);

            if (Mod.Config.GhostPipLight)
            {
                var light2d = placedEntity.AddComponent<Light2D>();
                light2d.overlayColour = TUNING.LIGHT2D.FLOORLAMP_OVERLAYCOLOR;
                light2d.Color = Color.green;
                light2d.Range = 1f;
                light2d.shape = LightShape.Circle;
                light2d.Offset = new Vector2(0, 0.3f);
                light2d.drawOverlay = true;
                light2d.Lux = 300;
            }

            EntityTemplates.ExtendEntityToBasicCreature(
                placedEntity,
                FactionManager.FactionID.Friendly,
                BASE_TRAIT_ID,
                onDeathDropID: "",
                onDeathDropCount: 0,
                warningLowTemperature: 0,
                warningHighTemperature: 9999,
                lethalLowTemperature: 0,
                lethalHighTemperature: 9999);

            placedEntity.AddOrGetDef<CreatureFallMonitor.Def>();
            placedEntity.AddOrGet<Trappable>();
            placedEntity.AddOrGet<LoopingSounds>().updatePosition = true;
            placedEntity.AddOrGet<UserNameable>();

            var storage = placedEntity.AddComponent<Storage>();
            storage.showInUI = false;

            var manualDeliveryKg = placedEntity.AddOrGet<ManualDeliveryKG>();
            manualDeliveryKg.SetStorage(storage);
            manualDeliveryKg.choreTypeIDHash = Db.Get().ChoreTypes.FarmFetch.IdHash;
            manualDeliveryKg.RequestedItemTag = GrilledPrickleFruitConfig.ID;
            manualDeliveryKg.refillMass = 1f;
            manualDeliveryKg.MinimumMass = 1f;
            manualDeliveryKg.capacity = 1f;

            EntityTemplates.AddCreatureBrain(placedEntity,
                new ChoreTable.Builder()
                .Add(new FallStates.Def())
                .Add(new BaggedStates.Def())
                .Add(new DebugGoToStates.Def())
                .Add(new FixedCaptureStates.Def())
                .Add(new IdleStates.Def()),
                GameTags.Creatures.Species.SquirrelSpecies, null);

            placedEntity.AddComponent<SeedTrader>();
            placedEntity.AddComponent<GhostSquirrel>();

            EntityTemplates.CreateAndRegisterBaggedCreature(placedEntity, true, true);

            return placedEntity;
        }

        public void OnPrefabInit(GameObject prefab)
        {
        }

        public void OnSpawn(GameObject inst)
        {
        }

        string[] IEntityConfig.GetDlcIds()
        {
            return DlcManager.AVAILABLE_ALL_VERSIONS;
        }
    }
}
