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
                //Debug.Log("AgeMonitor InitializeStates postfix");
                //float value = ___aging.Value;
                ___aging.SetValue(___aging.Value / cycleLengthModifier);
                //Debug.Log("Modified aging deltaattribute from " + value + " to " + ___aging.Value);
            }
        }
    }
}
