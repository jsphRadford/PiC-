using System;
using System.Collections.Generic;
using System.Device.Gpio;

namespace ButtonLights
{
    class SimpleButton
    {
        public GpioController _controller;

        public SimpleButton(GpioController controller)
        {
            _controller = controller;
            _controller.OpenPin(26, PinMode.Input);
            _controller.OpenPin(18, PinMode.Output);

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
                _controller.Write(18, PinValue.High);
            }
        }

        public void RisingButton(object sender, PinValueChangedEventArgs e)
        {
            if (e.ChangeType.Equals(PinEventTypes.Rising))
            {
                _controller.Write(18, PinValue.Low);
            }
        }
    }
}
