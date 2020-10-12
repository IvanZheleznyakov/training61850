using System.Runtime.InteropServices;

namespace test61850frm
{
    [ComVisible(true)]
    public interface IBerEncoder
    {
        int EncodeLength(uint length, ref byte[] buffer, int bufPos);
        int EncodeTL(byte tag, uint length, ref byte[] buffer, int bufPos);
        int EncodeBoolean(byte tag, bool value, ref byte[] buffer, int bufPos);
        int EncodeStringWithTag(byte tag, string encodingString, ref byte[] buffer, int bufPos);
        int EncodeAsn1PrimitiveValue(byte tag, Asn1PrimitiveVal value, ref byte[] buffer, int bufPos);
        int EncodeOctetString(byte tag, byte[] octetString, uint octetStringSize, ref byte[] buffer, int bufPos);
        int EncodeBitString(byte tag, int bitStringSize, byte[] bitString, ref byte[] buffer, int bufPos);
        int DetermineEncodedBitStringSize(int bitStringSize);
        void RevertByteOrder(ref byte[] octets, int size);
        int CompressInteger(ref byte[] integer, int originalSize);
        int EncodeUInt32(uint value, ref byte[] buffer, int bufPos);
        int EncodeInt32(int value, ref byte[] buffer, int bufPos);
        int EncodeUInt32WithTL(byte tag, uint value, ref byte[] buffer, int bufPos);
        int EncodeFloat(byte[] floatValue, byte formatWidth, byte exponentWidth,
        ref byte[] buffer, int bufPos);
        int UInt32determineEncodedSize(uint value);
        int DetermineLengthSize(uint length);
        int DetermineEncodedStringSize(string encodingString);
        int EncodeOIDToBuffer(string oidString, ref byte[] buffer, int maxBufLen);
    }
}
