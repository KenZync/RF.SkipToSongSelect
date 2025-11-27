using BepInEx.Logging;
using HarmonyLib;
using Scripts.Scene;
using UnityEngine.SceneManagement;

namespace SkipToSongSelect.Plugins
{
    [HarmonyPatch]
    internal class SkipToSongSelectPatch
    {
        private static ManualLogSource Log => Plugin.Log;

        // --- Redirect Logic ---
        private static void Redirect(ref string name)
        {
            string current = SceneManager.GetActiveScene().name;
            Log.LogInfo($"[SkipToSongSelect] Scene change request: {current} -> {name}");

            // Only redirect MainMenu if we are NOT coming from ThunderShrine
            if (name == SceneName.MainMenu && current != SceneName.ThunderShrine)
            {
                Log.LogInfo("[SkipToSongSelect] Redirecting MainMenu → SongSelect (not from ThunderShrine)");
                name = SceneName.SongSelect;
            }
        }

        // --- Patch ChangeScene ---
        [HarmonyPatch(typeof(SceneChanger))]
        [HarmonyPatch(nameof(SceneChanger.ChangeScene))]
        [HarmonyPrefix]
        private static void ChangeScene_Prefix(ref string name)
        {
            Redirect(ref name);
        }

        // --- Patch ChangeSceneAsync(string) ---
        [HarmonyPatch(typeof(SceneChanger))]
        [HarmonyPatch(nameof(SceneChanger.ChangeSceneAsync),
            new System.Type[] { typeof(string) })]
        [HarmonyPrefix]
        private static void ChangeSceneAsync_Prefix(ref string name)
        {
            Redirect(ref name);
        }

        // --- Patch TryChangeSceneAsync(string) ---
        [HarmonyPatch(typeof(SceneChanger))]
        [HarmonyPatch(nameof(SceneChanger.TryChangeSceneAsync),
            new System.Type[] { typeof(string) })]
        [HarmonyPrefix]
        private static void TryChangeSceneAsync_Prefix(ref string name)
        {
            Redirect(ref name);
        }
    }
}
