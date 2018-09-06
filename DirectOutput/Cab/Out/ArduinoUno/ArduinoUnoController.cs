using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;

// <summary>
// This namespace contains an arduino implementation
// </summary>
namespace DirectOutput.Cab.Out.NullOutputController
{

    /// <summary>
     /// </summary>
    public class ArduinoUnoController : OutputControllerBase, IOutputController
    {
        private System.IO.Ports.SerialPort serialPort1;

        /// <summary>
        /// Init initializes the ouput controller.<br />
        /// This method is called after the objects haven been instanciated.
        /// </summary>
        /// <param name="Cabinet">The cabinet object which is using the output controller instance.</param>
        public override void Init(Cabinet Cabinet)
        {
            this.serialPort1 = new System.IO.Ports.SerialPort();
            string portNum = "";
            string port = "";
            serialPort1.Close();

            foreach (string ports in SerialPort.GetPortNames())
            {
                portNum = ports.ToString();

                //port = textBox1.Text;
            }
            port = "COM3";
            try
            {
                serialPort1.PortName = (port);
                serialPort1.BaudRate = 57600;
                serialPort1.DataBits = 8;
                serialPort1.Parity = Parity.None;
                serialPort1.StopBits = StopBits.One;
                serialPort1.Handshake = Handshake.None;
                serialPort1.Encoding = System.Text.Encoding.Default;
            }
            catch
            {
                throw new Exception("I am too old for this shit.");
            }


        }

        /// <summary>
        /// Finishes the ouput controller.<br/>
        /// All necessary cleanup tasks have to be implemented here und all physical outputs have to be turned off.
        /// </summary>
        public override void Finish()
        {

        }

        /// <summary>
        /// Update must update the physical outputs to the values defined in the Outputs list. 
        /// </summary>
        public override void Update()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NullOutputController"/> class.
        /// </summary>
        public ArduinoUnoController()
        {
            Outputs = new OutputList();

            for (int i = 1; i <= 15; i++)
            {
                if (!Outputs.Any(x => x.Number == i))
                {
                    Outputs.Add(new Output() { Name = "{0}.{1:00}".Build(Name, i), Number = i });
                }
            }
        }


        /// <summary>
        /// This method is called whenever the value of a output in the Outputs property changes its value.<br />
        /// This method must implement the logic to trigger the update the physical outputs.
        /// </summary>a
        /// <param name="Output">The output.</param>
        protected override void OnOutputValueChanged(IOutput Output)
        {
            //outpout { Output.Name}, { Output.Value}
            if (Output.Name == ".01" && Output.Value == 255)
            {
                serialPort1.Open();
                serialPort1.WriteLine("on");
                serialPort1.Close();
            }
            else if (Output.Name == ".01" && Output.Value == 0)
            {
                serialPort1.Open();
                serialPort1.WriteLine("off");
                serialPort1.Close();
            }
            else if (Output.Name == ".02" && Output.Value == 255)
            {
                serialPort1.Open();
                serialPort1.WriteLine("on");
                serialPort1.Close();
            }
            else if (Output.Name == ".02" && Output.Value == 0)
            {
                serialPort1.Open();
                serialPort1.WriteLine("off");
                serialPort1.Close();
            }




            //outpout ".01", 255
            //outpout ".01", 0
            //outpout ".02", 255
            //outpout ".02", 0
            //outpout ".01", 255
            //outpout ".02", 255
        }
    }
}
