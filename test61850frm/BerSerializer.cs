using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace test61850frm
{
    public class BerSerializer
    {
        private byte[] ObjectToByteArray(object obj)
        {
            if (obj == null)
            {
                return null;
            }

            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
        }

        /*szt*/
        public long TLVTagSerialize(uint tag, object bufp, /*szt*/ long size)
        {
            int tClass = (int)(tag & 0x3);
            uint tVal = tag >> 2;
            byte[] buf = ObjectToByteArray(bufp);
            byte[] end;
            /*szt*/
            long requiredSize;

            if (tVal < 30)
            {
                if (size > 0)
                {
                    buf[0] = (byte)((tClass << 6) | tVal);
                }
                return 1;
            }
            else
            {
                if (size > 0)
                {
                    buf[0] = (byte)((tClass << 6) | tVal);
                    size--;
                }
            }


        }
    }
}
