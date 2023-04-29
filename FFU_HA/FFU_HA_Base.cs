#pragma warning disable IDE0051

using BepInEx;
using HarmonyLib;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace FFU_Horror_Abyss {
    [BepInDependency("mod.fightforuniverse.modlog")]
    [BepInPlugin(FFU_HA_Defs.modID, FFU_HA_Defs.modName, FFU_HA_Defs.modVersion)]
    public class FFU_HA_Base : BaseUnityPlugin {
        private void Awake() {
            FFU_HA_Defs.InitCfg();
            ModLog.Warning($"{FFU_HA_Defs.modName} v{FFU_HA_Defs.modVersion} configuration is loaded!");
            Harmony.CreateAndPatchAll(typeof(FFU_HA_ModBase));
            if (FFU_HA_Defs.modInfiniteResearch.Value) {
                Harmony.CreateAndPatchAll(typeof(FFU_HA_ModResearch));
                ModLog.Warning($"Submodule 'Infinite Research' is loaded and applied!");
            }
            if (FFU_HA_Defs.modBoostedAbilities.Value) {
                Harmony.CreateAndPatchAll(typeof(FFU_HA_ModSkills));
                ModLog.Warning($"Submodule 'Boosted Abilities' is loaded and applied!");
            }
            if (FFU_HA_Defs.modBiggerShopStock.Value) {
                Harmony.CreateAndPatchAll(typeof(FFU_HA_ModShopStock));
                ModLog.Warning($"Submodule 'Bigger Shop Stock' is loaded and applied!");
            }
            ModLog.Warning($"{FFU_HA_Defs.modName} v{FFU_HA_Defs.modVersion} submodules are loaded!");
        }
        public static void ModifyItem(SpatialItemData item) {
            if (item == null) return;
            if (item.itemType == ItemType.EQUIPMENT)
                if (item.id != "dredge1") 
                    item.canBeSoldByPlayer = true;
            switch (item.itemSubtype) {
                case ItemSubtype.ENGINE: ModifyEngine(item as EngineItemData); break;
                case ItemSubtype.LIGHT: ModifyLight(item as LightItemData); break;
                case ItemSubtype.NET: ModifyNet(item as DeployableItemData); break;
                case ItemSubtype.POT: ModifyPot(item as DeployableItemData); break;
                case ItemSubtype.ROD: ModifyRod(item as RodItemData); break;
                default: break;
            }
        }
        public static void ModifyEngine(EngineItemData engine) {
            if (engine == null) return;
            switch (engine.id) {
                case "engine1":
                    engine.value = 175;
                    break;
                case "engine10":
                    engine.speedBonus = 12;
                    engine.value = 450;
                    break;
                default: break;
            }
        }
        public static void ModifyLight(LightItemData light) {
            if (light == null) return;
            switch (light.id) {
                case "light6":
                    light.range = 100;
                    light.lumens = 5000;
                    light.value = 1250;
                    break;
                default: break;
            }
        }
        public static void ModifyNet(DeployableItemData net) {
            if (net == null) return;
            switch (net.id) {
                case "net6":
                    net.harvestableTypes = new HarvestableType[] {
                        HarvestableType.COASTAL,
                        HarvestableType.SHALLOW,
                        HarvestableType.VOLCANIC,
                        HarvestableType.MANGROVE,
                        HarvestableType.OCEANIC};
                    break;
                default: break;
            }
        }
        public static void ModifyPot(DeployableItemData pot) {
            if (pot == null) return;
            switch (pot.id) {
                default: break;
            }
        }
        public static void ModifyRod(RodItemData rod) {
            if (rod == null) return;
            switch (rod.id) {
                case "rod17":
                    rod.harvestableTypes = new HarvestableType[] {
                        HarvestableType.COASTAL,
                        HarvestableType.SHALLOW,
                        HarvestableType.VOLCANIC,
                        HarvestableType.MANGROVE,
                        HarvestableType.OCEANIC,
                        HarvestableType.ABYSSAL,
                        HarvestableType.HADAL};
                    rod.value = 2500;
                    break;
                case "rod20":
                    rod.value = 1000;
                    break;
                default: break;
            }
        }
    }
}
