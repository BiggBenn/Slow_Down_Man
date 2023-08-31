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
         * AttributeConverters Patches
         */
        [HarmonyPatch(typeof(Database.AttributeConverters))]
        [HarmonyPatch(MethodType.Constructor)]
        public class AttributeConverters_Constructor_Patch
        {
            public static void Postfix(ref Klei.AI.AttributeConverter ___ImmuneLevelBoost, ref Klei.AI.AttributeConverter ___RanchingEffectDuration, ref Klei.AI.AttributeConverter ___FarmedEffectDuration, ref Klei.AI.AttributeConverter ___PowerTinkerEffectDuration)
            {
                //Debug.Log("AttributeConverters Constructor Patch");
                /*if (modifyValues)
                {*/
                    ___ImmuneLevelBoost.baseValue *= cycleLengthModifier;
                    ___RanchingEffectDuration.baseValue *= cycleLengthModifier;
                    ___FarmedEffectDuration.baseValue *= cycleLengthModifier;
                    ___PowerTinkerEffectDuration.baseValue *= cycleLengthModifier;
                //}
            }
        }
    }
}
