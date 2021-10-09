using System.Device.Gpio;
using System.Threading;


namespace BlinkingLight
{
    public class BlinkingLight
    {
        private GpioController _controller;

        public BlinkingLight(GpioController controller)
        {
            _controller = controller;
        }

        public void BlinkTheLight(int pin)
        {
            _controller.OpenPin(pin, PinMode.Output);
            var ledOn = true;

            while (true)
            {
                _controller.Write(pin, ((ledOn) ? PinValue.High : PinValue.Low));
                Thread.Sleep(1000);
                ledOn = !ledOn;
            }
        }
    }
}