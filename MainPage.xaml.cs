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
            // Display the chosen name in the label
            string chosenName = myPicker.SelectedItem?.ToString();
            if (!string.IsNullOrWhiteSpace(chosenName))
            {
                labelDisplayChosenNameHere.Text = "You have chosen the name: " + chosenName;
            }
        }

    }
}