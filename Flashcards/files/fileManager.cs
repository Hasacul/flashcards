using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Flashcards.files
{
    public class fileManager
    {
        protected string fileName;
        protected string[] fileContent;                                         //variable for saving into file
        List<string> fileContents = new List<string>();                         //list of pairs
        public string folderLocation = "profiles/";                             //main folder

        public void saveTextFile(string fileName,string profile)
        {
            if (profile!=null &&(profile.Length > 0 && fileName.Length>0))
            {
                if (!doesFileExist(fileName+".txt", profile))
                {
                    string filePath = this.folderLocation + profile + "/" + fileName + ".txt";
                    FileInfo file = new FileInfo(filePath);
                    file.Directory.Create();
                    file.Create();
                }
                else
                {
                    MessageBox.Show("File already exists. Use another name.");
                }
            }
            else
            {
                MessageBox.Show("Invalid profile name or file name.");
            }
        }

        public void saveWordPairsFromList(string fileName, string profile, listManager LM)
        {
            if (profile != null && (profile.Length > 0 && fileName.Length > 0))
            {
                if (doesFileExist(fileName, profile))
                {
                    string filePath = this.folderLocation + profile + "/" + fileName;
                    foreach (pairWords PW in LM.getList())
                    {
                        this.addToContent(PW.getPairTogetherString());
                    }
                    File.WriteAllLines(@filePath, this.fileContents.ToArray());
                }
                else
                {
                    MessageBox.Show("File doesn't exists. Try to recreate file list.");
                }
            }
            else
            {
                MessageBox.Show("Invalid profile name or file name.");
            }
        }

        public List<pairWords> getWordPairsFromFile(string fileName, string profile)
        {
            if (profile != null && (profile.Length > 0 && fileName.Length > 0))
            {
                if (doesFileExist(fileName, profile))
                {
                    string filePath = this.folderLocation + profile + "/" + fileName;
                    List<pairWords> returnedList= new List<pairWords>();
                    string[] wordsTable;
                    FileInfo file = new FileInfo(filePath);
                    this.fileContents.Clear();
                    try
                    {
                        var lines = File.ReadAllLines(filePath);
                        foreach (var line in lines)
                        {
                            wordsTable=line.Split('@');
                            if (wordsTable.Length == 2)
                            {
                                returnedList.Add(new pairWords(wordsTable[0],wordsTable[1]));
                            }
                        }
                    }
                    catch(Exception e)
                    {
                        MessageBox.Show("File is used right now. "+ e.ToString());
                    }
                    return returnedList;
                }
                else
                {
                    MessageBox.Show("File doesn't exists. Check if file is not corrupted.");
                    return null;
                }
            }
            else
            {
                MessageBox.Show("Invalid profile name or file name.");
                return null;
            }
        }

        public void addToContent(string stringToAdd)
        {
           fileContents.Add(stringToAdd);
        }

        public void createNewProfile(string profileName)
        {
            if (!this.doesProfileExists(profileName, this.getProfiles()))
            {
                DirectoryInfo DirInfo = new DirectoryInfo(this.folderLocation);
                DirInfo.CreateSubdirectory(profileName);
            }
        }

        public List<String> getProfiles()
        {
            Directory.CreateDirectory(folderLocation);                                                          //creates profiles if not exists
            string[] directories = Directory.GetDirectories(folderLocation);
            return directories.ToList();
        }

        public List<String> getFiles(string profile)
        {
            List<string> fil = new List<string>();
            string[] files = Directory.GetFiles(this.folderLocation + profile);
            for(int i = 0; i < files.Length; i++)
            {
                fil.Add(Path.GetFileName(files[i]));
            }
            return fil;
        }

        public bool doesProfileExists(string profileName,List<string> profiles)
        {
            return profiles.Contains(this.folderLocation + profileName);
        }

        public bool doesFileExist(string fileName, string profile)
        {
            List<string> fileList = getFiles(profile);
            return fileList.Contains(fileName);
        }

        public List<string> readFromFile(string fileName, string profile)
        {
            string filePath = this.folderLocation + profile+"/"+fileName;
            FileInfo file = new FileInfo(filePath);
            this.fileContents.Clear();
            try
            {
                var lines = File.ReadAllLines(filePath);
                foreach (var line in lines)
                {
                    this.fileContents.Add(line);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("File is used right now. "+e.ToString());
            }
            return this.fileContents;
        }

        public void deleteFile(string profile, string fileName)
        {
            if (profile != null && !fileName.Contains("*")&&(profile.Length > 0 && fileName.Length > 0))
            {
                if(File.Exists(this.folderLocation + profile + "/" + fileName))
                {
                    MessageBoxResult result= MessageBox.Show("Confirm: Deleting file " + fileName + " from profile " + profile+"?","Delete File",MessageBoxButton.YesNo);
                    if (result == MessageBoxResult.Yes)
                    {
                        File.Delete(this.folderLocation + profile + "/" + fileName);
                    }
                } 
            }
            else
            {
                MessageBox.Show("Invalid profile name or file name.");
            }
        }
    }
}
