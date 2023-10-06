using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicQueuingSystem
{
    internal class EventManager
    {
        private Dictionary<string, Delegate> eventsDict = new Dictionary<string, Delegate>();

        public void RegisterEvent(string eventName)
        {
            Error.Assert(eventsDict.ContainsKey(eventName));
        }

        
    }

    // Error handling via Exception
    public class Error : Exception
    {
        public Error(object msg) : base(msg != null ? msg.ToString() : "Assertion Error Exception") { }
        public static bool Assert(bool condition, object msg = null)
        {
            if (!condition)
            {
                throw new Error(msg ?? null);
            }
            else
            {
                return true;
            }
        }
    }
}
