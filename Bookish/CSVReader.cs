using Bookish.DataAccess;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualBasic.FileIO;
using System;

namespace Bookish.ConsoleApp
{
    class CSVReader
    {
        private const string PHOTO_PLACEHOLDER_URL = "https://islandpress.org/sites/default/files/default_book_cover_2015.jpg";
        public static List<string> ExtractFromCSV(string path, bool includesHeaderRow)
        {
            int linesToSkip = includesHeaderRow ? 1 : 0;

            string[] text = File.ReadAllLines(path);
            List<string> allLines = text.Skip(linesToSkip).ToList();
            return allLines;
        }

        public static void AddCSVLineToBookDatabase(List<string> allLines)
        {
            foreach (string line in allLines)
            {
                List<string> item = line.Split(",").ToList();

                string title = item[0].Trim();
                string author = item[1].Trim();
                string isbn = item[2].Trim();
                string coverPhotoUrl = item.Count < 4 ? PHOTO_PLACEHOLDER_URL : item[3].Trim();

                BookRepo.AddBook(title, author, isbn, coverPhotoUrl);
            }
        }

        public static bool ProcessComplexCSV(string path)
        {
            //Get all data in a good format
            //List of dictionaries, where the dicts contain Header : Value for each row
            List<string> text = File.ReadAllLines(path).ToList();
            List<string> headers = text[0].Split(",").ToList();
            TextFieldParser parser;
            List<Dictionary<string, string>> data = new List<Dictionary<string, string>>();
            foreach (string line in text.Skip(1))
            {
                parser = new TextFieldParser(new StringReader(line));
                parser.HasFieldsEnclosedInQuotes = true;
                parser.SetDelimiters(",");
                while (!parser.EndOfData)
                {
                    Dictionary<string, string> rowDict = new Dictionary<string, string>();
                    try
                    {
                        string[] fields = parser.ReadFields();
                        for (int i = 0; i < headers.Count; i++)
                        {
                            //while (fields[i].Contains("\'"))
                            //{
                            //    int index = fields[i].IndexOf("\'");
                            //    fields[i] = fields[i].Remove(index);
                            //}
                            rowDict[headers[i]] = fields[i];
                        }
                        data.Add(rowDict);
                    } catch (Exception e)
                    {
                        continue;
                    }
                }
            }

            //Now process the data
            List<string> dbHeaders = new List<string>()
            {
                "title", "authors", "isbn"
            };
            bool validData = true;
            foreach (string header in dbHeaders)
            {
                if (!data[0].ContainsKey(header))
                {
                    validData = false;
                }
            }
            if (!validData) { return validData; }
            foreach (Dictionary<string, string> entry in data)
            {
                try
                {
                    BookRepo.AddBook(entry["title"], entry["authors"], entry["isbn"], PHOTO_PLACEHOLDER_URL);
                } catch (Exception ex)
                {
                    continue;
                }
            }
            return true;
        }
    }
}
