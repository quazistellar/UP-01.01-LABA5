using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UP_01._01.Laba_5.Model
{
    internal class formModel : IToFindModel
    {
       public string NameOfGuitarForm { get; set; }
        
    }

    internal class vidModel : IToFindModel
    {
        public string NameOfVidGuitar { get; set; }

    }

    internal interface IToFindModel
    {
    }
}
