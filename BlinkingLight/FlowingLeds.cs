using System.Collections.Generic;
using System.Device.Gpio;
using System.Threading;

namespace BlinkingLight
{
    public class FlowingLeds
    {
        private GpioController _controller;
        private List<int> _pins;

        public FlowingLeds(GpioController controller, List<int> pins)
        {
            _controller = controller;

            
        }

        public void FlowTheLights()
        {
            var ledOn = true;

            //Open all pins in the pins list in Output mode
            

            while (true)
            {
                //turn each pin on if ledOn is set to true, turns off once ledOn is inversed
                //Iterates through the list of pins in order
                foreach (var pin in _pins)
                {
                    _controller.Write(pin, ((ledOn) ? PinValue.High : PinValue.Low));
                    Thread.Sleep(100);
                }

                ledOn = !ledOn;
            }
            
        }

        public void CloseThePins()
        {
            foreach (var pin in _pins)
            {
                _controller.Write(pin, PinValue.Low);
                _controller.ClosePin(pin);
            }
        }
    }
}
