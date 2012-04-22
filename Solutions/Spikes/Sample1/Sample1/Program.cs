using System;

namespace Sample1
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (Sample1Game game = new Sample1Game())
            {
                game.Run();
            }
        }
    }
#endif
}

