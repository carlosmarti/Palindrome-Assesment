using System;
using System.Collections.Generic;

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
        private int numOfPalin;
        private string sentence;

        public int NumOfPalin { get{return numOfPalin;} }
        public string SentenceGetSet {get{return sentence;} set{sentence = value;}} 

        Sentence(string sentence)
        {
            SentenceGetSet = sentence;
        }

        public void FindPalindromes()
        {

        }

        private string reverse(string word)
        {
            return null;
        }
    }

    private List<Sentence> sentences;
    private string paragraph;

    Paragraph(string paragraph)
    {
        this.paragraph = paragraph;
    }

    public string GetParagraph()
    {
        return paragraph;
    }
}