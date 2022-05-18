using System;
using System.Collections.Generic;

namespace DemoCenter.Maui.Data {
    public class OscillatorDataProvider {
        const int k = 2;
        double alpha = 1.75;
        double beta = 5.0;
        double phi = 130.0;
        int count = 1000;
        double direction = 1.0;

        List<NumericData> CreateOscillatorData() {
            List<NumericData> data = new List<NumericData>();
            double left = 0, right = 360;
            double augment = (right - left) / count;
            double phiRad = ToRadians(phi);
            for (double t = left; t <= right + augment; t += augment) {
                double tRad = ToRadians(t);
                double x = Math.Sin(alpha * tRad + phiRad);
                double y = Math.Sin(beta * tRad);
                data.Add(new NumericData(x, y));
            }
            return data;
        }
        void UpdateOscillatorState() {
            alpha += k * direction * beta / 720.0;
            phi += k * direction * 0.5;
            if (phi > 360)
                direction = -1.0;
            else if (phi < 0.0)
                direction = 1.0;
        }
        double ToRadians(double angle) {
            return Math.PI * angle / 180.0;
        }

        public List<NumericData> GenerateNextData() {
            UpdateOscillatorState();
            return CreateOscillatorData();
        }
    }
}
