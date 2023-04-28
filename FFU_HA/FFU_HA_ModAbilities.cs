#pragma warning disable IDE0051
#pragma warning disable IDE0060

using HarmonyLib;

namespace FFU_Horror_Abyss {
    class FFU_HA_ModAbilities {
		[HarmonyPatch(typeof(AbilityBarUI), "CheckAbilityCooldown"), HarmonyPrefix]
		public static bool CheckAbilityCooldown_ReduceCooldown(AbilityBarUI __instance, bool refresh) {
			AbilityData currentAbilityData = (AbilityData)AccessTools.Field(typeof(AbilityBarUI), "currentAbilityData").GetValue(__instance);
			//ModLog.Message($"Current ability {currentAbilityData.name} has cooldown of {currentAbilityData.cooldown} and duration of {currentAbilityData.duration}");
			switch (currentAbilityData.name) {
				case "banish":
					currentAbilityData.duration = 60f;
					currentAbilityData.cooldown = 0.05f;
					break;
				default: break;
            }
			return true;
		}
		[HarmonyPatch(typeof(BanishAbility), "Activate"), HarmonyPrefix]
		static bool ActivateBanish_NoSanityLoss(BanishAbility __instance) {
			var sanityLossOnActivate = AccessTools.Field(typeof(BanishAbility), "sanityLossOnActivate");
			sanityLossOnActivate.SetValue(__instance, 0f);
			return true;
		}
		[HarmonyPatch(typeof(BoostAbility), "Activate"), HarmonyPrefix]
		static bool ActivateBoost_LongBoost(BoostAbility __instance) {
			/*var hasteHeatCap = AccessTools.Field(typeof(BoostAbility), "hasteHeatCap");
			var hasteHeatGain = AccessTools.Field(typeof(BoostAbility), "hasteHeatGain");
			var hasteHeatLoss = AccessTools.Field(typeof(BoostAbility), "hasteHeatLoss");
			var hasteHeatCooldown = AccessTools.Field(typeof(BoostAbility), "hasteHeatCooldown");
			ModLog.Message($"hasteHeatCap: {(float)hasteHeatCap.GetValue(__instance)}, " +
                $"hasteHeatGain: {(float)hasteHeatGain.GetValue(__instance)}, " +
                $"hasteHeatLoss: {(float)hasteHeatLoss.GetValue(__instance)}, " +
                $"hasteHeatCooldown: {(float)hasteHeatCooldown.GetValue(__instance)}");*/
			AccessTools.Field(typeof(BoostAbility), "hasteHeatCap").SetValue(__instance, 25f);
			AccessTools.Field(typeof(BoostAbility), "hasteHeatGain").SetValue(__instance, 0.2f);
			AccessTools.Field(typeof(BoostAbility), "hasteHeatLoss").SetValue(__instance, 1.6f);
			AccessTools.Field(typeof(BoostAbility), "hasteHeatCooldown").SetValue(__instance, 0.1f);
			return true;
		}
	}
}