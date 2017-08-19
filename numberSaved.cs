using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace postalCode {
    class NumberSaved {

        DataTable dtOfNumber;
        public DataTable DtOfNumber { get { return this.dtOfNumber; } set { dtOfNumber = value; } }

        public NumberSaved() {
            InitDtOfNumber();
        }

        void InitDtOfNumber() {

            dtOfNumber = new DataTable();
            dtOfNumber.Columns.Add("A");
            dtOfNumber.Columns.Add("B");
            dtOfNumber.Columns.Add("C");
            dtOfNumber.Columns.Add("D");
            dtOfNumber.Columns.Add("E");
            dtOfNumber.Columns.Add("F");

            for (int i = 0; i < 6; i++) {
                dtOfNumber.Rows.Add();
            }


        }

    }
}
