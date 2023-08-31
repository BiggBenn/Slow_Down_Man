using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static StateMachine;
using static STRINGS.INPUT_BINDINGS;

namespace SlowDownMod
{
    public partial class SlowDownMan
    {
        /*
         * ArtifactPOIStates patch
         */
        //note: instead of patching InitializeStates which calls RechargePOI just intercept the specific hardcoded argument and replace it
        /*[HarmonyPatch(typeof(ArtifactPOIStates.Instance))]
        [HarmonyPatch("RechargePOI")]
        public class ArtifactPOIStatesInstance_RechargePOI_Patch
        {
            public static void Prefix(float dt)
            {
                if(dt == 600f)
                {
                    dt = cycleLength;
                }
            }
        }*/
    }
}
