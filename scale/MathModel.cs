using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scale
{
    public class MathModel
    {
        private string ScaleKind { get; set; }
        private double ScaleBegin { get; set; }
        private double ScaleEnd { get; set; }

        public MathModel()
        {
        }

        public void SetScaleKind(string scaleKind) { ScaleKind = scaleKind; }
        public string GetScaleKind() { return ScaleKind; }

        public void SetScaleBegin(double scaleBegin) { ScaleBegin = scaleBegin; }
        public double GetScaleBegin() { return ScaleBegin; }

        public void SetScaleEnd(double scaleEnd) { ScaleEnd = scaleEnd; }
        public double GetScaleEnd() { return ScaleEnd; }
    }
}