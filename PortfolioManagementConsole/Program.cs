// See https://aka.ms/new-console-template for more information
using OfficeOpenXml;
using PortfolioManagementConsole.Model.Bovespa;
using PortfolioManagementConsole.Utilities;
using PortfolioManagementConsole.Utilities.Bovespa;
using System.Collections.Generic;

var filePath = "D:\\Investment Data\\bovespa\\Notas de Corretagem\\2019\\CLEAR\\2019.10 NotaCorretagem.xlsx";
var sheetName = "OPERACOES";

ExtractTransactionsFromExcelFile excelFile = new ExtractTransactionsFromExcelFile(filePath, sheetName);

excelFile.ReadTransactions();

foreach (var transaction in excelFile.Transactions)
{
    Console.WriteLine(transaction.GetJson());
}

excelFile.CloseExcelFile();