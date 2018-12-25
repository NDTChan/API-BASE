using log4net;
using System;
using System.Web;
namespace BTS.SP.API.PHF.Utils
{
    public class WriteLogs
    {
        private static string PageName = HttpContext.Current.Handler.GetType().Name;
        private static ILog log = LogManager.GetLogger(PageName);

        public static void LogError(Exception ex)
        {
            log.Error(ex);
        }

        public static void LogWarning(Exception ex)
        {
            log.Warn(ex);
        }

        public static void LogInfo(Exception ex)
        {
            log.Info(ex);
        }

        public static void LogFatal(Exception ex)
        {
            log.Fatal(ex);
        }
    }
}