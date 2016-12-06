using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBallistics.BallisticsLib
{
    class RangeCard
    {
        public int Range { get; set; }

        public double Drop { get; set; }

        public double CorrectionMOA { get; set; }

        public double CorrectionMIL { get; set; }

        public double Time { get; set; }

        public double Velocity { get; set; }

        public double Energy { get; set; }
    }
}
