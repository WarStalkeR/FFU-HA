#pragma warning disable IDE0051
#pragma warning disable IDE0060

using HarmonyLib;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace FFU_Horror_Abyss {
    class FFU_HA_ModBase {
        [HarmonyPatch(typeof(ItemManager), "OnItemDataAddressablesLoaded"), HarmonyPrefix]
        static bool OnItemDataAddressablesLoaded_ModifyItems(ItemManager __instance, AsyncOperationHandle<IList<ItemData>> handle) {
            Debug.Log("[ItemManager] OnItemDataAddressablesLoaded() [Modded]");
            foreach (ItemData itemData in handle.Result) {
                try {
                    if (itemData as SpatialItemData != null) FFU_HA_Base.ModifyItem(itemData as SpatialItemData);
                } catch { Debug.LogWarning($"[ItemManager] OnItemDataAddressablesLoaded() failed at: {itemData.id}"); }
                __instance.allItems.Add(itemData);
            }
            AccessTools.Field(typeof(ItemManager), "_hasLoadedItems").SetValue(__instance, true);
            FFU_HA_Defs.refItemManager = __instance;
            return false;
        }
        [HarmonyPatch(typeof(ItemManager), "OnGameStarted"), HarmonyPrefix]
        static bool OnGameStarted_FetchModdedData(ItemManager __instance) {
            bool debugInternal = false;
            if (debugInternal) {
                ModLog.Warning($"LIST OF ALL ITEMS IN GAME:");
                foreach (var item in FFU_HA_Defs.refItemManager.GetAllItemsOfType<SpatialItemData>()) {
                    if (debugInternal) ModLog.Message($"Type: {item.itemType}, " +
                    $"Subtype: {item.itemSubtype}, " +
                    $"ID: {item.id}, " +
                    $"Name: {item.itemNameKey.GetLocalizedString()}, " +
                    $"Value: {(item != null ? item.value : "0")}, " +
                    $"Instance: {item.GetInstanceID()}");
                }
            }
            return true;
        }
        /*
        [HarmonyPatch(typeof(GameManager), "Awake"), HarmonyPostfix]
        static void Awake_EnableLogging() {
            Debug.unityLogger.logEnabled = true;
        }
        */
    }
}
