using System;
using System.Timers;



void Handler(object s, ElapsedEventArgs arg)
{
    Console.WriteLine($"Timer with following interval:{(s as System.Timers.Timer).Interval}-{arg.SignalTime}");
}

void TimerSample()
{
    System.Timers.Timer aTimer = new System.Timers.Timer();
    aTimer.Interval = 2000;

    // Hook up the Elapsed event for the timer. 
    aTimer.Elapsed += (s, arg) => Console.WriteLine($"Timer is enabled:{(s as System.Timers.Timer).Enabled} last fired at:{arg.SignalTime} ");
    aTimer.Elapsed += Handler;
    //this is also referred to as callback in javascript
    // Have the timer fire repeated events (true is the default)
    aTimer.AutoReset = true;

    // Start the timer
    aTimer.Enabled = true;

    Console.WriteLine("Press the Enter key to remove Handler from Elaped Delegate");
    Console.ReadLine();
    aTimer.Elapsed -= Handler;

    Console.WriteLine("Press the Enter key to end the program");
    Console.ReadLine();
}