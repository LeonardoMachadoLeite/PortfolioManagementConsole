// See https://aka.ms/new-console-template for more information
using OfficeOpenXml;
using PortfolioManagementConsole.Domain.Bovespa;
using PortfolioManagementConsole.Application;
using PortfolioManagementConsole.Application.Bovespa;
using System.Collections.Generic;

var dirPath = "D:\\Investment Data\\bovespa\\Notas de Corretagem";

WalletController bovaController = new WalletController(dirPath);

Console.WriteLine("Breakpoint");