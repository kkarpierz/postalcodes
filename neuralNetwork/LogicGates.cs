using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Neural_Network
{
    public class LogicGates
    {
        static Network numberNetwork;

        public static List<int> recognizedPostalNums = new List<int>();
        public static List<int> probablyPostalNums = new List<int>();

        public static void Train()
        {
            var learnRate = 0.2;


            Console.WriteLine("Training numbers:");
            Console.WriteLine("==============");
            numberNetwork = Create35to10Network();

            new Trainer(numberNetwork, numCases2, CheckCorrect, testNums).TrainUntilDone();
            //new Trainer(numberNetwork, numCases2, CheckCorrect, testNums).Train(300);

        }

        public static void Recognize(double[] inputVector = null) {
            double[] myNumberToTest = new double[] { 0, 1, 1, 1, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 1, 1, 1, 1 };
            if (inputVector != null) {
                myNumberToTest = inputVector;
            }

            double[] output = numberNetwork.FeedForward(myNumberToTest);
            for (int i = 0; i < output.Length; i++) {
                Console.WriteLine(output[i]);
            }

            int numberRecognized = numberNetwork.RecognizeNumberFromVector(myNumberToTest);
            if (numberRecognized < 10) { //recognized with high probability
                Console.WriteLine(" ====   Recognized num: " + numberRecognized.ToString());
                recognizedPostalNums.Add(numberRecognized);
                probablyPostalNums.Add(numberRecognized);
            }
            else {//recognized with lower probability
                Console.WriteLine(" ====   Probably num: " + (numberRecognized/10).ToString());
                recognizedPostalNums.Add(numberRecognized);
                probablyPostalNums.Add(numberRecognized/10);
            }
        }

        static void HL() { Console.WriteLine(new string('=', 0)); }


        static Network Create21Network()
        {
            return new Network(2, new int[0], 1, 0.5);
        }

        static Network Create35to4Network() {
            return new Network(35, new int[0], 4, 0.5);
        }

        static Network Create35to10Network()
        {
            int[] i = {4};
            return new Network(35, i, 10, 0.5);
        }

        static bool CheckCorrect(double[] target, double[] output)
        {
            var t = target[0];
            var o = output[0];
            return (t == 1 && o > 0.7) || (t == 0 && o < 0.3);
        }



        static Sample[] numCases = new[] {
                Sample.Create("1 1 1 1 1 1 0 0 0 1 1 0 0 0 1 1 0 0 0 1 1 0 0 0 1 1 0 0 0 1 1 1 1 1 1", "0 0 0 0"),
                Sample.Create("0 0 1 0 0 0 1 1 0 0 0 0 1 0 0 0 0 1 0 0 0 0 1 0 0 0 0 1 0 0 0 0 1 0 0", "0 0 0 1"),
                Sample.Create("0 1 1 1 0 1 0 0 0 1 0 0 0 0 1 0 0 0 1 0 0 0 1 0 0 0 1 0 0 0 1 1 1 1 1", "0 0 1 0"),
                Sample.Create("1 1 1 1 1 0 0 0 0 1 0 0 0 0 1 1 1 1 1 1 0 0 0 0 1 0 0 0 0 1 1 1 1 1 1", "0 0 1 1"),
                Sample.Create("1 0 0 0 1 1 0 0 0 1 1 0 0 0 1 1 1 1 1 1 0 0 0 0 1 0 0 0 0 1 0 0 0 0 1", "0 1 0 0"),
                Sample.Create("1 1 1 1 1 1 0 0 0 0 1 0 0 0 0 1 1 1 1 1 0 0 0 0 1 0 0 0 0 1 1 1 1 1 1", "0 1 0 1"),
                Sample.Create("1 1 1 1 1 1 0 0 0 0 1 0 0 0 0 1 1 1 1 1 1 0 0 0 1 1 0 0 0 1 1 1 1 1 1", "0 1 1 0"),
                Sample.Create("1 1 1 1 1 0 0 0 0 1 0 0 0 0 1 0 0 0 1 0 0 0 1 0 0 0 1 0 0 0 1 0 0 0 0", "0 1 1 1"),
                Sample.Create("1 1 1 1 1 1 0 0 0 1 1 0 0 0 1 1 1 1 1 1 1 0 0 0 1 1 0 0 0 1 1 1 1 1 1", "1 0 0 0"),
                Sample.Create("1 1 1 1 1 1 0 0 0 1 1 0 0 0 1 1 1 1 1 1 0 0 0 0 1 0 0 0 0 1 1 1 1 1 1", "1 0 0 1")
        };

        static Sample[] numCases2 = new[] {
                Sample.Create("0 0 1 1 0 0 1 0 0 1 0 1 0 0 1 0 1 0 0 1 0 1 0 0 1 0 1 0 0 1 0 0 1 1 0", "1 0 0 0 0 0 0 0 0 0"),
                Sample.Create("0 1 1 0 0 1 0 0 1 0 1 0 0 1 0 1 0 0 1 0 1 0 0 1 0 1 0 0 1 0 0 1 1 0 0", "1 0 0 0 0 0 0 0 0 0"),
                Sample.Create("0 1 1 1 1 0 1 0 0 1 0 1 0 0 1 0 1 0 0 1 0 1 0 0 1 0 1 0 0 1 0 1 1 1 1", "1 0 0 0 0 0 0 0 0 0"),
                Sample.Create("1 1 1 1 0 1 0 0 1 0 1 0 0 1 0 1 0 0 1 0 1 0 0 1 0 1 0 0 1 0 1 1 1 1 0", "1 0 0 0 0 0 0 0 0 0"),
                Sample.Create("1 1 1 1 1 1 0 0 0 1 1 0 0 0 1 1 0 0 0 1 1 0 0 0 1 1 0 0 0 1 1 1 1 1 1", "1 0 0 0 0 0 0 0 0 0"),
                Sample.Create("1 1 1 1 1 1 0 0 0 1 1 0 0 0 1 1 0 0 0 1 1 0 0 0 1 1 0 0 0 1 1 1 1 1 1", "1 0 0 0 0 0 0 0 0 0"),
                Sample.Create("0 0 1 0 0 0 1 1 0 0 1 0 1 0 0 0 0 1 0 0 0 0 1 0 0 0 0 1 0 0 0 1 1 1 0", "0 1 0 0 0 0 0 0 0 0"),
                Sample.Create("0 0 1 0 0 0 1 1 0 0 0 0 1 0 0 0 0 1 0 0 0 0 1 0 0 0 0 1 0 0 0 1 1 1 0", "0 1 0 0 0 0 0 0 0 0"),
                Sample.Create("0 0 0 0 1 0 0 0 1 1 0 0 1 0 1 0 0 0 0 1 0 0 0 0 1 0 0 0 0 1 0 0 0 0 1", "0 1 0 0 0 0 0 0 0 0"),
                Sample.Create("0 0 0 0 0 0 0 1 0 0 0 1 1 0 0 0 0 1 0 0 0 0 1 0 0 0 0 1 0 0 0 1 1 1 0", "0 1 0 0 0 0 0 0 0 0"),
                Sample.Create("0 0 1 0 0 0 1 1 0 0 0 0 1 0 0 0 0 1 0 0 0 0 1 0 0 0 0 1 0 0 0 0 1 0 0", "0 1 0 0 0 0 0 0 0 0"),
                Sample.Create("0 0 1 0 0 0 1 1 0 0 0 0 1 0 0 0 0 1 0 0 0 0 1 0 0 0 0 1 0 0 0 0 1 0 0", "0 1 0 0 0 0 0 0 0 0"),
                Sample.Create("0 0 1 1 0 0 1 0 0 1 0 0 0 0 1 0 0 0 1 0 0 0 1 0 0 0 1 0 0 0 0 1 1 1 1", "0 0 1 0 0 0 0 0 0 0"),
                Sample.Create("0 1 1 0 0 1 0 0 1 0 0 0 0 1 0 0 0 0 1 0 0 0 1 0 0 0 1 0 0 0 1 1 1 1 0", "0 0 1 0 0 0 0 0 0 0"),
                Sample.Create("0 0 1 1 0 0 1 0 0 1 0 0 0 0 1 0 0 0 0 1 0 0 0 1 0 0 0 1 0 0 0 1 1 1 1", "0 0 1 0 0 0 0 0 0 0"),
                Sample.Create("0 1 1 1 0 1 0 0 1 0 0 0 0 1 0 0 0 1 0 0 0 1 0 0 0 1 0 0 1 0 1 1 1 1 0", "0 0 1 0 0 0 0 0 0 0"),
                Sample.Create("0 1 1 1 0 1 0 0 0 1 1 0 0 0 1 0 0 0 1 0 0 0 1 0 0 0 1 0 0 1 1 1 1 1 1", "0 0 1 0 0 0 0 0 0 0"),
                Sample.Create("0 1 1 1 0 1 0 0 0 1 0 0 0 0 1 0 0 0 1 0 0 0 1 0 0 0 1 0 0 0 1 1 1 1 1", "0 0 1 0 0 0 0 0 0 0"),
                Sample.Create("1 1 1 1 1 0 0 0 0 1 0 0 0 0 1 1 1 1 1 1 0 0 0 0 1 0 0 0 0 1 1 1 1 1 1", "0 0 0 1 0 0 0 0 0 0"),
                Sample.Create("0 0 1 1 0 0 1 0 0 1 0 0 0 0 1 0 0 0 1 0 0 0 0 0 1 0 1 0 0 1 0 0 1 1 0", "0 0 0 1 0 0 0 0 0 0"),
                Sample.Create("0 1 1 0 0 1 0 0 1 0 0 0 0 1 0 0 0 1 0 0 0 0 0 1 0 1 0 0 1 0 0 1 1 0 0", "0 0 0 1 0 0 0 0 0 0"),
                Sample.Create("0 0 1 1 0 0 1 0 0 1 0 0 0 0 1 0 0 0 1 0 0 0 0 0 1 0 1 0 0 1 0 0 1 1 0", "0 0 0 1 0 0 0 0 0 0"),
                Sample.Create("0 1 1 1 0 0 0 0 0 1 0 0 0 0 1 0 0 1 1 0 0 0 0 0 1 0 1 0 0 1 0 0 1 1 0", "0 0 0 1 0 0 0 0 0 0"),
                Sample.Create("0 1 1 1 0 1 0 0 0 1 0 0 0 0 1 0 0 1 1 0 0 0 0 0 1 1 0 0 0 1 0 1 1 1 0", "0 0 0 1 0 0 0 0 0 0"),
                Sample.Create("1 0 0 0 1 1 0 0 0 1 1 0 0 0 1 1 1 1 1 1 0 0 0 0 1 0 0 0 0 1 0 0 0 0 1", "0 0 0 0 1 0 0 0 0 0"),
                Sample.Create("0 0 0 1 0 0 0 1 0 0 0 1 0 0 0 1 1 1 1 1 0 0 0 1 0 0 0 0 1 0 0 0 0 1 0", "0 0 0 0 1 0 0 0 0 0"),
                Sample.Create("0 0 0 0 1 0 0 0 1 0 0 0 1 0 0 0 1 1 1 1 0 0 0 0 1 0 0 0 0 1 0 0 0 0 1", "0 0 0 0 1 0 0 0 0 0"),
                Sample.Create("0 0 0 1 0 0 0 1 0 0 0 1 0 1 0 1 1 1 1 1 0 0 0 1 0 0 0 0 1 0 0 0 0 1 0", "0 0 0 0 1 0 0 0 0 0"),
                Sample.Create("0 0 1 0 0 0 1 0 0 0 1 0 0 0 0 1 1 1 1 0 0 0 0 1 0 0 0 0 1 0 0 0 0 1 0", "0 0 0 0 1 0 0 0 0 0"),
                Sample.Create("0 0 0 0 1 0 0 0 1 0 0 0 1 0 0 0 1 0 1 0 1 1 1 1 1 0 0 0 1 0 0 0 0 1 0", "0 0 0 0 1 0 0 0 0 0"),
                Sample.Create("1 1 1 1 1 1 0 0 0 0 1 0 0 0 0 1 1 1 1 0 0 0 0 0 1 0 0 0 0 1 1 1 1 1 0", "0 0 0 0 0 1 0 0 0 0"),
                Sample.Create("1 1 1 1 0 1 0 0 0 0 1 0 0 0 0 1 1 1 0 0 0 0 0 1 0 1 0 0 1 0 0 1 1 0 0", "0 0 0 0 0 1 0 0 0 0"),
                Sample.Create("0 1 1 1 1 0 1 0 0 0 0 1 0 0 0 0 1 1 1 0 0 0 0 0 1 0 0 0 0 1 0 1 1 1 1", "0 0 0 0 0 1 0 0 0 0"),
                Sample.Create("1 1 1 1 0 1 0 0 0 0 1 0 0 0 0 1 1 1 1 0 0 0 0 1 0 0 0 0 1 0 1 1 1 1 0", "0 0 0 0 0 1 0 0 0 0"),
                Sample.Create("0 1 1 1 1 0 1 0 0 0 0 1 0 0 0 0 1 1 1 1 0 0 0 0 1 0 0 0 0 1 0 1 1 1 1", "0 0 0 0 0 1 0 0 0 0"),
                Sample.Create("1 1 1 1 1 1 0 0 0 0 1 0 0 0 0 1 1 1 1 1 0 0 0 0 1 0 0 0 0 1 1 1 1 1 1", "0 0 0 0 0 1 0 0 0 0"),
                Sample.Create("0 1 1 1 0 1 0 0 0 0 1 0 0 0 0 1 1 1 0 0 1 0 0 1 0 1 0 0 1 0 0 1 1 0 0", "0 0 0 0 0 0 1 0 0 0"),
                Sample.Create("0 1 1 0 0 1 0 0 1 0 1 0 0 0 0 1 1 1 0 0 1 0 0 1 0 1 0 0 1 0 0 1 1 0 0", "0 0 0 0 0 0 1 0 0 0"),
                Sample.Create("0 1 1 1 0 1 0 0 0 1 1 0 0 0 0 1 1 1 1 0 1 0 0 0 1 1 0 0 0 1 0 1 1 1 0", "0 0 0 0 0 0 1 0 0 0"),
                Sample.Create("0 0 1 1 1 0 1 0 0 0 0 1 0 0 0 0 1 1 1 0 0 1 0 0 1 0 1 0 0 1 0 0 1 1 0", "0 0 0 0 0 0 1 0 0 0"),
                Sample.Create("0 1 1 1 0 1 0 0 0 0 1 0 0 0 0 1 1 1 0 0 1 0 0 1 0 1 0 0 1 0 1 1 1 1 0", "0 0 0 0 0 0 1 0 0 0"),
                Sample.Create("1 1 1 1 1 1 0 0 0 0 1 0 0 0 0 1 1 1 1 1 1 0 0 0 1 1 0 0 0 1 1 1 1 1 1", "0 0 0 0 0 0 1 0 0 0"),
                Sample.Create("1 1 1 1 1 0 0 0 0 1 0 0 0 0 1 0 0 0 1 0 0 0 1 0 0 0 1 0 0 0 1 0 0 0 0", "0 0 0 0 0 0 0 1 0 0"),
                Sample.Create("0 1 1 1 1 0 0 0 0 1 0 0 0 0 1 0 0 0 1 0 0 0 0 1 0 0 0 1 0 0 0 0 1 0 0", "0 0 0 0 0 0 0 1 0 0"),
                Sample.Create("0 1 1 1 1 0 0 0 0 1 0 0 0 1 0 0 0 1 0 0 0 0 1 0 0 0 1 0 0 0 0 1 0 0 0", "0 0 0 0 0 0 0 1 0 0"),
                Sample.Create("1 1 1 1 1 0 0 0 0 1 0 0 0 1 0 0 0 1 0 0 0 0 1 0 0 0 1 0 0 0 1 0 0 0 0", "0 0 0 0 0 0 0 1 0 0"),
                Sample.Create("1 1 1 1 0 0 0 0 1 0 0 0 0 1 0 0 0 1 0 0 0 0 1 0 0 0 1 0 0 0 0 1 0 0 0", "0 0 0 0 0 0 0 1 0 0"),
                Sample.Create("1 1 1 1 1 0 0 0 0 1 0 0 0 0 1 0 0 0 1 0 0 0 1 0 0 0 1 0 0 0 1 0 0 0 0", "0 0 0 0 0 0 0 1 0 0"),
                Sample.Create("0 1 1 0 0 1 0 0 1 0 1 0 0 1 0 0 1 1 0 0 1 0 0 1 0 1 0 0 1 0 0 1 1 0 0", "0 0 0 0 0 0 0 0 1 0"),
                Sample.Create("0 0 1 1 0 0 1 0 0 1 0 1 0 0 1 0 0 1 1 0 0 1 0 0 1 0 1 0 0 1 0 0 1 1 0", "0 0 0 0 0 0 0 0 1 0"),
                Sample.Create("0 1 1 1 0 1 0 0 0 1 1 0 0 0 1 0 1 1 1 0 1 0 0 0 1 1 0 0 0 1 0 1 1 1 0", "0 0 0 0 0 0 0 0 1 0"),
                Sample.Create("0 1 1 1 0 1 0 0 0 1 1 0 0 0 1 0 1 1 1 0 1 0 0 0 1 1 0 0 0 1 1 1 1 1 1", "0 0 0 0 0 0 0 0 1 0"),
                Sample.Create("0 1 1 1 1 0 1 0 0 1 0 1 0 0 1 0 1 1 1 1 0 1 0 0 1 0 1 0 0 1 0 1 1 1 1", "0 0 0 0 0 0 0 0 1 0"),
                Sample.Create("1 1 1 1 1 1 0 0 0 1 1 0 0 0 1 1 1 1 1 1 1 0 0 0 1 1 0 0 0 1 1 1 1 1 1", "0 0 0 0 0 0 0 0 1 0"),
                Sample.Create("0 1 1 0 0 1 0 0 1 0 1 0 0 1 0 0 1 1 1 0 0 0 0 1 0 1 0 0 1 0 0 1 1 0 0", "0 0 0 0 0 0 0 0 0 1"),
                Sample.Create("0 0 1 1 0 0 1 0 0 1 0 1 0 0 1 0 0 1 1 1 0 0 0 0 1 0 1 0 0 1 0 0 1 1 0", "0 0 0 0 0 0 0 0 0 1"),
                Sample.Create("0 1 1 1 0 0 1 0 0 1 0 1 0 0 1 0 1 1 1 1 0 0 0 0 1 0 0 0 0 1 0 1 1 1 0", "0 0 0 0 0 0 0 0 0 1"),
                Sample.Create("0 1 1 1 0 1 0 0 1 0 1 0 0 1 0 0 1 1 1 0 0 0 0 1 0 1 0 0 1 0 0 1 1 1 0", "0 0 0 0 0 0 0 0 0 1"),
                Sample.Create("0 1 1 1 0 1 0 0 0 1 1 0 0 0 1 0 1 1 1 1 0 0 0 0 1 0 0 0 0 1 0 1 1 1 1", "0 0 0 0 0 0 0 0 0 1"),
                Sample.Create("1 1 1 1 1 1 0 0 0 1 1 0 0 0 1 1 1 1 1 1 0 0 0 0 1 0 0 0 0 1 1 1 1 1 1", "0 0 0 0 0 0 0 0 0 1")
        };

        static Sample[] testNums = new[] {
            Sample.Create("1 1 1 1 1 1 0 0 0 1 1 0 0 0 1 1 0 0 0 1 1 0 0 0 1 1 0 0 0 1 1 1 1 1 1", "0 0 0 0")
        };



    }
}
