using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuiaTI.Helpers
{
    public interface IPreference
    {
        string GetString(string key, string defaultValue);
    }
}
