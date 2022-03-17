// See https://aka.ms/new-console-template for more information
using OfficeOpenXml;

Console.WriteLine("Hello, World!");
var filePath = "C:\\Users\\leoml\\Documents\\Python Data\\bovespa\\Notas de Corretagem\\2019\\CLEAR\\2019.10 NotaCorretagem.xlsx";

using (var package = new ExcelPackage(new FileInfo(filePath)))
{
    ExcelWorksheet transactionsSheet = package.Workbook.Worksheets["OPERACOES"];

    foreach (var column in transactionsSheet.Tables["Tabela1"].Columns)
    {
        Console.WriteLine($"Header: { column.Name }");
    }
    
}