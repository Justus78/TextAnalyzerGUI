namespace TextAnalyzerGUI { 
    public partial class frmTextAnalyzer : Form {

        public Dictionary<string, int> wordDic;
        string text;
        public frmTextAnalyzer() {
            InitializeComponent();
        } // end form initialization

        private void btnAnalyze_Click(object sender, EventArgs e) {
            // make a new object of the TextAnalyzer class
            // passing the text from the textbox as an argument

            // try catch  to check if the user trys to run the 
            // program with no text in the text box, ends the 
            // program if no text is entered.
            try {
                text = txtText.Text;
                if (txtText.Text == "") {
                    throw new Exception();
                } // end if 
            } catch (Exception) {
                MessageBox.Show("You must enter some text in the text box.");
                return;
            } // end try catch
            
            TextAnalyzer t = new TextAnalyzer(text);

            // get the sentence, word and unique word counts
            // using the methods in the TextAnalyzer class
            // be sure to use GetSentenceCount() first before 
            // the other methods remove punctuation.
            var sentences = t.GetSentenceCount();
            int wordCount = t.GetWordCount();
            int uniqueWordCount = t.GetUniqueWordCount();
            // add the unique words to a dictionary object
            wordDic = t.GetUniqueWords();

            // set the results to the label
            lblResults.Text = $"Results: \n" +
                                $"Word Count: {wordCount} \n" +
                                $"Sentences: {sentences} \n" +
                                $"Unique Word Count: {uniqueWordCount} ";

            // use a loop to add each item from the dictionary to
            // the listview
            foreach (var item in wordDic) {

                // make a new list view item adding the key first
                ListViewItem lvItem = new ListViewItem(item.Key);
                // use subitems to add the value
                lvItem.SubItems.Add(item.Value.ToString());
                // add the item to the listview
                ltvDictionary.Items.Add(lvItem);            
            } // end foreach
        } // end analyze button click method

        private void btnClear_Click(object sender, EventArgs e)  {
            // reset the board
            txtText.Clear();
            ltvDictionary.Items.Clear();
            lblResults.Text = $"Results";
        }// end clear method

        private void btnExit_Click(object sender, EventArgs e) {
            Application.Exit();
        } // end exit method

        private void txtSearch_TextChanged(object sender, EventArgs e)  {
            // call the filter text method each time
            // the users adds or removes text from 
            // the search text box
            FilterText();
        } // end method

        private void FilterText() {
            // clear the items from the listview
            ltvDictionary.Items.Clear();

            // foreach to iterate the dictionary
            foreach (var item in wordDic) { 

                // if the entered text matches in character in the dictionary item
                // creates a new listview item and adds it to the listview
                if (item.Key.ToLower().Contains(txtSearch.Text.ToLower())) { 
                    ListViewItem lvItem = new ListViewItem(item.Key);
                    lvItem.SubItems.Add(item.Value.ToString());
                    ltvDictionary.Items.Add(lvItem);                    
                } // end if 

                // if the listview item count is greater than 0 and
                // the search text box is not empty, highlight the 
                // topmost items
                if (ltvDictionary.Items.Count > 0 && txtSearch.Text != "") {
                    ltvDictionary.Items[0].Selected = true;
                } // end if
            } // end foreach
        } // end method
    } // end class
} // end namespace