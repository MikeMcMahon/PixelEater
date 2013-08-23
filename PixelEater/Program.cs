using System;

namespace PixelEater
{
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            var factory = new MonoGame.Framework.GameFrameworkViewSource<PixelEater>();
            Windows.ApplicationModel.Core.CoreApplication.Run(factory);
        }
    }
}
