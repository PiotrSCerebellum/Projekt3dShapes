using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projekt3_Skupiński_59369
{
    public partial class PokazInitialForm : Form
    {
        public PokazInitialForm()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void btPrezentacjaBrył_Click(object sender, EventArgs e)
        {
            var Regularne = new PokazBryłRegularnych();
            Regularne.Location = this.Location;
            Regularne.StartPosition = FormStartPosition.CenterScreen;
            Regularne.Show();
            this.Hide();
        }

        private void btZłożoneBryły_Click(object sender, EventArgs e)
        {
            var Złożone = new PokazBryłRegularnych();
            Złożone.Location = this.Location;
            Złożone.StartPosition = FormStartPosition.CenterScreen;
            Złożone.Show();
            this.Hide();
        }
    }
}
