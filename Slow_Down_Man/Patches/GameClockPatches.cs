using HarmonyLib;
using KMod;
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
         * GameClock Patches
         */

        [HarmonyPatch(typeof(GameClock))]
        [HarmonyPatch("OnDeserialized")]
        public class GameClock_OnDeserialized_Patch
        {
            public static bool Prefix(GameClock __instance, ref float ___time, ref int ___cycle, ref float ___timeSinceStartOfCycle)
            {
                if (___time == 0.0f)
                    return false;
                //Debug.Log("OnDeserialized Prefix Start");
                //Debug.Log("Initial values::    Time: " + ___time + " Cycle: " + ___cycle + " Time Since Cycle start: " + ___timeSinceStartOfCycle);
                ___cycle = (int)(___time / cycleLength);
                //Debug.Log("Cycle: " + ___cycle);
                ___timeSinceStartOfCycle = UnityEngine.Mathf.Max(___time - (float)___cycle * cycleLength, 0.0f);
                //Debug.Log("Time since start of cycle: " + ___timeSinceStartOfCycle);
                //Debug.Log("OnDeserialized Prefix End");
                //Debug.Log("Skipping real function");
                ___time = 0.0f;
                return false;
            }
        }

        [HarmonyPatch(typeof(GameClock))]
        [HarmonyPatch("AddTime")]
        public class GameClock_AddTime_Patch
        {
            public static bool Prefix(GameClock __instance, float dt, ref bool ___isNight, ref float ___time, ref int ___cycle, ref float ___timeSinceStartOfCycle)
            {
                ___timeSinceStartOfCycle += dt;
                bool flag = false;
                while ((double)___timeSinceStartOfCycle >= cycleLength)
                {
                    ++___cycle;
                    ___timeSinceStartOfCycle -= cycleLength;
                    __instance.Trigger(631075836, (object)null);
                    foreach (KMonoBehaviour worldContainer in ClusterManager.Instance.WorldContainers)
                    {
                        worldContainer.Trigger(631075836, (object)null);
                    }
                    flag = true;
                }

                if (!___isNight && __instance.IsNighttime())
                {
                    //Debug.Log("Triggering Nighttime");
                    ___isNight = true;
                    __instance.Trigger(-722330267, (object)null);
                }

                if (___isNight && !__instance.IsNighttime())
                {
                    //Debug.Log("Triggering Daytime");
                    ___isNight = false;
                }

                if (flag && SaveGame.Instance.AutoSaveCycleInterval > 0 && ___cycle % SaveGame.Instance.AutoSaveCycleInterval == 0)
                {
                    System.Reflection.MethodInfo autosave = AccessTools.Method(typeof(GameClock), "DoAutoSave");
                    autosave.Invoke(__instance, new object[] { ___cycle });
                }
       
                //skip original method
                return false;
            }
        }

        [HarmonyPatch(typeof(GameClock))]
        [HarmonyPatch("GetCurrentCycleAsPercentage")]
        public class GameClock_GetCurrentCycleAsPercentage_Patch
        {
            public static void Postfix(ref float __result, ref float ___timeSinceStartOfCycle)
            {
                __result = ___timeSinceStartOfCycle / cycleLength;
            }
        }

        [HarmonyPatch(typeof(GameClock))]
        [HarmonyPatch("GetTime")]
        public class GameClock_GetTime_Patch
        {
            public static void Postfix(ref float __result, ref float ___timeSinceStartOfCycle, ref int ___cycle)
            {
                __result = ___timeSinceStartOfCycle + (float)___cycle * cycleLength;
            }
        }

        [HarmonyPatch(typeof(GameClock))]
        [HarmonyPatch("GetTimeSinceStartOfReport")]
        public class GameClock_GetTimeSinceStartOfReport_Patch
        {
            public static void Postfix(GameClock __instance, ref float __result, ref float ___timeSinceStartOfCycle)
            {
                __result = __instance.IsNighttime() ? dayLength - ___timeSinceStartOfCycle : ___timeSinceStartOfCycle + nightLength;
            }
        }
    }
}
