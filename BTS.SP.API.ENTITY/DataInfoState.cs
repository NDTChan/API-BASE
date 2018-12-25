using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTS.SP.API.ENTITY
{
    public class DataInfoState
    {
        #region State Base

        protected static readonly Dictionary<string, string> StateData = new Dictionary<string, string>();

        public static List<StateInfoObj> All
        {
            get
            {
                List<StateInfoObj> result = StateData.Select(item => new StateInfoObj
                {
                    Value = item.Key,
                    Text = item.Value
                }).ToList();
                return result;
            }
        }

        public static bool IsValidState(string state)
        {
            bool result = !string.IsNullOrEmpty(state) && StateData.ContainsKey(state);
            return result;
        }

        protected static void AddStateText(string state, string text, bool visible = true, bool executeable = true)
        {
            if (!string.IsNullOrEmpty(state) && !StateData.ContainsKey(state))
            {
                StateData.Add(state, text);
                if (visible)
                {
                    VisibleStates.Add(state);
                }
                if (executeable)
                {
                    ExecutableStates.Add(state);
                }
            }
        }

        public static string GetStateLabel(string state)
        {
            string result = "";
            if (IsValidState(state))
            {
                result = StateData[state];
            }
            return result;
        }

        public static List<string> VisibleStates = new List<string>();

        public static List<string> ExecutableStates = new List<string>();

        public static bool IsVisibleState(string state)
        {
            return VisibleStates.Contains(state);
        }

        public static bool IsExecutableState(string state)
        {
            return ExecutableStates.Contains(state);
        }

        #endregion

        static DataInfoState()
        {
            AddStateText(Static, "Static");
            AddStateText(Active, "Active");
            AddStateText(Imported, "Imported");
            AddStateText(Locked, "Locked", true, false);
            AddStateText(Inactive, "Inactive", true, false);
            AddStateText(Deleted, "Deleted", false, false);
        }

        public static string Static = "static";
        public static string Active = "active";
        public static string Imported = "imported";

        public static string Locked = "locked";
        public static string Inactive = "inactive";

        public static string Deleted = "deleted";
    }
}
