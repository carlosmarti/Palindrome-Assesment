using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

/*
A paragraph is a grouping of one or more sentences.

<summary>
This class will hold the paragraph data. Break the paragraph into sentences and store the data into a list. 
This class holds an inner class that will represent the sentences.
</summary>
*/
class Paragraph
{
    /*
    A sentence is a set of words that is complete in itself.

    <summary>
    The Sentence class will search through each if it's a palindrome. Once palindromes are found keeps track of how many there are.
    </summary>
    */
    class Sentence
    {
        private int numOfPalinWords;
        private string sentence;

        private bool palindrome;

        public int NumOfPalinWords { get{return numOfPalinWords;} set{ numOfPalinWords = value;} }
        public string SentenceGetSet {get{return sentence;} set{sentence = value;}} 

        public bool Palindrome {get{return palindrome;} set{palindrome = value;}}

        public Sentence(string sentence)
        {
            SentenceGetSet = sentence;
            palindrome = false;

            FindPalindromes();
        }

        /*
            <summary>
                This method will check each word in the sentence for palindrome words.
            </summary>
        */
        public void FindPalindromes()
        {
            string[] words = SentenceGetSet.Split();
            string[] reversedWords = new string[words.Length];

            //find the words that are palindrome
            for(int i = 0; i < words.Length; i++)
            {
                //quick fix for a pesky problem where a space is considered a word
                if(String.IsNullOrWhiteSpace(words[i]))
                    continue;
                

                //remove the problem if the first word in the sentence is capitalized
                string word = words[i].ToLower();
                reversedWords[(reversedWords.Length - 1) - i] = Reverse(word);

                if(word.Equals(reversedWords[(reversedWords.Length - 1) - i]))
                {
                    NumOfPalinWords += 1;
                }
            }

            //form a sentence from the reversed words
            string reversedSentence = string.Join("", reversedWords);

            //check if the sentence is a palindrome
            string trimed = Regex.Replace(SentenceGetSet, @"\s+", "");
            Console.WriteLine(trimed);
            if(trimed.ToLower().Equals(reversedSentence))
                Palindrome = true;

        }

        /*
            <summary>
                This method takes in a word to which it will break into characters. Each character will be stored into a stack since a stack is a LIFO data structure.
                Once all of the elements of the stack is poped the word will be reversed.
            </summary>
            <return>
                a new string with the reversed word.
            </return>
        */
        private string Reverse(string word)
        {
            char[] wordCharArr = word.ToCharArray();
            Stack<char> arrOfChar = new Stack<char>();

            //push each letter into the stack
            foreach(char letter in wordCharArr)
            {
                arrOfChar.Push(letter);
            }

            //pop stack into char array  
            for(int i = 0; i < wordCharArr.Length; i++)
            {
                wordCharArr[i] = arrOfChar.Pop();
            }

            //create a new string with the reversed word
            return new string(wordCharArr);
        }
    }

    private List<Sentence> sentences;
    private string paragraph;

    public Paragraph(string paragraph)
    {
        this.paragraph = paragraph;
        sentences = new List<Sentence>();

        PullSentences();
    }

    /*
        <summary>
            This method pulls out all of the sentences by using the Split method in the string object. After which each sentence string is passed to the Sentence object. 
        </summary>
    */
    public void PullSentences()
    {
        string[] paraSentences = paragraph.Split(".");

        foreach(string se in paraSentences)
        {
            //remove extra empty sentence caused by Split
            if(String.IsNullOrWhiteSpace(se))
                continue;
            
            sentences.Add(new Sentence(se));
        }
    }

    /*
        <summary>
            This method goes through each sentence class and stores amount of palindrome words in each sentence.
        </summary>

        <return>
            the accumulated amount of words that are palindrome.
        </return>
    */
    public int GetNumOfPalinWords()
    {
        var amount = 0;

        foreach(var sent in sentences)
        {
            amount += sent.NumOfPalinWords;
        }

        return amount;
    }

    public int GetNumOfPalinSentences()
    {
        var amount = 0;

        foreach(var sent in sentences)
        {
            if(sent.Palindrome)
                amount++;
        }

        return amount;
    }

    public string GetParagraph()
    {
        return paragraph;
    }
}