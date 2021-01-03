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
        private List<string> words;
        private bool palindrome;

        public int NumOfPalinWords { get{return numOfPalinWords;} set{ numOfPalinWords = value;} }
        public string SentenceGetSet {get{return sentence;} set{sentence = value;}}
        public bool Palindrome {get{return palindrome;} set{palindrome = value;}}
        public List<string> Words {get{return words;}}

        public Sentence(string sentence)
        {
            SentenceGetSet = sentence;
            palindrome = false;

            FindPalindromes();
        }

        /*
            <summary>
                This method will check each word in the sentence for palindrome words. As well as check if the sentence itself is a palindrome
            </summary>
        */
        public void FindPalindromes()
        {
            words = new List<string>(SentenceGetSet.Split());
            string[] reversedWords = new string[Words.Count];

            int count = 0;
            Words.ForEach(delegate (string word){

                 //quick fix for a pesky problem where a space is considered a word
                if(!String.IsNullOrWhiteSpace(word))
                {
                    //remove the problem if the first word in the sentence is capitalized
                    string lowerWord = word.ToLower();
                    reversedWords[(reversedWords.Length - 1) - count] = Reverse(lowerWord);

                    if(word.Equals(reversedWords[(reversedWords.Length - 1) - count]))
                    {
                        NumOfPalinWords += 1;
                    }
                }
                
                //increase count in order to go backwards through the array
                count++;
            });

            //form a sentence from the reversed words
            string reversedSentence = string.Join("", reversedWords);

            //check if the sentence is a palindrome
            string trimed = Regex.Replace(SentenceGetSet, @"\s+", "");
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
    public void ShowNumOfPalinWords()
    {
        var amount = 0;

        foreach(var sent in sentences)
        {
            amount += sent.NumOfPalinWords;
        }

        Console.WriteLine("Total amount of palindrome words: {0}", amount);
    }

    public void ShowNumOfPalinSentences()
    {
        var amount = 0;

        foreach(var sent in sentences)
        {
            if(sent.Palindrome)
                amount++;
        }

        Console.WriteLine("Total amount of palindrome sentences: {0}", amount);
    }

    public void ShowUniqueWords()
    {
        List<string> uniqueWords = new List<string>();
        string[] allWords;
        int amountOfWords = 0;

        foreach(var sentence in sentences)
        {
            amountOfWords += sentence.Words.Count;
        }

        allWords = new string[amountOfWords];

        int index = 0;
        foreach(var sentence in sentences)
        {
            sentence.Words.ForEach(delegate(string word)
            {
                allWords[index] = word;
                index++;
            });
        }

        for(int i = 0; i < allWords.Length; i++)
        {
            string word = allWords[i];
            bool found = false;

            for(int j = 0; j < allWords.Length; j++)
            {
                if(i == j)
                    continue;
                
                if(allWords[j].Equals(allWords[i]))
                {
                    found = true;
                    break;
                }
            }

            if(!found)
                uniqueWords.Add(allWords[i]);
        }

        //Output the result of unique words and how much there are
        Console.WriteLine("Unique words:");
        uniqueWords.ForEach(delegate(string word){

            Console.WriteLine(word);
        });
        Console.WriteLine("Number of unique words: {0}",uniqueWords.Count);
    }

    public void ShowWordsWithLetter(char letter)
    {
        List<string> matchingWords = new List<string>();

        foreach(var sentence in sentences)
        {
            sentence.Words.ForEach(delegate(string word){

                if(word.Contains(letter))
                    matchingWords.Add(word);
            });
        }

        Console.WriteLine("Words that contain the letter " + letter + ": ");
        if(matchingWords.Count == 0)
        {
            Console.WriteLine("None");
        }
        else
        {
            matchingWords.ForEach(delegate(string word){

            Console.WriteLine(word + " ");
            });
        }
        
    }

    public string GetParagraph()
    {
        return paragraph;
    }
}