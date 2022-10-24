using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Shows the openFileDialog
            openFileDialog1.ShowDialog();
            //Reads the text file
            System.IO.StreamReader OpenFile = new System.IO.StreamReader(openFileDialog1.FileName);
            //Displays the text file in the textBox
            richTextBox1.Text = OpenFile.ReadToEnd();
            //Closes the proccess
            OpenFile.Close();

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Determines the text file to save to
            System.IO.StreamWriter SaveFile = new System.IO.StreamWriter(openFileDialog1.FileName);
            //Writes the text to the file
            SaveFile.WriteLine(richTextBox1.Text);
            //Closes the proccess
            SaveFile.Close();

        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Open the saveFileDialog
            saveFileDialog1.ShowDialog();
            //Determines the text file to save to
            System.IO.StreamWriter SaveFile = new System.IO.StreamWriter(saveFileDialog1.FileName);
            //Writes the text to the file
            SaveFile.WriteLine(richTextBox1.Text);
            //Closes the proccess
            SaveFile.Close();

        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Declare prntDoc as a new PrintDocument
            System.Drawing.Printing.PrintDocument prntDoc = new System.Drawing.Printing.PrintDocument();
            MessageBox.Show("Do you really want to print?", "Print", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

        }

        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Redo();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Font = fontDialog1.Font;
            }

        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
               richTextBox1.ForeColor = colorDialog1.Color; 
            }

        }

        private void darkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.Black;
            richTextBox1.BackColor = Color.Black;
            menuStrip1.BackColor = Color.Black;
            statusStrip1.BackColor = Color.Black;
            this.ForeColor = Color.White;
            richTextBox1.ForeColor = Color.White;
            menuStrip1.ForeColor = Color.Gray;
            statusStrip1.ForeColor = Color.White;
        }

        private void lightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
            richTextBox1.BackColor = Color.White;
            menuStrip1.BackColor = Color.White;
            statusStrip1.BackColor = Color.White;
            this.ForeColor = Color.Black;
            richTextBox1.ForeColor = Color.Black;
            menuStrip1.ForeColor = Color.Black;
            statusStrip1.ForeColor = Color.Black;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            richTextBox1.WordWrap = wordWrapToolStripMenuItem.Checked;
        }

        private void wordWrapToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            richTextBox1.WordWrap = wordWrapToolStripMenuItem.Checked;
        }

        private void richTextBox1_SelectionChanged(object sender, EventArgs e)
        {
            UpdateStatus();
        }

        private void UpdateStatus()
        {
            int pos = richTextBox1.SelectionStart;
            int line = richTextBox1.GetLineFromCharIndex(pos)+1;
            int col = pos - richTextBox1.GetFirstCharIndexOfCurrentLine() + 1;

            toolStripStatusLabel1.Text = "Ln " + line + " ,Col " + col;
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString(richTextBox1.Text, richTextBox1.Font, Brushes.Black, 22, 20);
        }

        private void statusBarToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if (statusStrip1.Visible == true&&statusBarToolStripMenuItem.Checked==false)
            {
                statusStrip1.Visible = false;
            }
            else if (statusStrip1.Visible == false && statusBarToolStripMenuItem.Checked == true)
            {
                statusStrip1.Visible = true;
            }
        }

        private void timeDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DateTime thisMoment = DateTime.Now;
            richTextBox1.Text += thisMoment;
        }

        private void zoomInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            float currSize;
            currSize = richTextBox1.Font.Size;
            currSize += 2.0F;
            richTextBox1.Font = new Font(richTextBox1.Font.Name, currSize, richTextBox1.Font.Style, richTextBox1.Font.Unit);
        }

        private void zoomOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            float currSize;
            currSize = richTextBox1.Font.Size;
            currSize -= 2.0F;
            richTextBox1.Font = new Font(richTextBox1.Font.Name, currSize, richTextBox1.Font.Style, richTextBox1.Font.Unit);

        }

       
    }
}
