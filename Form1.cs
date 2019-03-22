using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConquerMoneyConverter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Global variables.
        double dbCost = 0;  //Cost of a DB on server.
        double cps = 0; //Number of CPs to convert.
        double silvers = 0; //Number of silvers to convert.
        const double DB_IN_CPs = 215; //The cost of a DB in CPs according to TQ.
        int conversion = 0; //Holds the converstion from CPs to Silvers and vice versa.
        
        private void btn1Calculate_Click(object sender, EventArgs e)
        {
            //Check to see if any of the inputs is invalid and notify the user.
            if (double.TryParse(txt1DBCost.Text, out dbCost) == false || double.TryParse(txtCPs.Text, out cps) == false)
            {
                MessageBox.Show("Invalid input detected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt1DBCost.Clear();
                txtCPs.Clear();
                txt1DBCost.Focus();
            }
            else
            {
                //Convert CPs to Silvers.
                conversion = Convert.ToInt32((cps / DB_IN_CPs) * dbCost);
                txtSilversEquivalent.Text = conversion.ToString();
            }

        }

        private void btn2Calculate_Click(object sender, EventArgs e)
        {
            //Check to see if any of the inputs is invalid and notify the user.
            if (double.TryParse(txt2DBCost.Text, out dbCost) == false || double.TryParse(txtSilvers.Text, out silvers) == false)
            {
                MessageBox.Show("Invalid input detected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt2DBCost.Clear();
                txtSilvers.Clear();
                txt2DBCost.Focus();
            }
            else
            {
                //Convert Silvers to CPs.
                conversion = Convert.ToInt32((silvers / dbCost) * DB_IN_CPs);
                txtCPsEquivalent.Text = conversion.ToString();
            }

        }

        private void btn1Reset_Click(object sender, EventArgs e)
        {
            //Reset all fields.
            txt1DBCost.Clear();
            txtCPs.Clear();
            txtSilversEquivalent.Clear();
            txt1DBCost.Focus();
        }

        private void btn2Reset_Click(object sender, EventArgs e)
        {
            //Reset all fields.
            txt2DBCost.Clear();
            txtSilvers.Clear();
            txtCPsEquivalent.Clear();
            txt2DBCost.Focus();
        }
    }
}
