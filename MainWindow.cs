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
                for (int i = 0; i < 6; i++) {
                    grids[j].Columns[i].Width = 22;
                    grids[j].Columns[i].Resizable = DataGridViewTriState.False;
                    grids[j].Rows[i].Resizable = DataGridViewTriState.False;
                }
                grids[j].ColumnHeadersVisible = false;
                grids[j].RowHeadersVisible = false;
            }

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

                for (int i = 0; i < 6; i++) {
                    for (int j = 0; j < 6; j++) {
                        if (grids[k].Rows[i].Cells[j].Selected)
                            MatrixOfNumbers[k].Rows[i][j] = 1;
                        else
                            MatrixOfNumbers[k].Rows[i][j] = 0;

                    }
                }

            }

            int ij = 0;

        }



    }
}
