using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleBallistics.Forms
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            numZeroRange.Value = (decimal)Properties.Settings.Default.ZeroRange;
            numBulletWeight.Value = (decimal)Properties.Settings.Default.BulletWeight;
            numMaxRange.Value = (decimal)Properties.Settings.Default.MaxRange;
            numBC.Value = (decimal)Properties.Settings.Default.BC;
            numMuzzleVelocity.Value = (decimal)Properties.Settings.Default.Velocity;
            numSightHeight.Value = (decimal)Properties.Settings.Default.SightHight;

            cbRange.Checked = Properties.Settings.Default.dispRange;
            cbDrop.Checked = Properties.Settings.Default.dispDrop;
            cbCorrectionMOA.Checked = Properties.Settings.Default.dispCorrectionMOA;
            cbCorrectionMIL.Checked = Properties.Settings.Default.dispCorrectionMIL;
            cbTime.Checked = Properties.Settings.Default.dispTime;
            cbVelocity.Checked = Properties.Settings.Default.dispVelocity;
            cbEnergy.Checked = Properties.Settings.Default.dispEnergy;

            cmbElevationUnit.SelectedIndex = cmbElevationUnit.Items.IndexOf(Properties.Settings.Default.clickElevationUnit);
            cmbTurretGrad.SelectedIndex = cmbTurretGrad.Items.IndexOf(Properties.Settings.Default.clickTurretGrad);

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveSettings();
            this.Close();
        }

        private void SaveSettings()
        {

            Properties.Settings.Default.ZeroRange = (double)numZeroRange.Value;
            Properties.Settings.Default.BulletWeight = (double)numBulletWeight.Value;
            Properties.Settings.Default.MaxRange = (double)numMaxRange.Value;
            Properties.Settings.Default.BC = (double)numBC.Value;
            Properties.Settings.Default.Velocity = (double)numMuzzleVelocity.Value;
            Properties.Settings.Default.SightHight = (double)numSightHeight.Value;

            Properties.Settings.Default.dispRange = cbRange.Checked;
            Properties.Settings.Default.dispDrop = cbDrop.Checked;
            Properties.Settings.Default.dispCorrectionMOA = cbCorrectionMOA.Checked;
            Properties.Settings.Default.dispCorrectionMIL = cbCorrectionMIL.Checked;
            Properties.Settings.Default.dispTime = cbTime.Checked;
            Properties.Settings.Default.dispVelocity = cbVelocity.Checked;
            Properties.Settings.Default.dispEnergy = cbEnergy.Checked;

            Properties.Settings.Default.clickElevationUnit = cmbElevationUnit.SelectedItem.ToString();
            Properties.Settings.Default.clickTurretGrad = cmbTurretGrad.SelectedItem.ToString();

            Properties.Settings.Default.Save();
        }

    }
}
