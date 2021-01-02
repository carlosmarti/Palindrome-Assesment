using System;
using System.IO;

namespace Pelindrome
{
    class Program
    {
        static void Main(string[] args)
        {
            //Provide directory of where the txt file is located
            var path = @"C:\Users\carlos\Documents\C-Sharp\Palindrome-Assesment\paragraph.txt";

            //check if file is in directory 
            if(!File.Exists(path))
            {
                throw new FileNotFoundException("File was not found in the directory given. Please provide correct directory.");
            }

            //Now that file has been confirmed to exist whe can pass in the contents into the paragraph class
            Paragraph paragraph = new Paragraph(File.ReadAllText(path));

            Console.WriteLine("Total amount of palindrome words: {0}", paragraph.GetNumOfPalinWords());
            Console.WriteLine("Total amount of palindrome sentences: {0}", paragraph.GetNumOfPalinSentences());
        }
    }
}
