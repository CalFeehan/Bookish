using Bookish.DataAccess;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookish.ConsoleApp
{
    class Utility
    {
        public static List<string> ExtractFromCSV(string path, bool includesHeaderRow)
        {
            int linesToSkip = includesHeaderRow ? 1 : 0;

            try
            {
                string[] text = File.ReadAllLines(path);
                List<string> allLines = text.Skip(linesToSkip).ToList();
                return allLines;
            }
            catch (FileNotFoundException e)
            {
                throw;
            }
        }

        public static void AddCSVLineToBookDatabase(List<string> allLines)
        {
            foreach (string line in allLines)
            {
                List<string> item = line.Split(",").ToList();

                try
                {
                    string title = item[0];
                    string author = item[1];
                    string isbn = item[2];
                    string coverPhotoUrl = item.Count < 4 ? "https://islandpress.org/sites/default/files/default_book_cover_2015.jpg" : item[3];

                    BookRepo.AddBook(title, author, isbn, coverPhotoUrl);
                }
                catch (IndexOutOfRangeException e)
                {
                    throw;
                }
            }
        }
    }
}
