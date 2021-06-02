using System;
using System.Collections.Generic;
using P04.PizzaCalories.Common;
using PizzaCalories.Common;

namespace P04.PizzaCalories.Models
{
    public class Dough
    {
        private const double MinWeight = 1;
        private const double MaxWeight = 200;
        

        private  Dictionary<string, double> _flourTypesCalories = new Dictionary<string, double>();
        private  Dictionary<string, double> _bakingTechniqueCalories = new Dictionary<string, double>();

        private string _flourType;
        private string _bakingTechnique;
        private double _weight;

        public Dough(string flourType, string bakingTechnique, double weight)
        {
            this.FillDictionaries();
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
            
        }

        public string FlourType
        {
            get => this._flourType;
            private set
            {
                if (!_flourTypesCalories.ContainsKey(value.ToLower()))
                {
                    ThrowException();
                }

                this._flourType = value;
            }
        }

        public string BakingTechnique
        {
            get => this._bakingTechnique;
            private set
            {
                if (!_bakingTechniqueCalories.ContainsKey(value.ToLower()))
                {
                   ThrowException();
                }

                this._bakingTechnique = value;
            }
        }

        public double Weight
        {
            get => this._weight;
            private set
            {
                if (value < MinWeight || value > MaxWeight)
                {
                    throw new Exception(ErrorMessages.InvalidWeightException);
                }

                this._weight = value;
            }
        }


        private static void ThrowException()
        {
            throw new Exception(ErrorMessages.InvalidDoughExceptionMessage);
        }

        public double CalculateCalories()
        {
            var calories = (GlobalConstants.BaseCalories * this.Weight)
                           * _flourTypesCalories[this.FlourType.ToLower()] *
                           _bakingTechniqueCalories[this.BakingTechnique.ToLower()];

            return calories;
        }

        private void FillDictionaries()
        {
            this._flourTypesCalories.Add("white", 1.5);
            this._flourTypesCalories.Add("wholegrain", 1.0);

            this._bakingTechniqueCalories.Add("crispy", 0.9);
            this._bakingTechniqueCalories.Add("chewy", 1.1);
            this._bakingTechniqueCalories.Add("homemade", 1.0);
        }
    }
}
