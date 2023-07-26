using System;
using System.Drawing;
using System.Windows.Forms;

public class CustomRichTextBox : RichTextBox
{
    public CustomRichTextBox()
    {
        // Set default properties for the custom RichTextBox
        this.Font = new Font("Courier New", 10); // Customize the font and size
        this.ForeColor = Color.White; // Set default text color
        this.BackColor = Color.Black; // Set default background color
        this.ReadOnly = true; // The player should not edit the game output
        this.ScrollBars = RichTextBoxScrollBars.Vertical; // Enable vertical scrollbars
    }

    // Method to add game text with a specific color
    public void AppendTextWithColor(string text, Color color)
    {
        this.SelectionStart = this.TextLength;
        this.SelectionLength = 0;
        this.SelectionColor = color;
        this.AppendText(text);
        this.SelectionColor = this.ForeColor;
        this.ScrollToCaret();
    }

    // Method to add game text with a custom font
    public void AppendTextWithFont(string text, Font font)
    {
        this.SelectionStart = this.TextLength;
        this.SelectionLength = 0;
        this.SelectionFont = font;
        this.AppendText(text);
        this.SelectionFont = this.Font;
        this.ScrollToCaret();
    }
}
