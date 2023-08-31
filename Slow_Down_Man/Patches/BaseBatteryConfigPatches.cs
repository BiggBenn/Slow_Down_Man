using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace SlowDownMod
{
    public partial class SlowDownMan
    {
        /*
         * BaseBatteryConfig patch
         */
        [HarmonyPatch(typeof(BaseBatteryConfig))]
        [HarmonyPatch("DoPostConfigureComplete")]
        public class BaseBatteryConfig_DoPostConfigureComplete_Patch
        {
            public static void Postfix(GameObject go)
            {
                DebugLog("BaseBatteryConfig Postfix");
                Battery battery = go.AddOrGet<Battery>();
                battery.joulesLostPerSecond /= cycleLengthModifier;
            }
        }
    }
}
