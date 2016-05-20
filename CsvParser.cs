using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DallasAdc {
    // class to read csv files and convert data to useable format
    class CsvParser {
        List<uint>[] sarStage1, sarTotal, rawBits;
        List<double>[] weightStage1, weightTotal;
        int nChannels = 3;
        int nSamples = 16 * 1024;

        public CsvParser () {
            sarStage1 = new List<uint>[nChannels];
            sarTotal = new List<uint>[nChannels];
            rawBits = new List<uint>[20];
            weightStage1 = new List<double>[nChannels];
            weightTotal = new List<double>[nChannels];

            for (int i = 0; i < nChannels; i++) {
                sarStage1[i] = new List<uint>();
                sarTotal[i] = new List<uint>();
                weightStage1[i] = new List<double>();
                weightTotal[i] = new List<double>();
            }
            for (int i = 0; i < 20; i++) rawBits[i] = new List<uint>();
        }

        public void ReadCsvFile (string filePath) {
            List<uint>[] data = new List<uint>[4];
            for (int i = 0; i < 4; i++) { data[i] = new List<uint>(); }

            using (StreamReader sr = new StreamReader(filePath)) {
                sr.ReadLine(); // Discard first line (column headers)
                string line;
                while ((line = sr.ReadLine()) != null) {
                    // assume 4 columns separated by commas
                    // discard the 1st column
                    string[] bits = line.Split(',');
                    for (int i = 1; i < 4; i++) {
                        data[i].Add(Convert.ToUInt32(bits[i]));
                    }
                }
            }

            int index0 = FindHeader(data[1]); // header is in the same place for all channels
            if (index0 < 0) throw new Exception("Header pattern not found in CSV file " + filePath);
            // Data comes in 20-bit strings
            // bits[0:1] are header, bits[2:10] are SAR1, bits[11:19] are SAR2
            // starting from the first header fill sarStage1 and sarTotal with these strings
            for (int iChannel = 1; iChannel < 4; iChannel++) {
                for (int iVal = index0; iVal < data[iChannel].Count; iVal += 20) {
                    for (int j = 0; j < 20; j++) {
                        rawBits[j].Add(data[iChannel][iVal + j]); // Store bit
                    } // end loop over bits in string
                } // end loop over strings (values from ADC)
            } // end loop over channels
        } // end ReadCsvFile

        // Raw data from each channel comes in 20-bit strings
        // 2 bits form an alternating 10,00,10,... pattern,
        // this is the header
        // Currently only looks for the first bit of that
        // pattern. For any reasonable number of samples, the
        // chance that this pattern occurs randomly is tiny
        public int FindHeader (List<uint> channelData) {
            for (int index = 0; index < 20; index++) {
                // Select every 20th element of the list and check if the pattern matches
                // to 1010... or 0101...
                bool isHeader = true;
                for (int it = 0; it < channelData.Count; it += 20) {
                    // (it/20)%2 alternates 0101..., if the pattern in bits[index] matches that
                    // then the XOR function will give all 0s, if bits[index] is the same
                    // pattern shifted by one then XOR will give all 1s
                    if ((channelData[index + it] ^ ((it / 20) % 2)) != (channelData[index] ^ 0)) {
                        isHeader = false; break;
                    }
                }
                if (isHeader) return index;
            }
            return -1; // no header found
        }

        // Calibrate to a sine wave
        // Least squares fit of data to a sine wave of known frequency
        // Done using Moore-Penrose inversion to solve system of linear equations
        // Equations of the form:
        // w1*bit1 + ... + w18*bit18 = A(sin(2pi*f*t+d)+1),
        // where the wi are the weights for each bit
        // This equation can be rearranged to:
        // -bit1 = (-A-Bsin(2pi*f*t)-Ccos(2pi*f*t) + w2*bit2 + ... + w18*bit18)/w1
        // and solved for the vector (-A -B -C w2 ... w18) with w1 normalized to 1
        public void SineCalibration (double frequency, double timeStep) {
            // Need matrix equation of the form Ax = B => x = (A^-1)*B
            // Convert raw bits to matrix of doubles
            double[,] A1 = new double[rawBits[0].Count, 12];
            double[,] A = new double[rawBits[0].Count, 20];
            // TODO: Fill A matrices

            double[] B1 = new double[rawBits[0].Count];
            double[] B = new double[rawBits[0].Count];
            for (int i = 0; i < rawBits[0].Count; i++) {
                B1[i] = (double) rawBits[2][i];
                B[i] = (double) rawBits[2][i];
            }
            
            // TODO: Import Math.NET libraries (or Ilnumerics.NET)
            //double[,] invA1 = Matrix.PseudoInverse[A1];
        }
    }
}
