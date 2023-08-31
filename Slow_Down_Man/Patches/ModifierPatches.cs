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
         * Modifier Patches
         */
        [HarmonyPatch(typeof(Klei.AI.Modifier))]
        [HarmonyPatch("Add")]
        public class Modifier_Add_Patch
        {
            public static void Prefix(ref Klei.AI.AttributeModifier modifier)
            {
                DebugLog("Modifier Add Postfix");
                /*if (modifyValues)
                {*/
                    //if we intercept a calorie usage attribute set, change it
                    if (modifier.AttributeId == Db.Get().Amounts.Calories.deltaAttribute.Id)
                    {
                        modifier.SetValue(modifier.Value / cycleLengthModifier);
                        DebugLog("Intercepted calorie usage rate attribute");
                    }
                    //do the same for stamina usage
                    else if (modifier.AttributeId == Db.Get().Amounts.Stamina.deltaAttribute.Id)
                    {
                        modifier.SetValue(modifier.Value / cycleLengthModifier);
                        DebugLog("Intercepted stamina usage attribute");
                    }
                    //do the same for bladder increase
                    else if (modifier.AttributeId == Db.Get().Amounts.Bladder.deltaAttribute.Id)
                    {
                        modifier.SetValue(modifier.Value / cycleLengthModifier);
                        DebugLog("Intercepted bladder rate attribute");
                    }
                    //do the same for Stress increase
                    else if (modifier.AttributeId == Db.Get().Amounts.Stress.deltaAttribute.Id)
                    {
                        modifier.SetValue(modifier.Value / cycleLengthModifier);
                        DebugLog("Intercepted Stress rate attribute");
                    }
                    //do the same for Fertilization increase
                    else if (modifier.AttributeId == Db.Get().Amounts.Fertilization.deltaAttribute.Id)
                    {
                        modifier.SetValue(modifier.Value / cycleLengthModifier);
                        DebugLog("Intercepted Fertilization rate attribute");
                    }
                    //do the same for Incubation increase
                    else if (modifier.AttributeId == Db.Get().Amounts.Incubation.deltaAttribute.Id)
                    {
                        modifier.SetValue(modifier.Value / cycleLengthModifier);
                        DebugLog("Intercepted Incubation rate attribute");
                    }
                    //do the same for RadiationRecovery
                    else if (modifier.AttributeId == Db.Get().Attributes.RadiationRecovery.Id)
                    {
                        modifier.SetValue(modifier.Value / cycleLengthModifier);
                        DebugLog("Intercepted RadiationRecovery rate attribute");
                    }
                    //do the same for DiseaseCureSpeed
                    else if (modifier.AttributeId == Db.Get().Attributes.DiseaseCureSpeed.Id)
                    {
                        modifier.SetValue(modifier.Value / cycleLengthModifier);
                        DebugLog("Intercepted DiseaseCureSpeed rate attribute");
                    }
                    //do the same for air consumption
                    else if (modifier.AttributeId == Db.Get().Attributes.AirConsumptionRate.Id)
                    {
                        modifier.SetValue(modifier.Value / cycleLengthModifier);
                        DebugLog("Intercepted air consumption rate attribute");
                    }
                //}
            }
        }
    }
}
