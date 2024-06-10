using Microsoft.Maui;
using Microsoft.Maui.Hosting;
using System;

namespace Flappy_Miau;

internal class Program : MauiApplication
{
    protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();

    static void Main(string[] args)
    {
        Program program = new Program();
        program.Run(args);
    }
}