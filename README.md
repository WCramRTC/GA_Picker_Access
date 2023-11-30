# GA_Picker_Access

The picker is a control that is similar to a drop down menu. When clicked a list of different options is display. When an option is selected, the menu is then hidden again, showing only the selected option.

The syntax to place a picker is <Picker />.
The 3 common attributes are

- `x:Name` gives a name to the control for referencing in code-behind.
- `Title` is a kind of instruction that is shown to the user to explain what should be done with the picker
- `SelectedIndexChanged` is an event that triggers when the selected item changes. Kind of like saying "a new option has been chosen, do something".

In the .cs the most common properties are

- `.ItemsSource` which was can assign a list to, so we can populate it with those values
- `.SelectedIndex` which will return the index of the selected item

```xml
    <Picker x:Name="myPicker"
            Title="Select an item"
             SelectedIndexChanged="OnPickerSelectedIndexChanged">
    </Picker>
```



```csharp
    public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();

        myPicker.ItemsSource = new List<string> { "Item1", "Item2", "Item3", "Item4" };
    }

    private void OnPickerSelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        int selectedIndex = picker.SelectedIndex;

        if (selectedIndex != -1)
        {
            // Handle the selection
            Console.WriteLine($"Selected item: {picker.Items[selectedIndex]}");
        }
    }
}
```

`Designer`
1. Create a maui application
2. Add a Picker object
3. Give it an x:name of my picker
4. Give it a title of "Choose a name"
5. Add a `SelectedIndexChanged` event
6. Add a label that says "Enter a name"
7. Add an editor with a name of editorAddName
8. Add a button that says "Add a name" and has a name of buttonAddName.
9. Add a click event to the button.
10. Add a label with a name that is labelDisplayChosenNameHere

`Code`

11. Create a global list of strings with 5 names.
12. Attach the list to the pickers .ItemsSource.
13. In the button click event, when the button is clicked, add the name from the editorAddName to the list, then refresh the picker
14. In the selectedIndexChanged event, display the chosen name to the labelDisplayChosenNameHere label, with the message "You have chosen the name" and display the name from the picker.

```xml
    <!-- Picker -->
    <Picker x:Name="myPicker" Title="Choose a name" SelectedIndexChanged="OnPickerSelectedIndexChanged">
        <!-- Items will be added programmatically in the code-behind -->
    </Picker>
        
    <!-- Label -->
    <Label Text="Enter a name" />

    <!-- Editor -->
    <Editor x:Name="editorAddName" />

    <!-- Button -->
    <Button x:Name="buttonAddName" Text="Add a name" Clicked="OnButtonAddNameClicked" />

    <!-- Display Label -->
    <Label x:Name="labelDisplayChosenNameHere" />

```

```csharp

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

```