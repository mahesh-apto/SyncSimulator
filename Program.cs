using SyncSimulator.Services;
using SyncSimulator.Utils;
using System;
using System.Threading.Tasks;

namespace SyncSimulator
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Logger.Log("Starting the File Uploader...");

            Console.Write("Enter the file path to upload: ");
            var filePath = Console.ReadLine();

            Console.Write("Enter the server URL: ");
            var serverUrl = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(filePath) || string.IsNullOrWhiteSpace(serverUrl))
            {
                Logger.Log("Invalid file path or server URL. Please try again.", LogLevel.Error);
                return;
            }

            var uploader = new FileUploaderService(serverUrl);

            try
            {
                Logger.Log($"Uploading file: {filePath} to {serverUrl}");
                await uploader.UploadFileAsync(filePath);
                Logger.Log("File upload completed successfully.");
            }
            catch (Exception ex)
            {
                Logger.Log($"Error during upload: {ex.Message}", LogLevel.Error);
            }
        }
    }
}
