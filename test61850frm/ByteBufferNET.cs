using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace test61850frm
{
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.None)]
    public class ByteBufferNET
    {
        public byte[] Buffer { get; set; }
        public int MaxSize { get; set; }
        public int Size { get; set; }

        /// <summary>
        /// Запись новых данных в конец буфера
        /// </summary>
        /// <param name="data">Байтовый буфер с новыми данными</param>
        /// <param name="dataSize">Длина присоединяемого буфера</param>
        /// <returns>Количество добавленных байтов; -1, если запись невозможна</returns>
        public int Append(byte[] data, int dataSize)
        {
            if (Size + dataSize <= MaxSize)
            {
                Buffer = Buffer.Concat(data).ToArray(); // TODO поменять реализацию, эта должна быть медленной
                Size += dataSize;                           // на больших размерах
                return dataSize;
            }

            return -1;
        }
    }
}
