﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// This is a re-work of the GNU Ballistics Lib that can 
/// be found @ https://sourceforge.net/projects/ballisticslib/
/// </summary>

namespace SimpleBallistics.BallisticsLib
{
    class Ballistics
    {

        #region DragFunctions ENUM

        public enum __DragFunctions
        {
            G1 = 1,
            G2,
            G3,
            G4,
            G5,
            G6,
            G7,
            G8
        }

        #endregion

        #region CONST's

        public const int __BCOMP_MAXRANGE__ = 5000;
        public const double GRAVITY = -32.194;
        public const double GNU_PI = 3.141592653589;    // Pi, more or less...

        #endregion

        #region Internal Functions

        /// <summary>
        /// Converts degrees to minutes of angle
        /// </summary>
        /// <param name="deg"></param>
        /// <returns></returns>
        public static double DegtoMOA(double deg)
        {
            return deg * 60;
        }

        /// <summary>
        /// Converts degrees to radians
        /// </summary>
        /// <param name="deg"></param>
        /// <returns></returns>
        public static double DegtoRad(double deg)
        {
            return (deg) * 0.01745329251994329576923690768489;
        }

        /// <summary>
        ///  Converts minutes of angle to degrees
        /// </summary>
        /// <param name="moa"></param>
        /// <returns></returns>
        public static double MOAtoDeg(double moa)
        {
            return moa * 0.01666666666666666666666666666667;
        }

        /// <summary>
        /// Converts minutes of angle to radians
        /// </summary>
        /// <param name="moa"></param>
        /// <returns></returns>
        public static double MOAtoRad(double moa)
        {
            return (moa) * 0.00029088820866572159615394846141477;
        }

        /// <summary>
        /// Converts radians to degrees
        /// </summary>
        /// <param name="rad"></param>
        /// <returns></returns>
        public static double RadtoDeg(double rad)
        {
            return rad * 57.295779513082320876798154814105;
        }

        /// <summary>
        /// Converts radians to MOA
        /// </summary>
        /// <param name="rad"></param>
        /// <returns></returns>
        public static double RadtoMOA(double rad)
        {
            return rad * 3437.7467707849392526078892888463;
        }

        // Converts radians to MIL
        public static double RadtoMIL(double rad)
        {
            return 0.000981747704247 * rad;
        }

        // Converts degrees to MIL
        public static double DegtoMil(double deg)
        {
            return deg * 17.777777777778;
        }

        #endregion

        #region Atmosphere Calculations

        public static double calcFR(double Temperature, double Pressure, double RelativeHumidity)
        {
            double VPw = 4e-6 * Math.Pow(Temperature, 3) - 0.0004 * Math.Pow(Temperature, 2) + 0.0234 * Temperature - 0.2517;
            double FRH = 0.995 * (Pressure / (Pressure - (0.3783) * (RelativeHumidity) * VPw));
            return FRH;
        }

        public static double calcFP(double Pressure)
        {
            double Pstd = 29.53; // in-hg
            double FP = 0;
            FP = (Pressure - Pstd) / (Pstd);
            return FP;
        }

        public static double calcFT(double Temperature, double Altitude)
        {
            double Tstd = -0.0036 * Altitude + 59;
            double FT = (Temperature - Tstd) / (459.6 + Tstd);
            return FT;
        }

        public static double calcFA(double Altitude)
        {
            double fa = 0;
            fa = -4e-15 * Math.Pow(Altitude, 3) + 4e-10 * Math.Pow(Altitude, 2) - 3e-5 * Altitude + 1;
            return (1 / fa);
        }

        #endregion

        /// c<summary>
        /// Correct a "standard" Drag Coefficient for differing atmospheric conditions.
        /// </summary>
        /// <param name="DragCoefficient"></param>
        /// <param name="Altitude"></param>
        /// <param name="Barometer"></param>
        /// <param name="Temperature"></param>
        /// <param name="RelativeHumidity"></param>
        /// <returns>Returns the corrected drag coefficient for supplied drag coefficient and atmospheric conditions.</returns>
        public static double AtmCorrect(double DragCoefficient, double Altitude, double Barometer, double Temperature, double RelativeHumidity)
        {
            double FA = calcFA(Altitude);
            double FT = calcFT(Temperature, Altitude);
            double FR = calcFR(Temperature, Barometer, RelativeHumidity);
            double FP = calcFP(Barometer);

            // calculate the atmospheric correction factor
            double CD = (FA * (1 + FT - FP) * FR);
            return DragCoefficient * CD;
        }

