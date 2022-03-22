using System;
using System.Collections;
using System.Collections.Generic;

namespace RazorMVCDotNetApp.Dto
{
    public class SearchDto
    {
        public IDictionary<String,string> search { set; get; }
        public int draw { set; get; }
        public int length { set; get; }
        public int start { set; get; }
        public int deptId { set; get; }
        public int empId { set; get; }
    }
}