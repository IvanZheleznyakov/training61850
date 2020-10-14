using System.Runtime.InteropServices;
using static test61850frm.Asn_TYPE_descriptor_tNET;

namespace test61850frm
{
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.None)]
    public class DerEncoder: IDerEncoder
    {
        /*     sszt*/
        public long WriteTL(uint tag, /*sszt*/ long len, asn_app_consume_bytes_fNET cb,
                            object appKey, int constructed)
        {
            byte[] buf = new byte[32];
            /*szt*/
            long size = 0;
            int bufSize;
            unsafe
            {
                bufSize = cb != null ? sizeof(byte) : 0;
            }

            /*sszt*/
            long tmp; //todo serialize methods
        }
            
        /*     sszt*/
        public long WriteTags(Asn_TYPE_descriptor_tNET sd, /*szt*/long structLength,
                                int tagMode, int lastTagForm, uint tag,
                                asn_app_consume_bytes_fNET cb, object appKey)
        {
            uint[] tagMem = new uint[5];
            uint[] tags;
            int tagsCount;
            /*szt*/
            long overallLength;
            /*sszt*/
            long[] lens = new long[5];

            if (sd.TagsCount > 4)
            {
                //too much tags
                return -1;
            }

            if (tagMode > 0)
            {
                int stagOffset;
                tags = tagMem;
                bool isTags = sd.TagsCount > 0;
                int oddExplicit = ((tagMode == -1) && isTags) ? 1 : 0;
                tagsCount = sd.TagsCount + 1 - oddExplicit;
                tags[0] = tag;
                stagOffset = -1 + oddExplicit;
                for (int i = 1; i != tagsCount; ++i)
                {
                    tags[i] = sd.Tags[i + stagOffset];
                }
            }
            else
            {
                tags = sd.Tags;
                tagsCount = sd.TagsCount;
            }

            if (tagsCount == 0)
            {
                return 0;
            }

            overallLength = structLength;
            for (int i = tagsCount - 1; i >= 0; --i)
            {
                //todo write TL
            }
        }
    }
}
