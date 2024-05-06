using EntityFrameworkTask2.Database;
using EntityFrameworkTask2.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkTask2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the directory path:");
            string directoryPath = Console.ReadLine();

            // Check if directory exists
            if (!Directory.Exists(directoryPath))
            {
                Console.WriteLine("Directory not found.");
                return;
            }
            Console.WriteLine("Chose the task number 1 ,2,3");
            switch (int.Parse(Console.ReadLine()))
            {
                case 1:
                    using (var dbContext = new FileDbContext())
                    {

                        Task1(directoryPath, dbContext);
                    }
                    break;
                case 2:
                    using (var dbContext = new FileDbContext())
                    {
                        var root = new Folder { Name = directoryPath };
                        dbContext.Folders.Add(root);
                        dbContext.SaveChanges();
                        Task2(directoryPath, root.Id, dbContext);
                    }
                    Console.WriteLine("Done saving");
                    break;
                case 3:
                    using (var dbContext = new FileDbContext())
                    {
                        var rootFolder = new Folder { Name = directoryPath };
                        dbContext.Folders.Add(rootFolder);
                        dbContext.SaveChanges();
                        Task4(directoryPath, rootFolder.Id, dbContext);
                        //Task3(directoryPath, dbContext);
                        //dbContext.SaveChanges();

                        //Console.Write("Enter the names of files to tag (comma-separated): ");
                        //string[] fileNames = Console.ReadLine().Split(',');
                        //Console.Write("Enter the tags for the files (comma-separated): ");
                        //string[] tagNames = Console.ReadLine().Split(',');

                        //TagFiles(dbContext, fileNames, tagNames);
                        Console.WriteLine("Done saving");
                    }
                    break;
                default:
                    break;
            }



        }

        static void Task1(string directoryPath, FileDbContext dbContext)
        {

            foreach (var item in Directory.GetFiles(directoryPath))
            {
                FileInfo fileInfo = new FileInfo(item);
                FileInfomation fileInfomation = new FileInfomation
                {
                    Name = fileInfo.Name,
                    Size = fileInfo.Length,
                    FullPath = fileInfo.FullName
                };

                dbContext.Add(fileInfomation);
            }
            dbContext.SaveChanges();

        }
        static void Task2(string directoryPath, int parentId, FileDbContext dbContext)
        {

            foreach (string itemPath in Directory.GetFileSystemEntries(directoryPath))
            {
                if (File.Exists(itemPath))
                {
                    FileInfo fileInfo = new FileInfo(itemPath);

                    var fileInformation = new FileInfomation
                    {
                        Name = fileInfo.Name,
                        Size = fileInfo.Length,
                        FullPath = fileInfo.FullName,
                        FolderId = parentId
                    };

                    // dbContext.FileInfomations.Add(fileInformation);
                }

                else if (Directory.Exists(itemPath))
                {
                    DirectoryInfo dirInfo = new DirectoryInfo(itemPath);

                    var folder = new Folder
                    {
                        Name = dirInfo.Name
                    };

                    dbContext.Folders.Add(folder);
                    dbContext.SaveChanges();

                    Task2(itemPath, folder.Id, dbContext);
                }

            }
        }

        //  static void Task3(string directoryPath, int parentId, FileDbContext dbContext)
        // {

        //foreach (string itemPath in Directory.GetFileSystemEntries(directoryPath))
        //{
        //    if (File.Exists(itemPath))
        //    {
        //        FileInfo fileInfo = new FileInfo(itemPath);

        //        var fileInformation = new FileInfomation
        //        {
        //            Name = fileInfo.Name,
        //            Size = fileInfo.Length,
        //            FullPath = fileInfo.FullName,
        //            FolderId = parentId
        //        };

        //        dbContext.FileInfomations.Add(fileInformation);
        //        dbContext.SaveChanges();

        //        AddTags(fileInformation, dbContext);
        //        dbContext.SaveChanges();

        //    }
        //    else if (Directory.Exists(itemPath))
        //    {
        //        DirectoryInfo dirInfo = new DirectoryInfo(itemPath);

        //        var folder = new Folder
        //        {
        //            Name = dirInfo.Name
        //        };

        //        dbContext.Folders.Add(folder);
        //        dbContext.SaveChanges();

        //        Task3(itemPath, folder.Id, dbContext);
        //    }

        //}
        static void Task3(string directoryPath, FileDbContext db, Folder parentFolder = null)
        {

            if (parentFolder == null)
                parentFolder = new Folder { Name = Path.GetFileName(directoryPath) };



            foreach (string subDirectoryPath in Directory.GetDirectories(directoryPath))
            {
                var folder = new Folder { Name = Path.GetFileName(subDirectoryPath) };
                //parentFolder.FileInfomations = parentFolder.FileInfomations ?? new List<FileInfomation>();
                //parentFolder.FileInfomations.Add((FileInfomation)folder.FileInfomations);

                //db.Folders.Add(folder);
                List<FileInfomation> fileInfomations = new List<FileInfomation>();
                foreach (string filePath in Directory.GetFiles(subDirectoryPath))
                {
                    var fileInformation = new FileInfomation
                    {
                        Name = Path.GetFileName(filePath),
                        Size = new FileInfo(filePath).Length,
                        FullPath = filePath,
                        Folder = parentFolder
                    };
                    fileInfomations.Add(fileInformation);
                    //db.FileInfomations.AddRange(fileInformation);
                    //Task3(subDirectoryPath, db, folder);

                }
                parentFolder = new Folder { Name = Path.GetFileName(subDirectoryPath) };
                db.Folders.Add(parentFolder);
                db.FileInfomations.AddRange(fileInfomations);
                db.SaveChanges();
            }




        }

        static void Task4(string directoryPath, int parentId, FileDbContext dbContext)
        {

            foreach (string itemPath in Directory.GetFileSystemEntries(directoryPath))
            {
                if (File.Exists(itemPath))
                {
                    FileInfo fileInfo = new FileInfo(itemPath);

                    var fileInformation = new FileInfomation
                    {
                        Name = fileInfo.Name,
                        Size = fileInfo.Length,
                        FullPath = fileInfo.FullName,
                        FolderId = parentId
                    };

                    dbContext.FileInfomations.AddRange(fileInformation);
                    dbContext.SaveChanges();

                    Tag tag = AddTags(dbContext, fileInformation);
                    //dbContext.FileInfomations.Add;
                    dbContext.SaveChanges();

                }
                else if (Directory.Exists(itemPath))
                {
                    DirectoryInfo dirInfo = new DirectoryInfo(itemPath);

                    var folder = new Folder
                    {
                        Name = dirInfo.Name
                    };

                    dbContext.Folders.Add(folder);
                    dbContext.SaveChanges();

                    Task4(itemPath, folder.Id, dbContext);
                }

            }

            static Tag AddTags(FileDbContext dbContext, FileInfomation file)
            {
                string fileExtension = System.IO.Path.GetExtension(file.FullPath);
                string tag;
                Tag tag1 = new Tag(); ;
                switch (fileExtension.ToLower())
                {
                    case ".png":
                        tag = "Image";
                        break;
                    case ".txt":
                        tag = "Text";
                        break;
                    case ".pdf":
                        tag = "PDF";
                        break;
                    case ".cs":
                        tag = "C# Class";
                        break;
                    default:
                        tag = "Unknown";
                        break;
                }
                tag1.Name = tag;
                return tag1;
                //dbContext.Tags.Add(tag1);
                //dbContext.SaveChanges();
            }

            //static void TagFiles(FileDbContext db, string[] fileNames, string[] tagNames)
            //{
            //    foreach (string fileName in fileNames)
            //    {
            //        var file = db.FileInfomations.FirstOrDefault(f => f.Name == fileName);
            //        if (file != null)
            //        {
            //            foreach (string tagName in tagNames)
            //            {
            //                var tag = db.Tags.FirstOrDefault(t => t.Name == tagName);
            //                if (tag == null)
            //                {
            //                    tag = new Tag { Name = tagName };
            //                    db.Tags.Add(tag);
            //                }

            //                //file.Tags = file.Tags ?? new List<Tag>();
            //                //file.Tags.Add(new Tag { Tag = tag });
            //            }
            //        }
            //    }

            //    db.SaveChanges();
            //}
        }
    }
}