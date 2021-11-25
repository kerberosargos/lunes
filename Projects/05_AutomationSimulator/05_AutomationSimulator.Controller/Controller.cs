using System.Diagnostics;

namespace _05_AutomationSimulator
{
    public class Controller
    {
        public static Outputs Update(Inputs inputs)
        {

            Debug.WriteLine($"inputs -> Time {inputs.CurrentTimeInMilliseconds}  -> PositioningEnabled: {inputs.PositioningEnabled} -> SensorLeft: {inputs.ProximitySensorLeft} -> SensorMiddle: {inputs.ProximitySensorMiddle} -> SensorRight: {inputs.ProximitySensorRight}");

            if (!inputs.PositioningEnabled)
            {
                return default(Outputs);

            }
            else
            {
                var outputs = new Outputs();

                if (!inputs.ProximitySensorLeft && !inputs.ProximitySensorMiddle && !inputs.ProximitySensorRight)
                {
                    outputs.MoveRight = true;
                    outputs.MoveSpeed = 20.0;
                }
                else if (!inputs.ProximitySensorLeft && inputs.ProximitySensorMiddle && !inputs.ProximitySensorRight)
                {
                    outputs.MoveRight = true;
                    outputs.MoveSpeed = 10.0;
                }
                else if (!inputs.ProximitySensorLeft && !inputs.ProximitySensorMiddle && inputs.ProximitySensorRight)
                {
                    outputs.MoveRight = false;
                    outputs.MoveSpeed = 0;
                }
                return outputs;

            }
        }
    }
}
