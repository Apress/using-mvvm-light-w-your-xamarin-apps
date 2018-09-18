using System;
using TimeOfDeath.Extensions;
using TimeOfDeath.Models;

namespace TimeOfDeath.Helpers
{
    public class Calculation
    {
        CalcData calcData;
        double[,] correctionData = new double[3, 20];
        double[,] iterations = new double[3, 20];
        double c = 0, b = 0, cas = 0;

        public Calculation(CalcData calc)
        {
            calcData = calc;
        }

        double correctionFactor()
        {
            double correction = 0;
            switch (calcData.setP)
            {
                case 0: // dry naked
                    correction = calcData.setA == 0 ? 0.75 : 1;
                    break;
                case 1: // dry 1-2 thin layers
                    correction = calcData.setA == 0 ? 0.9 : 1.1;
                    break;
                case 2: // dry 2-3 thin layers
                case 4: // dry 1-2 thicker
                    correction = 1.2;
                    break;
                case 3: // dry 3-4 thin layers
                    correction = 1.3;
                    break;
                case 5: // more layers
                    correction = calcData.setA == 2 ? 1.8 : 1.4;
                    break;
                case 6: // naked
                    if (calcData.setW != 2 && calcData.setA == -2)
                        correction = calcData.setW == 0 ? 0.35 : 0.5;
                    else
                        correction = 0.7;
                    break;
                case 7: // wet 1-2 thin layers
                    correction = 0.7;
                    break;
                case 8: // wet 2 thicker
                    correction = 1.1;
                    break;
                case 9: // wet, 2 or more
                    correction = calcData.setPA == 0 ? 1.2 : 0.9;
                    break;
            }
            return correction;
        }

        void calculateCandB(double ta, double tr, double m)
        {
            c = (tr - ta) / (37.2 - ta);
            b = -1.2815 * (1 / Math.Pow(m, 0.625)) + 0.0284;
        }

        void calculateCorrections(bool test)
        {
            double x = test == true ? 1.25 : 1.11;
            double y = test == true ? 6.25 : 11;
            double z = test == true ? 5 : 10;
            int n = 1;
            correctionData[0, 0] = 0;
            correctionData[1, 0] = x * (b * b) * Math.Exp(b * correctionData[0, 0]) -
            y * (b * b) * Math.Exp(z * b * correctionData[0, 0]);
            correctionData[2, 0] = x * Math.Pow(b, 3) * Math.Exp(b * correctionData[0, 0]) -
            y * z * Math.Pow(b, 3) * Math.Exp(z * b * correctionData[0, 0]);
            while (n < 20)
            {
                correctionData[0, n] = correctionData[0, n - 1] -
                (correctionData[1, n - 1] / correctionData[2, n - 1]);
                correctionData[1, n] = x * (b * b) * Math.Exp(b * correctionData[0, n]) -
                y * (b * b) * Math.Exp(z * b * correctionData[0, n]);
                correctionData[2, n] = x * Math.Pow(b, 3) * Math.Exp(b * correctionData[0, n]) -
                y * z * Math.Pow(b, 3) * Math.Exp(z * b * correctionData[0, n]);
                n++;
            }
        }

        void calculateIterations(bool test)
        {
            double x = test == true ? 1.25 : 1.11;
            double y = test == true ? 0.25 : 0.11;
            double z = test == true ? 5 : 10;
            double o = test == true ? 6.25 : 11;
            double j = x * (b * b) * Math.Exp(b * (correctionData[0, 19] + 0.0001)) - o * (b * b) *
                       Math.Exp(z * b * (correctionData[0, 19] + 0.0001));
            double n = x * Math.Exp(b * (correctionData[0, 19] + 0.0001)) -
                       y * Math.Exp(z * b * (correctionData[0, 19] + 0.0001)) - c;
            double g = x * (b * b) * Math.Exp(b * (correctionData[0, 19] - 0.0001)) -
                       o * (b * b) * Math.Exp(z * b * (correctionData[0, 19] - 0.0001));
            double h = x * Math.Exp(b * (correctionData[0, 19] - 0.0001)) -
                       y * Math.Exp(z * b * (correctionData[0, 19] - 0.0001)) - c;
            double f = j * n;
            double i = g * h;

            int q = 0;
            if (f > 0)
                iterations[0, q] = correctionData[0, 19] + 0.0001;
            else if (g > 0)
                iterations[0, q] = correctionData[0, 19] - 0.0001;
            else
                iterations[0, q] = 999.9999; // it's in here for a hack!
            while (q < 20)
            {
                if (q > 0)
                    iterations[0, q] = iterations[0, q - 1] - (iterations[1, q - 1] / iterations[2, q - 1]);
                iterations[1, q] = x * Math.Exp(b * iterations[0, q]) -
                y * Math.Exp(z * b * iterations[0, q]) - c;
                iterations[2, q] = x * b * Math.Exp(b * iterations[0, q]) -
                x * b * Math.Exp(z * b * iterations[0, q]);
                q++;
            }

            if (iterations[1, 19] < 0.00000001)
                cas = iterations[0, 19];
        }

        public void CalcTOD(DateTime death)
        {
            DateTime newdeath;
            var ta = calcData.tempSurround;
            var tr = calcData.tempBody;
            var m = calcData.bodyWeight;
            var t = ta <= 23 ? true : false;
            calculateCandB(ta, tr, m);
            calculateCorrections(t);
            calculateIterations(t);
            var factor = correctionFactor();
            var h = (-cas * factor); // convert to minutes
            var mi = -(((cas - Convert.ToInt32(cas)) * 100) / 1.6666) * factor + h;
            newdeath = death.AddHours(h).AddMinutes(mi);
            var calced = death.Subtract(newdeath);
            var todead = death.Subtract(calced);
            calcData.timeOfDeath = todead.ToShortTimeString();
            calcData.dateOfDeath = todead.Date.ToShortDateString();
        }
    }
}
