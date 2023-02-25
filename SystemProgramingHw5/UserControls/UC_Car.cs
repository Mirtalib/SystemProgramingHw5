using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SystemProgramingHw5.Models;

namespace SystemProgramingHw5.UserControls
{
    public partial class UC_Car : UserControl
    {
        private Car car = null!;
        public UC_Car(Car car)
        {
            InitializeComponent();
            this.car = car;
        }

        private void UC_Car_Load(object sender, EventArgs e)
        {
            lblVINCode.Text = car.VINCode;
            lblMake.Text = car.Make ;
            lblModel.Text = car.Model;
            lblPrice.Text = car.Price;
            lblYear.Text = car.Year.ToString();
        }
    }
}
