using System;
using System.Collections;
using System.Collections.Generic;
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
        }

        internal static Dictionary<OrbBuilder.OrbInfo, GameObject> allOrbs = new Dictionary<OrbBuilder.OrbInfo, GameObject>();


        [HarmonyPatch(typeof(PopulateSuggestionOrbs), nameof(Awake))]
        public static class AddNewOrbsToPools
        {
            [HarmonyPrefix]
            public static void Prefix(ref PopulateSuggestionOrbs __instance)
            {
                
            }
        }
    }
}