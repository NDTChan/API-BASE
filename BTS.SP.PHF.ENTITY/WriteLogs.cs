using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace BTS.SP.PHF.ENTITY
{
    public  class WriteLogs
    {
        private static readonly ILog Log=LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static void LogError(Exception ex)
        {
            Log.Error(ex);
        }

        public static void LogWarning(Exception ex)
        {
            Log.Warn(ex);
        }

        public static void LogInfo(Exception ex)
        {
            Log.Info(ex);
        }

        public static void LogFatal(Exception ex)
        {
            Log.Fatal(ex);
        }
    }
}
