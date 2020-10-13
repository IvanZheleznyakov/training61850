using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test61850frm
{
    public class Asn_TYPE_tag2member_tNET
    {
        public uint ElTag { get; set; }   /* Outmost tag of the member */
        public int ElNo { get; set; }      /* Index of the associated member, base 0 */
        public int ToffFirst { get; set; }     /* First occurence of the el_tag, relative */
        public int ToffLast { get; set; }		/* Last occurence of the el_tag, relatvie */
    }
}
