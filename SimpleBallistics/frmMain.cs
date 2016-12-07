using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleBallistics
{
    public partial class frmMain : Form
    {
        /// <summary>
        /// Used for our printing.
        /// </summary>
        TablePrinting.Printing print = null;

        /// <summary>
        /// Constructor
        /// </summary>
        public frmMain()
        {
            InitializeComponent();

            comboBox1.DataSource = Enum.GetValues(typeof(BallisticsLib.Ballistics.__DragFunctions));

            this.Text = string.Format("{0} - Version: {1:N2}-{2}", this.Text, Main.VERSION, Main.REVISION);
        }

        /// <summary>
        /// Setup some default settings when the form loads.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMain_Load(object sender, EventArgs e)
        {
            LoadDefaults();
            RangeCardDisplay();
            SetClickHeaderText();
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            SetClickHeaderText();
            RangeCardDisplay();

            // a list to hold our calculations
            List<Dictionary<string, double>> calcs;

            ////////////////////////////////////////////////////////////
            // defaults for testing
            ////////////////////////////////////////////////////////////
            //double bc = 0.475; // The ballistic coefficient for the projectile.
            //double v = 1200; // Intial velocity, in ft/s
            //double sh = 1.6; // The Sight height over bore, in inches.
            //double angle = 0; // The shooting angle (uphill / downhill), in degrees.
            //double zero = 100; // The zero range of the rifle, in yards.
            //double windspeed = 0; // The wind speed in miles per hour.
            //double windangle = 0; // The wind angle (0=headwind, 90=right to left, 180=tailwind, 270/-90=left to right)
            //double weight = 168;

            double bc = (double)numBC.Value;
            double v = (double)numMuzzleVelocity.Value;
            double sh = (double)numSightHeight.Value;
            double angle = 0;
            double zero = (double)numZeroRange.Value;
            double windspeed = 0;
            double windangle = 0;
            double weight = (double)numBulletWeight.Value;
            BallisticsLib.Ballistics.__DragFunctions dragModel = BallisticsLib.Ballistics.__DragFunctions.G1;
            Enum.TryParse<BallisticsLib.Ballistics.__DragFunctions>(comboBox1.SelectedValue.ToString(), out dragModel);

            // If we wish to use the weather correction features, we need to 
            // Correct the BC for any weather conditions.  If we want standard conditions,
            // then we can just leave this commented out.
            // 
            // NOTES:
            // Altitude: The altitude above sea level in feet.Standard altitude is 0 feet above sea level.
            //
            // Barometer: The barometric pressure in inches of mercury(in Hg).
            // This is not "absolute" pressure, it is the "standardized" pressure reported in the papers and news.
            // Standard pressure is 29.53 in Hg.
            //
            // Temperature:  The temperature in Fahrenheit.Standard temperature is 59 degrees.
            //
            // RelativeHumidity:  The relative humidity fraction.  Ranges from 0.00 to 1.00, with 0.50 being 50 % relative humidity.
            // Standard humidity is 78 %
            if (cbAtmosphere.Checked)
                bc = BallisticsLib.Ballistics.AtmCorrect(bc, Properties.Settings.Default.Altitude, Properties.Settings.Default.Barometer, Properties.Settings.Default.Temperature, Properties.Settings.Default.RelativeHumidity);

            // First find the angle of the bore relative to the sighting system.
            // We call this the "zero angle", since it is the angle required to 
            // achieve a zero at a particular yardage.  This value isn't very useful
            // to us, but is required for making a full ballistic solution.
            // It is left here to allow for zero-ing at altitudes (bc) different from the
            // final solution, or to allow for zero's other than 0" (ex: 3" high at 100 yds)
            double zeroangle = 0;
            zeroangle = BallisticsLib.Ballistics.ZeroAngle(dragModel, bc, v, sh, zero, 0);

            // Now we have everything needed to generate a full solution.
            // So we do.  The solution is stored in the pointer "sln" passed as the last argument.
            // k has the number of yards the solution is valid for, also the number of rows in the solution.
            calcs = BallisticsLib.Ballistics.SolveAll(dragModel, bc, weight, v, sh, 0, zeroangle, 0, 0);

            for (int x = 5; x <= numMaxRange.Value; x += 5)
            {
                dataGridView1.Rows.Add(
                    Math.Round(calcs[x]["range"], 0),
                    string.Format("{0} in", Math.Round(calcs[x]["path"], 1)),
                    Math.Round(calcs[x]["correction_moa"], 2),
                    string.Format("{0}", Math.Round(calcs[x]["correction_mil"] * 1000000, 2)),
                    string.Format("{0}", calcClicks(Math.Round(calcs[x]["correction_mil"] * 1000000, 2), Math.Round(calcs[x]["correction_moa"], 2))),
                    string.Format("{0} sec", Math.Round(calcs[x]["time"], 2)),
                    string.Format("{0} fps", Math.Round(calcs[x]["velocity_z"], 1)),
                    string.Format("{0} ft-lb", Math.Round(calcs[x]["energy"], 2))
                );
            }
        }

        #region Menubar Buttons

        /// <summary>
        /// Prints the range table.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (PrintDialog printDialog = new PrintDialog())
            {
                printDialog.Document = printDocument1;
                printDialog.UseEXDialog = true;

                // the document
                if (DialogResult.OK == printDialog.ShowDialog())
                {
                    printDocument1.DocumentName = "Test Page Print";
                    printDocument1.Print();
                }
            }

        }

        /// <summary>
        /// Displays the print preview dialog.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // print preview
            PrintPreviewDialog objPPdialog = new PrintPreviewDialog();
            objPPdialog.Document = printDocument1;
            objPPdialog.ShowDialog();
        }

        /// <summary>
        /// Displays the settings page.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Forms.Settings().Show(this);
        }

        #endregion

        #region Printing Functions

        private void printDocument1_PrintPage_1(object sender, PrintPageEventArgs e)
        {
            print.printPage(e);
        }

        private void printDocument1_BeginPrint_1(object sender, PrintEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                List<int> selectedIndicies = new List<int>();

                foreach (DataGridViewRow r in dataGridView1.SelectedRows)
                    selectedIndicies.Add(r.Index);

                print = new TablePrinting.Printing(dataGridView1, selectedIndicies);
            }
                
            else
                print = new TablePrinting.Printing(dataGridView1);
        }

        #endregion

        #region Atmosphere Functions

        private void cbAtmosphere_CheckedChanged(object sender, EventArgs e)
        {
            if (cbAtmosphere.Checked)
            {
                new Forms.Atmosphere().Show(this);
            }
        }

        #endregion

        #region Misc Functions

        /// <summary>
        /// Shows or hides range card columns based on user prefrance.
        /// </summary>
        private void RangeCardDisplay()
        {
            dataGridView1.Columns["clRange"].Visible = Properties.Settings.Default.dispRange;
            dataGridView1.Columns["clDrop"].Visible = Properties.Settings.Default.dispDrop;
            dataGridView1.Columns["clCorrectionMOA"].Visible = Properties.Settings.Default.dispCorrectionMOA;
            dataGridView1.Columns["clCorrectionMIL"].Visible = Properties.Settings.Default.dispCorrectionMIL;
            dataGridView1.Columns["clClicks"].Visible = Properties.Settings.Default.dispClicks; ;
            dataGridView1.Columns["clTime"].Visible = Properties.Settings.Default.dispTime;
            dataGridView1.Columns["clVelocity"].Visible = Properties.Settings.Default.dispVelocity;
            dataGridView1.Columns["clEnergy"].Visible = Properties.Settings.Default.dispEnergy;
        }

        /// <summary>
        /// If we have some user defaults we should load them for the user.
        /// </summary>
        private void LoadDefaults()
        {
            if (Properties.Settings.Default.ZeroRange != 0)
                numZeroRange.Value = (decimal)Properties.Settings.Default.ZeroRange;

            if (Properties.Settings.Default.BulletWeight != 0)
                numBulletWeight.Value = (decimal)Properties.Settings.Default.BulletWeight;

            if (Properties.Settings.Default.MaxRange != 0)
                numMaxRange.Value = (decimal)Properties.Settings.Default.MaxRange;

            if (Properties.Settings.Default.BC != 0)
                numBC.Value = (decimal)Properties.Settings.Default.BC;

            if (Properties.Settings.Default.Velocity != 0)
                numMuzzleVelocity.Value = (decimal)Properties.Settings.Default.Velocity;

            if (Properties.Settings.Default.SightHight != 0)
                numSightHeight.Value = (decimal)Properties.Settings.Default.SightHight;
            
            cbClicks.Checked = Properties.Settings.Default.dispClicks;
        }

        /// <summary>
        /// Calculates the number of corrective clicks, based on 
        /// user settings. Default is Mil at 1/4 mil turret clicks
        /// </summary>
        /// <param name="mils"></param>
        /// <param name="moa"></param>
        /// <returns></returns>
        private int calcClicks(double mils, double moa)
        {
            double divisor = 0.25;

            switch (Properties.Settings.Default.clickTurretGrad)
            {
                case "1/20":
                    divisor = 0.05;
                    break;

                case "1/10":
                    divisor = 0.10;
                    break;

                case "1/8":
                    divisor = 0.125;
                    break;

                case "1/6":
                    divisor = 0.166;
                    break;

                case "1/5":
                    divisor = 0.20;
                    break;

                case "1/3":
                    divisor = 0.333;
                    break;

                case "1/2":
                    divisor = 0.50;
                    break;

                case "5/8":
                    divisor = 0.625;
                    break;

                case "1":
                    divisor = 1;
                    break;

                case "2":
                    divisor = 2;
                    break;

                case "1/4":
                default:
                    divisor = 0.25;
                    break;

            }

            if (Properties.Settings.Default.clickElevationUnit == "Mils")
                return BallisticsLib.Ballistics.toMILClicks(Math.Round(mils, 2), divisor);

            return BallisticsLib.Ballistics.toMOAClicks(Math.Round(moa, 2), divisor);
        }

        private void SetClickHeaderText()
        {
            dataGridView1.Columns["clClicks"].HeaderText = string.Format("Clicks ({0} {1})", Properties.Settings.Default.clickTurretGrad, Properties.Settings.Default.clickElevationUnit);
        }
        
        #endregion

        /// <summary>
        /// Clicks checkbox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbClicks_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.Columns["clClicks"].Visible = cbClicks.Checked;
            SetClickHeaderText();
            dataGridView1.Refresh();

            Properties.Settings.Default.dispClicks = cbClicks.Checked;
            Properties.Settings.Default.Save();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Forms.frmAbout().Show();
        }
    }
}
