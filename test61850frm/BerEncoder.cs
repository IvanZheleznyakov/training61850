using System;
using System.Runtime.InteropServices;
using System.Text;

namespace test61850frm
{
    /// <summary>
    /// Класс, который предоставляет методы BER-кодирования 
    /// </summary>
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.None)]
    public class BerEncoder : IBerEncoder
    {
        /// <summary>
        /// Кодирование длины строки в буфер
        /// </summary>
        /// <param name="length">Кодируемая длина</param>
        /// <param name="buffer">Байтовый буфер</param>
        /// <param name="bufPos">Позиция в буфере, с которой записывается длина</param>
        /// <returns>Позиция в буфере после записанной длины</returns>
        public int EncodeLength(uint length, ref byte[] buffer, int bufPos)
        {
            if (length < 128)
            {
                buffer[bufPos++] = (byte)length;
            }
            else if (length < 256)
            {
                buffer[bufPos++] = 0x81;
                buffer[bufPos++] = (byte)length;
            }
            else if (length < 65535)
            {
                buffer[bufPos++] = 0x82;

                buffer[bufPos++] = (byte)(length / 256);
                buffer[bufPos++] = (byte)(length % 256);
            }
            else
            {
                buffer[bufPos++] = 0x83;

                buffer[bufPos++] = (byte)(length / 0x10000);
                buffer[bufPos++] = (byte)((length & 0xffff) / 0x100);
                buffer[bufPos++] = (byte)(length % 256);
            }

            return bufPos;
        }

        private int EncodeLengthHELP(uint length, ref byte[] buffer, int bufPos)
        {
            if (length < 128)
            {
                buffer[bufPos++] = (byte)length;
            }
            else if (length < 256)
            {
                buffer[bufPos++] = 0x81;
                buffer[bufPos++] = (byte)length;
            }
            else if (length < 65535)
            {
                buffer[bufPos++] = 0x82;

                buffer[bufPos++] = (byte)(length / 256);
                buffer[bufPos++] = (byte)(length % 256);
            }
            else
            {
                buffer[bufPos++] = 0x83;

                buffer[bufPos++] = (byte)(length / 0x10000);
                buffer[bufPos++] = (byte)((length & 0xffff) / 0x100);
                buffer[bufPos++] = (byte)(length % 256);
            }

            return bufPos;
        }

        /// <summary>
        /// Кодирование тега и его длины в буфер
        /// </summary>
        /// <param name="tag">Тег идентификатора данных</param>
        /// <param name="length">Длина кодируемого тега</param>
        /// <param name="buffer">Байтовый буфер</param>
        /// <param name="bufPos">Позиция в буфере, с которой записывается длина</param>
        /// <returns>Позиция в буфере после записанной длины</returns>
        public int EncodeTL(byte tag, uint length, ref byte[] buffer, int bufPos)
        {
            buffer[bufPos++] = tag;
            //    bufPos = EncodeLengthHELP(length, ref buffer, bufPos);
            //begin encodelength
            if (length < 128)
            {
                buffer[bufPos++] = (byte)length;
            }
            else if (length < 256)
            {
                buffer[bufPos++] = 0x81;
                buffer[bufPos++] = (byte)length;
            }
            else if (length < 65535)
            {
                buffer[bufPos++] = 0x82;

                buffer[bufPos++] = (byte)(length / 256);
                buffer[bufPos++] = (byte)(length % 256);
            }
            else
            {
                buffer[bufPos++] = 0x83;

                buffer[bufPos++] = (byte)(length / 0x10000);
                buffer[bufPos++] = (byte)((length & 0xffff) / 0x100);
                buffer[bufPos++] = (byte)(length % 256);
            }
            //end encodelength

            return bufPos;
        }

        /// <summary>
        /// Кодирование булевого значения в буфер
        /// </summary>
        /// <param name="tag">Тег идентификатора данных</param>
        /// <param name="value">Булевое значение, которое нужно закодировать</param>
        /// <param name="buffer">Байтовый буфер</param>
        /// <param name="bufPos">Позиция в буфере, с которой записывается длина</param>
        /// <returns>Позиция в буфере после записанной длины</returns>
        public int EncodeBoolean(byte tag, bool value, ref byte[] buffer, int bufPos)
        {
            buffer[bufPos++] = tag;
            buffer[bufPos++] = 1;

            if (value)
                buffer[bufPos++] = 0xff;
            else
                buffer[bufPos++] = 0x00;

            return bufPos;
        }

        /// <summary>
        /// Кодирование строки в буфер
        /// </summary>
        /// <param name="tag">Тег идентификатора данных</param>
        /// <param name="encodingString">Кодируемая строка</param>
        /// <param name="buffer">Байтовый буфер</param>
        /// <param name="bufPos">Позиция в буфере, с которой записывается длина</param>
        /// <returns>Позиция в буфере после записанной длины</returns>
        public int EncodeStringWithTag(byte tag, string encodingString, ref byte[] buffer, int bufPos)
        {
            buffer[bufPos++] = tag;

            if (encodingString != null)
            {
                int length = encodingString.Length;

                bufPos = EncodeLength((uint)length, ref buffer, bufPos);

                byte[] bytesOfASCII = Encoding.ASCII.GetBytes(encodingString);

                for (int i = 0; i < length; i++)
                {
                    buffer[bufPos++] = bytesOfASCII[i];
                }
            }
            else
            {
                buffer[bufPos++] = 0;
            }

            return bufPos;
        }

        /// <summary>
        /// Кодирование значения в формате Asn.1
        /// </summary>
        /// <param name="tag">Тег идентификатора данных</param>
        /// <param name="value">Кодируемое значение Asn.1</param>
        /// <param name="buffer">Байтовый буфер</param>
        /// <param name="bufPos">Позиция в буфере, с которой записывается длина</param>
        /// <returns>Позиция в буфере после записанной длины</returns>
        public int EncodeAsn1PrimitiveValue(byte tag, Asn1PrimitiveVal value, ref byte[] buffer, int bufPos)
        {
            buffer[bufPos++] = tag;

            bufPos = EncodeLength(value.Size, ref buffer, bufPos);

            for (int i = 0; i < value.Size; i++)
            {
                buffer[bufPos++] = value.Octets[i];
            }

            return bufPos;
        }

        /// <summary>
        /// Кодирование октетов информации в буфер
        /// </summary>
        /// <param name="tag">Тег идентификатора данных</param>
        /// <param name="octetString">Кодируемые октеты</param>
        /// <param name="octetStringSize">Длина кодируемых октетов</param>
        /// <param name="buffer">Байтовый буфер</param>
        /// <param name="bufPos">Позиция в буфере, с которой записывается длина</param>
        /// <returns>Позиция в буфере после записанной длины</returns>
        public int EncodeOctetString(byte tag, byte[] octetString, uint octetStringSize, ref byte[] buffer, int bufPos)
        {
            buffer[bufPos++] = tag;

            bufPos = EncodeLength(octetStringSize, ref buffer, bufPos);

            for (int i = 0; i < octetStringSize; i++)
            {
                buffer[bufPos++] = octetString[i];
            }

            return bufPos;
        }

        /// <summary>
        /// Кодирование битовой последовательности в буфер
        /// </summary>
        /// <param name="tag">Тег идентификатора данных</param>
        /// <param name="bitStringSize">Длина битовой последовательности</param>
        /// <param name="bitString">Битовая последовательность</param>
        /// <param name="buffer">Байтовый буфер</param>
        /// <param name="bufPos">Позиция в буфере, с которой записывается длина</param>
        /// <returns>Позиция в буфере после записанной длины</returns>
        public int EncodeBitString(byte tag, int bitStringSize, byte[] bitString, ref byte[] buffer, int bufPos)
        {
            buffer[bufPos++] = tag;

            int byteSize = bitStringSize / 8;

            if (bitStringSize % 8 > 0)
            {
                byteSize++;
            }

            int padding = (byteSize * 8) - bitStringSize;

            bufPos = EncodeLength((uint)byteSize + 1, ref buffer, bufPos);

            buffer[bufPos++] = (byte)padding;

            for (int i = 0; i < byteSize; i++)
            {
                buffer[bufPos++] = bitString[i];
            }

            byte paddingMask = 0;

            for (byte i = 0; i < padding; i++)
            {
                byte a = ((byte)(1 << i));
                paddingMask += a;
            }

            paddingMask = (byte)~paddingMask;

            buffer[bufPos - 1] = (byte)(buffer[bufPos - 1] & paddingMask);

            return bufPos;
        }

        /// <summary>
        /// Определение длины закодированной последовательности битов
        /// </summary>
        /// <param name="bitStringSize">Длина исходной последовательности битов</param>
        /// <returns>Длина закодированной последовательности битов</returns>
        public int DetermineEncodedBitStringSize(int bitStringSize)
        {
            int size = 2; /* for tag and padding */

            int byteSize = bitStringSize / 8;

            if (bitStringSize % 8 > 0)
                byteSize++;

            //   size += DetermineLengthSize((uint)byteSize);
            if (byteSize < 128)
            {
                size += 1;
            }
            else if (byteSize < 256)
            {
                size += 2;
            }
            else if (byteSize < 65536)
            {
                size += 3;
            }
            else
            {
                size += 4;
            }

            size += byteSize;

            return size;
        }

        /// <summary>
        /// Представление последовательности байтов в обратном порядке
        /// </summary>
        /// <param name="octets">Последовательность байтов</param>
        /// <param name="size">Длина последовательности</param>
        public void RevertByteOrder(ref byte[] octets, int size)
        {
            for (int i = 0; i < size / 2; i++) 
            {
                var temp = octets[i];
                octets[i] = octets[(size - 1) - i];
                octets[(size - 1) - i] = temp;
            }
        }

        /// <summary>
        /// Сжатие целочисленного значения
        /// </summary>
        /// <param name="integer">Значение для сжатия, представленное массивом</param>
        /// <param name="originalSize">Изначальный размер массива</param>
        /// <returns>Новый размер массива представления числа</returns>
        public int CompressInteger(ref byte[] integer, int originalSize)
        {
            int bytePosition;
            for (bytePosition = 0; bytePosition < originalSize - 1; ++bytePosition)
            {
                if (integer[bytePosition] == 0x00)
                {
                    if ((integer[bytePosition + 1] & 0x80) == 0)
                    {
                        continue;
                    }
                }
                else if (integer[bytePosition] == 0xff)
                {
                    if ((integer[bytePosition + 1] & 0x80) == 0x80)
                    {
                        continue;
                    }
                }

                break;
            }

            int bytesToDelete = bytePosition;
            int newSize = originalSize;

            if (bytesToDelete > 0)
            {
                newSize -= bytesToDelete;

                int k;
                for (k = 0; k < newSize; ++k)
                {
                    integer[k] = integer[bytePosition];
                    bytePosition++;
                }
            }

            return newSize;
        }


        /// <summary>
        /// Кодирование 32-битового беззначного числа
        /// </summary>
        /// <param name="value">Число для кодирования</param>
        /// <param name="buffer">Байтовый буфер</param>
        /// <param name="bufPos">Позиция в буфере, с которой записывается длина</param>
        /// <returns>Позиция в буфере после записанной длины</returns>
        public int EncodeUInt32(uint value, ref byte[] buffer, int bufPos)
        {
            byte[] valueArray = BitConverter.GetBytes(value);
            byte[] valueBuffer = new byte[5];

            for (int i = 0; i < 4; i++)
            {
                valueBuffer[i + 1] = valueArray[i];
            }

            if (BitConverter.IsLittleEndian)
            {
                for (int i = 1; i < 3; ++i)
                {
                    byte temp = valueBuffer[i];
                    valueBuffer[i] = valueBuffer[5 - i];
                    valueBuffer[5 - i] = temp;
                }
            }

     //       int size = CompressInteger(ref valueBuffer, 5);
            
            //begin compress
            int bytePosition;
            for (bytePosition = 0; bytePosition < 5 - 1; ++bytePosition)
            {
                if (valueBuffer[bytePosition] == 0x00)
                {
                    if ((valueBuffer[bytePosition + 1] & 0x80) == 0)
                    {
                        continue;
                    }
                }
                else if (valueBuffer[bytePosition] == 0xff)
                {
                    if ((valueBuffer[bytePosition + 1] & 0x80) == 0x80)
                    {
                        continue;
                    }
                }

                break;
            }

            int bytesToDelete = bytePosition;
            int newSize = 5;

            if (bytesToDelete > 0)
            {
                newSize -= bytesToDelete;

                int k;
                for (k = 0; k < newSize; ++k)
                {
                    valueBuffer[k] = valueBuffer[bytePosition];
                    bytePosition++;
                }
            }
            //end compress
            int size = newSize;

            for (int i = 0; i < size; ++i)
            {
                buffer[bufPos++] = valueBuffer[i];
            }

            return bufPos;
        }

        /// <summary>
        /// Кодирование 32-битового знакового числа
        /// </summary>
        /// <param name="value">Число для кодирования</param>
        /// <param name="buffer">Байтовый буфер</param>
        /// <param name="bufPos">Позиция в буфере, с которой записывается длина</param>
        /// <returns>Позиция в буфере после записанной длины</returns>
        public int EncodeInt32(int value, ref byte[] buffer, int bufPos)
        {
            var valueArray = BitConverter.GetBytes(value);
            byte[] valueBuffer = new byte[4];

            if (BitConverter.IsLittleEndian)
            {
                for (int i = 0; i < 4; i++)
                {
                    valueBuffer[3 - i] = valueArray[i];
                }
            }
            else
            {
                for (int i = 0; i < 4; i++)
                {
                    valueBuffer[i] = valueArray[i];
                }
            }

        //    int size = CompressInteger(ref valueBuffer, 4);
            //begin compr
            int bytePosition;
            for (bytePosition = 0; bytePosition < 4 - 1; ++bytePosition)
            {
                if (valueBuffer[bytePosition] == 0x00)
                {
                    if ((valueBuffer[bytePosition + 1] & 0x80) == 0)
                    {
                        continue;
                    }
                }
                else if (valueBuffer[bytePosition] == 0xff)
                {
                    if ((valueBuffer[bytePosition + 1] & 0x80) == 0x80)
                    {
                        continue;
                    }
                }

                break;
            }

            int bytesToDelete = bytePosition;
            int newSize = 4;

            if (bytesToDelete > 0)
            {
                newSize -= bytesToDelete;

                int k;
                for (k = 0; k < newSize; ++k)
                {
                    valueBuffer[k] = valueBuffer[bytePosition];
                    bytePosition++;
                }
            }
            //end compress
            int size = newSize;

            for (int i = 0; i < size; i++)
            {
                buffer[bufPos++] = valueBuffer[i];
            }

            return bufPos;
        }

        /// <summary>
        /// Кодирование 32-битового беззнакового числа с тегом
        /// </summary>
        /// <param name="tag">Тег идентификатора данных</param>
        /// <param name="value">Число для кодирования</param>
        /// <param name="buffer">Байтовый буфер</param>
        /// <param name="bufPos">Позиция в буфере, с которой записывается длина</param>
        /// <returns>Позиция в буфере после записанной длины</returns>
        public int EncodeUInt32WithTL(byte tag, uint value, ref byte[] buffer, int bufPos)
        {
            var valueArray = BitConverter.GetBytes(value);
            int sizeOfValueBuffer = 5;
            byte[] valueBuffer = new byte[sizeOfValueBuffer];

            for (int i = 0; i < 4; i++)
            {
                valueBuffer[i + 1] = valueArray[i];
            }

            if (BitConverter.IsLittleEndian)
            {
                for (int i = 1; i < 3; ++i)
                {
                    byte temp = valueBuffer[i];
                    valueBuffer[i] = valueBuffer[sizeOfValueBuffer - i];
                    valueBuffer[sizeOfValueBuffer - i] = temp;
                }
            }

       //     int size = CompressInteger(ref valueBuffer, sizeOfValueBuffer);
            //begin compr
            int bytePosition;
            for (bytePosition = 0; bytePosition < 5 - 1; ++bytePosition)
            {
                if (valueBuffer[bytePosition] == 0x00)
                {
                    if ((valueBuffer[bytePosition + 1] & 0x80) == 0)
                    {
                        continue;
                    }
                }
                else if (valueBuffer[bytePosition] == 0xff)
                {
                    if ((valueBuffer[bytePosition + 1] & 0x80) == 0x80)
                    {
                        continue;
                    }
                }

                break;
            }

            int bytesToDelete = bytePosition;
            int newSize = 5;

            if (bytesToDelete > 0)
            {
                newSize -= bytesToDelete;

                int k;
                for (k = 0; k < newSize; ++k)
                {
                    valueBuffer[k] = valueBuffer[bytePosition];
                    bytePosition++;
                }
            }
            //end compress
            int size = newSize;

            buffer[bufPos++] = tag;
            buffer[bufPos++] = (byte)size;

            for (int i = 0; i < size; i++)
            {
                buffer[bufPos++] = valueBuffer[i];
            }

            return bufPos;
        }

        /// <summary>
        /// Кодирование значения float в буфер
        /// </summary>
        /// <param name="floatValue">Представление float</param>
        /// <param name="formatWidth"></param>
        /// <param name="exponentWidth"></param>
        /// <param name="buffer">Байтовый буфер</param>
        /// <param name="bufPos">Позиция в буфере, с которой записывается длина</param>
        /// <returns>Позиция в буфере после записанной длины</returns>
        public int EncodeFloat(byte[] floatValue, byte formatWidth, byte exponentWidth,
        ref byte[] buffer, int bufPos)
        {
            /* TODO operate on encoding buffer directly */

            byte[] valueBuffer = new byte[9];

            int byteSize = formatWidth / 8;

            valueBuffer[0] = exponentWidth;

            for (int i = 0; i < byteSize; i++)
            {
                valueBuffer[i + 1] = floatValue[i];
            }

            if (BitConverter.IsLittleEndian)
            {
                for (int i = 1; i < byteSize / 2; i++)
                {
                    var temp = valueBuffer[i];
                    valueBuffer[i] = valueBuffer[(byteSize - 1) - i];
                    valueBuffer[(byteSize - 1) - i] = temp;
                }
            }

            for (int i = 0; i < byteSize + 1; i++)
            {
                buffer[bufPos++] = valueBuffer[i];
            }

            return bufPos;
        }

        /// <summary>
        /// Определение размера закодированного 32-битового беззнакового числа
        /// </summary>
        /// <param name="value">Число, для которого нужно определить размер кодировки</param>
        /// <returns>Размер закодированного числа</returns>
        public int UInt32determineEncodedSize(uint value)
        {
            var valueArray = BitConverter.GetBytes(value);
            int sizeOfValueBuffer = 5;
            byte[] valueBuffer = new byte[sizeOfValueBuffer];

            for (int i = 0; i < 4; i++)
            {
                valueBuffer[i + 1] = valueArray[i];
            }

            if (BitConverter.IsLittleEndian)
            {
                for (int i = 1; i < 3; ++i)
                {
                    byte temp = valueBuffer[i];
                    valueBuffer[i] = valueBuffer[sizeOfValueBuffer - i];
                    valueBuffer[sizeOfValueBuffer - i] = temp;
                }
            }

           // int size = CompressInteger(ref valueBuffer, sizeOfValueBuffer);

            //begin compress
            int bytePosition;
            for (bytePosition = 0; bytePosition < 5 - 1; ++bytePosition)
            {
                if (valueBuffer[bytePosition] == 0x00)
                {
                    if ((valueBuffer[bytePosition + 1] & 0x80) == 0)
                    {
                        continue;
                    }
                }
                else if (valueBuffer[bytePosition] == 0xff)
                {
                    if ((valueBuffer[bytePosition + 1] & 0x80) == 0x80)
                    {
                        continue;
                    }
                }

                break;
            }

            int bytesToDelete = bytePosition;
            int newSize = 5;

            if (bytesToDelete > 0)
            {
                newSize -= bytesToDelete;

                int k;
                for (k = 0; k < newSize; ++k)
                {
                    valueBuffer[k] = valueBuffer[bytePosition];
                    bytePosition++;
                }
            }
            // end compress

            int size = newSize;

            return size;
        }

        /// <summary>
        /// Определение количества октетов по размеру сущности
        /// </summary>
        /// <param name="length">Размер сущности</param>
        /// <returns>Количество октетов для кодирования</returns>
        public int DetermineLengthSize(uint length)
        {
            if (length < 128)
                return 1;
            if (length < 256)
                return 2;
            if (length < 65536)
                return 3;
            else
                return 4;
        }

        /// <summary>
        /// Определение размера закодированной строки
        /// </summary>
        /// <param name="encodingString">Кодируемая строка</param>
        /// <returns>Размер закодированной строки</returns>
        public int DetermineEncodedStringSize(string encodingString)
        {
            if (encodingString != null)
            {
                int size = 1;

                int length = encodingString.Length;

                //size += DetermineLengthSize((uint)length);
                if (length < 128)
                {
                    size += 1;
                }
                else if (length < 256)
                {
                    size += 2;
                }
                else if (length < 65536)
                {
                    size += 3;
                }
                else
                {
                    size += 4;
                }

                size += length;

                return size;
            }
            else
            {
                return 2;
            }
        }

        /// <summary>
        /// Чтение из строки числа до первого неподходящего символа
        /// </summary>
        /// <param name="stringNumber">Строка, содержащая число</param>
        /// <returns>Первое прочитанное из строки число</returns>
        private int ReadNumberUpToTheInappropriateSymbol(string stringNumber)
        {
            string resultString = "";
            int i = 0;
            while (i < stringNumber.Length && Char.IsDigit(stringNumber[i]))
            {
                resultString += stringNumber[i];
                ++i;
            }

            return Convert.ToInt32(resultString);
        }

        /// <summary>
        /// Кодирование OID в буфер
        /// </summary>
        /// <param name="oidString">OID</param>
        /// <param name="buffer">Байтовый буфер</param>
        /// <param name="maxBufLen">Максимальная длина буфера</param>
        /// <returns>Количество закодированных байтов</returns>
        public int EncodeOIDToBuffer(string oidString, ref byte[] buffer, int maxBufLen)
        {
            int encodedBytes = 0;

            int x = ReadNumberUpToTheInappropriateSymbol(oidString);

            char sepChar = '.';

            int separator = oidString.IndexOf(sepChar);

            if (separator == -1) 
            {
                sepChar = ',';
                separator = oidString.IndexOf(sepChar);
            }

            if (separator == -1) 
            {
                sepChar = ' ';
                separator = oidString.IndexOf(sepChar);
            }

            if (separator == -1)
            {
                return 0;
            }

            string subString = oidString.Substring(separator + 1);

            int y = ReadNumberUpToTheInappropriateSymbol(subString);

            int val = x * 40 + y;

            if (encodedBytes < maxBufLen)
            {
                buffer[encodedBytes] = (byte)val;
            }
            else
            {
                return 0;
            }

            encodedBytes++;

            while (true)
            {
                separator = subString.IndexOf(sepChar);

                if (separator == -1)
                {
                    break;
                }

                subString = subString.Substring(separator + 1);

                val = ReadNumberUpToTheInappropriateSymbol(subString);

                int requiredBytes = 0;

                int val2 = val;
                while (val2 > 0)
                {
                    requiredBytes++;
                    val2 = val2 >> 7;
                }

                while (requiredBytes > 0)
                {
                    val2 = val >> (7 * (requiredBytes - 1));

                    val2 = val2 & 0x7f;

                    if (requiredBytes > 1)
                        val2 += 128;

                    if (encodedBytes == maxBufLen)
                        return 0;

                    buffer[encodedBytes++] = (byte)val2;

                    requiredBytes--;
                }
            }

            return encodedBytes;
        }
    }
}