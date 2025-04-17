using System;
using System.Runtime.InteropServices;

class KLCConsole
{
    // Importing functions from the KLCCommandLib_x64.dll using P/Invoke
    [DllImport("KLCCommandLib_x64.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern int List([Out] char[] listStr, int bufferSize);

    [DllImport("KLCCommandLib_x64.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern int Open(string comPort, int baudRate, int timeout);

    [DllImport("KLCCommandLib_x64.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void Close(int handle);

    [DllImport("KLCCommandLib_x64.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void SetVoltage1(int handle, float voltage);

    [DllImport("KLCCommandLib_x64.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void GetVoltage1(int handle, out float voltage);

    [DllImport("KLCCommandLib_x64.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void SetVoltage2(int handle, float voltage);

    [DllImport("KLCCommandLib_x64.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void GetVoltage2(int handle, out float voltage);

    [DllImport("KLCCommandLib_x64.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void SetFrequency1(int handle, ushort frequency);

    [DllImport("KLCCommandLib_x64.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void GetFrequency1(int handle, out ushort frequency);

    [DllImport("KLCCommandLib_x64.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void SetFrequency2(int handle, ushort frequency);

    [DllImport("KLCCommandLib_x64.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void GetFrequency2(int handle, out ushort frequency);

    [DllImport("KLCCommandLib_x64.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void SetSWFrequency(int handle, float frequency);

    [DllImport("KLCCommandLib_x64.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void GetSWFrequency(int handle, out float frequency);

    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to KLC command library test");
        Console.WriteLine("Below are connected devices, please input com port:");

        char[] listStr = new char[2048];
        int count = List(listStr, listStr.Length);
        if (count == 0)
        {
            Console.WriteLine("There is no KLC device connected!");
            return;
        }

        Console.WriteLine(new string(listStr));
        Console.Write("Enter serial number of device: ");
        string comPort = Console.ReadLine();

        int handle = Open(comPort, 115200, 3000);
        if (handle < 0)
        {
            Console.WriteLine($"Open {comPort} failed!");
            Console.WriteLine("Please check the connection and try again.");
            Console.ReadLine();
            return;
        }
        else
        {
            Console.WriteLine("Open successful!");
        }

        Console.WriteLine("Key => q 'exit'");
        Console.WriteLine("Key => v 'Voltage 1'");
        Console.WriteLine("Key => V 'Voltage 2'");
        Console.WriteLine("Key => f 'Frequency 1'");
        Console.WriteLine("Key => F 'Frequency 2'");
        Console.WriteLine("Key => s 'Switch frequency'");

        char ch;
        float vol1 = 0, vol2 = 0;
        ushort f1 = 0, f2 = 0;
        float swFreq = 0;

        do
        {
            ch = Console.ReadKey(true).KeyChar;
            switch (ch)
            {
                case 'v':
                    Console.WriteLine("Input the voltage 1 (0~25):");
                    float v = float.Parse(Console.ReadLine());
                    SetVoltage1(handle, v);
                    GetVoltage1(handle, out vol1);
                    Console.WriteLine($"vol1 get => {vol1}");
                    break;

                case 'V':
                    Console.WriteLine("Input the voltage 2 (0~25):");
                    float V = float.Parse(Console.ReadLine());
                    SetVoltage2(handle, V);
                    GetVoltage2(handle, out vol2);
                    Console.WriteLine($"vol2 get => {vol2}");
                    break;

                case 'f':
                    Console.WriteLine("Input the frequency 1 (500~10000):");
                    ushort f = ushort.Parse(Console.ReadLine());
                    SetFrequency1(handle, f);
                    GetFrequency1(handle, out f1);
                    Console.WriteLine($"f1 get => {f1}");
                    break;

                case 'F':
                    Console.WriteLine("Input the frequency 2 (500~10000):");
                    ushort F = ushort.Parse(Console.ReadLine());
                    SetFrequency2(handle, F);
                    GetFrequency2(handle, out f2);
                    Console.WriteLine($"f2 get => {f2}");
                    break;

                case 's':
                    Console.WriteLine("Input the switch frequency (0.1~150):");
                    float s = float.Parse(Console.ReadLine());
                    SetSWFrequency(handle, s);
                    GetSWFrequency(handle, out swFreq);
                    Console.WriteLine($"swFreq => {swFreq}");
                    break;

                default:
                    if (ch != 'q')
                        Console.WriteLine($"{ch} is not a valid input");
                    break;
            }
        } while (ch != 'q');

        Close(handle);
    }
}