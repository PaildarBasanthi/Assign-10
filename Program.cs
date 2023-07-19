using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Choose an operation:");
                Console.WriteLine("1. Create a new file");
                Console.WriteLine("2. Read a file");
                Console.WriteLine("3. Append to a file");
                Console.WriteLine("4. Delete a file");
                Console.WriteLine("5. Exit");

                Console.Write("Enter your choice (1/2/3/4/5): ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter the filename: ");
                        string createFileName = Console.ReadLine();
                        Console.Write("Enter the content: ");
                        string createFileContent = Console.ReadLine();
                        CreateFile(createFileName, createFileContent);
                        break;

                    case "2":
                        Console.Write("Enter the filename to read: ");
                        string readFileName = Console.ReadLine();
                        ReadFile(readFileName);
                        break;

                    case "3":
                        Console.Write("Enter the filename to append: ");
                        string appendFileName = Console.ReadLine();
                        Console.Write("Enter the content to append: ");
                        string appendFileContent = Console.ReadLine();
                        AppendToFile(appendFileName, appendFileContent);
                        break;

                    case "4":
                        Console.Write("Enter the filename to delete: ");
                        string deleteFileName = Console.ReadLine();
                        DeleteFile(deleteFileName);
                        break;

                    case "5":
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                Console.WriteLine();
            }
        }

        static void CreateFile(string fileName, string content)
        {
            try
            {
                using (StreamWriter sw = File.CreateText(fileName))
                {
                    sw.Write(content);
                    Console.WriteLine($"File '{fileName}' created successfully.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating the file: {ex.Message}");
            }
        }

        static void ReadFile(string fileName)
        {
            try
            {
                string content = File.ReadAllText(fileName);
                Console.WriteLine($"Content of '{fileName}':\n{content}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading the file: {ex.Message}");
            }
        }

        static void AppendToFile(string fileName, string content)
        {
            try
            {
                using (StreamWriter sw = File.AppendText(fileName))
                {
                    sw.Write(content);
                    Console.WriteLine($"Content appended to '{fileName}' successfully.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error appending to the file: {ex.Message}");
            }
        }

        static void DeleteFile(string fileName)
        {
            try
            {
                File.Delete(fileName);
                Console.WriteLine($"File '{fileName}' deleted successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting the file: {ex.Message}");
            }
        }
    }
}
