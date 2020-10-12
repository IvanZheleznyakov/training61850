using System.Runtime.InteropServices;

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
