using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MassIndex_calculator
{
    public partial class AddPerson : Form
    {
       
        public int NewPersonId { get; set; }
        DatabaseHelper db = new DatabaseHelper();

        public AddPerson()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void AddPerson_Load(object sender, EventArgs e)
        {

        }

        private void FirstNameBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void FInitialsBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void AgeBox_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Person person = new Person(
                FirstNameBox.Text,
                LastNameBox.Text,
                FInitialsBox.Text,
                (int)AgeBox.Value
            );

            string query = @"
        INSERT INTO dbo.Person (FirstName, LastName, FatherInitials, Age)
        VALUES (@fn, @ln, @fi, @age);
        SELECT SCOPE_IDENTITY();";

            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@fn", person.FirstName),
        new SqlParameter("@ln", person.LastName),
        new SqlParameter("@fi", person.FatherInitials),
        new SqlParameter("@age", person.Age)
            };

            object result = db.ExecuteScalar(query, parameters);

            int newId = Convert.ToInt32(result);

            person.Id = newId;
            NewPersonId = newId;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
