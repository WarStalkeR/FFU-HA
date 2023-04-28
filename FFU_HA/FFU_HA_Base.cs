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
            if (FFU_HA_Defs.modInfiniteResearch.Value) {
                Harmony.CreateAndPatchAll(typeof(FFU_HA_ModResearch));
                ModLog.Warning($"Mod submodule 'InfiniteResearch' is loaded and applied!");
            }
            if (FFU_HA_Defs.modBoostedAbilities.Value) {
                Harmony.CreateAndPatchAll(typeof(FFU_HA_ModAbilities));
                ModLog.Warning($"Mod submodule 'BoostedAbilities' is loaded and applied!");
            }
            if (FFU_HA_Defs.modBiggerShopStock.Value) {
                Harmony.CreateAndPatchAll(typeof(FFU_HA_ModShopStock));
                ModLog.Warning($"Mod submodule 'BiggerShopStock' is loaded and applied!");
            }
            ModLog.Warning($"{FFU_HA_Defs.modName} v{FFU_HA_Defs.modVersion} submodules are loaded!");
        }
    }
}
