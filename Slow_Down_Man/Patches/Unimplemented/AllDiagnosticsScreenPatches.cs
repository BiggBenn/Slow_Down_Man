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
         * AllDiagnosticsScreen Patches
         */
        //note: SpawnRow looks like an absolute clusterfuck, at least in the decompiled source. Probably not worth fixing for a small cosmetic change.
        /*[HarmonyPatch(typeof(AllDiagnosticsScreen))]
        [HarmonyPatch("SpawnRow")]
        public class AllDiagnosticsScreen_SpawnRow_Patch()
        {
            public static void PreFix()
            {
            }
        }*/
    }
}
