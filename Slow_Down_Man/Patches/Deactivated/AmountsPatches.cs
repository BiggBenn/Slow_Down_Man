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
         * Database.Amounts patch
         */
        /*[HarmonyPatch(typeof(Database.Amounts))]
        [HarmonyPatch("CreateAmount")]
        public class DatabaseAmounts_Load_Patch
        {
            public static void Prefix(string id)
            {
                Debug.Log("I execute before Db.Initialize!");
            }

            /*public static void Postfix()
            {
                Debug.Log("Amounts load completed");
            }*/
        /*}*/
    }
}
