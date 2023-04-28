using BepInEx;
using BepInEx.Configuration;
using System.IO;

namespace FFU_Horror_Abyss {
    public class FFU_HA_Defs {
        public const string modID = "mod.fightforuniverse.horror_abyss";
        public const string modName = "Fight for Universe: Horror Abyss";
        public const string modVersion = "1.0.0.0";
        public static ConfigFile modDefsCfg;
        public static ConfigEntry<bool> modInfiniteResearch;
        public static ConfigEntry<bool> modBoostedAbilities;
        public static void InitCfg() {
            modDefsCfg = new ConfigFile(Path.Combine(Paths.ConfigPath, "mod_FFU_HA_Defs.cfg"), true);
            modInfiniteResearch = modDefsCfg.Bind("InfiniteResearch", "Enabled", true, "Allows you to research stuff indefinitely, as long as you have at least one research part.");
            modBoostedAbilities = modDefsCfg.Bind("BoostedAbilities", "Enabled", true, "Significantly boosts all abilities and allows you to use them more often, and with zero drawback.");
        }
    }
}