using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static test61850frm.Asn_per_constraint_tNET;

namespace test61850frm
{
    public class Asn_TYPE_member_tNET
    {
		public delegate void asn_app_constraint_failed_fNET(object application_specific_key,
															Asn_TYPE_descriptor_tNET typeDescriptor,
															object structure_which_failed_ptr,
															string error_message_format,
															params object[] variable);

		public delegate int asn_constr_check_fNET(Asn_TYPE_descriptor_tNET typeDescriptor,
													object structPtr,
													asn_app_constraint_failed_fNET opt_callback,
													object optional_app_key);

		public Asn_per_constraint_flagsNET Flags { get; set; }	/* Element's presentation flags */
		public int Optional { get; set; }   /* Following optional members, including current */
		public int MembOffset { get; set; }        /* Offset of the element */
		public uint Tag { get; set; }      /* Outmost (most immediate) tag */
		public int TagMode { get; set; }       /* IMPLICIT/no/EXPLICIT tag at current level */
		public Asn_TYPE_descriptor_tNET Type { get; set; }    /* Member type descriptor */
		public asn_constr_check_fNET memb_constraints;   /* Constraints validator */
		public Asn_per_constraints_tNET PerConstraints { get; set; } /* PER compiled constraints */
		/* TODO DEFAULT <value> */
		public string Name { get; set; }         /* ASN.1 identifier of the element */
	}
}
