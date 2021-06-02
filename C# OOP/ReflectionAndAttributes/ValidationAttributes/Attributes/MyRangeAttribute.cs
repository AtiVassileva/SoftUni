using System;

namespace ValidationAttributes.Attributes
{
    public class MyRangeAttribute : MyValidationAttribute
    {
        private readonly int _minValue;
        private readonly int _maxValue;

        public MyRangeAttribute(int minValue, int maxValue)
        {
            this.ValidateRange(minValue, maxValue);
            this._minValue = minValue;
            this._maxValue = maxValue;
        }

        public override bool IsValid(object obj)
        {
            if (obj is int value)
            {
                if (value < this._minValue || value > this._maxValue)
                {
                    return false;
                }

                return true;
            }

            throw new InvalidOperationException("Cannot parse value!");
        }

        private void ValidateRange(int minValue, int maxValue)
        {
            if (minValue > maxValue)
            {
                throw new ArgumentException("Invalid range!");
            }
        }
    }
}
