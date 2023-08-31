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
         * ReportManager patch
         */
        [HarmonyPatch(typeof(ReportManager))]
        [HarmonyPatch("ReportValue")]
        public class ReportManager_ReportValue_Patch
        {
            public static void Prefix(ReportManager.ReportType reportType, ref float value)
            {
                DebugLog("Intercepted ReportManager.ReportValue with type " + reportType + " and value " + value);
                if(reportType == ReportManager.ReportType.IdleTime 
                    || reportType == ReportManager.ReportType.TimeSpent 
                    || reportType == ReportManager.ReportType.TravelTime
                    || reportType == ReportManager.ReportType.PersonalTime
                    || reportType == ReportManager.ReportType.WorkTime)
                {
                    value /= cycleLengthModifier;
                }
            }
        }
    }
}
