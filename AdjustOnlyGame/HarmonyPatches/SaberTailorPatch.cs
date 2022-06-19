using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine.SceneManagement;

namespace AdjustOnlyGame.HarmonyPatches
{
    [HarmonyPatch]
    internal class SaberTailorPatch
    {
        private static bool s_isGame = false;

        [HarmonyTargetMethods]
        public static IEnumerable<MethodBase> TargetMethods()
        {
            yield return AccessTools.Method(Type.GetType("SaberTailor.HarmonyPatches.DevicelessVRHelperAdjustControllerTransform, SaberTailor"), "Prefix");
            yield return AccessTools.Method(Type.GetType("SaberTailor.HarmonyPatches.OculusVRHelperAdjustControllerTransform, SaberTailor"), "Prefix");
            yield return AccessTools.Method(Type.GetType("SaberTailor.HarmonyPatches.OpenVRHelperAdjustControllerTransform, SaberTailor"), "Prefix");
        }

        [HarmonyPrefix]
        public static bool Prefix(ref bool __runOriginal)
        {
            if (__runOriginal == false) {
                return false;
            }
            __runOriginal = s_isGame;
            return __runOriginal;
        }

        static SaberTailorPatch()
        {
            SceneManager.activeSceneChanged += SceneManager_activeSceneChanged;
        }

        private static void SceneManager_activeSceneChanged(Scene arg0, Scene arg1)
        {
            if (arg1.name == "GameCore") {
                s_isGame = true;
            }
            else {
                s_isGame = false;
            }
        }
    }
}
