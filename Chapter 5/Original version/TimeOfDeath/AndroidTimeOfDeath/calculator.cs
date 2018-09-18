using System;
using System.Collections.Generic;
using System.Text;

namespace AndroidTimeOfDeath
{
    class calculator
    {
        public double[,] correctionData = new double[3, 20];
        public double[,] iterations = new double[3, 20];
        public double c, b, cas;
        public int p, a, w, pa;

        private void calculateCandB(double ta, double tr, double m)
        {
            c = (tr - ta) / (37.2 - ta);
            b = -1.2815 * (1 / Math.Pow(m, 0.625)) + 0.0284;
        }

        private void calculateCorrections(bool test)
        {
            double x = test == true ? 1.25 : 1.11;
            double y = test == true ? 6.25 : 11;
            double z = test == true ? 5 : 10;
            int n = 1;
            correctionData[0, 0] = 0;
            correctionData[1, 0] = x * (b * b) * Math.Exp(b * correctionData[0, 0]) - y * (b * b) * Math.Exp(z * b * correctionData[0, 0]);
            correctionData[2, 0] = x * Math.Pow(b, 3) * Math.Exp(b * correctionData[0, 0]) - y * z * Math.Pow(b, 3) * Math.Exp(z * b * correctionData[0, 0]);
            while (n < 20)
            {
                correctionData[0, n] = correctionData[0, n - 1] - (correctionData[1, n - 1] / correctionData[2, n - 1]);
                correctionData[1, n] = x * (b * b) * Math.Exp(b * correctionData[0, n]) - y * (b * b) * Math.Exp(z * b * correctionData[0, n]);
                correctionData[2, n] = x * Math.Pow(b, 3) * Math.Exp(b * correctionData[0, n]) - y * z * Math.Pow(b, 3) * Math.Exp(z * b * correctionData[0, n]);
                n++;
            }
        }

        private void calculateIterations(bool test)
        {
            double x = test == true ? 1.25 : 1.11;
            double y = test == true ? 0.25 : 0.11;
            double z = test == true ? 5 : 10;
            double o = test == true ? 6.25 : 11;
            double j = x * (b * b) * Math.Exp(b * (correctionData[0, 19] + 0.0001)) - o * (b * b) * Math.Exp(z * b * (correctionData[0, 19] + 0.0001));
            double n = x * Math.Exp(b * (correctionData[0, 19] + 0.0001)) - y * Math.Exp(z * b * (correctionData[0, 19] + 0.0001)) - c;
            double g = x * (b * b) * Math.Exp(b * (correctionData[0, 19] - 0.0001)) - o * (b * b) * Math.Exp(z * b * (correctionData[0, 19] - 0.0001));
            double h = x * Math.Exp(b * (correctionData[0, 19] - 0.0001)) - y * Math.Exp(z * b * (correctionData[0, 19] - 0.0001)) - c;
            double f = j * n;
            double i = g * h;

            int q = 0;
            if (f > 0)
                iterations[0, q] = correctionData[0, 19] + 0.0001;
            else
                if (g > 0)
                    iterations[0, q] = correctionData[0, 19] - 0.0001;
                else
                    iterations[0, q] = 999.9999; // it's in here for a hack!
            while (q < 20)
            {
                if (q > 0)
                    iterations[0, q] = iterations[0, q - 1] - (iterations[1, q - 1] / iterations[2, q - 1]);
                iterations[1, q] = x * Math.Exp(b * iterations[0, q]) - y * Math.Exp(z * b * iterations[0, q]) - c;
                iterations[2, q] = x * b * Math.Exp(b * iterations[0, q]) - x * b * Math.Exp(z * b * iterations[0, q]);
                q++;
            }

            if (iterations[1, 19] < 0.00000001)
                cas = iterations[0, 19];
        }

        private void tod(string time, string dead)
        {
            deadtime.Text = time;
            dateofdeath.Text = dead;
        }