        /// <summary>
        /// Calculate ballistic retardation values based on standard drag functions.
        /// </summary>
        /// <param name="DragFunction"></param>
        /// <param name="DragCoefficient"></param>
        /// <param name="Velocity"></param>
        /// <returns></returns>
        public static double retard(__DragFunctions DragFunction, double DragCoefficient, double Velocity)
        {

            //	printf("DF: %d, CD: %f, V: %f,);

            double vp = Velocity;
            double val = -1;
            double A = -1;
            double M = -1;
            switch (DragFunction)
            {
                case __DragFunctions.G1:
                    if (vp > 4230) { A = 1.477404177730177e-04; M = 1.9565; }
                    else if (vp > 3680) { A = 1.920339268755614e-04; M = 1.925; }
                    else if (vp > 3450) { A = 2.894751026819746e-04; M = 1.875; }
                    else if (vp > 3295) { A = 4.349905111115636e-04; M = 1.825; }
                    else if (vp > 3130) { A = 6.520421871892662e-04; M = 1.775; }
                    else if (vp > 2960) { A = 9.748073694078696e-04; M = 1.725; }
                    else if (vp > 2830) { A = 1.453721560187286e-03; M = 1.675; }
                    else if (vp > 2680) { A = 2.162887202930376e-03; M = 1.625; }
                    else if (vp > 2460) { A = 3.209559783129881e-03; M = 1.575; }
                    else if (vp > 2225) { A = 3.904368218691249e-03; M = 1.55; }
                    else if (vp > 2015) { A = 3.222942271262336e-03; M = 1.575; }
                    else if (vp > 1890) { A = 2.203329542297809e-03; M = 1.625; }
                    else if (vp > 1810) { A = 1.511001028891904e-03; M = 1.675; }
                    else if (vp > 1730) { A = 8.609957592468259e-04; M = 1.75; }
                    else if (vp > 1595) { A = 4.086146797305117e-04; M = 1.85; }
                    else if (vp > 1520) { A = 1.954473210037398e-04; M = 1.95; }
                    else if (vp > 1420) { A = 5.431896266462351e-05; M = 2.125; }
                    else if (vp > 1360) { A = 8.847742581674416e-06; M = 2.375; }
                    else if (vp > 1315) { A = 1.456922328720298e-06; M = 2.625; }
                    else if (vp > 1280) { A = 2.419485191895565e-07; M = 2.875; }
                    else if (vp > 1220) { A = 1.657956321067612e-08; M = 3.25; }
                    else if (vp > 1185) { A = 4.745469537157371e-10; M = 3.75; }
                    else if (vp > 1150) { A = 1.379746590025088e-11; M = 4.25; }
                    else if (vp > 1100) { A = 4.070157961147882e-13; M = 4.75; }
                    else if (vp > 1060) { A = 2.938236954847331e-14; M = 5.125; }
                    else if (vp > 1025) { A = 1.228597370774746e-14; M = 5.25; }
                    else if (vp > 980) { A = 2.916938264100495e-14; M = 5.125; }
                    else if (vp > 945) { A = 3.855099424807451e-13; M = 4.75; }
                    else if (vp > 905) { A = 1.185097045689854e-11; M = 4.25; }
                    else if (vp > 860) { A = 3.566129470974951e-10; M = 3.75; }
                    else if (vp > 810) { A = 1.045513263966272e-08; M = 3.25; }
                    else if (vp > 780) { A = 1.291159200846216e-07; M = 2.875; }
                    else if (vp > 750) { A = 6.824429329105383e-07; M = 2.625; }
                    else if (vp > 700) { A = 3.569169672385163e-06; M = 2.375; }
                    else if (vp > 640) { A = 1.839015095899579e-05; M = 2.125; }
                    else if (vp > 600) { A = 5.71117468873424e-05; M = 1.950; }
                    else if (vp > 550) { A = 9.226557091973427e-05; M = 1.875; }
                    else if (vp > 250) { A = 9.337991957131389e-05; M = 1.875; }
                    else if (vp > 100) { A = 7.225247327590413e-05; M = 1.925; }
                    else if (vp > 65) { A = 5.792684957074546e-05; M = 1.975; }
                    else if (vp > 0) { A = 5.206214107320588e-05; M = 2.000; }
                    break;

                case __DragFunctions.G2:
                    if (vp > 1674) { A = .0079470052136733; M = 1.36999902851493; }
                    else if (vp > 1172) { A = 1.00419763721974e-03; M = 1.65392237010294; }
                    else if (vp > 1060) { A = 7.15571228255369e-23; M = 7.91913562392361; }
                    else if (vp > 949) { A = 1.39589807205091e-10; M = 3.81439537623717; }
                    else if (vp > 670) { A = 2.34364342818625e-04; M = 1.71869536324748; }
                    else if (vp > 335) { A = 1.77962438921838e-04; M = 1.76877550388679; }
                    else if (vp > 0) { A = 5.18033561289704e-05; M = 1.98160270524632; }
                    break;

                case __DragFunctions.G5:
                    if (vp > 1730) { A = 7.24854775171929e-03; M = 1.41538574492812; }
                    else if (vp > 1228) { A = 3.50563361516117e-05; M = 2.13077307854948; }
                    else if (vp > 1116) { A = 1.84029481181151e-13; M = 4.81927320350395; }
                    else if (vp > 1004) { A = 1.34713064017409e-22; M = 7.8100555281422; }
                    else if (vp > 837) { A = 1.03965974081168e-07; M = 2.84204791809926; }
                    else if (vp > 335) { A = 1.09301593869823e-04; M = 1.81096361579504; }
                    else if (vp > 0) { A = 3.51963178524273e-05; M = 2.00477856801111; }
                    break;

                case __DragFunctions.G6:
                    if (vp > 3236) { A = 0.0455384883480781; M = 1.15997674041274; }
                    else if (vp > 2065) { A = 7.167261849653769e-02; M = 1.10704436538885; }
                    else if (vp > 1311) { A = 1.66676386084348e-03; M = 1.60085100195952; }
                    else if (vp > 1144) { A = 1.01482730119215e-07; M = 2.9569674731838; }
                    else if (vp > 1004) { A = 4.31542773103552e-18; M = 6.34106317069757; }
                    else if (vp > 670) { A = 2.04835650496866e-05; M = 2.11688446325998; }
                    else if (vp > 0) { A = 7.50912466084823e-05; M = 1.92031057847052; }
                    break;

                case __DragFunctions.G7:
                    if (vp > 4200) { A = 1.29081656775919e-09; M = 3.24121295355962; }
                    else if (vp > 3000) { A = 0.0171422231434847; M = 1.27907168025204; }
                    else if (vp > 1470) { A = 2.33355948302505e-03; M = 1.52693913274526; }
                    else if (vp > 1260) { A = 7.97592111627665e-04; M = 1.67688974440324; }
                    else if (vp > 1110) { A = 5.71086414289273e-12; M = 4.3212826264889; }
                    else if (vp > 960) { A = 3.02865108244904e-17; M = 5.99074203776707; }
                    else if (vp > 670) { A = 7.52285155782535e-06; M = 2.1738019851075; }
                    else if (vp > 540) { A = 1.31766281225189e-05; M = 2.08774690257991; }
                    else if (vp > 0) { A = 1.34504843776525e-05; M = 2.08702306738884; }
                    break;

                case __DragFunctions.G8:
                    if (vp > 3571) { A = .0112263766252305; M = 1.33207346655961; }
                    else if (vp > 1841) { A = .0167252613732636; M = 1.28662041261785; }
                    else if (vp > 1120) { A = 2.20172456619625e-03; M = 1.55636358091189; }
                    else if (vp > 1088) { A = 2.0538037167098e-16; M = 5.80410776994789; }
                    else if (vp > 976) { A = 5.92182174254121e-12; M = 4.29275576134191; }
                    else if (vp > 0) { A = 4.3917343795117e-05; M = 1.99978116283334; }
                    break;

                default:
                    break;

            }

            if (A != -1 && M != -1 && vp > 0 && vp < 10000)
            {
                val = A * Math.Pow(vp, M) / DragCoefficient;
                return val;
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// A function to generate a ballistic solution table in 1 yard increments, up to __BCOMP_MAXRANGE__.
        /// </summary>
        /// <param name="DragFunction"></param>
        /// <param name="DragCoefficient"></param>
        /// <param name="weight"></param>
        /// <param name="Vi"></param>
        /// <param name="SightHeight"></param>
        /// <param name="ShootingAngle"></param>
        /// <param name="ZAngle"></param>
        /// <param name="WindSpeed"></param>
        /// <param name="WindAngle"></param>
        /// <returns></returns>
        public static List<Dictionary<string, double>> SolveAll(__DragFunctions DragFunction, double DragCoefficient, double weight, double Vi, double SightHeight, double ShootingAngle, double ZAngle, double WindSpeed, double WindAngle)
	    {            
            // our calculated resutls
            List<Dictionary<string, double>> items = new List<Dictionary<string, double>>();

		    double t = 0;
		    double dt = 0.5 / Vi;
		    double v = 0;
		    double vx = 0;
		    double vx1 = 0;
		    double vy = 0;
		    double vy1 = 0;
		    double dv = 0;
		    double dvx = 0;
		    double dvy = 0;
		    double x = 0;
		    double y = 0;

		    double headwind = HeadWind(WindSpeed, WindAngle);
		    double crosswind = CrossWind(WindSpeed, WindAngle);

		    double Gy = GRAVITY * Math.Cos(DegtoRad((ShootingAngle + ZAngle)));
		    double Gx = GRAVITY * Math.Sin(DegtoRad((ShootingAngle + ZAngle)));

		    vx = Vi * Math.Cos(DegtoRad(ZAngle));
		    vy = Vi * Math.Sin(DegtoRad(ZAngle));

		    y = -SightHeight / 12;

		    int n = 0;
		    for (t = 0;;t = t + dt)
		    {

                vx1 = vx;
                vy1 = vy;
			
                v = Math.Pow(Math.Pow(vx,2) + Math.Pow(vy,2),0.5);
			    dt = 0.5 / v;

			    // compute acceleration using the drag function retardation	
			    dv = retard(DragFunction, DragCoefficient, v + headwind);
			    dvx = -(vx / v) * dv;
			    dvy = -(vy / v) * dv;

			    // compute velocity, including the resolved gravity vectors.	
			    vx = vx + dt * dvx + dt * Gx;
			    vy = vy + dt * dvy + dt * Gy;

			    if (x / 3 >= n)
			    {
                    items.Add(new Dictionary<string, double>
                    {
                        { "range", x / 3 },                                         // range in yards
                        { "path", y * 12 },                                         // path in inches
                        { "correction_moa", -RadtoMOA(Math.Atan(y / x)) },          // correction in MOA
                        { "correction_mil", -RadtoMIL(Math.Atan(y / x)) },          // correction in MIL
                        { "time", t + dt },                                         // time in seconds
                        { "windage_in", Windage(crosswind, Vi, x, t + dt) },        // windade in inches
                        { "windage_moa", InchestoMOA(x / 3, Windage(crosswind, Vi, x, t + dt)) },         // windage in MOA
                        { "windage_mil", InchestoMIL(x / 3, Windage(crosswind, Vi, x, t + dt)) },         // windage in MOA
                        { "velocity_z", v },                                        // velocity (combined)
                        { "velocity_x", vx },                                       // velocity (x)
                        { "velocity_y", vy },                                       // Velocity (y)
                        { "energy", Math.Pow(v, 2) / 450380.0 * weight },           // energy
                        { "reserved", 0 },

                    });
				    
				    n++;
			    }

			    // compute position based on average velocity.
			    x = x + dt * (vx + vx1) / 2;
			    y = y + dt * (vy + vy1) / 2;

			    if (Math.Abs(vy) > Math.Abs(3 * vx))
				    break;

			    if (n >= __BCOMP_MAXRANGE__ + 1)
				    break;
		    }

            return items;
	    }

        /// <summary>
        /// Compute the windage deflection for a given crosswind speed,
        /// given flight time in a vacuum, and given flight time in real life.
        /// </summary>
        /// <param name="WindSpeed"></param>
        /// <param name="Vi"></param>
        /// <param name="xx"></param>
        /// <param name="t"></param>
        /// <returns>Returns the windage correction needed in inches.</returns>
        public static double Windage(double WindSpeed, double Vi, double xx, double t)
        {
            double Vw = WindSpeed * 17.60; // Convert to inches per second.
            return (Vw * (t - xx / Vi));
        }

        /// <summary>
        /// Headwind is positive at WindAngle = 0
        /// </summary>
        /// <param name="WindSpeed"></param>
        /// <param name="WindAngle"></param>
        /// <returns></returns>
        public static double HeadWind(double WindSpeed, double WindAngle)
        {
            double Wangle = DegtoRad(WindAngle);
            return (Math.Cos(Wangle) * WindSpeed);
        }

        /// <summary>
        /// Positive is from Shooter's Right to Left (Wind from 90 degree)
        /// </summary>
        /// <param name="WindSpeed"></param>
        /// <param name="WindAngle"></param>
        /// <returns></returns>
        public static double CrossWind(double WindSpeed, double WindAngle)
        {
            double Wangle = DegtoRad(WindAngle);
            return (Math.Sin(Wangle) * WindSpeed);
        }

        /// <summary>
        /// Determine the bore angle needed to achieve a target zero at Range yards
        /// (at standard conditions and on level ground.)
        /// </summary>
        /// <param name="DragFunction"></param>
        /// <param name="DragCoefficient"></param>
        /// <param name="Vi"></param>
        /// <param name="SightHeight"></param>
        /// <param name="ZeroRange"></param>
        /// <param name="yIntercept"></param>
        /// <returns></returns>
        public static double ZeroAngle(__DragFunctions DragFunction, double DragCoefficient, double Vi, double SightHeight, double ZeroRange, double yIntercept)
        {

            // Numerical Integration variables
            double t = 0;
            double dt = 1 / Vi; // The solution accuracy generally doesn't suffer if its within a foot for each second of time.
            double y = -SightHeight / 12;
            double x = 0;
            double da; // The change in the bore angle used to iterate in on the correct zero angle.

            // State variables for each integration loop.
            double v = 0; // velocity
            double vx = 0;
            double vy = 0;
            double vx1 = 0; // Last frame's velocity, used for computing average velocity.
            double vy1 = 0;
            double dv = 0; // acceleration
            double dvx = 0;
            double dvy = 0;
            double Gx = 0; // Gravitational acceleration
            double Gy = 0;

            double angle = 0; // The actual angle of the bore.

            int quit = 0; // We know it's time to quit our successive approximation loop when this is 1.

            // Start with a very coarse angular change, to quickly solve even large launch angle problems.
            da = DegtoRad(14);


            // The general idea here is to start at 0 degrees elevation, and increase the elevation by 14 degrees
            // until we are above the correct elevation.  Then reduce the angular change by half, and begin reducing
            // the angle.  Once we are again below the correct angle, reduce the angular change by half again, and go
            // back up.  This allows for a fast successive approximation of the correct elevation, usually within less
            // than 20 iterations.
            for (angle = 0; quit == 0; angle = angle + da)
            {
                vy = Vi * Math.Sin(angle);
                vx = Vi * Math.Cos(angle);
                Gx = GRAVITY * Math.Sin(angle);
                Gy = GRAVITY * Math.Cos(angle);

                for (t = 0, x = 0, y = -SightHeight / 12; x <= ZeroRange * 3; t = t + dt)
                {
                    vy1 = vy;
                    vx1 = vx;
                    v = Math.Pow((Math.Pow(vx, 2) + Math.Pow(vy, 2)), 0.5);
                    dt = 1 / v;

                    dv = retard(DragFunction, DragCoefficient, v);
                    dvy = -dv * vy / v * dt;
                    dvx = -dv * vx / v * dt;

                    vx = vx + dvx;
                    vy = vy + dvy;
                    vy = vy + dt * Gy;
                    vx = vx + dt * Gx;

                    x = x + dt * (vx + vx1) / 2;
                    y = y + dt * (vy + vy1) / 2;
                    // Break early to save CPU time if we won't find a solution.
                    if (vy < 0 && y < yIntercept)
                    {
                        break;
                    }
                    if (vy > 3 * vx)
                    {
                        break;
                    }
                }

                if (y > yIntercept && da > 0)
                {
                    da = -da / 2;
                }

                if (y < yIntercept && da < 0)
                {
                    da = -da / 2;
                }

                if (Math.Abs(da) < MOAtoRad(0.01))
                {
                    quit = 1; // If our accuracy is sufficient, we can stop approximating.
                }
                if (angle > DegtoRad(45))
                {
                    quit = 1; // If we exceed the 45 degree launch angle, then the projectile just won't get there, so we stop trying.
                }

            }
            
            return RadtoDeg(angle); // Convert to degrees for return value.
        }

        /// <summary>
        /// Gets Mil clicks for scope.
        /// </summary>
        /// <param name="mil"></param>
        /// <param name="grad"></param>
        /// <returns></returns>
        public static int toMILClicks(double mil, double grad = 0.10)
        {
            return (int) Math.Ceiling((mil / grad));
        }

        /// <summary>
        /// Gets MOA clicks for scope.
        /// </summary>
        /// <param name="moa"></param>
        /// <param name="grad"></param>
        /// <returns></returns>
        public static int toMOAClicks(double moa, double grad = 0.25)
        {
            return (int)Math.Ceiling((moa / grad));
        }

        /// <summary>
        /// Takes inches and a given correction and returns MOA
        /// </summary>
        /// <param name="range"></param>
        /// <param name="correction"></param>
        /// <returns></returns>
        public static double InchestoMOA(double range, double correction)
        {
            return correction / ((range / 100) * 1.047);
        }

        public static double InchestoMIL(double range, double correction)
        {
            return correction / ((range / 100) * 3.6);
        }
        
    }
}

