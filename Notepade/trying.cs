using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
// Eng.Rasheed Adnan Al-Wahbany ^_^
namespace Notepade
{
    public partial class trying : Form
    {
        int index = 0, num = 0, rech_txt_length = 0,lines_counter=0;
        bool rech_txt_changed = false;
        string file_name = "";

        public void save_file_as()
        {
            string[] lines = rech.Lines;
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Text (*.cpp)|*.cpp|(*.h)|*.h";

            if (save.ShowDialog() == DialogResult.OK)
            {
                StreamWriter write = new StreamWriter(save.FileName);
                for (int i = 0; i < lines.Length; i++)
                {
                    write.WriteLine(lines[i]);
                }
                write.Close();

            }
        }
        public void open_file(string outer_file="")
        {
            rech.Text = "";
            if (outer_file != "")
            {
                string line = "";
                StreamReader read = new StreamReader(outer_file);
                line = read.ReadLine();
                while (line != null)
                {
                    rech.Text = rech.Text + line + "\n";
                    line = read.ReadLine();
                }
                read.Close();
            }
            else
            {
                OpenFileDialog open = new OpenFileDialog();
                open.Filter = "Text (*.cpp)|*.cpp|Header (*.h)|*.h";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    string line = "";
                    file_name = open.FileName;
                    StreamReader read = new StreamReader(open.FileName);
                    line = read.ReadLine();
                    while (line != null)
                    {
                        rech.Text = rech.Text + line + "\n";
                        line = read.ReadLine();
                    }
                    read.Close();
                }
            }
        }
        public bool save_file()
        {
            string[] lines = rech.Lines;
            //MessageBox.Show(""+file_name);
            if (File.Exists(file_name))
            {
                StreamWriter write = new StreamWriter(file_name);
                for (int i = 0; i < lines.Length; i++)
                {
                    write.WriteLine(lines[i]);
                }
                write.Close();
                return true;
            }
            else
            {
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "Text (*.cpp)|*.cpp|(*.h)|*.h";

                if (save.ShowDialog() == DialogResult.OK)
                {
                    StreamWriter write = new StreamWriter(save.FileName);
                    for (int i = 0; i < lines.Length; i++)
                    {
                        write.WriteLine(lines[i]);
                    }
                    write.Close();
                    file_name = save.FileName;
                    return true;
                }
            }
            return false;
        }
        public void variables_zero()
        {
            
            index = num = 0;
            rech.SelectionStart = 0;

        }
        private void rech_TextChanged(object sender, EventArgs e)
        {
            
        }

        public void rech_color_txt_change()
        {
            index = num = rech_txt_length - 4;
            rech_txt_length = rech.TextLength;
            rech.SelectionColor = Color.Black;
            rech_txt_changed = true;
            rech_color("#include");
            index = num = rech_txt_length - 4;
            rech_txt_length = rech.TextLength;
            rech_color("class");
            index = num = rech_txt_length - 4;
            rech_txt_length = rech.TextLength;
            rech_color("struct");
            index = num = rech_txt_length - 4;
            rech_txt_length = rech.TextLength;
            rech_color("enum");
            index = num = rech_txt_length - 4;
            rech_txt_length = rech.TextLength;
            rech_color("cout");
            index = num = rech_txt_length - 4;
            rech_txt_length = rech.TextLength;
            rech_color("int");
            index = num = rech_txt_length - 4;
            rech_txt_length = rech.TextLength;
            rech_color("cin");
            index = num = rech_txt_length - 4;
            rech_txt_length = rech.TextLength;
            rech_color("<<");
            index = num = rech_txt_length - 4;
            rech_txt_length = rech.TextLength;
            rech_color(">>");
            index = num = rech_txt_length - 4;
            rech_txt_length = rech.TextLength;
            rech_color("{");
            index = num = rech_txt_length - 4;
            rech_txt_length = rech.TextLength;
            rech_color("}");
            index = num = rech_txt_length - 4;
            rech_txt_length = rech.TextLength;
            rech_color("(");
            index = num = rech_txt_length - 4;
            rech_txt_length = rech.TextLength;
            rech_color(")");
            index = num = rech_txt_length - 4;
            rech_txt_length = rech.TextLength;
            rech_color(";");

        }
        public void rech_color_txt()
        {
            
            
            if (rech_txt_changed == false)
            {
                rech_color("#include");
                variables_zero();

                rech_color("class");
                variables_zero();
                rech_color("struct");
                variables_zero();
                rech_color("enum");
                variables_zero();
                rech_color("cout");
                variables_zero();
                rech_color("int");
                variables_zero();
                rech_color("cin");
                variables_zero();
                rech_color("<<");
                variables_zero();
                rech_color(">>");
                variables_zero();
                rech_color("{");
                variables_zero();
                rech_color("}");
                variables_zero();
                rech_color("(");
                variables_zero();
                rech_color(")");
                variables_zero();
                rech_color(";");
            }
            else
            {
                index = num = rech_txt_length;
                rech_color_txt_change();
            }
            
            rech.SelectionColor = Color.Black;
            rech.SelectionStart = rech.TextLength;
        }
        public void rech_color(string txt)
        {

            if (rech.Text.Length == 0|| rech.Text.Length < rech_txt_length)
                rech.SelectionColor = Color.Black;
            else
            {
                
                    while (num<rech.TextLength && index < rech.TextLength)
                    {


                    //MessageBox.Show(rech.TextLength+"/" + index);
                    
                    index = rech.Text.IndexOf(txt, index);
                    if (index > -1)
                    {
                        
                        rech.Select(index, txt.Length);
                        rech.SelectionColor = Color.Black;
                        if (txt == "#include")
                            rech.SelectionColor = Color.Green;
                        else if (txt == "cout" || txt == "class" || txt == "int" || txt == "struct" || txt == "enum" || txt == "cin")
                            rech.SelectionColor = Color.Blue;
                        else if (txt == "<<" || txt == ">>" || txt == ";")
                            rech.SelectionColor = Color.Red;
                        else if (txt == "{" || txt == "}" || txt == "(" || txt == ")")
                            rech.SelectionColor = Color.DarkOrange;
                        
                        index = index + txt.Length;
                    }
                    else
                    {
                       
                        index = index + 1;
                    }
                        num = num + 1;
                }
                
                
               
            }


        }

