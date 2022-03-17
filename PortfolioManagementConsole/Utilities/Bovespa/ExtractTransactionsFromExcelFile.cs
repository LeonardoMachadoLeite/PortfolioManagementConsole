using OfficeOpenXml;
using PortfolioManagementConsole.Model.Bovespa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioManagementConsole.Utilities.Bovespa
{
    internal class ExtractTransactionsFromExcelFile : ExtractFromExcelFile
    {

        private LinkedList<Transaction> transactions;

        public ExtractTransactionsFromExcelFile(string excelFilePath) : base(excelFilePath, "OPERACOES")
        {
            this.transactions = new LinkedList<Transaction>();
        }

        internal LinkedList<Transaction> Transactions { get => transactions; }

        public void ReadTransactions()
        {
            this.transactions.Clear();
            ExcelWorksheet sheet = this.SheetReader.ExcelWorksheet;
            Transaction newTransaction;

            for (int row = 2; row < this.SheetReader.FilledRows; row++)
            {
                newTransaction = new Transaction(
                    sheet.GetValue<DateTime>(row, 1),
                    sheet.GetValue<string>(row, 2),
                    sheet.GetValue<string>(row, 3),
                    sheet.GetValue<int>(row, 4),
                    sheet.GetValue<double>(row, 5)
                );
                this.transactions.AddLast(newTransaction);
            }
        }

    }
}
