using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test61850frm
{
    [ComVisible(true)]
    public interface IAsn1PrimitiveValue
    {
        byte Size { get; set; }
        byte MaxSize { get; set; }
        byte[] Octets { get; set; }
    }
}
