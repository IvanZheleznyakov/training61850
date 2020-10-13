using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test61850frm
{
    public class Asn_TYPE_descriptor_tNET
    {
        public delegate int asn_app_consume_bytes_fNET(object[] buffer, long size,
                                                        object application_specific_key);
        public delegate int asn_struct_print_fNET(Asn_TYPE_descriptor_tNET typeDescriptor,
                                                    object structPtr, int level,
                                                    asn_app_consume_bytes_fNET callback,
                                                    object appKey);

        public delegate Asn_dec_rval_tNET ber_type_decoder_fNET(Asn_codec_ctx_tNET opt_codec_ctx,
                                                                Asn_TYPE_descriptor_tNET typeDescriptor,
                                                                object structPtr,
                                                                object bufPtr, /*sizet*/ long size,
                                                                int tagMode);

        public delegate Asn_enc_rval_tNET der_type_encoder_FNET(Asn_TYPE_descriptor_tNET typeDescriptor,
                                                                object structPtr, int tagMode,
                                                                uint tag,
                                                                asn_app_consume_bytes_fNET consumeBytes,
                                                                object appKey);

        public delegate Asn_dec_rval_tNET xer_type_decoder_fNET(Asn_codec_ctx_tNET opt_codex_ctx,
                                                                Asn_TYPE_descriptor_tNET typeDescriptor,
                                                                object structPtr, string optName,
                                                                object bufPtr, /*szt*/long size);

        public enum xer_encoder_flags_eNET
        {
            XER_F_BASIC_NET = 0x01, /* BASIC-XER (pretty-printing) */
            XER_F_CANONICAL_NET = 0x02	/* Canonical XER (strict rules) */
        };

        public delegate Asn_enc_rval_tNET xer_type_encoder_fNET(Asn_TYPE_descriptor_tNET typeDescriptor,
                                                                object structPtr, int iLevel,
                                                                xer_encoder_flags_eNET flags,
                                                                asn_app_consume_bytes_fNET consumeBytes,
                                                                object app_key);

        public asn_struct_print_fNET PrintStruct { get; set; }
        public ber_type_decoder_fNET BerDecoder { get; set; }
        public der_type_encoder_FNET DerEncoder { get; set; }
        public xer_type_decoder_fNET XerDecoder { get; set; }
        public xer_type_encoder_fNET XerEncoder { get; set; }




        public string Name { get; set; }
        public string XmlTag { get; set; }

        //TODO en-/de- coders, struct with tags
        public delegate long Asn_outmost_tag_fNET(Asn_TYPE_descriptor_tNET type_descriptor,
                                        object struct_ptr,
                                        int tag_mode, long tag);

        public Asn_outmost_tag_fNET outmost_tag;

        public uint[] Tags { get; set; }
        public int TagsCount { get; set; }
        public uint[] AllTags { get; set; }
        public int AllTagsCount { get; set; }

        public Asn_per_constraints_tNET PerConstraints { get; set; } 

        public Asn_TYPE_member_tNET Elements { get; set; }
        public int ElementsCount { get; set; }

        public object Specifics { get; set; }
    }
}
