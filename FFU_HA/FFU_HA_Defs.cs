using BepInEx;
using BepInEx.Configuration;
using System.Collections.Generic;
using System.IO;

namespace FFU_Horror_Abyss {
    public class FFU_HA_Defs {
        public const string modID = "mod.fightforuniverse.horror_abyss";
        public const string modName = "Fight for Universe: Horror Abyss";
        public const string modVersion = "1.0.0.0";
        public static ConfigFile modDefsCfg;
        public static ConfigEntry<bool> modInfiniteResearch;
        public static ConfigEntry<bool> modBoostedAbilities;
        public static ConfigEntry<bool> modBiggerShopStock;
        public static ConfigEntry<bool> debugListAllItems;
        public static ConfigEntry<bool> debugListShopItems;
        public static List<SpatialItemData> refItemList = null;
        public static void InitCfg() {
            modDefsCfg = new ConfigFile(Path.Combine(Paths.ConfigPath, "mod_FFU_HA_Defs.cfg"), true);
            modInfiniteResearch = modDefsCfg.Bind("InfiniteResearch", "Enabled", true, "Allows you to research stuff indefinitely, as long as you have at least one research part.");
            modBoostedAbilities = modDefsCfg.Bind("BoostedAbilities", "Enabled", true, "Significantly boosts all abilities and allows you to use them more often, and with zero drawback.");
            modBiggerShopStock = modDefsCfg.Bind("BiggerShopStock", "Enabled", true, "Allows trader that sells resources to sell all resources necessary for upgrades as well.");
            debugListAllItems = modDefsCfg.Bind("BiggerShopStock", "ListAllItems", false, "Debug function: prints list of all items available in game.");
            debugListAllItems = modDefsCfg.Bind("BiggerShopStock", "ListShopItems", false, "Debug function: prints list of all items available in shops.");
        }
    }
}