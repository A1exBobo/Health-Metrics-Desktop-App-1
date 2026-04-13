using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MassIndex_calculator
{
    internal class BMICalculator:Calculator
    {

        public BMICalculator(float inaltime, float masa)
         : base( inaltime, masa)
        {
        }

        public float GetBMI()
        {
            return Masa / (Inaltime * Inaltime);
        }


        public override string Calculate()
        {
            float  BMI = GetBMI();
            return BMI.ToString();
        }


        public override string WeightCategory()
        {
            float bmi = GetBMI();

            if (bmi < BMI_ranges[0]) return "Underweight";
            if (bmi < BMI_ranges[1]) return "Normal";
            if (bmi < BMI_ranges[2]) return "Overweight";
            if (bmi < BMI_ranges[3]) return "Obese Class 1";
            if (bmi < BMI_ranges[4]) return "Obese Class 2";

            return "Obese Class 3";
        }

        public override string IdealWeight()
        {
          
            // BMI normal range midpoint
            float normalBMI = (BMI_ranges[0] + BMI_ranges[1])/2f;

            // Calcul greutate ideală
            float idealWeight = normalBMI * (Inaltime * Inaltime);

            // Diferența între greutatea ideală și cea curentă
            float diference = idealWeight - Masa;
            float epsilon = 0.1f; //100 grame 

            if (diference > epsilon)
            {
                return $"Mai trebuie sa pui {diference:F2} kg pana la medie.";
            }
            else if (diference < epsilon)
            {
                return $"Mai trebuie sa slabesti {Math.Abs(diference):F2} kg pana la medie.";
            }
            else
            {
                return "Ai greutatea ideala!";
            }
        }



    }
}
