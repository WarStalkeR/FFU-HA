#pragma warning disable IDE0051

using BepInEx;
using BepInEx.Logging;

namespace FFU_Horror_Abyss {
    [BepInPlugin("mod.fightforuniverse.modlog", "ModLog", "1.0.0.0")]
    public class ModLog : BaseUnityPlugin {
        public static ManualLogSource refModLog;
        private void Awake() {
            refModLog = Logger;
        }
        public static void Info(string logEntry = "") {
            refModLog.Log(LogLevel.All, $"{logEntry}");
        }
        public static void Debug(string logEntry = "") {
            refModLog.Log(LogLevel.Debug, $"{logEntry}");
        }
        public static void Message(string logEntry = "") {
            refModLog.Log(LogLevel.Message, $"{logEntry}");
        }
        public static void Warning(string logEntry = "") {
            refModLog.Log(LogLevel.Warning, $"{logEntry}");
        }
        public static void Error(string logEntry = "") {
            refModLog.Log(LogLevel.Error, $"{logEntry}");
        }
        public static void Fatal(string logEntry = "") {
            refModLog.Log(LogLevel.Fatal, $"{logEntry}");
        }
    }
}