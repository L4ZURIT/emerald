using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace emerald
{

    public class btn : Button
    {
        public bool slct;
        int[] s_fk;
        int[] u_fk;
        int[] s_bk;
        int[] u_bk;
        public string tag;
        public btn(int[] s_fk, int[] u_fk, int[] s_bk, int[] u_bk, string tag, bool sel = false)
        {
            this.s_fk = s_fk;
            this.u_fk = u_fk;
            this.s_bk = s_bk;
            this.u_bk = u_bk;
            this.slct = sel;
            this.tag = tag;
            this.AutoSize = true;
            this.Dock = DockStyle.Fill;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            if (!sel)
            {
                this.BackColor = System.Drawing.Color.FromArgb(u_bk[0], u_bk[1], u_bk[2]);
                this.ForeColor = System.Drawing.Color.FromArgb(u_fk[0], u_fk[1], u_fk[2]);
            }
            else
            {
                this.BackColor = System.Drawing.Color.FromArgb(s_bk[0], s_bk[1], s_bk[2]);
                this.ForeColor = System.Drawing.Color.FromArgb(s_fk[0], s_fk[1], s_fk[2]);
            }
            this.FlatAppearance.BorderSize = 0;
            this.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Location = new System.Drawing.Point(3, 111);
            this.Size = new System.Drawing.Size(126, 30);
            this.Text = "#" + tag;
            this.UseVisualStyleBackColor = false;
            this.Click += new System.EventHandler(this.btn_tag_Click);
            
            
        }

        public void set_selected(bool b)
        {
            if (b)
            {
                this.BackColor = System.Drawing.Color.FromArgb(s_bk[0], s_bk[1], s_bk[2]);
                this.ForeColor = System.Drawing.Color.FromArgb(s_fk[0], s_fk[1], s_fk[2]);
                this.slct = true;
            }
            else
            {
                this.BackColor = System.Drawing.Color.FromArgb(u_bk[0], u_bk[1], u_bk[2]);
                this.ForeColor = System.Drawing.Color.FromArgb(u_fk[0], u_fk[1], u_fk[2]);
                this.slct = false;
            }
        }

        public void btn_tag_Click(object? sender, EventArgs e)
        {
           
            if (this.slct)
            {
                set_selected(false);
            }
            else
            {
                set_selected(true);
            }
        }

    }

    public class tb : TextBox
    {
        public tb(int[] u_fk, int[] u_bk)
        {
            this.AutoSize = true;
            this.SetAutoSizeMode(AutoSizeMode.GrowAndShrink);
            this.BackColor = System.Drawing.Color.FromArgb(u_bk[0], u_bk[1], u_bk[2]);
            this.ForeColor = System.Drawing.Color.FromArgb(u_fk[0], u_fk[1], u_fk[2]);
            this.TextChanged += new EventHandler(this.OnTextChanged);
            
        }

        private void OnTextChanged(object? sender, EventArgs e)
        {
            Size size = TextRenderer.MeasureText(this.Text, this.Font);
            this.Width = size.Width;
            this.Height = size.Height;
        }
    }
    // класс кнопки отметки тегов
    public class btn_tag : Panel
    {
        public int id;
        public string tag_name;
        public string module;
        

        public btn b;
        public tb tb_ed;
        private FlowLayoutPanel place;
       
        public btn_tag(int[] s_fk, int[] u_fk, int[] s_bk, int[] u_bk, int id, string tag, string module, FlowLayoutPanel place, bool sel = false)
        {
            
            this.AutoSize = true;
            b = new btn(s_fk, u_fk, s_bk, u_bk, tag, sel);
            tb_ed = new tb(u_fk, u_bk);
            tb_ed.Text = tag;

            this.id = id;   
            this.tag_name = tag;    
            this.module = module;

            this.Controls.Add(b);
            this.Controls.Add(tb_ed);
            b.MouseDown += new MouseEventHandler(this.btn_tag_RMB_Pressed);
            tb_ed.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tb_tag_EnterPressed);
            tb_ed.Leave += new EventHandler(this.tb_tag_focus_lost);
            this.place = place;

        }

        public void btn_tag_RMB_Pressed(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                b.Hide();
        }

        public void tb_tag_focus_lost(object? sender, EventArgs e)
        {
           reset_tag();   
        }

        public void tb_tag_EnterPressed(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                reset_tag();
            }
                
        }

        public void reset_tag()
        {
            if (tb_ed.Text == "")
            {
                if (place.Contains(this))
                {
                    DialogResult res = MessageBox.Show("Вы уверены что хотите удaлить этот тег?", "", MessageBoxButtons.YesNo);
                    if (res == DialogResult.Yes)
                    {
                        place.Controls.Remove(this);
                    }
                    else if (res == DialogResult.No)
                    {
                        tb_ed.Text = b.tag;
                    }
                }
               
            }
            b.Text = "#" + tb_ed.Text;
            b.tag = tb_ed.Text;
            b.Show();
        }

    }

    

}
