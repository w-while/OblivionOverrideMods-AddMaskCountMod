using System;
using BepInEx;
using BepInEx.Configuration;
using HarmonyLib;
using hex;

namespace AddMaskCountMod
{

    [BepInPlugin("while.AddMaskCountMod", "增加屏蔽数量", "1.0.0")]
    public class ModLoad : BaseUnityPlugin
    {
        public static ConfigEntry<int> MaskCountIntConfig;
        void Start()
        {
            MaskCountIntConfig = Config.Bind<int>("config", "MastCountIntConfig", 7, "屏蔽数量");
            new Harmony("while.AddMaskCountMod").PatchAll();
        }
    }

}
