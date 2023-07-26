using System;
using System.Drawing;
using System.Windows.Forms;

public class CustomTextBox : TextBox
{
    private string defaultText;
    private Color defaultTextColor;
    private Button submitButton; // Reference to the submit button

    public CustomTextBox()
    {
        defaultText = "Enter your commands here...";
        defaultTextColor = Color.Gray;

        Text = defaultText;
        ForeColor = defaultTextColor;

        // Subscribe to the Click event to clear the default text when the user clicks on the textbox
        Click += CustomTextBox_Click;

        // Subscribe to the KeyDown event to handle the 'Enter' key press
        KeyDown += CustomTextBox_KeyDown;
    }

    private void CustomTextBox_Click(object sender, EventArgs e)
    {
        // Clear the default text and change text color to black when the user clicks on the textbox
        if (Text == defaultText)
        {
            Text = "";
            ForeColor = Color.White;
        }
    }

    private void CustomTextBox_KeyDown(object sender, KeyEventArgs e)
    {
        // If the 'Enter' key is pressed, trigger the Click event for the submit button
        if (e.KeyCode == Keys.Enter && submitButton != null)
        {
            submitButton.PerformClick();
        }
    }

    // Overriding the OnLeave event to set the default text if the user leaves the textbox empty
    protected override void OnLeave(EventArgs e)
    {
        base.OnLeave(e);

        if (string.IsNullOrWhiteSpace(Text))
        {
            Text = defaultText;
            ForeColor = defaultTextColor;
        }
    }

    // Property to get the player's input text while ignoring the default text
    public string PlayerInput
    {
        get
        {
            return Text == defaultText ? "" : Text;
        }
    }

    // Property to get whether the input is the default text
    public bool IsDefaultText
    {
        get
        {
            return Text == defaultText;
        }
    }

    // Method to set the reference to the submit button
    public void SetSubmitButton(Button button)
    {
        submitButton = button;
    }
}
