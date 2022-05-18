using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using DemoCenter.Maui.Data;

namespace DemoCenter.Maui.ViewModels {

    public class LogarithmicScaleViewModel : ChartViewModelBase {
        static DateTime BasisDate = new DateTime(2020, 1, 1);

        const int SamplingFrequency = 22050; 
        const int DefaultFrameLength = 2048;
        const double sixteenBitSampleMaxVale = short.MaxValue;
        const double MinDb = -500d;

        readonly double[] realSpectrum = new double[DefaultFrameLength];
        readonly double[] imaginarySpectrum = new double[DefaultFrameLength];
        readonly double[] zeroSpectrum = new double[DefaultFrameLength];

        int frameStartIndex = 0;
        int frameEndIndex = DefaultFrameLength - 1;
        double[] averageChannelNormalized;
        DateTime last;

        public BindingList<DateTimeData> LeftChannelData { get; } = new BindingList<DateTimeData>();
        public BindingList<DateTimeData> RightChannelData { get; } = new BindingList<DateTimeData>();
        public BindingList<NumericData> FrequencyData { get; private set; } = new BindingList<NumericData>();
        public DateTime StripMinLimit { get; private set; }
        public DateTime StripMaxLimit { get; private set; }

        public LogarithmicScaleViewModel() {
            short[] sampleBuffer = CreateSampleBuffer();

            this.averageChannelNormalized = new double[sampleBuffer.Length / 2];
            for (int i = 1, k = 0; i < sampleBuffer.Length; i += 2, k++) {
                double seconds = (i / 2) * (1.0 / SamplingFrequency);
                double normalizedValueOfLeftChannel = sampleBuffer[i] / sixteenBitSampleMaxVale;
                double normalizedValueOfRightChannel = sampleBuffer[i - 1] / sixteenBitSampleMaxVale;
                LeftChannelData.Add(new DateTimeData(BasisDate.AddSeconds(seconds), normalizedValueOfLeftChannel));
                RightChannelData.Add(new DateTimeData(BasisDate.AddSeconds(seconds), normalizedValueOfRightChannel));
                this.averageChannelNormalized[k] = (normalizedValueOfLeftChannel + normalizedValueOfRightChannel) / 2d;
            }

            int halfOfFrame = DefaultFrameLength / 2;
            double frequencyStep = SamplingFrequency / 2d / halfOfFrame;
                for (int i = 0; i < halfOfFrame; i++)
                    FrequencyData.Add(new NumericData(frequencyStep* i, 0));

            this.last = DateTime.Now;
        }

        byte[] ReadBuffer() {
            using (Stream stream = GetType().Assembly.GetManifestResourceStream("Resources.sound.bin")) {
                byte[] buffer = new byte[stream.Length];
                stream.Read(buffer, 0, buffer.Length);
                return buffer;
            }
        }
        short[] CreateSampleBuffer() {
            byte[] buffer = ReadBuffer();
            short[] sampleBuffer = new short[buffer.Length / 2];
            Buffer.BlockCopy(buffer, 0, sampleBuffer, 0, buffer.Length);
            return sampleBuffer;
        }

        void MoveFrame(int offset) {
            int newEndIndex = this.frameEndIndex + offset;
            if (newEndIndex < this.averageChannelNormalized.Length) {
                this.frameStartIndex += offset;
                this.frameEndIndex = newEndIndex;
            } else {
                this.frameStartIndex = 0;
                this.frameEndIndex = DefaultFrameLength;
            }
            StripMinLimit = BasisDate.AddSeconds(1d / SamplingFrequency * this.frameStartIndex);
            StripMaxLimit = BasisDate.AddSeconds(1d / SamplingFrequency * this.frameEndIndex);
            OnPropertyChanged(nameof(StripMinLimit));
            OnPropertyChanged(nameof(StripMaxLimit));
        }
        void RecalculateFrequencySpectrum() {
            Array.Copy(this.averageChannelNormalized, this.frameStartIndex, this.realSpectrum, 0, DefaultFrameLength);
            Array.Copy(this.zeroSpectrum, 0, this.imaginarySpectrum, 0, DefaultFrameLength);
            FastFourierTransformation.Transform(this.realSpectrum, this.imaginarySpectrum);

            BindingList<NumericData> tmpFrequencyData = new BindingList<NumericData>();
            for (int i = 0; i < DefaultFrameLength / 2; i++) {
                double magnitude = Math.Sqrt(this.realSpectrum[i] * this.realSpectrum[i] + this.imaginarySpectrum[i] * this.imaginarySpectrum[i]);
                double magnitudeDB = magnitude != 0 ? 20d * Math.Log10(magnitude) : MinDb;
                tmpFrequencyData.Add(new NumericData(FrequencyData[i].Argument, magnitudeDB));
            }
            FrequencyData = tmpFrequencyData;
            OnPropertyChanged(nameof(FrequencyData));
        }

        public void MoveToNextFrame() {
            DateTime current = DateTime.Now;
            double span = (current - this.last).TotalSeconds;
            this.last = current;
            MoveFrame((int)(span * SamplingFrequency));
            RecalculateFrequencySpectrum();
        }
    }

    static class FastFourierTransformation {
        public static void Transform(double[] real, double[] imaginary) {
            double powerOf2Double = Math.Log(real.Length, 2);
            Debug.Assert(powerOf2Double == Math.Floor(powerOf2Double));
            int powerOf2 = (int)powerOf2Double;
            int frameLength = real.Length;
            int j = 0;
            for (int i = 0; i < frameLength - 1; i++) {
                if (i < j) {
                    double tempReal = real[i];
                    double tempImaginary = imaginary[i];
                    real[i] = real[j];
                    imaginary[i] = imaginary[j];
                    real[j] = tempReal;
                    imaginary[j] = tempImaginary;
                }
                int k = frameLength / 2;
                while (k <= j) {
                    j -= k;
                    k = k / 2;
                }
                j += k;
            }
            double c1 = -1d;
            double c2 = 0d;
            int currentPowerOf2 = 1;
            for (int l = 0; l < powerOf2; l++) {
                int previousPowerOf2 = currentPowerOf2;
                currentPowerOf2 *= 2;
                double u1 = 1.0;
                double u2 = 0.0;
                for (j = 0; j < previousPowerOf2; j++) {
                    for (int i = j; i < frameLength; i += currentPowerOf2) {
                        int i1 = i + previousPowerOf2;
                        double t1 = u1 * real[i1] - u2 * imaginary[i1];
                        double t2 = u1 * imaginary[i1] + u2 * real[i1];
                        real[i1] = real[i] - t1;
                        imaginary[i1] = imaginary[i] - t2;
                        real[i] += t1;
                        imaginary[i] += t2;
                    }
                    double z = u1 * c1 - u2 * c2;
                    u2 = u1 * c2 + u2 * c1;
                    u1 = z;
                }
                c2 = -Math.Sqrt((1d - c1) / 2d);
                c1 = Math.Sqrt((1d + c1) / 2d);
            }
            for (int i = 0; i < frameLength; i++) {
                real[i] /= frameLength;
                imaginary[i] /= frameLength;
            }
        }
    }

}
