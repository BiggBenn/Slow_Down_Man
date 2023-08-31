using HarmonyLib;
using KMod;
using System.Collections.Generic;
using System.IO;

namespace SlowDownMod
{
    public partial class SlowDownMan : UserMod2
    {
        //Custom log function to override only in debug builds
        public static void DebugLog(string msg)
        {
#if DEBUG
            Debug.Log(msg);
#endif
        }

        static float cycleLengthModifier = 2.5f;
        static float cycleLength = cycleLengthModifier * 600.0f;
        static float dayLength = cycleLength * 0.875f;
        static float nightLength = cycleLength * 0.125f;

        /*static bool modifyValues = true;
        static bool alsoExtendNegative = true;*/

        public override void OnLoad(Harmony harmony)
        {
            //get the file, if it exists
            try
            {
                using (StreamReader input = new StreamReader(Path.Combine(mod.ContentPath, "Config.cfg")))
                {
                    string configText = input.ReadToEnd();
                    if (configText != null)
                    {
                        char[] delimiters = { '\n', '=' };
                        //get the value we want, first split the line by our delimiters
                        string[] segments = configText.Split(delimiters);
                        try
                        {
                            int cycleLengthLabelIndex = -1, modifyValuesLabelIndex = -1, alsoExtendBadLabelIndex = -1;
                            for(int i=0; i<segments.Length; i++)
                            {
                                string segment = segments[i];
                                if (segment.Equals("DayLengthMultiplier"))
                                    cycleLengthLabelIndex = i;
                                /*else if (segment.Equals("ModifyValues"))
                                    modifyValuesLabelIndex = i;
                                else if (segment.Equals("AlsoModifyBadEffects"))
                                    alsoExtendBadLabelIndex = i;*/
                            }
                            
                            cycleLengthModifier = float.Parse(segments[cycleLengthLabelIndex + 1]);
                            cycleLength = cycleLengthModifier * 600.0f;
                            dayLength = cycleLength * 0.875f;
                            nightLength = cycleLength * 0.125f;

                            /*modifyValues = bool.Parse(segments[modifyValuesLabelIndex + 1]);

                            alsoExtendNegative = bool.Parse(segments[alsoExtendBadLabelIndex + 1]);*/

                            DebugLog("Loaded config values");
                            DebugLog("DayLengthMultiplier=" + cycleLengthModifier);
                            //DebugLog("ModifyValues=" + modifyValues);
                            //Debug.Log("AlsoModifyBadEffects=" + alsoExtendNegative);
                        }
                        catch (System.Exception e)
                        {
                            Debug.Log("SlowDownMod Malformed Config.cfg");
                        }
                    }
                }
            }
            catch(System.Exception e)
            {
                Debug.Log("Config file missing, using default value of 2.5x cycle length");
            }

            base.OnLoad(harmony);
        }


        /*
         * Example patch
         */
        /*[HarmonyPatch(typeof(Db))]
        [HarmonyPatch("Initialize")]
        public class Db_Initialize_Patch
        {
            public static void Prefix()
            {
                Debug.Log("I execute before Db.Initialize!");
            }

            public static void Postfix()
            {
                Debug.Log("I execute after Db.Initialize!");
            }
        }*/

        /*
         * GeyserConfigurator Patches
         */
        /*[HarmonyPatch(typeof(GeyserConfigurator.GeyserInstanceConfiguration))]
        [HarmonyPatch("GetEmitRate")]
        public class GeyserConfiguratorGetEmitRatePatch
        {
            public static void Postfix(GeyserConfigurator.GeyserInstanceConfiguration __instance, ref float __result)
            {
                __result = __instance.GetMassPerCycle() / (cycleLength / __instance.GetIterationLength()) / __instance.GetOnDuration();
            }
        }*/

        /*
         * Operational Patches
         */
        /*[HarmonyPatch(typeof(Operational))]
        [HarmonyPatch("OnNewDay")]
        public class OperationalOnNewDayPatch
        {
            public static void Postfix(List<float> ___uptimeData, float ___activeTime)
            {
                ___uptimeData[___uptimeData.Count - 1] = ___activeTime / cycleLength;
            }
        }*/

        

        

        

        
    }
}
