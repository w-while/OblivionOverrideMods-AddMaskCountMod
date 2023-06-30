using HarmonyLib;
using hex;
using System;
using System.Collections.Generic;
using UnityEngine.UI;

namespace AddMaskCountMod
{
    public class Patches
    {
        [HarmonyPatch(typeof(ProficiencyBuildMaskUI), "UpdateTxt")]
        public static class ProficiencyBuildMaskUI_UpdateTxt_Patch
        {
            public static void Postfix(Text ___txtNum)
            {
                ___txtNum.text = Singleton<ProficiencyManager>.Instance.profMaskMap.Count + "/" + ModLoad.MaskCountIntConfig.Value;
            }
        }
        [HarmonyPatch(typeof(ProficiencyManager), nameof(ProficiencyManager.CheckMask))]
        public static class ProficiencyManager_CheckMask_Patch
        {
            public static bool Prefix(ref bool __result, Dictionary<int, bool> ___profMaskMap)
            {
                if (___profMaskMap.Count == ModLoad.MaskCountIntConfig.Value)
                {
                    __result=false;
                }
                else
                {
                    __result=true;
                }
                return false;
            }
        }
    }
}
