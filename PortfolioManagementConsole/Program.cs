// See https://aka.ms/new-console-template for more information
using OfficeOpenXml;
using PortfolioManagementConsole.Domain.Bovespa;
using PortfolioManagementConsole.Application;
using PortfolioManagementConsole.Application.Bovespa;
using System.Collections.Generic;

var dirPath = "D:\\Investment Data\\bovespa\\Notas de Corretagem";

Wallet bovaController = new Wallet(dirPath);

Console.WriteLine(bovaController);