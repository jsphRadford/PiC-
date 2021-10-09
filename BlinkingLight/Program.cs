using System;
using System.Collections.Generic;
using System.Threading;
using System.Device.Gpio;

namespace BlinkingLight
{

    class Program
    {
        static void Main(string[] args)
        {

            using var controller = new GpioController();

            


            //--------------------FLOWING LIGHTS---------------------------
            //List of current GPIO pins on physical board
            List<int> leds = new List<int> { 18, 23, 24, 25, 12, 16, 20, 21 };
            //-----------------------------------------------

            //-------------------FLOWING LIGHTS----------------------------
            var flowingLights = new FlowingLeds(controller, leds);
            flowingLights.FlowTheLights();
            //-----------------------------------------------

            //--------------------FLOWING LIGHTS---------------------------
            //When Ctrl+C is pressed turn all pins off
            //Otherwise the GPIO pins will still be allocated and set the whatever state there in last
            Console.CancelKeyPress += delegate
            {
                flowingLights.CloseThePins();

                Console.WriteLine("\nClosed unexpectedly!");
            };
            //-----------------------------------------------




            //-------------------BLINKING LIGHTS----------------------------
            //var blinkLight = new BlinkingLight(controller);
            //Pass the pin the LED is on
            //blinkLight.BlinkTheLight(19);
            //-----------------------------------------------


        }
    }
}
