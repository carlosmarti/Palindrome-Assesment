using System;
using System.IO;
using System.Collections.Generic;

namespace Pelindrome
{
    class Program
    {
        static void Main(string[] args)
        {
            bool goodChar = false;
            char letter = 'y';

            //Provide directory of where the txt file is located
            var path = @"your-directory\Palindrome-Assesment\paragraph.txt";

            //check if file is in directory 
            if(!File.Exists(path))
            {
                throw new FileNotFoundException("File was not found in the directory given. Please provide correct directory.");
            }

            //ask user for letter they want found inside a word. Continue to ask them for a valid letter they don't give a valid letter.
            Console.WriteLine("Please input a letter a-z in order to find a list of words that have your letter:");
            while(!goodChar)
            {
                letter = Char.Parse(Console.ReadLine());
                
                //check ascii values of char to make sure letter given is infact a letter
                if((int)letter >= 97 && (int)letter <= 122)
                {
                    goodChar = true;
                }
                else
                {
                    Console.WriteLine("That was an incorrect input!");
                    Console.WriteLine("Please input a letter a-z in order to find a list of words that have your letter:");
                }
            }


            //Now that file has been confirmed to exist and user has given proper letter.We can pass in the contents into the paragraph class
            Paragraph paragraph = new Paragraph(File.ReadAllText(path));

            paragraph.ShowNumOfPalinWords();
            paragraph.ShowNumOfPalinSentences();
            paragraph.ShowUniqueWords();
            paragraph.ShowWordsWithLetter(letter);
        }
    }
}
