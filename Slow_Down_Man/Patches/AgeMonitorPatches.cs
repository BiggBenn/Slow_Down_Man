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
        [HarmonyPatch(typeof(AgeMonitor))]
        [HarmonyPatch("InitializeStates")]
        public class AgeMonitor_InitializeStates_Patch
        {
            public static void Postfix(ref Klei.AI.AttributeModifier ___aging)
            {
                DebugLog("AgeMonitor InitializeStates postfix, Modified aging deltaattribute from " + ___aging.Value + " to " + ___aging.Value/cycleLengthModifier);
                ___aging.SetValue(___aging.Value / cycleLengthModifier);
            }
        }
    }
}
