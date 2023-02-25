using System.Diagnostics;
using System.Text.Json;
using SystemProgramingHw5.Models;

namespace SystemProgramingHw5
{
    public partial class Form1 : Form
    {
        private CancellationTokenSource? CancellationToken = new();


        public Form1()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (radioBtnMulti.Checked == false && radioBtnSingle.Checked == false)
            {
                MessageBox.Show("Please Select Mod");
                return;
            }

            CancellationToken = new();
            btnStart.Visible = false;
            btnCancel.Visible = true;

            if (radioBtnMulti.Checked == true)
            {
            }
            else
            {
                Thread thread = new Thread(AddCarSingleMod);
                thread.Start();
            }
        }




        private void AddCarSingleMod()
        {
            panel3.Controls.Clear();
            var watch = Stopwatch.StartNew();
            var directory = new DirectoryInfo(@"..\..\..\JsonFakeData");
            foreach (var item in directory.GetFiles())
            {

                if (item.Extension == ".json")
                {
                    var jsonText = File.ReadAllText(item.FullName);
                    var listCar = JsonSerializer.Deserialize<List<Car>>(jsonText);

                    if (listCar != null)
                    {
                        if (CancellationToken.IsCancellationRequested)
                        {


                        }
                    }



                }

            }
        }
    }
}