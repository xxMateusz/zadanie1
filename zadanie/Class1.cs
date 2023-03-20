using System;
using zadanie;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;

namespace zadanie
{

    public sealed class Pudelko : IEquatable<Pudelko>, IFormattable, IEnumerable<double>
    {
        private double a, b, c;
        private object centimeter;
        private double[] ArrOfLngth => new double[] { A, B, C };
        public readonly double A;

        public readonly double B ;
        public readonly double C;
        public readonly UnitOfMeasure Unit;

        public double Current => throw new NotImplementedException();

       // object IEnumerator.Current => throw new NotImplementedException();

        public double ConvertToMeters(double number, UnitOfMeasure unit)
        {
            switch (unit)
            {
                case UnitOfMeasure.milimeter:
                    return number / 1000;
                case UnitOfMeasure.centimeter:
                    return number / 100;
                default:
                    return number;
            }
        }
        private void CheckValues(double a, double b, double c)
        {
            if ((a) <= 0 || (b) <= 0 || (c) <= 0)
                throw new ArgumentOutOfRangeException();

            if (a > 10 || (b) > 10 ||(c) > 10)
                throw new ArgumentOutOfRangeException();
        }
        public Pudelko()
        {

            A = 0.1;
            B = 0.1;
            C = 0.1;

        }
        public Pudelko(double a = 0.1, double b = 0.1, double c = 0.1, UnitOfMeasure unit = UnitOfMeasure.meter)
        {
            switch (unit)
            {
                case UnitOfMeasure.centimeter:
                    if (a == null) a = 10;
                    if (b == null) b = 10;
                    if (c == null) c = 10;
                    a = a / 100;
                    b = b / 100;
                    c = c / 100;
                    unit = UnitOfMeasure.meter;
                    break;
                case UnitOfMeasure.meter:
                    if (a == null) a = 0.1;
                    if (b == null) b = 0.1;
                    if (c == null) c = 0.1;
                    break;

                case UnitOfMeasure.milimeter:
                    if (a == null)
                        a = 100;
                    if (b == null)
                        b = 100;
                    if (c == null)
                        c = 100;
                    a = a / 1000;
                    b = b / 1000;
                    c = c / 1000;
                    unit = UnitOfMeasure.meter;
                    break;

              
                default:
                    break;
            }

            A = ConvertToMeters(a, unit);
            B = ConvertToMeters(b, unit);
            C = ConvertToMeters(c, unit);
            A = Rounded(A);
            B = Rounded(B);
            C = Rounded(C);
            Unit = unit;
            CheckValues(A, B, C);
        }

        public string Objetosc => $"{Math.Round(a * b * c, 1)} m3";
        public string Pole => $"{Math.Round(2 * a * b + 2 * a * c + 2 * b * c, 2)} m2";
        //ToString
        #region ToString
        public override string ToString()
        {
            return $"{A.ToString("F3")} m \u00D7 {B.ToString("F3")} m \u00D7 {C.ToString("F3")} m";
        }
        public string ToString(string format, IFormatProvider formatProvider = null)
        {
            if (format is null)
                format = "m";
            switch (format)
            {
                case "m":
                    return ToString();
                case "cm":
                    return $"{(A * 100).ToString("F1")} cm \u00D7 {(B * 100).ToString("F1")} cm \u00D7 {(C * 100).ToString("F1")} cm";
                case "mm":
                    return $"{A * 1000} mm \u00D7 {B * 1000} mm \u00D7 {C * 1000} mm";
                default:
                    throw new FormatException("Niepoprawny format!");
            }
        }
        #endregion
       
        private string ConvertUnite(UnitOfMeasure unit)
        {
            switch (unit)
            {
                case UnitOfMeasure.milimeter:
                    return "mm";
                case UnitOfMeasure.centimeter:
                    return "cm";
                case UnitOfMeasure.meter:
                    return "m";
                default: throw new Exception();
            }

        }
        public static explicit operator double[](Pudelko p)
        {
            double[] pudelkoArr =
            {
                p.A,
                p.B,
                p.C
            };

            return pudelkoArr;
        }
       
        public override int  GetHashCode()
        {
            return HashCode.Combine<double, double, double, UnitOfMeasure>(A, B, C, Unit);

        }
        public static bool operator ==(Pudelko? other, Pudelko box)
        {
            if (ReferenceEquals(other, box))
                return true;
            if (ReferenceEquals(other, null))
                return false;
            if (ReferenceEquals(null, box))
                return false;
            else
                return box.Equals(other);

        }
        public static bool operator !=(Pudelko? other, Pudelko box)
        {


            return !(other == box);
        }
        public bool Equals(Pudelko? other)
        {
            if (ReferenceEquals(other, null))
                return false;
            if (ReferenceEquals(this, other))
                return true;


            double a = ConvertToMeters(other.A, UnitOfMeasure.meter);
            double b = ConvertToMeters(other.B, UnitOfMeasure.meter);
            double c = ConvertToMeters(other.C, UnitOfMeasure.meter);

            double a1 = ConvertToMeters(a, UnitOfMeasure.meter);
            double b1 = ConvertToMeters(b, UnitOfMeasure.meter);
            double c1 = ConvertToMeters(c, UnitOfMeasure.meter);


            Sort(ref a, ref b, ref c);
            Sort(ref a1, ref b1, ref c1);

            if (a1 == a && b == b1 && c == c1)
                return true;
            else
                return false;


        }
       
      
        public static implicit operator Pudelko(ValueTuple<int,int,int> tuple)
        {
            return new Pudelko(tuple.Item1, tuple.Item2, tuple.Item3, UnitOfMeasure.milimeter);
        }
        private void Sort(ref double a, ref double b, ref double c)
        {
            List<double> numbers = new List<double>();
            numbers.Add(a); 
            numbers.Add(b);
                numbers.Add(c);
            numbers.Sort();
            a = numbers[0];
            b = numbers[1];
            c = numbers[2];
        }
        public double this[int i]
        {
            get 
            {
                if (i == 0)
                    return A;
                if( i == 1)
                    return B;
                if ( i == 2)  
                    return C;
                throw new IndexOutOfRangeException();
            }
            }
    
        public Pudelko Parse(string stringToParse, IFormatProvider format)
        {
            var arr = stringToParse.Split(' ');

            UnitOfMeasure unit;

            switch (arr[1])
            {
                case "cm":
                    unit = UnitOfMeasure.centimeter;
                    break;
                case "mm":
                    unit = UnitOfMeasure.milimeter;
                    break;
                default:
                    unit = UnitOfMeasure.meter;
                    break;
            }

            var a = ConvertToMeters(double.Parse(arr[0], format), unit);
            var b = ConvertToMeters(double.Parse(arr[3], format), unit);
            var c = ConvertToMeters(double.Parse(arr[6], format), unit);

            return new Pudelko(a, b, c);

        }

        private double Rounded(double num)
        {
            num = (Math.Truncate(num * 1000) / 1000);
            return num;
        }


        public IEnumerator<double> GetEnumerator()
        {
            return GetEnumerator(); 
        }

     



        public bool MoveNext()
        {
            throw new NotImplementedException();    
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }


}