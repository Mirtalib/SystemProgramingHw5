using System;
using System.Diagnostics;
using System.Text.Json;
using SystemProgramingHw5.Models;
using SystemProgramingHw5.UserControls;

namespace SystemProgramingHw5
{
    public partial class Form1 : Form
    {
        private CancellationTokenSource CancellationToken = new();


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
            var directory = new DirectoryInfo(@"..\..\..\CarData");

            foreach (var item in directory.GetFiles())
            {

                if (item.Extension == ".json")
                {
                    var jsonText = File.ReadAllText(item.FullName);
                    var listCar = JsonSerializer.Deserialize<List<Car>>(jsonText);

                    if (listCar is null)
                        continue;

                    foreach (var car in listCar)
                    {
                        if (CancellationToken.IsCancellationRequested)
                        {
                            watch.Stop();
                            lblTimeLoading.Text = watch.Elapsed.ToString();
                            btnStart.Visible = true;
                            btnCancel.Visible = false;
                            break;
                        }


                        // lblTimeLoading.Text = watch.Elapsed.ToString();
                        UC_Car uC_Car = new(car);
                        panel3.Controls.Add(uC_Car);
                        Thread.Sleep(100);
                    }
                }
            }

            watch.Stop();
            lblTimeLoading.Text = watch.Elapsed.ToString();
            btnStart.Visible = true;
            btnCancel.Visible = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            CancellationToken.Cancel();
            btnStart.Visible = true;
            btnCancel.Visible = false;
            lblTimeLoading.Text = "00:00:00";
        }
    }
}