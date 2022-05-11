using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using PortfolioManagementConsole.Application.Bovespa;

namespace PortfolioManagementTests
{
    [TestClass]
    public class ExtractDayCostFromExcelFileTest
    {
        [TestMethod]
        public void TestExtractTransactionsFromExcel()
        {
            var filePath = "D:\\Investment Data\\bovespa\\Notas de Corretagem\\2019\\CLEAR\\2019.10 NotaCorretagem.xlsx";

            ExtractTransactionDayCostFromExcelFile excelFileDayCost = new ExtractTransactionDayCostFromExcelFile(filePath);
            ExtractTransactionsFromExcelFile excelFileTransaction = new ExtractTransactionsFromExcelFile(filePath);

            excelFileTransaction.ReadTransactions();
            excelFileDayCost.ReadTransactionsDayCosts();


            foreach (var transaction in excelFileTransaction.Transactions)
            {
                Console.WriteLine(transaction.GetJson());
            }

            foreach (var transaction in excelFileDayCost.TransactionDayCosts)
            {
                Console.WriteLine(transaction.GetJson());
            }

            excelFileTransaction.CloseExcelFile();
            excelFileDayCost.CloseExcelFile();
        }
    }
}