namespace GA_Picker_Access
{
    public partial class MainPage : ContentPage
    {

        private List<string> namesList = new List<string>
        {
            "Name1",
            "Name2",
            "Name3",
            "Name4",
            "Name5"
        };

        public MainPage()
        {
            InitializeComponent();

            // Bind the namesList to the Picker's ItemsSource
            myPicker.ItemsSource = namesList;
        }

        private void OnButtonAddNameClicked(object sender, EventArgs e)
        {
            // Add the name from the editor to the list
            string newName = editorAddName.Text;
            if (!string.IsNullOrWhiteSpace(newName))
            {
                namesList.Add(newName);

                // Refresh the Picker
                myPicker.ItemsSource = null;
                myPicker.ItemsSource = namesList;
            }
        }

        private void OnPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the index of the selected item in the Picker
            int selectedIndex = myPicker.SelectedIndex;

            // Retrieve the name from the namesList based on the selected index
            string chosenName = namesList[selectedIndex];

            // Check if the chosenName is not empty or non-existent
            if (!string.IsNullOrWhiteSpace(chosenName))
            {
                // Update the label to display the chosen name
                labelDisplayChosenNameHere.Text = "You have chosen the name: " + chosenName;
            }
        }

    }
}