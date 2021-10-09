using System;
using System.Device.Gpio;
using System.Collections.Generic;
using System.Threading;

namespace ButtonLights
{
    public class ButtonPress
    {
        public GpioController _controller;
        List<int> pins = new List<int> { 18, 23, 24, 25, 12, 16, 20, 21 };

        public ButtonPress(GpioController controller)
        {
            _controller = controller;
            _controller.OpenPin(26, PinMode.Input);

            foreach (var pin in pins)
            {
                _controller.OpenPin(pin, PinMode.Output);
            }


            RegisterEvents();
        }

        public void RegisterEvents()
        {
            
            //Register callbacks for button press and release
            //Falling is button press, turn light on
            //Rising is releasing the button, turn light off
            _controller.RegisterCallbackForPinValueChangedEvent(26, PinEventTypes.Falling, new PinChangeEventHandler(FallingButton));
            _controller.RegisterCallbackForPinValueChangedEvent(26, PinEventTypes.Rising, new PinChangeEventHandler(RisingButton));
           
        }

        public void FallingButton(object sender, PinValueChangedEventArgs e)
        {
            if (e.ChangeType.Equals(PinEventTypes.Falling))
            {
                bool ledOn = true;
                for(int i=0; i<5; i++)
                {
                    foreach (var pin in pins)
                    {
                        _controller.Write(pin, ((ledOn) ? PinValue.High : PinValue.Low));
                        Thread.Sleep(100);
                    }

                    ledOn = !ledOn;
                }
            }
        }

        public void RisingButton(object sender, PinValueChangedEventArgs e)
        {
            if (e.ChangeType.Equals(PinEventTypes.Rising))
            {
                foreach (var pin in pins)
                {
                    _controller.Write(pin, PinValue.Low);
                    _controller.ClosePin(pin);
                }
            }
        }
    }
}
