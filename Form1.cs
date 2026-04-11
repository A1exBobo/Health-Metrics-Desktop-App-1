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

        // ================= FORM LOAD =================
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadPeopleIntoComboBox();
            LoadDataInDVG();
        }

        // ================= CALCULATE =================
        private void button1_Click(object sender, EventArgs e)
        {
            float masa = float.Parse(textBox1.Text);
            float inaltime = float.Parse(textBox2.Text);

            BMICalculator BMI = new BMICalculator(inaltime, masa);
            PICalculator PI = new PICalculator(inaltime, masa);

            textBox3.Text = BMI.Calculate();
            textBox4.Text = PI.Calculate();

            textBox5.Text = BMI.WeightCategory();
            textBox6.Text = PI.WeightCategory();

            textBox7.Text = BMI.IdealWeight();
            textBox8.Text = PI.IdealWeight();
        }

        // ================= SAVE =================
        private void button2_Click(object sender, EventArgs e)
        {
            if (!float.TryParse(textBox1.Text, out float mass) ||
                !float.TryParse(textBox2.Text, out float height))
            {
                MessageBox.Show("Invalid input.");
                return;
            }

            if (!double.TryParse(textBox3.Text, out double bmi) ||
                !double.TryParse(textBox4.Text, out double pi))
            {
                MessageBox.Show("Invalid BMI/PI.");
                return;
            }

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

                textBox1.Clear();
                textBox2.Clear();
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
        private void button3_Click(object sender, EventArgs e)
        {
            var form = new AddPerson();

            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadPeopleIntoComboBox();
                comboBox1.SelectedValue = form.NewPersonId;
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue == null)
            {
                MessageBox.Show("Select a person!");
                return;
            }

            if (!float.TryParse(textBox1.Text, out float mass) ||
                !float.TryParse(textBox2.Text, out float height))
            {
                MessageBox.Show("Invalid mass or height!");
                return;
            }

            if (!double.TryParse(textBox3.Text, out double bmi) ||
                !double.TryParse(textBox4.Text, out double pi))
            {
                MessageBox.Show("BMI or PI invalid!");
                return;
            }

            int personId = Convert.ToInt32(comboBox1.SelectedValue);

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

                MessageBox.Show("Saved successfully!");

                LoadDataInDVG();

                textBox1.Clear();
                textBox2.Clear();
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
    }
}