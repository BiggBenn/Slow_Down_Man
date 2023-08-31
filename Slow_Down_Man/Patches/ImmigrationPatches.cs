using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlowDownMod
{
    public partial class SlowDownMan
    {
        /*
         * Example patch
         */
        [HarmonyPatch(typeof(Immigration))]
        [HarmonyPatch("OnPrefabInit")]
        public class Immigration_OnPrefabInit_Patch
        {
            public static void Postfix(ref float ___timeBeforeSpawn)
            {
                ___timeBeforeSpawn *= cycleLengthModifier;
            }
        }

        [HarmonyPatch(typeof(Immigration))]
        [HarmonyPatch("EndImmigration")]
        public class Immigration_EndImmigration_Patch
        {
            public static void Postfix(ref float ___timeBeforeSpawn)
            {
                ___timeBeforeSpawn *= cycleLengthModifier;
            }
        }

        [HarmonyPatch(typeof(Immigration))]
        [HarmonyPatch("GetTotalWaitTime")]
        public class Immigration_GetTotalWaitTime_Patch
        {
            public static void Postfix(ref float __result)
            {
                __result *= cycleLengthModifier;
            }
        }
    }
}
