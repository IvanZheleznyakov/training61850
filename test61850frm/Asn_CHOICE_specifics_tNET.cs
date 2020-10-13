using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test61850frm
{
    public class Asn_CHOICE_specifics_tNET
    {
		/*
		 * Target structure description.
		 */
		public int StructSize { get; set; }    /* Size of the target structure. */
		public int CtxOffset { get; set; }     /* Offset of the asn_codec_ctx_t member */
		public int PresOffset { get; set; }    /* Identifier of the present member */
		public int PresSize { get; set; }      /* Size of the identifier (enum) */

		/*
		 * Tags to members mapping table.
		 */
		public Asn_TYPE_tag2member_tNET Tag2el { get; set; }
		public int Tag2el_count { get; set; }

		/* Canonical ordering of CHOICE elements, for PER */
		public int[] CanonicalOrder { get; set; }

		/*
		 * Extensions-related stuff.
		 */
		public int ExtStart { get; set; }      /* First member of extensions, or -1 */
	}
}
