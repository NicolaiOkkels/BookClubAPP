using BookClubApp.DataAccess.Entities;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;

public class ExcelDataLoader
{
    public static List<Libraries> LoadDataFromExcel(string filePath)
    {
        var libraries = new List<Libraries>();

        var fileInfo = new FileInfo(filePath);
        if (!fileInfo.Exists)
        {
            throw new FileNotFoundException($"The file {filePath} was not found.");
        }

        using (var package = new ExcelPackage(fileInfo))
        {
            var workbook = package.Workbook;
            var worksheet = workbook.Worksheets[0];

            for (int row = 2; row <= worksheet.Dimension.End.Row; row++)
            {
                var Libraries = new Libraries
                {
                    LibrarieNumber = int.Parse(worksheet.Cells[row, 1].Value.ToString()),
                    LibrarieName = worksheet.Cells[row, 2].Value.ToString(),
                    LibrarieAddress = worksheet.Cells[row, 3].Value.ToString(),
                    LibrarieZipCode = int.Parse(worksheet.Cells[row, 4].Value.ToString()),
                    LibrarieCity = worksheet.Cells[row, 5].Value.ToString(),
                    PhoneNumber = worksheet.Cells[row, 6].Value.ToString(),
                    Email = worksheet.Cells[row, 7].Value.ToString(),
                };

                libraries.Add(Libraries);
            }
        }

        return libraries;
    }
}