﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test61850frm
{
    public class Asn_TYPE_descriptor_tNET
    {
        public string Name { get; set; }
        public string XmlTag { get; set; }

        //TODO en-/de- coders, struct with tags

        public uint[] Tags { get; set; }
        public int TagsCount { get; set; }
        public int AllTagsCount { get; set; }


        public int ElementsCount { get; set; }

        public object Specifics { get; set; }
    }
}