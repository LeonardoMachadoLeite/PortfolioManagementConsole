// See https://aka.ms/new-console-template for more information
using OfficeOpenXml;
using PortfolioManagementConsole.Domain.Bovespa;
using PortfolioManagementConsole.Application;
using PortfolioManagementConsole.Application.Bovespa;
using System.Collections.Generic;

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