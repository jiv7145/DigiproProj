using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DigiproProjectFirst {
    class Scratch {
        /// <summary>
        /// Calculates Discrete Fourier Transform of given digital signal x
        /// </summary>
        /// <param name="x">Signal x samples values</param>
        /// <returns>Fourier Transform of signal x</returns>
        public Complex[] DFT(Double[] x) {
            int N = x.Length; // Number of samples
            Complex[] X = new Complex[N];

            for (int k = 0; k < N; k++) {
                X[k] = 0;

                for (int n = 0; n < N; n++) {
                    X[k] += x[n] * Complex.Exp(-Complex.ImaginaryOne * 2 * Math.PI * (k * n) / Convert.ToDouble(N));
                }

                X[k] = X[k] / N;

            }

            return X;
        }



        /// <summary>
        /// Calculates inverse Discrete Fourier Transform of given spectrum X
        /// </summary>
        /// <param name="X">Spectrum complex values</param>
        /// <returns>Signal samples in time domain</returns>
        public Double[] iDFT(Complex[] X) {
            int N = X.Length; // Number of spectrum elements
            Double[] x = new Double[N];

            for (int n = 0; n < N; n++) {
                Complex sum = 0;

                for (int k = 0; k < N; k++) {
                    sum += X[k] * Complex.Exp(Complex.ImaginaryOne * 2 * Math.PI * (k * n) / Convert.ToDouble(N));
                }

                x[n] = sum.Real; // As a result we expect only real values (if our calculations are correct imaginary values should be equal or close to zero)
            }

            return x;
        }
    }
}
