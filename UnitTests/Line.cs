using SnowPlowSolver.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    internal class Line : ILine
    {
        private IPoint startPoint;
        public IPoint StartPoint
        {
            get
            {
                return startPoint;
            }
            set
            {
                startPoint = value;
                CalculateDirection();
            }
        }

        private IPoint endPoint;
        public IPoint EndPoint
        {
            get
            {
                return endPoint;
            }
            set
            {
                endPoint = value;
                CalculateDirection();
            }
        }

        [Key]
        public int Id { get; set; }

        [NotMapped]
        public Vector2 Direction { get; set; }

        public Line()
        {

        }

        public Line(int id)
        {
            Id= id;
        }

        public bool Equals(ILine? other)
        {
            if(other == null)
            {
                return false;
            }
            if (Id == other.Id)
            {
                return true;
            }
            return false;
        }

        private void CalculateDirection()
        {
            if (StartPoint == null || EndPoint == null)
                return;
            var x = EndPoint.X - StartPoint.X;
            var y = EndPoint.Y - StartPoint.Y;
            Direction = new Vector2((float)x, (float)y);
        }

        public bool Reversed { get; set; }

        public void Reverse()
        {
            var temp = StartPoint;
            StartPoint = EndPoint;
            EndPoint = temp;
            Reversed = !Reversed;
        }
    }
}
