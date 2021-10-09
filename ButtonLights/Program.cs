using System;
using System.Device.Gpio;

namespace ButtonLights
{
    class Program
    {
        static void Main(string[] args)
        {
            GpioController controller = new GpioController();

            SimpleButton simpleButton = new SimpleButton(controller);

            //ButtonPress buttonPress = new ButtonPress(controller);

            while (true) ;

        }
    }
}
