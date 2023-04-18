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
using System.Speech.Synthesis;

namespace NotesProject
{
    public partial class Userform : Form
    {
        // SpeechSynthesizer voice;
        SpeechSynthesizer voice = new SpeechSynthesizer();
        public Userform()
        {
            InitializeComponent();
           // SpeechSynthesizer voice = new SpeechSynthesizer();
        }
        #region step1
        
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Text = File.ReadAllText(openFileDialog1.FileName);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.DefaultExt = ".text";
            saveFileDialog1.Filter = "Text File|*.txt|PDF file|*.pdf|Word File|*.doc";
            DialogResult result = saveFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog1.FileName, richTextBox1.Text);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
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

        private void dateTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = System.DateTime.Now.ToString();
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

        private void Search_button_Click(object sender, EventArgs e)
        {
            string[] words = Search_textbox.Text.Split(' ');
            foreach (string word in words)
            {
                int startIndex = 0;
                while (startIndex < richTextBox1.TextLength) 
                {
                    int wordStartIndex = richTextBox1.Find(word, startIndex, RichTextBoxFinds.None);
                    if (wordStartIndex != -1)
                    {
                        richTextBox1.SelectionStart = wordStartIndex;
                        richTextBox1.SelectionLength = word.Length;
                        richTextBox1.SelectionBackColor = Color.Yellow;
                    }
                    else
                    {
                        break;
                    }
                    startIndex = wordStartIndex + word.Length;
                }
            }
        }

        private void Refresh_button_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionStart = 0;
            richTextBox1.SelectAll();
            richTextBox1.SelectionBackColor = Color.White;
        }
        #endregion

        #region step2
        private void Speak_button_Click(object sender, EventArgs e)
        {
            switch (Voiceselect.SelectedIndex) 
            { 
                case 0:
                    voice.SelectVoiceByHints(VoiceGender.Male);
                    break;
                case 1:
                    voice.SelectVoiceByHints(VoiceGender.Female);
                    break;
                default: 
                    break;
            }
            voice.SpeakAsync(richTextBox1.Text);
            voice.Resume();
        }

        private void Repeat_button_Click(object sender, EventArgs e)
        {
            voice.SpeakAsyncCancelAll();
        }

        private void Pause_button_Click(object sender, EventArgs e)
        {
            voice.Pause();
        }

        private void Save_button_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog save = new SaveFileDialog())
            { 
                save.Filter = "Wav files|*.wav";
                save.Title = "Save to File";
                if (save.ShowDialog() == DialogResult.OK)
                { 
                    FileStream fs = new FileStream(save.FileName, FileMode.Create, FileAccess.Write);
                    voice.SetOutputToWaveStream(fs);
                    voice.Speak(richTextBox1.Text);
                }
            }
        }
        #endregion
    }
}
