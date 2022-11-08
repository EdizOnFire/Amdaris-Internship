using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Basics.Models
{
    public class MachineModel
    {
        private string _machineId;
        public int Quantity { get; set; }
        bool isOn = false;
        public string MachineId
        {
            get { return _machineId; }
            set { _machineId = value; }
        }

        public void TurnOn()
        {
            if (isOn)
            {
                Console.WriteLine("The machine is already on.");
            }
            else
            {
                Console.WriteLine("The machine is turned on.");
                isOn = true;
            }
        }

        public void TurnOff()
        {
            if (isOn)
            {
                Console.WriteLine("The machine is turned off.");
                isOn = false;
            }
            else
            {
                Console.WriteLine("The machine is already turned off.");
            }
        }
    }
}
