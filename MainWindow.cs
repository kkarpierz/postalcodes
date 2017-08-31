using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using postalCode;
using CSharp_Neural_Network;
using System.Diagnostics;

namespace postalCode {
    public partial class MainWindow : Form {

        List<DataGridView> grids;

        public MainWindow() {
            InitializeComponent();

            List<NumberSaved> numbers = new List<NumberSaved>();

            for (int i = 0; i < 5; i++) {
                numbers.Add(new NumberSaved());
            }
            
            grids = new List<DataGridView>();

            grids.Add(FirstNumber);
            grids.Add(SecondNumber);
            grids.Add(ThirdNumber);
            grids.Add(FourthNumber);
            grids.Add(FifthNumber);

            for (int j = 0; j < grids.Count; j++) {
                grids[j].DataSource = numbers[j].DtOfNumber;
                for (int i = 0; i < 5; i++) {
                    grids[j].Columns[i].Width = 22;
                    grids[j].Columns[i].Resizable = DataGridViewTriState.False;
                }
                for (int l = 0; l < 7; l++) {
                    grids[j].Rows[l].Resizable = DataGridViewTriState.False;
                }
                grids[j].Rows.RemoveAt(6);
                grids[j].ColumnHeadersVisible = false;
                grids[j].RowHeadersVisible = false;
            }

            LogicGates.Train();
            LogicGates.Recognize();
            //Mnist.Train(18900, 0.0015);
            Debug.WriteLine("Linijka w debugu :-)");
            Console.WriteLine("Everything done.  Press any key to stop.");
            Console.ReadLine();

        }


        private void button1_Click(object sender, EventArgs e) {

            List<DataTable> MatrixOfNumbers = new List<DataTable>();

            for (int i = 0; i < 5; i++) {
                DataTable dt = new DataTable();
                NumberSaved number = new NumberSaved();
                dt = number.DtOfNumber;
                MatrixOfNumbers.Add(dt);
            }


            for (int k = 0; k < grids.Count; k++) {

                for (int i = 0; i < 7; i++) {
                    for (int j = 0; j < 5; j++) {
                        if (grids[k].Rows[i].Cells[j].Selected)
                            MatrixOfNumbers[k].Rows[i][j] = 1;

                        else
                            MatrixOfNumbers[k].Rows[i][j] = 0;

                    }
                }

            }

            double[] NumberFromDt = new double[35];
            List<double[]> listOfNumbersFromDt = new List<double[]>();

            for (int k = 0; k < MatrixOfNumbers.Count; k++) {
                for (int i = 0; i < MatrixOfNumbers[k].Rows.Count; i++) {
                    for (int j = 0; j < MatrixOfNumbers[k].Columns.Count; j++) {
                        NumberFromDt[(5 * i) + j] = Convert.ToDouble(MatrixOfNumbers[k].Rows[i][j]);
                    }
                }
                listOfNumbersFromDt.Add(NumberFromDt);
                NumberFromDt = new double[35];
            }

            for (int i = 0; i < listOfNumbersFromDt.Count; i++) {
                LogicGates.Recognize(listOfNumbersFromDt[i]);
            }
            

            int ij = 0;

        }



    }
}
