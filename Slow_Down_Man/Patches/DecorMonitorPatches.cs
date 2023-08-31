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
         * DecorMonitor Patches
         */
        [HarmonyPatch(typeof(DecorMonitor.Instance))]
        [HarmonyPatch("OnNewDay")]
        public class DecorMonitorInstance_OnNewDay_Patch
        {
            public static void Prefix(ref float ___yesterdaysTotalDecor)
            {
                ___yesterdaysTotalDecor /= cycleLengthModifier;
            }

            public static void Postfix(ref float ___yesterdaysTotalDecor)
            {
                ___yesterdaysTotalDecor *= cycleLengthModifier;
            }
        }

        [HarmonyPatch(typeof(DecorMonitor.Instance))]
        [HarmonyPatch("GetTodaysAverageDecor")]
        public class DecorMonitorInstance_GetTodaysAverageDecor_Patch
        {
            /*public static bool Prefix(ref float __result, float ___cycleTotalDecor)
            {
                __result = ___cycleTotalDecor / GameClock.Instance.GetTimeSinceStartOfCycle();
                return false;
            }*/

            public static void PostFix(ref float __result)
            {
                __result /= cycleLengthModifier;
            }
        }

        [HarmonyPatch(typeof(DecorMonitor.Instance))]
        [HarmonyPatch("GetYesterdaysAverageDecor")]
        public class DecorMonitorInstance_GetYesterdaysAverageDecor_Patch
        {
            /*public static bool Prefix(ref float __result, float ___yesterdaysTotalDecor)
            {
                __result = ___yesterdaysTotalDecor / GameClock.Instance.GetTimeSinceStartOfCycle();
                return false;
            }*/

            public static void PostFix(ref float __result)
            {
                __result /= cycleLengthModifier;
            }
        }
    }
}
