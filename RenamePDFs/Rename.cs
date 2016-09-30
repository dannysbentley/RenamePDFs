using System;
using System.Text.RegularExpressions;

namespace RenamePDFs
{
    class Rename
    {
        private string fileName;
        private string newFileName;

        public void setFileName(string filename)
        {
            fileName = filename;
        }

        public string getFileName()
        {
            return newFileName;
        }

        ///*****************************renamefile()*****************************
        /// summary:
        ///    Rename file using regex  
        /// parameter:  
        ///    regex = regular expression.  
        public void renamefile(string regex, string replace)
        {
            try
            {
                string input;
                var pattRegex = regex;
                var fileNameRegex = Regex.Match(fileName, pattRegex, RegexOptions.None);
                input = fileNameRegex.ToString();

                //Seattle format. 
                if (replace != "-")
                {
                    string renamedCorrect = ReplaceAt(input, replace);
                    newFileName = renamedCorrect;
                }
                else
                {
                    newFileName = input;
                }

            }
            catch { }
        }

        ///*****************************IsPDFHeader()*****************************
        /// summary:
        ///    Check to see if file is a PDF. 
        /// parameter:  
        ///    FileName = file name to check in diretory. 
        /// Returns: 
        ///    True if it ends with .pdf
        public bool IsPDFHeader(string fileName)
        {
            var pattRegex = @"\.(pdf)$";
            var fileNameRegex = Regex.Match(fileName, pattRegex, RegexOptions.None);
            if (fileNameRegex.ToString() == ".pdf")
            {
                return true;
            }
            return false;
        }

        ///*****************************IsPDFHeader()*****************************
        /// summary:
        ///    Check to see if file is a DWG. 
        /// parameter:  
        ///    FileName = file name to check in diretory. 
        /// Returns: 
        ///    True if it ends with .pdf
        public bool IsDWGHeader(string fileName)
        {
            var pattRegex = @"\.(dwg)$";
            var fileNameRegex = Regex.Match(fileName, pattRegex, RegexOptions.None);
            if (fileNameRegex.ToString() == ".dwg")
            {
                return true;
            }
            return false;
        }

        ///*****************************ReplaceAt()*****************************
        /// summary:
        ///    replace dash to any char.  
        /// parameter:  
        ///    input = string of file name 
        ///    replace = char to replace dash
        /// Returns: 
        ///    new string of file name. 
        public static string ReplaceAt(string input, string replace)
        {
            if (input == null)
            {
                throw new ArgumentNullException("input");
            }
            
            char period = Convert.ToChar(replace);
            char[] chars = input.ToCharArray();
            for (int i = 0; i < input.Length; i++)
            {
                if (!char.IsWhiteSpace(chars[i]))
                {
                    if (chars[i] == '-')
                    {
                        chars[i] = period;
                    }
                }
                else
                {
                    break;
                }
            }
            return new string(chars);
        }
    }
}
