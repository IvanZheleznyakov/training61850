using System;
using System.Runtime.InteropServices;

namespace test61850frm
{
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
