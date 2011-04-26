using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GluonCS
{
    public interface IGcsLogger
    {
        void AddLogline(GcsLayer layer, string message);
    }
}
