using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test61850frm
{
    public class Asn_dec_rval_tNET
    {
        public enum Asn_dec_rval_code_eNET
        {
            RC_OK,      /* Decoded successfully */
            RC_WMORE,   /* More data expected, call again */
            RC_FAIL     /* Failure to decode data */
        };

        public Asn_dec_rval_code_eNET Code { get; set; }
        public long /*size_t*/ Consumded { get; set; }
    }
}
