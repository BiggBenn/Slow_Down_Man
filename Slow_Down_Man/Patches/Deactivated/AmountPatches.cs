using HarmonyLib;
using Klei.AI;
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
         * Amount patch
         */
        /*[HarmonyPatch(typeof(Klei.AI.Amount))]
        [HarmonyPatch(MethodType.Constructor)]
        [HarmonyPatch(new Type[] {  typeof(string),
                                    typeof(string),
                                    typeof(string),
                                    typeof(Klei.AI.Attribute),
                                    typeof(Klei.AI.Attribute),
                                    typeof(Klei.AI.Attribute),
                                    typeof(bool),
                                    typeof(Units),
                                    typeof(float),
                                    typeof(bool),
                                    typeof(string),
                                    typeof(string) })]
        public class Amount_Constructor_Patch
        {
            public static void Prefix(ref string id, ref Klei.AI.Attribute delta_attribute)
            {
                Debug.Log("Amount with ID " + id + " created");
                switch(id)
                {
                    case "Stamina":
                    case "Calories":
                    case "Stress":
                    case "Bladder":
                    case "Fertilization":
                    case "Incubation":
                        float bv = delta_attribute.BaseValue;
                        delta_attribute.BaseValue /= cycleLengthModifier;
                        Debug.Log("Modified " + id + " deltaattribute, was " + bv + " now is: " + delta_attribute.BaseValue);
                        break;

                    default:
                        break;
                }
            }

            public static void Postfix(ref string __Id)
            {
                Debug.Log("Amount with ID " + __Id + " created");
            }
        }*/
    }
}
