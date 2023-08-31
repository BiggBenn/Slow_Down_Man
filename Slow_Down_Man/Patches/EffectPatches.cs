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
         *  Effect Patches
         */
        [HarmonyPatch(typeof(Klei.AI.Effect))]
        [HarmonyPatch(MethodType.Constructor)]
        [HarmonyPatch(new System.Type[] { typeof(string),
                                          typeof(string),
                                          typeof(string),
                                          typeof(float),
                                          typeof(bool),
                                          typeof(bool),
                                          typeof(bool),
                                          typeof(string),
                                          typeof(float),
                                          typeof(string),
                                          typeof(string)})]
        public class Effect_Constructor2_Patch
        {
            public static void Postfix(ref float ___duration, bool ___isBad)
            {
                //only modify effects if user wants it
                /*if (modifyValues)
                {
                    //use the indicator effects being bad to choose whether or not to extend them too
                    if (!___isBad || alsoExtendNegative)
                    {*/
                        ___duration *= cycleLengthModifier;
                    /*}
                }*/
            }
        }

        [HarmonyPatch(typeof(Klei.AI.Effect))]
        [HarmonyPatch(MethodType.Constructor)]
        [HarmonyPatch(new System.Type[] { typeof(string),
                                          typeof(string),
                                          typeof(string),
                                          typeof(float),
                                          typeof(bool),
                                          typeof(bool),
                                          typeof(bool),
                                          typeof(Emote),
                                          typeof(float),
                                          typeof(float),
                                          typeof(string),
                                          typeof(string)})]
        public class Effect_Constructor1_Patch
        {
            public static void Postfix(ref float ___duration, bool ___isBad)
            {
                //only modify effects if user wants it
                /*if (modifyValues)
                {
                    //use the indicator effects being bad to choose whether or not to extend them too
                    if (!___isBad || alsoExtendNegative)
                    {*/
                        ___duration *= cycleLengthModifier;
                    /*}
                }*/
            }
        }
    }
}
