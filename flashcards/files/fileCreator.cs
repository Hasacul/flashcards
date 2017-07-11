using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flashcards.files
{
    class fileCreator
    {
        protected string fileName;
        protected string[] fileContent;                                         
        List<string> fileContents = new List<string>();                         //list of pairs
        public string folderLocation = "profiles/";

        public void saveFile(string fileName)
        {
            string filePath = this.folderLocation + fileName+".txt";
            FileInfo file = new FileInfo(filePath);
            file.Directory.Create();
            File.WriteAllLines(@filePath, this.fileContents.ToArray());
            //System.IO.File.WriteAllLines(@"C:\Users\Public\TestFolder\WriteLines.txt", lines);
        }

        public void addToContent(string stringToAdd)
        {
           fileContents.Add(stringToAdd);
        }

        public string getContents()
        {
            return string.Join("\n",fileContents.ToArray());
        }

        public void createNewProfile(string profileName)
        {
            DirectoryInfo DirInfo = new DirectoryInfo(this.folderLocation);
            DirInfo.CreateSubdirectory(profileName);
        }

        public string readFromFile(string fileName)
        {
            string filePath = this.folderLocation + fileName+".txt";
            FileInfo file = new FileInfo(filePath);
            this.fileContents.Clear();
            var lines = File.ReadAllLines(filePath);
            foreach(var line in lines)
            {
                this.fileContents.Add(line);
            }
            return this.getContents();
        }
    }
}
