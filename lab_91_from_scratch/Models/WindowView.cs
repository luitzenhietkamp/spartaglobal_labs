using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab_91_from_scratch.Models
{
    public class WindowView
    {
        public List<string> itemsInView { get; set; } = new List<string>();

        public new string ToString
        {
            get
            {
                string ret = "<ol>";
                foreach (var item in itemsInView)
                {
                    ret += $"<li>{item}</li>";
                }
                ret += "</ol>";
                return ret;
            }
        }
    }
}
