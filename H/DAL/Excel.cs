using System;
using System.Linq;
using Microsoft.Office.Interop.Excel;
using System.Collections.Generic;

namespace ImportProject.DAL
{
    internal class Excel
    {
        private readonly _Application _excel = new Application();
        private readonly Workbook _wb;
        private readonly Worksheet _ws;
        private readonly int _numberOfRows;
        private readonly int _numberOfColumns;
        private Dictionary<string, int> _dictionary;
        public Excel(string path, int sheet)
        {
            _wb = _excel.Workbooks.Open(path);
            _ws = _excel.Worksheets[sheet];
            _numberOfRows = _ws.UsedRange.Rows.Count;
            _numberOfColumns = _ws.UsedRange.Columns.Count;
            Console.WriteLine("Excel Sheet Opened!");
            _dictionary = new Dictionary<string, int>();
            StoreColumnsName();
        }

        // read a cell from excel
        public string ReadCell(int r, int c)
        {
            r++;
            c++;
            var cell = _ws.Cells[r, c].Value2;
            return cell != null ? cell.ToString() : "";
        }
        
        // get the row as an "Hotel" object
        public Hotel GetRow(int row)
        {
            int col;
            var obj = new Hotel
            {
                HotelId = Convert.ToInt32(ReadCell(row, 
                _dictionary.TryGetValue(
                    nameof(Hotel.HotelId), out col) ? col : 0)),
                DisplayName = ReadCell(row, 
                _dictionary.TryGetValue(
                    nameof(Hotel.DisplayName), out col) ? col : 0),
                DisplayNameAr = ReadCell(row, 
                _dictionary.TryGetValue(
                    nameof(Hotel.DisplayNameAr), out col) ? col : 0),
                CountryCode = ReadCell(row, 
                _dictionary.TryGetValue(
                    nameof(Hotel.CountryCode), out col) ? col : 0),
                CountryName = ReadCell(row, 
                _dictionary.TryGetValue(
                    nameof(Hotel.CountryName), out col) ? col : 0),
                State = ReadCell(row, 
                _dictionary.TryGetValue(
                    nameof(Hotel.State), out col) ? col : 0),
                CityName = ReadCell(row, 
                _dictionary.TryGetValue(
                    nameof(Hotel.CityName), out col) ? col : 0),
                Address = ReadCell(row, 
                _dictionary.TryGetValue(
                    nameof(Hotel.Address), out col) ? col : 0),
                ZipCode = ReadCell(row, 
                _dictionary.TryGetValue(
                    nameof(Hotel.ZipCode), out col) ? col : 0),
                StarRating = ConvertToByte(ReadCell(row, 
                _dictionary.TryGetValue(
                    nameof(Hotel.StarRating), out col) ? col : 0)),
                Lat = ConvertToDouble(ReadCell(row, 
                _dictionary.TryGetValue(
                    nameof(Hotel.Lat), out col) ? col : 0)),
                Lng = ConvertToDouble(ReadCell(row, 
                _dictionary.TryGetValue(
                    nameof(Hotel.Lng), out col) ? col : 0)),
                RoomCount = ConvertToShort(ReadCell(row, 
                _dictionary.TryGetValue(
                    nameof(Hotel.RoomCount), out col) ? col : 0)),
                Phone = ReadCell(row, 
                _dictionary.TryGetValue(
                    nameof(Hotel.Phone), out col) ? col : 0),
                Fax = ReadCell(row, 
                _dictionary.TryGetValue(
                    nameof(Hotel.Fax), out col) ? col : 0),
                Email = ReadCell(row, 
                _dictionary.TryGetValue(
                    nameof(Hotel.Email), out col) ? col : 0),
                Website = ReadCell(row, 
                _dictionary.TryGetValue(
                    nameof(Hotel.Website), out col) ? col : 0),
                CreationTime = DateTime.FromOADate(
                    Convert.ToDouble(ReadCell(row, 
                    _dictionary.TryGetValue(
                        nameof(Hotel.CreationTime), out col) ? col : 0))),
                UpdateTime = DateTime.FromOADate(
                    Convert.ToDouble(ReadCell(row, 
                    _dictionary.TryGetValue(
                        nameof(Hotel.CreationTime), out col) ? col : 0))),
                PropertyCategory = ReadCell(row, 
                _dictionary.TryGetValue(
                    nameof(Hotel.PropertyCategory), out col) ? col : 0),
                ChainCode = ReadCell(row, 
                _dictionary.TryGetValue(
                    nameof(Hotel.ChainCode), out col) ? col : 0),
                AddressAr = ReadCell(row, 
                _dictionary.TryGetValue(
                    nameof(Hotel.AddressAr), out col) ? col : 0)
            };
            return obj;
        }

        // close the file openned
        public bool Close()
        {
            try
            {
                _wb.Close(0);
                _excel.Quit();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private double? ConvertToDouble(string number)
        {
            if (number.Any())
            {
                return Convert.ToDouble(number);
            }
            return null;
        }
        private byte? ConvertToByte(string number)
        {
            if (number.Any())
            {
                return Convert.ToByte(number);
            }
            return null;
        }
        private short? ConvertToShort(string number)
        {
            if (number.Any())
            {
                return Convert.ToInt16(number);
            }
            return null;
        }
        public int RowsNumbers()
        {
            return _numberOfRows;
        }

        private void StoreColumnsName()
        {
            for (var i = 0; i < _numberOfColumns; i++)
            {
                _dictionary.Add(ReadCell(0, i), i);
            }
        }
    }
}
