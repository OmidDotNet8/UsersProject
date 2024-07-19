using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UExample.Core
{
    public static class CodeGenerator
    {
        public static Guid GetId()
        {
            return Guid.NewGuid();
        }
    }
}
