﻿using UnityEngine;
using static EdiblesManager;

namespace SpookyPumpkin
{
    public class PumkinPieConfig : IEntityConfig
    {
        public const string ID = "SP_PumkinPie";
        public static ComplexRecipe recipe;

        public GameObject CreatePrefab()
        {
            GameObject prefab = EntityTemplates.CreateLooseEntity(
                id: ID,
                name: STRINGS.ITEMS.FOOD.PUMPKINPIE.NAME,
                desc: STRINGS.ITEMS.FOOD.PUMPKINPIE.DESC,
                mass: 1f,
                unitMass: false,
                anim: Assets.GetAnim("sp_pumpkinpie_kanim"),
                initialAnim: "object",
                sceneLayer: Grid.SceneLayer.Front,
                collisionShape: EntityTemplates.CollisionShape.RECTANGLE,
                width: 0.8f,
                height: 0.4f,
                isPickupable: true,
                sortOrder: 0,
                element: SimHashes.Creature,
                additionalTags: null);

            FoodInfo foodInfo = new FoodInfo(
                id: ID,
                caloriesPerUnit: 6000000f,
                quality: 3,
                preserveTemperatue: 255.15f,
                rotTemperature: 277.15f,
                spoilTime: 60f,
                can_rot: true);

            return EntityTemplates.ExtendEntityToFood(prefab, foodInfo);
        }

        public void OnPrefabInit(GameObject inst)
        {
        }

        public void OnSpawn(GameObject inst)
        {
        }
    }
}
