#pragma warning disable IDE0051
#pragma warning disable IDE0060

using HarmonyLib;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace FFU_Horror_Abyss {
    class FFU_HA_ModShopStock {
        [HarmonyPatch(typeof(ShopData), "GetNewStock"), HarmonyPostfix]
        static void GetNewStock_MoreResources(ShopData  __instance, ref List<SpatialItemData> __result) {
            bool debugInternal = false;
            if (debugInternal) {
                ModLog.Warning($"LIST OF ITEMS IN SHOP:");
                foreach (SpatialItemData item in __result) ModLog.Message($"Type: {item.itemType}, Subtype: {item.itemSubtype}, ID: {item.id}, Name: {item.itemNameKey.GetLocalizedString()}, Value: {item.value}, Instance: {item.GetInstanceID()}");
            }
            if (FFU_HA_Defs.refItemManager != null) {
                if (__result.Find(x => x.id == "rod11") && __result.Find(x => x.id == "rod15")) {
                    if (!__result.Find(x => x.id == "rod1")) // Basic Fishing Pole
                        __result.Add(FFU_HA_Defs.refItemManager.GetItemDataById<SpatialItemData>("rod1"));
                    if (!__result.Find(x => x.id == "rod21")) // Custom Rod
                        __result.Add(FFU_HA_Defs.refItemManager.GetItemDataById<SpatialItemData>("rod21"));
                    if (!__result.Find(x => x.id == "rod8")) // Viscera Crane
                        __result.Add(FFU_HA_Defs.refItemManager.GetItemDataById<SpatialItemData>("rod8"));
                    if (!__result.Find(x => x.id == "rod19")) // Sinew Spindle
                        __result.Add(FFU_HA_Defs.refItemManager.GetItemDataById<SpatialItemData>("rod19"));
                    if (!__result.Find(x => x.id == "rod16")) // Tendon Rod
                        __result.Add(FFU_HA_Defs.refItemManager.GetItemDataById<SpatialItemData>("rod16"));
                    if (!__result.Find(x => x.id == "rod17")) // Encrusted Talisman
                        __result.Add(FFU_HA_Defs.refItemManager.GetItemDataById<SpatialItemData>("rod17"));
                    if (__result.FindAll(x => x.id == "rod20").Count < 4) // Sign of Ruin
                        for (int i = 0; i < 4; i++) __result.Add(FFU_HA_Defs.refItemManager.GetItemDataById<SpatialItemData>("rod20"));
                    ModLog.Warning($"Shop item list updated: added more fishing equipment.");
                }
                if (__result.Find(x => x.id == "engine6")) {
                    if (__result.FindAll(x => x.id == "engine6").Count < 4) // Jet Drive Engine
                        for (int i = 0; i < 3; i++) __result.Add(FFU_HA_Defs.refItemManager.GetItemDataById<SpatialItemData>("engine6"));
                    if (__result.FindAll(x => x.id == "engine10").Count < 4) // Arterial Engine
                        for (int i = 0; i < 4; i++) __result.Add(FFU_HA_Defs.refItemManager.GetItemDataById<SpatialItemData>("engine10"));
                    if (__result.FindAll(x => x.id == "engine1").Count < 2) // Peculiar Engine
                        for (int i = 0; i < 2; i++) __result.Add(FFU_HA_Defs.refItemManager.GetItemDataById<SpatialItemData>("engine1"));
                    if (!__result.Find(x => x.id == "engine9")) // Weak Valve Engine
                        __result.Add(FFU_HA_Defs.refItemManager.GetItemDataById<SpatialItemData>("engine9"));
                    ModLog.Warning($"Shop item list updated: added multiple engines.");
                }
                if (__result.Find(x => x.id == "light5")) {
                    if (__result.FindAll(x => x.id == "light5").Count < 2) // Incandescent Array
                        __result.Add(FFU_HA_Defs.refItemManager.GetItemDataById<SpatialItemData>("light5"));
                    if (__result.FindAll(x => x.id == "light6").Count < 2) // Flame of the Sky
                        for (int i = 0; i < 2; i++) __result.Add(FFU_HA_Defs.refItemManager.GetItemDataById<SpatialItemData>("light6"));
                    ModLog.Warning($"Shop item list updated: added high-end lamps.");
                }
                if (__result.Find(x => x.id == "pot7")) {
                    if (__result.FindAll(x => x.id == "pot7").Count < 2) // Reinforced Crab Pot
                        __result.Add(FFU_HA_Defs.refItemManager.GetItemDataById<SpatialItemData>("pot7"));
                    if (__result.FindAll(x => x.id == "pot8").Count < 2) // Mouth of the Deep
                        for (int i = 0; i < 2; i++) __result.Add(FFU_HA_Defs.refItemManager.GetItemDataById<SpatialItemData>("pot8"));
                    ModLog.Warning($"Shop item list updated: added high-end crab pots.");
                }
                if (__result.Find(x => x.id == "metal")) {
                    if (!__result.Find(x => x.id == "lumber")) 
                        for (int i = 0; i < 4; i++) __result.Add(FFU_HA_Defs.refItemManager.GetItemDataById<SpatialItemData>("lumber"));
                    if (!__result.Find(x => x.id == "scrap")) 
                        for (int i = 0; i < 4; i++) __result.Add(FFU_HA_Defs.refItemManager.GetItemDataById<SpatialItemData>("scrap"));
                    if (!__result.Find(x => x.id == "cloth")) 
                        for (int i = 0; i < 4; i++) __result.Add(FFU_HA_Defs.refItemManager.GetItemDataById<SpatialItemData>("cloth"));
                    ModLog.Warning($"Shop item list updated: added lumber, scrap & cloth.");
                }
            }
        }
    }
}