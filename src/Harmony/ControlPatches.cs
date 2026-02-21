using HarmonyLib;

namespace HaldorOverhaul
{
    public static class TraderPatches
    {
        private static TraderUI _traderUI;

        internal static void SetTraderUI(TraderUI ui) => _traderUI = ui;

        /// <summary>
        /// Intercept StoreGui.Show — prevent vanilla UI, show our custom UI instead.
        /// </summary>
        [HarmonyPatch(typeof(StoreGui), "Show")]
        [HarmonyPrefix]
        private static bool StoreGui_Show_Prefix(StoreGui __instance, Trader trader)
        {
            if (_traderUI == null) return true;
            _traderUI.Show(trader, __instance);
            return false; // skip vanilla StoreGui
        }

        /// <summary>
        /// When StoreGui.Hide is called, also close our UI.
        /// </summary>
        [HarmonyPatch(typeof(StoreGui), "Hide")]
        [HarmonyPostfix]
        private static void StoreGui_Hide_Postfix()
        {
            if (_traderUI != null && _traderUI.IsVisible)
                _traderUI.Hide();
        }

        /// <summary>
        /// Report visible when our UI is open so the game knows a store UI is active.
        /// </summary>
        [HarmonyPatch(typeof(StoreGui), "IsVisible")]
        [HarmonyPostfix]
        private static void StoreGui_IsVisible_Postfix(ref bool __result)
        {
            if (_traderUI != null && _traderUI.IsVisible)
                __result = true;
        }

        /// <summary>
        /// Block keyboard input when the search box is focused.
        /// </summary>
        [HarmonyPatch(typeof(Chat), "HasFocus")]
        [HarmonyPostfix]
        private static void Chat_HasFocus_Postfix(ref bool __result)
        {
            if (!__result && _traderUI != null && _traderUI.IsSearchFocused)
                __result = true;
        }

        /// <summary>
        /// Block player movement/input when our UI is open.
        /// </summary>
        [HarmonyPatch(typeof(Player), "TakeInput")]
        [HarmonyPrefix]
        private static bool Player_TakeInput_Prefix(ref bool __result)
        {
            if (_traderUI != null && _traderUI.IsVisible)
            {
                __result = false;
                return false;
            }
            return true;
        }
    }
}
