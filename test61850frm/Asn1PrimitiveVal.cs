using System;
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

    /// <summary>
    /// Информация в формате ASN.1 /*временное название, чтобы не было конфликта имен*/
    /// </summary>
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.None)]
    public class Asn1PrimitiveVal : IAsn1PrimitiveValue
    {
        public byte Size { get; set; }
        public byte MaxSize { get; set; }
        public byte[] Octets { get; set; }
    }
}
