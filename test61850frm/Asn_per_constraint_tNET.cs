using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test61850frm
{
    public class Asn_per_constraint_tNET
    {
        public enum Asn_per_constraint_flagsNET
        {
            APC_UNCONSTRAINED_NET = 0x0,    /* No PER visible constraints */
            APC_SEMI_CONSTRAINED_NET = 0x1, /* Constrained at "lb" */
            APC_CONSTRAINED_NET = 0x2,  /* Fully constrained */
            APC_EXTENSIBLE_NET = 0x4	/* May have extension */
        };

        public Asn_per_constraint_flagsNET Flags { get; set; }
        public int RangeBits { get; set; }
        public int EffectiveBits { get; set; }
        public int UpperBound { get; set; }
        public int LowerBound { get; set; }
    }
}
