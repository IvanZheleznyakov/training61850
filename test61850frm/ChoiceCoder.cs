﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static test61850frm.Asn_TYPE_descriptor_tNET;

namespace test61850frm
{
    public class ChoiceCoder
    {
        public int FetchPresentIdx(object structPtr, int presOffset, int presSize)
        {
            object presentPtr;
            int present = 0;
        }

        public Asn_enc_rval_tNET DerEncodeChoice(Asn_TYPE_descriptor_tNET td, object sptr,
                                                int tagMode, uint tag,
                                                asn_app_consume_bytes_fNET cb,
                                                object appKey)
        {
            Asn_CHOICE_specifics_tNET specs = (Asn_CHOICE_specifics_tNET)td.Specifics;
            Asn_TYPE_member_tNET elm = new Asn_TYPE_member_tNET();
            Asn_enc_rval_tNET erval = new Asn_enc_rval_tNET();
            object membPtr;
            /*szt*/
            long computedSize = 0;
            int present = 0;
            if (sptr == null)
            {
                Asn_enc_rval_tNET tmpError = new Asn_enc_rval_tNET()
                {
                    Encoded = -1,
                    FailedType = td,
                    StructurePtr = sptr,
                };

                return tmpError;
            }


        }
    }
}
