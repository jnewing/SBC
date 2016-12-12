using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;

namespace SimpleBallistics
{
    /// <summary>
    /// The main shared class.
    /// </summary>
    public class Main
    {
        /// <summary>
        /// RangeMonkey version major
        /// </summary>
        public const double VERSION = 1.1;
        
        /// <summary>
        /// RangeMonkey version minor
        /// </summary>
        public const int REVISION = 241;
        
        /// <summary>
        /// Is this a beta version?
        /// </summary>
        public const bool IS_BETA = true;

        /// <summary>
        /// Are we running debug version?
        /// </summary>
        public const bool DEBUG = false;
        
        /// <summary>
        /// Gets the .exe path.
        /// </summary>
        public static string ExecutablePath = Environment.GetCommandLineArgs()[0];
    }

}