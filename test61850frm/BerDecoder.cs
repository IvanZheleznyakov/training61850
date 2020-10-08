using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace test61850frm
{
   /* [ComVisible(true)]
    [Guid("643DC85F-BA85-4C8D-8162-4E869ED8E8A1"), ClassInterface(ClassInterfaceType.AutoDual)]
    public class BerDecoder
    {
        public int DecodeLength(ref byte[] buffer, ref int[] length, int bufPos, int maxBufPos)
        {
            if (bufPos >= maxBufPos)
            {
                return -1;
            }

            byte len1 = buffer[bufPos++];

            if ((len1 & 0x80) > 0)
            {
                int lenLength = len1 & 0x7f;

                if (lenLength == 0)
                { /* indefinite length form */
                 /*   length[0] = -1;
                }
                else
                {
                    length[0] = 0;

                    int i;
                    for (i = 0; i < lenLength; i++)
                    {
                        if (bufPos >= maxBufPos)
                            return -1;

                        length[0] <<= 8;
                        length[0] += buffer[bufPos++];
                    }
                }

            }
            else
            {
                length[0] = len1;
            }

            if (length[0] < 0)
            {
                return -1;
            }

            if (length[0] > maxBufPos)
            {
                return -1;
            }

            if (bufPos + length[0] > maxBufPos)
            {
                return -1;
            }

            return bufPos;
        }
    }*/
}
