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
         * AllResourcesScreen Patches
         */
        //note: SpawnCategoryRow looks like an absolute clusterfuck, at least in the decompiled source. Probably not worth fixing for a small cosmetic change.
        /*[HarmonyPatch(typeof(AllResourcesScreen))]
        [HarmonyPatch("SpawnCategoryRow")]
        public class AllResourcesScreen_SpawnCategoryRow_Patch()
        {
            public static void PreFix()
            {
            }
        }*/
    }
}
