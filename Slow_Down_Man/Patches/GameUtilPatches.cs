using HarmonyLib;
using STRINGS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using UnityEngine;

namespace SlowDownMod
{
    public partial class SlowDownMan
    {
        /*
         * GameUtil patches, I think these are mainly cosmetic, for displaying "x% per day" or some shit
         */
        [HarmonyPatch(typeof(GameUtil))]
        [HarmonyPatch("ApplyTimeSlice")]
        [HarmonyPatch(new Type[] { typeof(float), typeof(GameUtil.TimeSlice) })]
        public class GameUtil_ApplyTimeSliceFloat_Patch
        {
            public static void Postfix(ref float __result, GameUtil.TimeSlice timeSlice)
            {
                if(timeSlice == GameUtil.TimeSlice.PerCycle)
                {
                    __result *= cycleLengthModifier;
                }
            }
        }

        [HarmonyPatch(typeof(GameUtil))]
        [HarmonyPatch("ApplyTimeSlice")]
        [HarmonyPatch(new Type[] { typeof(int), typeof(GameUtil.TimeSlice) })]
        public class GameUtil_ApplyTimeSliceInt_Patch
        {
            public static void Postfix(ref float __result, GameUtil.TimeSlice timeSlice)
            {
                if (timeSlice == GameUtil.TimeSlice.PerCycle)
                {
                    __result *= cycleLengthModifier;
                }
            }
        }

        [HarmonyPatch(typeof(GameUtil))]
        [HarmonyPatch("GetFormattedCycles")]
        public class GameUtil_GetFormattedCycles_Patch
        {
            public static bool Prefix(ref string __result, float seconds, string formatString, bool forceCycles)
            {
                if (forceCycles || (double)Mathf.Abs(seconds) > cycleLength / 6)
                {
                    __result = string.Format((string)UI.FORMATDAY, (object)GameUtil.FloatToString(seconds / cycleLength, formatString));
                }
                else
                {
                    __result = GameUtil.GetFormattedTime(seconds);
                }
                return false;
            }
        }
    }
}
