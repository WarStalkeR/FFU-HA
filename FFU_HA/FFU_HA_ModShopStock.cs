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
            //List<object> alwaysInStock = (List<object>)AccessTools.Field(typeof(ShopData), "alwaysInStock").GetValue(__instance);
            if (FFU_HA_Defs.refItemList is null) {
                FFU_HA_Defs.refItemList = new List<SpatialItemData>();
                var tempList = Resources.FindObjectsOfTypeAll<SpatialItemData>().ToList();
                tempList.Sort((x, y) => x.GetInstanceID().CompareTo(y.GetInstanceID()));
                foreach (var item in tempList) if (FFU_HA_Defs.refItemList.Find(x => x.id == item.id) == null) FFU_HA_Defs.refItemList.Add(item);
                if (FFU_HA_Defs.debugListAllItems.Value) {
                    ModLog.Warning($"LIST OF ALL ITEMS IN GAME:");
                    foreach (SpatialItemData item in FFU_HA_Defs.refItemList) ModLog.Message($"Type: {item.itemType}, Subtype: {item.itemSubtype}, ID: {item.id}, Name: {item.itemNameKey.GetLocalizedString()}, Instance: {item.GetInstanceID()}");
                }
            }
            if (FFU_HA_Defs.debugListShopItems.Value) {
                ModLog.Warning($"LIST OF ITEMS IN SHOP:");
                foreach (SpatialItemData item in __result) ModLog.Message($"Type: {item.itemType}, Subtype: {item.itemSubtype}, ID: {item.id}, Name: {item.itemNameKey.GetLocalizedString()}, Instance: {item.GetInstanceID()}");
            }
            if (__result.Find(x => x.id == "metal")) {
                ModLog.Warning($"Shop item list updated!");
                var refLumber = FFU_HA_Defs.refItemList.Find(x => x.id == "lumber");
                var refScrap = FFU_HA_Defs.refItemList.Find(x => x.id == "scrap");
                var refCloth = FFU_HA_Defs.refItemList.Find(x => x.id == "cloth");
                if (refLumber != null) for (int i = 0; i < 5; i++) __result.Add(refLumber);
                if (refScrap != null) for (int i = 0; i < 5; i++) __result.Add(refScrap);
                if (refCloth != null) for (int i = 0; i < 5; i++) __result.Add(refCloth);
            }
        }
    }
}