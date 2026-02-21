using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using BepInEx;
using Newtonsoft.Json;

namespace HaldorOverhaul
{
    public static class ConfigLoader
    {
        private static string BuyFile => Path.Combine(Paths.ConfigPath, "HaldorOverhaul.haldor.buy.json");
        private static string SellFile => Path.Combine(Paths.ConfigPath, "HaldorOverhaul.haldor.sell.json");

        public static List<TradeEntry> BuyEntries { get; private set; } = new List<TradeEntry>();
        public static List<TradeEntry> SellEntries { get; private set; } = new List<TradeEntry>();

        public static void Initialize()
        {
            EnsureConfigFilesExist();
            LoadBuyConfig();
            LoadSellConfig();
            ValidateAndLogStats();
        }

        private static void ValidateAndLogStats()
        {
            int buyValid = 0, buyInvalid = 0;
            int sellValid = 0, sellInvalid = 0;

            foreach (var entry in BuyEntries.ToList())
            {
                if (!ValidateEntry(entry, "BUY"))
                {
                    BuyEntries.Remove(entry);
                    buyInvalid++;
                }
                else
                {
                    buyValid++;
                }
            }

            foreach (var entry in SellEntries.ToList())
            {
                if (!ValidateEntry(entry, "SELL"))
                {
                    SellEntries.Remove(entry);
                    sellInvalid++;
                }
                else
                {
                    sellValid++;
                }
            }

            if (buyInvalid > 0 || sellInvalid > 0)
            {
                HaldorOverhaul.Log.LogWarning($"[ConfigLoader] Removed {buyInvalid} invalid BUY entries and {sellInvalid} invalid SELL entries.");
            }

            HaldorOverhaul.Log.LogInfo($"{"[ConfigLoader]"} Config validated: {buyValid} BUY entries, {sellValid} SELL entries.");
        }

        private static bool ValidateEntry(TradeEntry entry, string type)
        {
            if (entry == null)
            {
                HaldorOverhaul.Log.LogWarning($"{"[ConfigLoader]"} {type} entry is null, skipping.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(entry.prefab))
            {
                HaldorOverhaul.Log.LogWarning($"{"[ConfigLoader]"} {type} entry has empty prefab name, skipping.");
                return false;
            }

            if (entry.price < 0)
            {
                HaldorOverhaul.Log.LogWarning($"{"[ConfigLoader]"} {type} entry '{entry.prefab}' has negative price ({entry.price}), setting to 0.");
                entry.price = 0;
            }

            if (entry.stack <= 0)
            {
                HaldorOverhaul.Log.LogWarning($"{"[ConfigLoader]"} {type} entry '{entry.prefab}' has invalid stack ({entry.stack}), setting to 1.");
                entry.stack = 1;
            }

            return true;
        }

        private static void EnsureConfigFilesExist()
        {
            if (!File.Exists(BuyFile))
            {
                File.WriteAllText(BuyFile, DefaultBuyJson());
                HaldorOverhaul.Log.LogInfo("[ConfigLoader] Created default BUY config.");
            }

            if (!File.Exists(SellFile))
            {
                File.WriteAllText(SellFile, DefaultSellJson());
                HaldorOverhaul.Log.LogInfo("[ConfigLoader] Created default SELL config.");
            }
        }

        private static void LoadBuyConfig()
        {
            try
            {
                BuyEntries = JsonConvert.DeserializeObject<List<TradeEntry>>(File.ReadAllText(BuyFile)) ?? new List<TradeEntry>();
                HaldorOverhaul.Log.LogInfo($"[ConfigLoader] Loaded {BuyEntries.Count} BUY entries.");
            }
            catch (Exception ex)
            {
                HaldorOverhaul.Log.LogError($"[ConfigLoader] Error loading BUY config: {ex}");
                BuyEntries = new List<TradeEntry>();
            }
        }

        private static void LoadSellConfig()
        {
            try
            {
                SellEntries = JsonConvert.DeserializeObject<List<TradeEntry>>(File.ReadAllText(SellFile)) ?? new List<TradeEntry>();
                HaldorOverhaul.Log.LogInfo($"[ConfigLoader] Loaded {SellEntries.Count} SELL entries.");
            }
            catch (Exception ex)
            {
                HaldorOverhaul.Log.LogError($"[ConfigLoader] Error loading SELL config: {ex}");
                SellEntries = new List<TradeEntry>();
            }
        }

        private static string DefaultBuyJson() => JsonConvert.SerializeObject(new List<TradeEntry>
        {
            new TradeEntry() { prefab = "Wood", stack = 50, price = 25, requiredGlobalKey = "defeated_eikthyr" }
        }, Formatting.Indented);

        private static string DefaultSellJson() => JsonConvert.SerializeObject(new List<TradeEntry>
        {
            new TradeEntry() { prefab = "Wood", stack = 1, price = 1 }
        }, Formatting.Indented);
    }

    public class TradeEntry
    {
        [JsonProperty("item_prefab")]
        public string prefab = "";

        [JsonProperty("item_quantity")]
        public int stack = 1;

        [JsonProperty("item_price")]
        public int price = 1;

        [JsonProperty("must_defeated_boss")]
        public string requiredGlobalKey = "";
    }
}