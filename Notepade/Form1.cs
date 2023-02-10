using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//Eng.Rasheed Adnan Al-Wahbany ^_^
namespace Notepade
{
    public partial class Form1 : Form
    {
        RichTextBox rech;
        
        int index=0,num, count = 1, rech_txt_length=0,timers=0;
        
        public void rech_color_txt()
        {

           // rech_color("class");
            //if (timers == 0)
            //    index = num = 0;
            //rech_color("struct");
            //rech_color("enum");
            rech_color("cout");
            //rech_color("cin");
            //rech_color("<<");
            //rech_color(">>");
            //rech_color("{");
            //rech_color("}");
            //rech_color("(");
            //rech_color(")");
            //rech_color(";");
        }
        public void rech_color(string txt)
        {
           

            while (num != rech.Text.Length)
            {
                
                index = rech.Text.IndexOf(txt,index);
                if (index > -1)
                {
                    rech.Select(index, 4);
                   if(txt=="cout"||txt=="class"||txt=="struct"||txt=="enum"||txt=="cin")
                        rech.SelectionColor = Color.Blue;
                   else if(txt=="<<"||txt==">>"||txt==";")
                        rech.SelectionColor = Color.Red;
                   else if(txt=="{"||txt=="}"||txt=="("||txt==")")
                        rech.SelectionColor = Color.Green;
                   else
                        rech.SelectionColor = Color.Black;
                    index = index + 4;
                }
                else
                    index = index + 1;
                num = num + 1;
            }
            rech.SelectionStart = num;

            
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (rech.TextLength> rech_txt_length+4)
            {
               // timers = 1;
                rech_color_txt();

            }
            else if(rech.TextLength < rech_txt_length )
            {
                
                rech_txt_length = rech.TextLength;
                rech.SelectionColor = Color.Black;
                index = num = rech.TextLength;
            }
             if (rech.TextLength==0)
            {
                
                rech_txt_length = 0;
                timers = index = num = 0;
            }

        }

        private void tabControl1_TabIndexChanged(object sender, EventArgs e)
        {
            rech_color_txt();

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Add("New "+count);
            num = tabControl1.TabCount;
            rech = new RichTextBox();
            rech.Name = tabControl1.Name;
            rech.Dock = DockStyle.Fill;
            tabControl1.TabPages[num-1].Controls.Add(rech);
            count += 1;
            rech.Text = "cout << 'hello'; cout <<;";
            rech_color_txt();
            rech_txt_length = rech.TextLength;
            timer1.Enabled = true;

        }
    }
}
