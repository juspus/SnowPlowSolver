using SnowPlowSolver.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SnowPlowProblem
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
        public bool Reversed { get; set; }

        [Key]
        public int Id { get; set; }

        [NotMapped]
        public Vector2 Direction { get; set; }

        public bool Equals(ILine? other)
        {
            if(Id == other.Id)
            {
                return true;
            }
            if(StartPoint == other.StartPoint && EndPoint == other.EndPoint)
            {
                return true;
            }
            if (StartPoint == other.EndPoint && EndPoint == other.StartPoint)
            {
                return true;
            }
            return false;
        }

        private void CalculateDirection()
        {
            if (StartPoint == null)
                return;
            if (EndPoint == null)
                return;
            var x = EndPoint.X - StartPoint.X;
            var y = EndPoint.Y - StartPoint.Y;
            Direction = new Vector2((float)x, (float)y);
        }


        public void Reverse()
        {
            var temp = StartPoint;
            StartPoint = EndPoint;
            EndPoint = temp;
            Reversed = !Reversed;
        }
    }
}
