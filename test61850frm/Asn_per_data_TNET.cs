using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test61850frm
{
    public class Asn_per_data_TNET
    {
        public byte[] Buffer { get; set; } /* Pointer to the octet stream */
        /*szt*/
        public long NBoff { get; set; } /* Bit offset to the meaningful bit */
        /*szt*/
        public long NBits { get; set; } /* Number of bits in the stream */
    }
}
