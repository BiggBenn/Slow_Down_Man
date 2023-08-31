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
         * Modifier Patches
         */
        /*[HarmonyPatch(typeof(Klei.AI.Attribute))]
        [HarmonyPatch(MethodType.Constructor)]
        [HarmonyPatch(new Type[] { typeof(string), typeof(bool), typeof(Klei.AI.Attribute.Display), typeof(bool), typeof(float), typeof(string), typeof(string), typeof(string), typeof(string[]) })]
        public class Attribute_Constructor1_Patch
        {
            public static void PreFix(string id, ref float base_value)
            {
                Debug.Log("Attribute Constructor1 PreFix, id: " + id);
                switch (id)
                {
                    case "AirConsumptionRate":
                        base_value /= cycleLengthModifier;
                        break;

                    default:
                        break;
                }
            }*/

            /*public static void PostFix(Klei.AI.Attribute ___instance, string __id)
            {
                Debug.Log("Attribute Constructor1 Postfix");
                if (modifyValues)
                {
                    //if we intercept a calorie usage attribute set, change it
                    if (__id == Db.Get().Amounts.Calories.deltaAttribute.Id)
                    {
                        ___instance.BaseValue /= cycleLengthModifier;
                        Debug.Log("Intercepted calorie usage rate attribute");
                    }
                    //do the same for air consumption
                    else if (__id == Db.Get().Attributes.AirConsumptionRate.Id)
                    {
                        ___instance.BaseValue /= cycleLengthModifier;
                        Debug.Log("Intercepted air consumption rate attribute");
                    }
                    //do the same for stamina usage
                    else if (__id == Db.Get().Amounts.Stamina.deltaAttribute.Id)
                    {
                        ___instance.BaseValue /= cycleLengthModifier;
                        Debug.Log("Intercepted stamina usage rate attribute");
                    }
                    //do the same for bladder increase
                    else if (__id == Db.Get().Amounts.Bladder.deltaAttribute.Id)
                    {
                        ___instance.BaseValue /= cycleLengthModifier;
                        Debug.Log("Intercepted bladder rate attribute");
                    }
                }
            }*/
        /*}
        

        [HarmonyPatch(typeof(Klei.AI.Attribute))]
        [HarmonyPatch(MethodType.Constructor)]
        [HarmonyPatch(new Type[] { typeof(string), typeof(string), typeof(string), typeof(string), typeof(float), typeof(Klei.AI.Attribute.Display), typeof(bool), typeof(string), typeof(string), typeof(string)})]
        public class Attribute_Constructor2_Patch
        {
            public static void PreFix(string id, ref float base_value)
            {
                Debug.Log("Attribute Constructor2 PreFix, id: " + id);
                switch (id)
                {
                    case "AirConsumptionRate":
                        base_value /= cycleLengthModifier;
                        break;

                    default:
                        break;
                }
            }

            /*public static void PostFix(Klei.AI.Attribute ___instance, string __id)
            {
                Debug.Log("Attribute Constructor2 Postfix");
                if (modifyValues)
                {
                    //if we intercept a calorie usage attribute set, change it
                    if (__id == Db.Get().Amounts.Calories.deltaAttribute.Id)
                    {
                        ___instance.BaseValue /= cycleLengthModifier;
                        Debug.Log("Intercepted calorie usage rate attribute");
                    }
                    //do the same for air consumption
                    else if (__id == Db.Get().Attributes.AirConsumptionRate.Id)
                    {
                        ___instance.BaseValue /= cycleLengthModifier;
                        Debug.Log("Intercepted air consumption rate attribute");
                    }
                    //do the same for stamina usage
                    else if (__id == Db.Get().Amounts.Stamina.deltaAttribute.Id)
                    {
                        ___instance.BaseValue /= cycleLengthModifier;
                        Debug.Log("Intercepted stamina usage rate attribute");
                    }
                    //do the same for bladder increase
                    else if (__id == Db.Get().Amounts.Bladder.deltaAttribute.Id)
                    {
                        ___instance.BaseValue /= cycleLengthModifier;
                        Debug.Log("Intercepted bladder rate attribute");
                    }
                }
            }
        }*/
    }
}
