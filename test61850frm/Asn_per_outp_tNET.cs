using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test61850frm
{
    public class Asn_per_outp_tNET
    {
		public byte[] Buffer { get; set; }    /* Pointer into the (tmpspace) */
		/*szt*/ public long NBoff { get; set; }       /* Bit offset to the meaningful bit */
		/*szt*/ public long NBits { get; set; }       /* Number of bits left in (tmpspace) */
		public byte[] Tmpspace { get; set; }   /* Preliminary storage to hold data; TODO size is 32 */
		// TODO outper
		public object OpKey { get; set; }       /* Key for (outper) data callback */
		/*szt*/ public long FlushedBytes { get; set; }   /* Bytes already flushed through (outper) */
	}
}
