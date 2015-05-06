using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using WUApiLib;

namespace Toolkit.Windows
{
    public class Updates
    {

        public static bool GetKBInstalledByWMI(string KbId)
        {
            bool ret = false;

            const string query = "SELECT HotFixID FROM Win32_QuickFixEngineering";
            var search = new ManagementObjectSearcher(query);
            var collection = search.Get();

            List<string> updates = new List<string>();

            foreach (ManagementObject quickFix in collection)
                updates.Add(quickFix["HotFixID"].ToString());
            var singleUpdate = updates.Where(x => x.Contains(KbId));
            
            if(singleUpdate.Count() > 0)
            {
                ret = true;
            }

            return (ret);
        }

        public static bool GetKBInstalledByWUApi(string KbId)
        {
            bool ret = false;

            var updateSession = new UpdateSession();
            var updateSearcher = updateSession.CreateUpdateSearcher();
            updateSearcher.IncludePotentiallySupersededUpdates = true;
            var count = updateSearcher.GetTotalHistoryCount();
            if (count > 0)
            {
                var history = updateSearcher.QueryHistory(0, count);

                List<string> updates = new List<string>();

                for (int i = 0; i < count; ++i)
                    updates.Add(history[i].Title);

                var singleUpdate = updates.Where(x => x.Contains(KbId));
                if(singleUpdate.Count() > 0)
                {
                    ret = true;
                }
            }
            return (ret);
        }
    }
}