        private void calctod(DateTime death)
        {
            DateTime newdeath;
            double ta = Convert.ToDouble(surroundtemp.Text);
            double tr = Convert.ToDouble(bodytemp.Text);
            double m = Convert.ToDouble(weight.Text);
            if (weightunit.SelectedIndex == 1)
                m *= 6.35029318;
            double factor;
            bool t = ta <= 23 ? true : false;
            calculateCandB(ta, tr, m);
            calculateCorrections(t);
            calculateIterations(t);
            factor = correctionfactor();
            double h, mi;
            h = (-cas * factor); // convert to minutes
            mi = -(((cas - Convert.ToInt32(cas)) * 100) / 1.6666) * factor + h;
            newdeath = death.AddHours(h).AddMinutes(mi);
            TimeSpan calced = death.Subtract(newdeath);
            DateTime todead = death.Subtract(calced);
            tod(todead.ToShortTimeString(), todead.Date.ToShortDateString());
        }

        private double correctionfactor()
        {
            double correction = 0;
            switch (p)
            {
                case 0: // dry naked
                    correction = a == 0 ? 0.75 : 1;
                    break;
                case 1: // dry 1-2 thin layers
                    correction = a == 0 ? 0.9 : 1.1;
                    break;
                case 2: // dry 2-3 thin layers
                case 4: // dry 1-2 thicker
                    correction = 1.2;
                    break;
                case 3: // dry 3-4 thin layers
                    correction = 1.3;
                    break;
                case 5: // more layers
                    correction = a == 2 ? 1.8 : 1.4;
                    break;
                case 6: // naked
                    if (w != 2)
                        correction = w == 0 ? 0.35 : 0.5;
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
                    correction = pa == 0 ? 1.2 : 0.9;
                    break;
            }
            return correction;
        }

        private void foundcondition_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (foundcondition.SelectedIndex < 6)
            {
                watercond.Enabled = false;
                waterlabel.Enabled = false;
                waterlabel.Enabled = false;
                if (w == 2)
                {
                    pulledair.Enabled = false;
                    pulledlabel.Enabled = false;
                }
                aircond.Enabled = true;
                airlabel.Enabled = true;
            }
            else
            {
                watercond.Enabled = true;
                waterlabel.Enabled = true;
                pulledair.Enabled = true;
                pulledlabel.Enabled = true;
                airlabel.Enabled = false;
                aircond.Enabled = false;
            }
            p = foundcondition.SelectedIndex;
        }

        private void aircond_SelectedIndexChanged(object sender, EventArgs e)
        {
            a = aircond.SelectedIndex;
            w = pa = -1;
        }

        private void watercond_SelectedIndexChanged(object sender, EventArgs e)
        {
            w = aircond.SelectedIndex;
            a = -1;
        }

        private void pulledair_SelectedIndexChanged(object sender, EventArgs e)
        {
            pa = pulledair.SelectedIndex;
            a = -1;
        }

        private void calculate_Click(object sender, EventArgs e)
        {
            double s = Convert.ToDouble(surroundtemp.Text);
            double b = Convert.ToDouble(bodytemp.Text);
            if (s > b)
            {
                MessageBox.Show("Body temperature must be greater than the air temperature", "Time of death error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (weight.Text == "")
            {
                MessageBox.Show("The body will have some weight - even if it is only the bones!", "Time of death error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            calctod(datemeasured.Value);
        }

        public class NumberBox : TextBox
        {
            public NumberBox()
            {
                this.CausesValidation = true;
                this.Validating += new CancelEventHandler(TextBox_Validation);
            }

            private void TextBox_Validation(object sender, CancelEventArgs e)
            {
                try
                {
                    double value = System.Double.Parse(this.Text);
                }
                catch (System.Exception)
                {
                    e.Cancel = true;
                }
            }
        }

        private void clear_Click(object sender, EventArgs e)
        {
            weight.Text = "";
            bodytemp.Text = "";
            surroundtemp.Text = "";
            deadtime.Text = "";
            dateofdeath.Text = "";
            watercond.Enabled = false;
            waterlabel.Enabled = false;
            pulledair.Enabled = false;
            pulledlabel.Enabled = false;
            airlabel.Enabled = true;
            aircond.Enabled = true;
            foundcondition.SelectedIndex = 0;
            weightunit.SelectedIndex = 0;
        }
    }
}
