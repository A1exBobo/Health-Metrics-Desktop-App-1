using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassIndex_calculator
{
    internal class PICalculator:Calculator
    {
        public PICalculator(float inaltime, float masa)
        : base(inaltime, masa)
        {
        }

        public float GetPI()
        {
            return Masa / (Inaltime * Inaltime * Inaltime);
        }

        public override string Calculate()
        {
            float PI =GetPI();
            return PI.ToString();
        }

        public override string WeightCategory()
        {
            float pi = GetPI();

            if (pi < PI_ranges[0]) return "Underweight";
            if (pi < PI_ranges[1]) return "Normal";
            if (pi < PI_ranges[2]) return "Overweight";
            

            return "Obese Class 1,2 or 3";
        }

        public override string IdealWeight()
        {

            // BMI normal range midpoint
            float normalPI = 11.5f;

            // Calcul greutate ideală
            float idealWeight = normalPI * (Inaltime * Inaltime * Inaltime);

            // Diferența între greutatea ideală și cea curentă
            float diference = idealWeight - Masa;

            if (diference > 0)
            {
                return $"Mai trebuie sa pui {diference:F2} kg pana la medie.";
            }
            else if (diference < 0)
            {
                return $"Mai trebuie sa slabesti {Math.Abs(diference):F2} kg";
            }
            else
            {
                return "Ai greutatea ideala!";
            }
        }

    }
}