        private void rech_TextChanged_1(object sender, EventArgs e)
        {
            
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            open_file();
            
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            trying f = new trying();
            f.Show();
            //rech.Text = "";
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            save_file();

        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            save_file_as();
        }

        private void aboutUsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this,"This is App is under RAGT2019 Copy Rights\nThanks for vissit us.","Info",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void trying_FormClosing(object sender, FormClosingEventArgs e)
        {
            bool close=false;
            if (rech.Text != "")
            {
                if (MessageBox.Show(this, "Do you want to save your work?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes) { 
                    if (save_file() == true)
                    {
                        close = true;
                    }
                    else
                    {
                        if (MessageBox.Show(this, "There is an error occurse when trying to save this file\nAre you sure you want exit.", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                        {
                            close = true;
                        }
                        else
                            close = false;

                    }
                }
                else
                    close = true;

            }
            else
                close = true;
            if (close == false)
            {
                e.Cancel = true;
            }
        }

        private void newToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            trying f = new trying();
            f.Show();
        }

        private void openToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            open_file();
        }

        private void saveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            save_file();
        }

        private void saveAsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            save_file_as();
        }

        private void aboutUsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this, "This is App is under RAGT2019 Copy Rights\nThanks for vissit us.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void clearToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Are you sure you want clear all data in this file.", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                rech.Text = "";
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show(this,"Are you sure you want clear all data in this file.", "Warning", MessageBoxButtons.YesNo,MessageBoxIcon.Warning)==DialogResult.Yes)
                rech.Text = "";
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rech.Undo();
        }

        private void reUndoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rech.Redo();
        }

        private void undoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            rech.Undo();
        }

        private void reUndoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            rech.Redo();
        }

        private void rech_MultilineChanged(object sender, EventArgs e)
        {
           
        }

        private void rech_TextChanged_2(object sender, EventArgs e)
        {
            rech.ScrollToCaret();
            rech_color_txt();
            rech.SelectionColor = Color.Black;
            if (rech.Lines.Length > lines_counter)
            {
                rech_lines.Text += (lines_counter + 1) + "\n";
            }
            else if (rech.Lines.Length < lines_counter)
            {

                string[] arr = rech_lines.Lines;
                rech_lines.Text = "";
                for (int i = 0; i < arr.Length - 2; i++)
                    rech_lines.Text += arr[i] + "\n";
            }
            lines_counter = rech.Lines.Length;
        }

        private void aboutUsToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Eng.Rasheed Adnan Al-Wahbany ^_^");
        }

        public trying()
        {
            InitializeComponent();
        }

        public trying(string[] arr)
        {
            InitializeComponent();
            if (arr.Length > 0)
                open_file(arr[0]);

        }
        private void trying_Load(object sender, EventArgs e)
        {
            // rech.Text = "cout << 'hello'; cout <<;";
            
            rech_color_txt();
        }
    }
}
