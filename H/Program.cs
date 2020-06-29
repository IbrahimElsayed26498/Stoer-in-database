using System;
using System.IO;
using ImportProject.DAL;


namespace ImportProject
{
    class Program
    {

        static void Main(string[] args)
        {
            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "..", "..")
                             +
                             @"\SampleExcelFiles\";
            var fileNames = Directory.GetFiles(folderPath, "*.xlsx");

            Excel excel = null;
            var hotelDAL = new HotelDAL();
            try
            {
                foreach (var item in fileNames)
                {

                    var success = true;
                    Console.WriteLine($"Path = {item}");
                    excel = new Excel(item, 1);
                    try
                    {
                        Console.WriteLine($"Loading Sheet : {Path.GetFileName(item)}");
                        var rows = excel.RowsNumbers();
                        for (var i = 1; i < rows; i++) // row 0 is the columns' names
                        {

                            if (!hotelDAL.Add(excel.GetRow(i), out var message))
                            {
                                success = false;
                                Console.WriteLine($"Error in row ({i}).");
                                Console.WriteLine($"----{message}----");
                            }
                            Console.Write("\b\b\b" + "" + (int)((double)i / rows * 100) + "%");
                        }
                        excel.Close();
                        Console.WriteLine("\b\b\b*********Finished" +
                            $"{ (success ? "Successfully." : ".")}*******\n\n");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        Console.WriteLine($"Loading {Path.GetFileName(item)} does not compeleted Successfully\n\n");
                    }
                    finally
                    {
                        excel.Close();
                    }

                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                excel?.Close();
            }

        }

    }
}
