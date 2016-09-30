using System;
using System.Collections.Generic;
using System.IO;

namespace RenamePDFs
{
    //  Author:   Danny Bentley
    //  Date  :   9/30/16
    //  Objective : Rename PDFs and DWGs using Regular Expressions. 
    public class StartRenamer
    {
        public List<String> GetDirectory(string sourcePath, string targetPath, string regex, string replace = "-")
        {
            List<String> returnList = new List<string>();
            //Gets files from directory 
            if (Directory.Exists(sourcePath))
            {
                string[] files = Directory.GetFiles(sourcePath);

                foreach (string s in files)
                {
                    string fileName;
                    string destfile;

                    fileName = Path.GetFileName(s);

                    //renames the file using regular expressions 
                    Rename renameFile = new Rename();
                    //bool checks to make sure file is a PDF. 
                    bool PDFresult = renameFile.IsPDFHeader(fileName);
                    //bool check to make sure file is a DWG.
                    bool DWGresult = renameFile.IsDWGHeader(fileName);

                    if (PDFresult == true)
                    {
                        renameFile.setFileName(fileName);

                        renameFile.renamefile(regex, replace);
                        string fileRename = renameFile.getFileName();
                        string newName;
                        //sets the new name to the old name
                        
                        if (renameFile.IsPDFHeader(fileRename) == false)
                        {
                            newName = fileRename + ".pdf";
                            //combines the new name to the directory 
                            destfile = Path.Combine(targetPath, newName);

                            //copies the files and will override the file if it already exists. 
                            File.Copy(s, destfile, true);
                            returnList.Add(newName);
                        }
                        else
                        {
                            newName = fileRename;
                            //combines the new name to the directory 
                            destfile = Path.Combine(targetPath, newName);

                            //copies the files and will override the file if it already exists. 
                            File.Copy(s, destfile, true);
                            returnList.Add(newName);
                        }
                    }

                    if (DWGresult == true)
                    {
                        renameFile.setFileName(fileName);

                        renameFile.renamefile(regex, replace);
                        string fileRename = renameFile.getFileName();
                        string newName;
                        //sets the new name to the old name

                        if (renameFile.IsPDFHeader(fileRename) == false)
                        {
                            newName = fileRename + ".dwg";
                            //combines the new name to the directory 
                            destfile = Path.Combine(targetPath, newName);

                            //copies the files and will override the file if it already exists. 
                            File.Copy(s, destfile, true);
                            returnList.Add(newName);
                        }
                        else
                        {
                            newName = fileRename;
                            //combines the new name to the directory 
                            destfile = Path.Combine(targetPath, newName);

                            //copies the files and will override the file if it already exists. 
                            File.Copy(s, destfile, true);
                            returnList.Add(newName);
                        }
                    }
                }
            }
            return returnList;
        }
    }
}
