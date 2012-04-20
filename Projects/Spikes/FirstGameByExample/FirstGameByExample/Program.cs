using System;

namespace FirstGameByExample
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (FirstGame game = new FirstGame())
            {
                game.Run();
            }
        }
    }
#endif
}

