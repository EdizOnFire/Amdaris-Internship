using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Basics.Models
{
    public class ComputerModel : MachineModel
    {
        public string Processor { get; set; }
        public int AmountOfRam { get; set; }
    }
}
