using System;

public class TextAnalyzer {
    // variables
    private string text;
    public Dictionary<string, int> uniqueWordDictionary = new Dictionary<string, int>(); 

    // properties
    public string Text { get; set; } // end property

    // constructor Method accepts 1 argument(string text)
    public TextAnalyzer(string text) {
        this.text = text;
        this.Text = text;
    } // end constructor
   
    //////////////////////////////////////////////////////////
    //                  <PUBLIC METHODS>                    //
    //////////////////////////////////////////////////////////
    // method to return word count
    public int GetWordCount() {
        // call the method to remove punctuation
        RemovePunctuation();

        // create an array of words from the text using an
        // empty space for the split method
        List<string> words = RemoveNonWords();
       
        return words.Count();        
    } // end method

    // method to return sentence count
    public int GetSentenceCount() {     
        // initialize accumulator to 0
        int count = 0;

        // add each character from the text to the array of chars
        char[] chars = text.ToLower().ToArray(); 

        // check each char against common sentence punctuation
        // increase accumulator for each common punctuation
        foreach (char item in chars){
            if (item == char.Parse(".") || item == char.Parse("!") || item == char.Parse("?")) { count += 1; }
        } // end if 
        // return the sentence count
        return count;
    } // end method

    // method to return number of unique words
    public int GetUniqueWordCount() {
        // remove the punctuation
        RemovePunctuation();

        // create an array of words from the text using an
        // empty space for the split method
        List<string> words = RemoveNonWords();


        // get the unique word using the Distinct method
        var uniqueWords = words.Distinct();

        // return the number of unique words
        return uniqueWords.Count();
    } // end method
    

    public Dictionary<string, int> GetUniqueWords() {
        // remove the punctuation
        RemovePunctuation();

        // create an array of words from the text using an
        // empty space for the split method
        List<string> words = RemoveNonWords();


        // get the unique word using the Distinct method
        var uniqueWords = words.Distinct();

        // add the unique words to the dictionary starting value 0
        foreach (string word in uniqueWords) {
            
            uniqueWordDictionary.Add(word, 0);
        } // end foreach


        // for loop to check each word ion the dictionary and see
        // how many times they appear in the words array
        for (int i = 0; i <= words.Count -1; i++) { 
            // if the dictionary containes the word
            // increase the key's value by one
            if (uniqueWordDictionary.ContainsKey(words[i])) {
                uniqueWordDictionary[words[i]]++;            
            } // end if
        } // end for

        // return the dictionary
        return uniqueWordDictionary;
    } // end method


    ////////////////////////////////////////////////////////////
    ///                <END PUBLIC METHODS>                 ///    
    ///////////////////////////////////////////////////////////

    ////////////////////////////////////////////////////////////
    ///                <PRIVATE METHODS>                 ///    
    ///////////////////////////////////////////////////////////

    // method to remove the punctuation from the text
    private void RemovePunctuation() {

        // remove the punctuation from the text.
        // the empty strings will be replaced with a method
        text = text.Replace(".", " ");
        text = text.Replace("!", " ");
        text = text.Replace("?", " ");
        text = text.Replace(",", " ");
        text = text.Replace(";", " ");
        text = text.Replace("\r\n", " ");
        text = text.Replace("\\r", " ");


    } // end method

    private List<string> RemoveNonWords() {

        // create an array of words from the text using an
        // empty space for the split method
        string[] words = text.ToLower().Split(" ");

        // initialize a new list
        List<string> words2 = new List<string>();

        // if the word is not a empty string, add to the list
        foreach (string word in words) {
            if (word != "") {
                words2.Add(word);
            } // end if 
        } // end foreach

        // return the list of words
        return words2;
    } // end method

    ////////////////////////////////////////////////////////////
    ///                <END PRIVATE METHODS>                 ///    
    ///////////////////////////////////////////////////////////
    
} //end class
