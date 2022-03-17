using OfficeOpenXml;
using PortfolioManagementConsole.Model.Bovespa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioManagementConsole.Utilities.Bovespa
{
    internal class ExtractTransactionDayCostFromExcelFile : ExtractFromExcelFile
    {
        private LinkedList<TransactionDayCost> transactionDayCosts;

        public ExtractTransactionDayCostFromExcelFile(string excelFilePath) : base(excelFilePath, "CUSTOS")
        {
            this.transactionDayCosts = new LinkedList<TransactionDayCost>();
        }

        internal LinkedList<TransactionDayCost> TransactionDayCosts { get => transactionDayCosts; }

        public void ReadTransactionsDayCosts()
        {
            this.transactionDayCosts.Clear();
            ExcelWorksheet sheet = this.SheetReader.ExcelWorksheet;
            TransactionDayCost newTransactionDayCosts;

            for (int row = 2; row < this.SheetReader.FilledRows; row++)
            {
                newTransactionDayCosts = new TransactionDayCost(
                    sheet.GetValue<DateTime>(row, 1),
                    sheet.GetValue<double>(row, 2),
                    sheet.GetValue<double>(row, 3),
                    sheet.GetValue<double>(row, 4),
                    sheet.GetValue<double>(row, 5),
                    sheet.GetValue<double>(row, 6),
                    sheet.GetValue<double>(row, 7),
                    sheet.GetValue<double>(row, 8),
                    sheet.GetValue<double>(row, 9),
                    sheet.GetValue<double>(row, 10),
                    sheet.GetValue<double>(row, 11)
                );
                this.transactionDayCosts.AddLast(newTransactionDayCosts);
            }
        }


    }
}
