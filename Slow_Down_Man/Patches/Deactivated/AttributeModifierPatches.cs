using HarmonyLib;
using Klei.AI;
using ProcGen.Noise;
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
         * Modifier Patches
         */
        /*[HarmonyPatch(typeof(Klei.AI.AttributeModifier))]
        [HarmonyPatch(MethodType.Constructor)]
        [HarmonyPatch(new Type[] { typeof(string), typeof(float), typeof(string), typeof(bool), typeof(bool), typeof(bool) })]
        public class AttributeModifier_Constructor1_Patch
        {
            public static void PostFix(ref AttributeModifier ___instance)
            {
                Debug.Log("AttributeModifier Constructor1 Postfix");
                if (modifyValues)
                {
                    
                    if (___instance.AttributeId == Db.Get().Amounts.Age.deltaAttribute.Id)
                    {
                        float mv = ___instance.Value;
                        ___instance.SetValue(___instance.Value / cycleLengthModifier);
                        Debug.Log("Intercepted Age rate attribute, was " + mv + " now is: " + ___instance.Value);
                    }

                }
            }
        }

        [HarmonyPatch(typeof(Klei.AI.AttributeModifier))]
        [HarmonyPatch(MethodType.Constructor)]
        [HarmonyPatch(new Type[] { typeof(string), typeof(float), typeof(Func<string>), typeof(bool), typeof(bool) })]
        public class AttributeModifier_Constructor2_Patch
        {
            public static void PostFix(ref AttributeModifier ___instance)
            {
                Debug.Log("AttributeModifier Constructor2 Postfix");
                if (modifyValues)
                {
                    if (___instance.AttributeId == Db.Get().Amounts.Age.deltaAttribute.Id)
                    {
                        float mv = ___instance.Value;
                        ___instance.SetValue(___instance.Value / cycleLengthModifier);
                        Debug.Log("Intercepted Age rate attribute, was " + mv + " now is: " + ___instance.Value);
                    }
                    
                    //if we intercept a calorie usage attribute set, change it
                    if (___instance.AttributeId == Db.Get().Amounts.Calories.deltaAttribute.Id)
                    {
                        ___instance.SetValue(___instance.Value / cycleLengthModifier);
                        Debug.Log("Intercepted calorie usage rate attribute");
                    }
                    //do the same for air consumption
                    else if (___instance.AttributeId == Db.Get().Attributes.AirConsumptionRate.Id)
                    {
                        ___instance.SetValue(___instance.Value / cycleLengthModifier);
                        Debug.Log("Intercepted air consumption rate attribute");
                    }
                    //do the same for stamina usage
                    else if (___instance.AttributeId == Db.Get().Amounts.Stamina.deltaAttribute.Id)
                    {
                        ___instance.SetValue(___instance.Value / cycleLengthModifier);
                        Debug.Log("Intercepted stamina usage rate attribute");
                    }

                }
            }
        }*/
    }
}
