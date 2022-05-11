using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioManagementConsole.Application.Bovespa
{
    public class GetBuyOrSellHistoryExcelFiles : IGetBuyOrSellHistoryExcelFiles
    {

        private readonly LinkedList<string> excelFileNames = new LinkedList<string>();

        public GetBuyOrSellHistoryExcelFiles(string excelHomeDir)
        {
            string[] filesFound;
            string searchDirectory;
            Queue<string> directoryQueue = new Queue<string>();

            if (Directory.Exists(excelHomeDir))
            {
                directoryQueue.Enqueue(excelHomeDir);

                while (directoryQueue.Count > 0)
                {
                    searchDirectory = directoryQueue.Dequeue();

                    filesFound = Directory.GetFiles(searchDirectory);
                    foreach (string fileName in filesFound)
                    {
                        if (this.ValidExcelFile(fileName))
                        {
                            this.excelFileNames.AddLast(fileName);  
                        }
                    }

                    foreach (string directoryPath in Directory.GetDirectories(searchDirectory))
                    {
                        directoryQueue.Enqueue(directoryPath);
                    }
                }

                if (excelFileNames.Count == 0)
                {
                    throw new Exception(String.Format("No excel files found in {0}", excelHomeDir));
                }
            }
            else
            {
                throw new Exception(String.Format("{0} is not a valid directory.", excelHomeDir));
            }
        }

        public LinkedList<string> ExcelFileNames => this.excelFileNames;

        private bool ValidExcelFile(string fileName)
        {
            return fileName.EndsWith("NotaCorretagem.xlsx");
        }
    }
}
