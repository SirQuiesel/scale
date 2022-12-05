using System.Collections.Generic;

namespace scale
{
    public class MathModel
    {
        private string ScaleKind { get; set; }

        private double ScaleBegin { get; set; }
        private double ScaleEnd { get; set; }

        private List<double> ScaleValues { get; set; }

        public MathModel()
        {
            ScaleValues = new List<double>();
            ScaleBegin = 0;
            ScaleEnd = 10;
        }

        public void SetScaleKind(string scaleKind) { ScaleKind = scaleKind; }
        public string GetScaleKind() { return ScaleKind; }

        public void SetScaleBegin(double scaleBegin) { ScaleBegin = scaleBegin; }
        public double GetScaleBegin() { return ScaleBegin; }

        public void SetScaleEnd(double scaleEnd) { ScaleEnd = scaleEnd; }
        public double GetScaleEnd() { return ScaleEnd; }

        public void AddScaleValue(double value) { ScaleValues.Add(value); }
        public void DeleteScaleValue(double value) { ScaleValues.Remove(value); }
        public bool ContainsScaleValue(double value) { return ScaleValues.Contains(value); }
        public int ScaleValuesCount() { return ScaleValues.Count; }
    }
}