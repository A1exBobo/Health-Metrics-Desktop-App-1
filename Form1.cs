using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MassIndex_calculator
{
    public partial class Form1 : Form
    {
        DatabaseHelper db = new DatabaseHelper();

        public Form1()
        {
            InitializeComponent();
        }

        // ================= LOAD GRID =================
        private void LoadDataInDVG()
        {
            string query = @"
           SELECT v.Id,
           p.FirstName + ' ' + p.LastName AS Person,
           v.Mass,
           v.Height,
           v.Date,
           v.BMI,
           v.PI
            FROM dbo.ValoriIndecsi v
            JOIN dbo.Person p ON v.PersonId = p.Id";

            dataGridView1.DataSource = db.ExecuteQuery(query);
        }

        // ================= LOAD COMBO =================
        private void LoadPeopleIntoComboBox()
        {
            string query = @"
            SELECT 
            Id,
            FirstName + ' ' + LastName + ' (ID: ' + CAST(Id AS VARCHAR) + ')' AS DisplayText
            FROM dbo.Person";
            DataTable dt = db.ExecuteQuery(query);

            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "DisplayText";
            comboBox1.ValueMember = "Id";
        }


        // ================= SHOW WEIGHT TIPS =================

        private string FormatWeightMessage(float diff)
        {
            float epsilon = 0.1f;

            if (diff > epsilon)
                return $"Mai trebuie sa pui {diff:0.00} kg pana la medie.";
            else if (diff < -epsilon)
                return $"Mai trebuie sa slabesti {Math.Abs(diff):0.00} kg pana la medie.";
            else
                return "Ai greutatea ideala!";
        }



        // ================= FORM LOAD =================
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadPeopleIntoComboBox();
            LoadDataInDVG();
        }

        

        // ================= SAVE =================
        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue == null)
            {
                MessageBox.Show("Select a person!");
                return;
            }

            float mass = (float)numericUpDown1.Value;
            float height = (float)numericUpDown2.Value;

            if (mass <= 0 || height <= 0)
            {
                MessageBox.Show("Mass and height must be greater than 0!");
                return;
            }

            BMICalculator BMI = new BMICalculator(height, mass);
            PICalculator PI = new PICalculator(height, mass);

            double bmi = BMI.Calculate();
            double pi = PI.Calculate();

            int personId = (int)comboBox1.SelectedValue;

            string query = @"
    INSERT INTO dbo.ValoriIndecsi (PersonId, Mass, Height, Date, BMI, PI)
    VALUES (@PersonId, @Mass, @Height, @Date, @BMI, @PI)";

            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@PersonId", personId),
        new SqlParameter("@Mass", Math.Round(mass, 2)),
        new SqlParameter("@Height", Math.Round(height, 2)),
        new SqlParameter("@Date", DateTime.Now),
        new SqlParameter("@BMI", Math.Round(bmi, 2)),
        new SqlParameter("@PI", Math.Round(pi, 2))
            };

            try
            {
                db.ExecuteNonQuery(query, parameters);

                LoadDataInDVG();

                MessageBox.Show("Saved!");

                // reset numeric controls instead of textboxes
                numericUpDown1.Value = numericUpDown1.Minimum;
                numericUpDown2.Value = numericUpDown2.Minimum;

                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                textBox7.Clear();
                textBox8.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        // ================= ADD PERSON =================
        private void AddPersButton_Click(object sender, EventArgs e)
        {
            var form = new AddPerson();

            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadPeopleIntoComboBox();
                comboBox1.SelectedValue = form.NewPersonId;
            }
        }

        // ================= CALCULATE =================
        private void button1_Click_1(object sender, EventArgs e)
        {

            float masa = (float)numericUpDown1.Value;
            float inaltime = (float)numericUpDown2.Value;

            BMICalculator BMI = new BMICalculator(inaltime, masa);
            PICalculator PI = new PICalculator(inaltime, masa);

            textBox3.Text = BMI.Calculate().ToString("0.00");
            textBox4.Text = PI.Calculate().ToString("0.00");

            textBox5.Text = BMI.WeightCategory();
            textBox6.Text = PI.WeightCategory();

            float diffBMI = BMI.GetWeightDiffrence();
            float diffPI = PI.GetWeightDiffrence();

            textBox7.Text = FormatWeightMessage(diffBMI);
            textBox8.Text = FormatWeightMessage(diffPI);
        }

        
    }
}