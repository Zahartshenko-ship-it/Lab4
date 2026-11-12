using System;

namespace Lab4
{
    internal class RightTriangle
    {
        private double _a;
        private double _b;

        public double A
        {
            get { return _a; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(
                        "Длина катета a должна быть больше 0.");
                }
                _a = value;
            }
        }

        public double B
        {
            get { return _b; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(
                        "Длина катета b должна быть больше 0.");
                }
                _b = value;
            }
        }

        public RightTriangle()
        {
            _a = 3.0;
            _b = 4.0;
        }

        public RightTriangle(double a, double b)
        {
            A = a;
            B = b;
        }

        public RightTriangle(RightTriangle other)
        {
            if (other == null)
            {
                throw new ArgumentNullException(
                    nameof(other),
                    "Объект для копирования не задан.");
            }
            _a = other._a;
            _b = other._b;
        }

        public double CalculateArea()
        {
            return 0.5 * _a * _b;
        }

        public override string ToString()
        {
            return $"Прямоугольный треугольник " +
                   $"(катет a = {_a:F2}, катет b = {_b:F2})";
        }
    }
}