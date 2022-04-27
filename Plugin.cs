using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BepInEx;
using HarmonyLib;
using UnityEngine;

namespace API
{
    [BepInPlugin(PluginGuid, PluginName, PluginVersion)]
    public class Plugin : BaseUnityPlugin
    {
        private const string PluginGuid = "kopie.peglin.api";
        private const string PluginName = "Peglin_API";
        private const string PluginVersion = "0.0.1";

        private void Awake()
        {
            new OrbBuilder().WithName("test").WithDamage(1).WithDescription("Test of new api").Build();
            Harmony h = new Harmony(PluginGuid);
            h.PatchAll();
        }

        internal static Dictionary<OrbBuilder.OrbInfo, GameObject> allOrbs = new Dictionary<OrbBuilder.OrbInfo, GameObject>();


        [HarmonyPatch(typeof(PopulateSuggestionOrbs), nameof(PopulateSuggestionOrbs.CreateNewOrbOptions))]
        public static class AddNewOrbsToPools
        {
            [HarmonyPrefix]
            public static void Postfix(ref PopulateSuggestionOrbs __instance)
            {
                __instance._orbPool.AvailableOrbs = allOrbs.Values.ToArray();
            }
        }
        
        
        [HarmonyPatch(typeof(Attack), "Name", MethodType.Getter)]
        public class NameFix
        {
            public static bool Prefix(ref Attack __instance, ref string __result)
            {
                Attack t = __instance;
                bool flag = allOrbs.Keys.ToList().Find(o=>o.name==t.locNameString)!=null;
                bool result;
                if (flag)
                {
                    __result = __instance.locName;
                    result = false;
                }
                else
                {
                    result = true;
                }
                return result;
            }
        }

        [HarmonyPatch(typeof(Attack), "Description", MethodType.Getter)]
        public class DescriptionFix
        {
            public static bool Prefix(ref Attack __instance, ref string __result)
            {
                Attack t = __instance;
                bool flag = allOrbs.Keys.ToList().Find(o=>o.description==t.locDescStrings[0])!=null;
                bool result;
                if (flag)
                {
                    __result = __instance.locDescStrings[0];
                    result = false;
                }
                else
                {
                    result = true;
                }
                return result;
            }
        }

        [HarmonyPatch(typeof(Attack), "EnglishDescription", MethodType.Getter)]
        public class EnglishDescriptionFix
        {
            public static bool Prefix(ref Attack __instance, ref string __result)
            {
                Attack t = __instance;
                bool flag = allOrbs.Keys.ToList().Find(o=>o.description==t.locDescStrings[0])!=null;
                bool result;
                if (flag)
                {
                    __result = __instance.locDescStrings[0];
                    result = false;
                }
                else
                {
                    result = true;
                }
                return result;
            }
        }

    }
}