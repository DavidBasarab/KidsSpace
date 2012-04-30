using System;

namespace Chapter2
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (var game = new Chapter2Game())
            {
                game.Run();
            }
        }
    }
#endif
}

