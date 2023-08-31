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
         * AdditionalDetailsPanel Patches
         */
        //note: RefreshDetails looks like an absolute clusterfuck, at least in the decompiled source. Probably not worth fixing for a small cosmetic change.
        /*[HarmonyPatch(typeof(AdditionalDetailsPanel))]
        [HarmonyPatch("RefreshDetails")]
        public class AdditionalDetailsPanel_RefreshDetails_Patch()
        {
            public static void PreFix()
            {
            }
        }*/
    }
}
