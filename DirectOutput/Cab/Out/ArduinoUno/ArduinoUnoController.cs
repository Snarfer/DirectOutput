using System;
using System.Collections.Generic;
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


        /// <summary>
        /// Init initializes the ouput controller.<br />
        /// This method is called after the objects haven been instanciated.
        /// </summary>
        /// <param name="Cabinet">The cabinet object which is using the output controller instance.</param>
        public override void Init(Cabinet Cabinet)
        {
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
        /// </summary>
        /// <param name="Output">The output.</param>
        protected override void OnOutputValueChanged(IOutput Output)
        {

        }
    }
}
