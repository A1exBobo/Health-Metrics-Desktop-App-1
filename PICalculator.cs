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
            float PI = GetPI();
            return PI.ToString();
        }

        public override string WeightCategory()
        {
            /*
              BMI_ranges = { 18.5f, 24.9f, 29.9f, 34.9f, 39.9f };
              PI_ranges = { 11f, 14f, 17f };
             */

            float pi = GetPI();

            if (pi < PI_ranges[0]) return "Underweight";
            if (pi < PI_ranges[1]) return "Normal";
            if (pi < PI_ranges[2]) return "Overweight";
            

            return "Obese Class 1,2 or 3";
        }

        public override string IdealWeight()
        {
            float normalPI = (PI_ranges[0] + PI_ranges[1]) / 2f;

            float idealWeight = normalPI * (Inaltime * Inaltime * Inaltime);
            float diference = idealWeight - Masa;

            float epsilon = 0.1f; //100 grame

            if (diference > epsilon)
                return $"Mai trebuie sa pui {diference:F2} kg pana la medie.";

            if (diference < -epsilon)
                return $"Mai trebuie sa slabesti {Math.Abs(diference):F2} kg";

            return "Ai greutatea ideala!";
        }

    }
}
