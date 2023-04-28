#pragma warning disable IDE0051

using HarmonyLib;

namespace FFU_Horror_Abyss {
	class FFU_HA_ModResearch {
		[HarmonyPatch(typeof(ResearchHelper), "SpendResearchItem"), HarmonyPrefix]
		static bool SpendResearchItem_Infinite(ResearchHelper __instance, ref bool __result) {
			bool hasPartInInventory = true;
			HarvestableItemData researchItemData = (HarvestableItemData)AccessTools.Field(typeof(ResearchHelper), "researchItemData").GetValue(__instance);
			SpatialItemInstance itemInstanceById = GameManager.Instance.SaveData.GetItemInstanceById<SpatialItemInstance>(new string[1] { researchItemData.id }, allowDamaged: false, GameManager.Instance.SaveData.Inventory);
			if (itemInstanceById == null) {
				itemInstanceById = GameManager.Instance.SaveData.GetItemInstanceById<SpatialItemInstance>(new string[1] { researchItemData.id }, allowDamaged: false, GameManager.Instance.SaveData.Storage);
				if (!(itemInstanceById != null)) {
					__result = false;
					return false;
				}
				hasPartInInventory = false;
			}
			var totalPartCountField = AccessTools.Field(typeof(ResearchHelper), "totalPartCount");
			int totalPartCount = (int)totalPartCountField.GetValue(__instance);
			if (totalPartCount > 1) {
				if (hasPartInInventory) {
					GameManager.Instance.SaveData.Inventory.RemoveObjectFromGridData(itemInstanceById, notify: false);
				} else {
					GameManager.Instance.SaveData.Storage.RemoveObjectFromGridData(itemInstanceById, notify: false);
				}
				totalPartCount--;
				totalPartCountField.SetValue(__instance, totalPartCount);
			}
			GameManager.Instance.UI.ResearchWindow.SpendResearchSuccess();
			GameEvents.Instance.TriggerItemInventoryChanged(researchItemData);
			__result = true;
			return false;
		}
    }
}