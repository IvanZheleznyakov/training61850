﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test61850frm
{
    public class ByteBuffer
    {
        public byte[] Buffer { get; set; }
        public int MaxSize { get; set; }
        public int Size { get; set; }

        public int Append(byte[] data, int dataSize)
        {
            if (Size + dataSize <= MaxSize)
            {
                Buffer = (byte[])Buffer.Concat(data);
                return dataSize;
            }

            return -1;
        }
    }
}
