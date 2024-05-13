using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notepad_Ultra
{
    public partial class MainForm : Form
    {
        private bool fileAlreadySaved;
        private bool fileUpdated;
        private string currentfilename;
        private FontDialog fontdialog = new FontDialog();
        public MainForm()
        {
            InitializeComponent();
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainRichTextBox.SelectAll();
        }

        private void notepadUltraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This is my Notepad Ultra Application", "Notepad About ", MessageBoxButtons.OK, MessageBoxIcon.Information );
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }



        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fileUpdated) { 
            DialogResult result = MessageBox.Show("Do you want to save your changes?", "Notepad Ultra Altert!!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
            switch (result)
            {
                case DialogResult.Yes:
                    SaveFileUpdated();
                    ClearScreen();
                    break;
                case DialogResult.No:
                    ClearScreen();
                    break;

                }
            }
            else
            {
                ClearScreen();
            }
            undoToolStripMenuItem.Enabled = false;
            redoToolStripMenuItem.Enabled = false;

            undoToolStripMenuItem1.Enabled = false;
            redoToolStripMenuItem1.Enabled = false;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text File (*.txt)|*.txt|Rich Text File (*.rtf)|*.rtf" ;
            DialogResult result = openFileDialog.ShowDialog();

            if(result == DialogResult.OK) 
            {
                if(Path.GetExtension(openFileDialog.FileName) == ".txt")
                {
                    MainRichTextBox.LoadFile(openFileDialog.FileName, RichTextBoxStreamType.PlainText);
                }
                if(Path.GetExtension(openFileDialog.FileName) == ".rtf")
                {
                    MainRichTextBox.LoadFile(openFileDialog.FileName, RichTextBoxStreamType.RichText);
                }
                this.Text = Path.GetFileName(openFileDialog.FileName) + " - Notepad Ultra";

                fileAlreadySaved = true;
                fileUpdated = false;
                currentfilename = openFileDialog.FileName;
            }
            undoToolStripMenuItem.Enabled = false;
            redoToolStripMenuItem.Enabled = false;

            undoToolStripMenuItem1.Enabled = false;
            redoToolStripMenuItem1.Enabled = false;
        }

        private void saveAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            savefile();
        }

        private void savefile()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text File (*.txt)|*.txt|Rich Text File (*.rtf)|*.rtf";
            DialogResult savefileresult = saveFileDialog.ShowDialog();

            if (savefileresult == DialogResult.OK)
            {
                if (Path.GetExtension(saveFileDialog.FileName) == ".txt")
                {
                    MainRichTextBox.SaveFile(saveFileDialog.FileName, RichTextBoxStreamType.PlainText);
                }
                if (Path.GetExtension(saveFileDialog.FileName) == ".rtf")
                {
                    MainRichTextBox.SaveFile(saveFileDialog.FileName, RichTextBoxStreamType.RichText);
                }
                this.Text = Path.GetFileName(saveFileDialog.FileName) + " - Notepad Ultra";

                fileAlreadySaved = true;
                fileUpdated = false;
                currentfilename = saveFileDialog.FileName;
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            fileUpdated = true;
            undoToolStripMenuItem.Enabled = true;

            undoToolStripMenuItem1.Enabled = true;
            redoToolStripMenuItem1.Enabled = false;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            fileAlreadySaved = false;
            fileUpdated = false;
            currentfilename = "";

        }
        

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileUpdated();
        }

        private void SaveFileUpdated()
        {
            if (fileAlreadySaved)
            {
                if (Path.GetExtension(currentfilename) == ".txt")
                {
                    MainRichTextBox.SaveFile(currentfilename, RichTextBoxStreamType.PlainText);
                }
                if (Path.GetExtension(currentfilename) == ".rtf")
                {
                    MainRichTextBox.SaveFile(currentfilename, RichTextBoxStreamType.RichText);
                }
                fileUpdated = false;
            }
            else
            {
                if (fileUpdated)
                {
                    savefile();
                }
                else
                {
                    ClearScreen();
                }

            }

        }

        private void ClearScreen()
        {
            MainRichTextBox.Clear();
            fileUpdated = false;
            this.Text = " Notepad Ultra";
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainRichTextBox.Undo();
            undoToolStripMenuItem.Enabled = false;
            redoToolStripMenuItem.Enabled = true;
            undoToolStripMenuItem1.Enabled = false;
            redoToolStripMenuItem1.Enabled = true;

        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainRichTextBox.Redo();
            redoToolStripMenuItem.Enabled = false;
            undoToolStripMenuItem.Enabled = true;
            undoToolStripMenuItem1.Enabled = true;
            redoToolStripMenuItem1.Enabled = false;
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {

        }

        private void printReviewToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {

        }

        private void formatToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void formatFontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            fontdialog.ShowColor = true;
            fontdialog.ShowApply = true;

            fontdialog.Apply += new System.EventHandler(font_Apply_Dialog);
            DialogResult result = fontdialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                if (MainRichTextBox.SelectionLength > 0)
                {
                    MainRichTextBox.SelectionFont = fontdialog.Font;
                    MainRichTextBox.SelectionColor = fontdialog.Color;
                }
            }
        }

        private void font_Apply_Dialog(object sender, EventArgs e)
        {
            if (MainRichTextBox.SelectionLength > 0)
            {
                MainRichTextBox.SelectionFont = fontdialog.Font;
                MainRichTextBox.SelectionColor = fontdialog.Color;
            }
        }

        private void changeTextColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            DialogResult result = colorDialog.ShowDialog();
            if(result == DialogResult.OK)
            {
                if(MainRichTextBox.SelectionLength > 0)
                {
                    MainRichTextBox.SelectionColor = colorDialog.Color;
                }
            }
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {

        }

        private void normalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontTextStyle(FontStyle.Regular);
        }

        private void boldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontTextStyle(FontStyle.Bold);
        }

        private void FontTextStyle(FontStyle fontstyle)
        {
            MainRichTextBox.SelectionFont = new Font(MainRichTextBox.Font, fontstyle);
        }

        private void italicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontTextStyle(FontStyle.Italic);
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {

        }

        private void underlineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontTextStyle(FontStyle.Underline);
        }

        private void strikethroughToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontTextStyle(FontStyle.Strikeout);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void dateTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainRichTextBox.SelectedText = DateTime.Now.ToString();
        }

        private void undoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MainRichTextBox.Undo();
            undoToolStripMenuItem.Enabled = false;
            redoToolStripMenuItem.Enabled = true;
            undoToolStripMenuItem1.Enabled = false;
            redoToolStripMenuItem1.Enabled = true;
        }

        private void redoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MainRichTextBox.Redo();
            redoToolStripMenuItem.Enabled = false;
            undoToolStripMenuItem.Enabled = true;
            undoToolStripMenuItem1.Enabled = true;
            redoToolStripMenuItem1.Enabled = false;
        }

        private void normalToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FontTextStyle(FontStyle.Regular);
        }

        private void boldToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FontTextStyle(FontStyle.Bold);
        }

        private void italicToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FontTextStyle(FontStyle.Italic);
        }

        private void underLineToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FontTextStyle(FontStyle.Underline);
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MainRichTextBox.Cut();
            if(MainRichTextBox.SelectionLength > 0)
            {
                Clipboard.SetText(MainRichTextBox.SelectedText);
                MainRichTextBox.SelectedText = "";
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MainRichTextBox.Copy();
            if (MainRichTextBox.SelectionLength > 0)
            {
                Clipboard.SetText(MainRichTextBox.SelectedText);
                
            }
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MainRichTextBox.Paste();
            if(Clipboard.ContainsText())
            {
                MainRichTextBox.SelectedText = Clipboard.GetText();
            }
        }

        private void cutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (MainRichTextBox.SelectionLength > 0)
            {
                Clipboard.SetText(MainRichTextBox.SelectedText);
                MainRichTextBox.SelectedText = "";
            }
        }

        private void copyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (MainRichTextBox.SelectionLength > 0)
            {
                Clipboard.SetText(MainRichTextBox.SelectedText);

            }
        }

        private void pasteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText())
            {
                MainRichTextBox.SelectedText = Clipboard.GetText();
            }
        }
    }
}
