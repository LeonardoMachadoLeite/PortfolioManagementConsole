using OfficeOpenXml;
using PortfolioManagementConsole.Domain.Bovespa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioManagementConsole.Application.Bovespa
{
    public class ExtractTransactionsFromExcelFile : ExtractFromExcelFile, IExtractTransactionsFromExcelFile
    {

        private LinkedList<ITransaction> transactions;

        public ExtractTransactionsFromExcelFile(string excelFilePath) : base(excelFilePath, "OPERACOES")
        {
            this.transactions = new LinkedList<ITransaction>();
        }

        public LinkedList<ITransaction> Transactions { get => transactions; }

        public void ReadTransactions()
        {
            this.transactions.Clear();
            ExcelWorksheet sheet = this.SheetReader.ExcelWorksheet;
            ITransaction newTransaction;

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
