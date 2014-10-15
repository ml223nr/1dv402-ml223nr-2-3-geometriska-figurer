using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV402.S2.L3B
{    
    public enum ShapeType { Ellipse, Rectangle }

    public abstract class Shape : IComparable
    {
        //fält
        private double _length;
        private double _width;

        //egenskaper
        public abstract double Area { get;}
        public abstract double Perimeter { get; }

        public double Length 
        { 
            get {return _length; }
            set {
                if (value <= 0)
                    throw new ArgumentException("Längden är inte större än 0");

                _length = value;
                }
        }

        public double Width 
        {
            get { return _width;}
            set {
                if (value <= 0)
                    throw new ArgumentException("Bredden är inte större än 0");

                _width = value;
                } 
        }

        //metoder
        /// <summary>
        /// Jämför två objekt med avseende på deras areor.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int CompareTo(Object obj)
        {
            if (obj == null)
                return 1;

            Shape that = obj as Shape;
            if (that == null)
                throw new ArgumentException("Objektet är inte en Shape.");

            //if (this.Area > other.Area)
            //    return -1;

            //if (this.Area < other.Area)
            //    return 2;

            //if (this == obj)
            //    return 0;

            return that.Area.CompareTo(this.Area);  
        }

        /// <summary>
        /// Returnerar en sträng representerande värdet av en instans.
        /// Innehåller figurens typ, längd, bredd, omkrets och area.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3} {4}", 
                                    GetType().Name.PadRight(9), 
                                    Length.ToString("0.0").PadLeft(8), 
                                    Width.ToString("0.0").PadLeft(8), 
                                    Perimeter.ToString("0.0").PadLeft(9), 
                                    Area.ToString("00.0").PadLeft(8));
        } 

        //konstruktor
        protected Shape(double length, double width)
        {
            Length = length;
            Width = width;
        }
    }
}
