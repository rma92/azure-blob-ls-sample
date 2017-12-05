using System;
using System.Collections.Generic;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System.Threading;

namespace azure_blob_testderp
{
  class Program
  {
    static string connStr = "";//"";

    static async void a()
    {
      var connectionString = connStr; //_configuration["AzureStorageAccountConnectionString"];
      var storageAccount = CloudStorageAccount.Parse(connectionString);
      var blobClient = storageAccount.CreateCloudBlobClient();
      var container = blobClient.GetContainerReference("updates-container");
      var urls = new List<string>();
      Console.WriteLine("D");
      var listBlobItems = await container.ListBlobsSegmentedAsync
        ("", true, BlobListingDetails.All, 200, null, null, null );
        Console.WriteLine("A");
      foreach( var t in listBlobItems.Results )
      {
        Console.WriteLine( ((CloudBlockBlob)t).Name );
      }
      /*
      var file = picture.File;
      var parsedContentDisposition =
          ContentDispositionHeaderValue.Parse(file.ContentDisposition);
      var filename = Path.Combine(parsedContentDisposition.FileName.Trim('"'));
      var blockBlob = container.GetBlockBlobReference(filename);
      await blockBlob.UploadFromStreamAsync(file.OpenReadStream());
      */
    }

    static void Main(string[] args)
    {
      Console.WriteLine("Hello World!");
      if( connStr.Length < 2 )
      {
        Console.Write("Insert Connection String\n>");
        connStr = Console.ReadLine();
      }
      a();
      Thread.Sleep(10000);
      Console.WriteLine("done");
    }
  }
}
