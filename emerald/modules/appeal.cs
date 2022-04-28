using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using data;


namespace appeal_interface_description
{

    public class line_tb : TextBox
    {
        public line_tb(string PlaceHolder, Panel parent)
        {
            TextAlign = HorizontalAlignment.Center;
            ForeColor = Color.Black;
            Dock = DockStyle.Right;
            BackColor = parent.BackColor;
            BorderStyle = BorderStyle.None;
            PlaceholderText = PlaceHolder;
            parent.Controls.Add(this);  
        }
    }

    public class multi_line_tb : TextBox
    {
        public multi_line_tb(Panel parent)
        {
            ForeColor = Color.White;
            BackColor = parent.BackColor;
            Multiline = true;
            Dock = DockStyle.Fill;
            BorderStyle = BorderStyle.None;
            parent.Controls.Add(this);
        }
    }


    public class today_mtb : MaskedTextBox
    {
        public today_mtb(Panel parent)
        {
            TextAlign = HorizontalAlignment.Center;
            Mask = "00/00/0000";
            Text = DateTime.Today.ToShortDateString();
            ForeColor = Color.Black;
            Dock = DockStyle.Right;
            BorderStyle = BorderStyle.None;
            BackColor = parent.BackColor;
            parent.Controls.Add(this);
        }
    }

    public class action_btn: Button
    {
        public delegate void click();

        private click? action_clicked;
        public action_btn(string text, Panel parent)
        {
            FlatStyle = FlatStyle.Flat;
            Text = text;
            FlatAppearance.BorderSize = 0;
            ForeColor = Color.White;
            parent.Controls.Add(this);
            Click += new EventHandler(action_btn_Click);
        }

        private void action_btn_Click(object sender, EventArgs e)
        {
            if (action_clicked != null) action_clicked();
        }

        public void clear_click()
        {
            action_clicked = null;
        }

        public void set_click(click new_click)
        {
            action_clicked = new_click;
        }
    }

    public class combox : ComboBox
    {
        public combox(string[] items, int index)
        {
            Items.AddRange(items);
            SelectedIndex = index;
            ForeColor = Color.Black;
            FlatStyle = FlatStyle.Flat;
            Dock = DockStyle.Left;
            DropDownStyle = ComboBoxStyle.DropDownList;
            FlatStyle |= FlatStyle.Flat;
            BackColor = Color.FromArgb(126, 163, 150);
        }
    }

    public class label : Label
    {
        public label(string text)
        {
            Text = text;
            ForeColor = Color.Black;
            FlatStyle = FlatStyle.Flat;
            Dock = DockStyle.Right;
            AutoSize = true;
        }
    }

}


namespace emerald
{
    using appeal_interface_description;

    public class appeal_card: Panel
    {
        
        int? id;
        int customer_id;
        dbm pdbm;
        dbm.parent_method cust_click;
        user cur_user;

        Panel top_panel;
        Panel bottom_panel;
        Panel side_panel;

        action_btn top;
        action_btn bottom;
        action_btn side;


        ComboBox status;
        MaskedTextBox date;
        TextBox price;
        TextBox content;

        public appeal_card(dbm.parent_method cust_click, dbm pdbm, ref user cur_user, int customer_id, int? appeal_id = null)
        {
            
            this.pdbm = pdbm;
            this.Dock = DockStyle.Top;
            this.Size = new Size(this.Width, 276);
            this.BackColor = Color.FromArgb(37, 53, 47);
            this.Padding = new Padding(7);


            this.id = appeal_id;
            this.customer_id = customer_id;
            this.cust_click = cust_click;
            this.cur_user = cur_user;

            customer_card cust_c = pdbm.get_customer_card(cust_click, this.customer_id);
            cust_c.icon.Click += new EventHandler(cust_click);
            cust_c.Dock = DockStyle.Left;
            

            top_panel = new Panel();
            bottom_panel = new Panel();
            side_panel = new Panel();

                        
            top_panel.Size = new Size(top_panel.Width, cust_c.lbl_id.Height);
            top_panel.Dock = DockStyle.Top;

            bottom_panel.Size = top_panel.Size;
            bottom_panel.Dock = DockStyle.Bottom;

            side_panel.BackColor = Color.FromArgb(14, 46, 34);
            side_panel.Dock = DockStyle.Right;
            side_panel.Size = new Size(80,side_panel.Height);


            
            side = new action_btn("SIDE", side_panel);
            side.Dock = DockStyle.Fill;
            

            top = new action_btn("TOP", side_panel);
            top.Dock = DockStyle.Top    ;
            top.Size = new Size(top.Width, 70);

            bottom = new action_btn("BOTT", side_panel);
            bottom.Dock = DockStyle.Bottom;
            bottom.Size = new Size(bottom.Width, 70);



            if (appeal_id != null)
            {
                set_show_mod((int)appeal_id);
            }
            else
            {
                set_new_mod();
            }


            this.Controls.Add(side_panel);
            this.Controls.Add(top_panel);
            this.Controls.Add(bottom_panel);
            this.Controls.Add(cust_c);
            

        }

        public void set_new_mod()
        {
  
            top_panel.Controls.Clear(); 
            bottom_panel.Controls.Clear();

            top_panel.BackColor = Color.FromArgb(126, 163, 150);
            bottom_panel.BackColor = top_panel.BackColor;


            // top region
            status = new combox(pdbm.get_appeal_statuses(), 0);
            label lbl_id = new label("no id");
            label lbl_empl_fio = new label(cur_user.fio);
            lbl_empl_fio.Dock = DockStyle.Fill;


            top_panel.Controls.Add(lbl_empl_fio);
            top_panel.Controls.Add(status);
            top_panel.Controls.Add(lbl_id);
            // top region



            // bottom region
            price = new line_tb("Введите цену", bottom_panel);  
            date = new today_mtb(bottom_panel);
            //bottom region

            content = new multi_line_tb(this);
           

            // buttons initialize region
            top.Text = "";
            top.Enabled = false;

            side.Text = "";
            side.Enabled = false;

            bottom.Text = "Добавить";
            bottom.clear_click();
            bottom.set_click(add_new_appeal);
            // buttons initialize region

        }

        public void set_show_mod(int appeal_id)
        {
            id = appeal_id;
            top_panel.BackColor = Color.FromArgb(37, 53, 47);
            bottom_panel.BackColor = top_panel.BackColor;

            top_panel.Controls.Clear();
            bottom_panel.Controls.Clear();


            pdbm.select_appeal(appeal_id, out string customer, out string employee, out string status, out string content, out string price, out string date);

            //top region
            label lbl_status = new label(status);
            lbl_status.Dock = DockStyle.Left;
            lbl_status.ForeColor = Color.White;

            label lbl_fio = new label(employee);
            lbl_fio.ForeColor = Color.White;
            lbl_fio.Dock = DockStyle.Fill;

            label lbl_id = new label(appeal_id.ToString());
            lbl_id.Dock = DockStyle.Right;
            lbl_id.ForeColor = Color.White;

            top_panel.Controls.Add(lbl_fio);
            top_panel.Controls.Add(lbl_status);
            top_panel.Controls.Add(lbl_id);
            //top region


            this.content.Text = content;
            this.content.ReadOnly = true;
            


            //bottom region
            label lbl_date = new label(date);
            lbl_date.ForeColor = Color.White;
            label lbl_price = new label(price);
            lbl_price.ForeColor = Color.White;

            bottom_panel.Controls.Add(lbl_price);
            bottom_panel.Controls.Add(lbl_date);
            //bottom region


            // buttons initialize region
            top.Text = "";
            top.Enabled = false;

            side.Text = "";
            side.Enabled = false;

            bottom.Text = "Удалить";
            bottom.clear_click();
            bottom.set_click(remove_appeal);
            // buttons initialize region

        }


        public void add_new_appeal()
        {
            pdbm.insert_new_appeal(customer_id, cur_user.id, pdbm.get_appeal_status_id_by_name(status.Text), content.Text, price.Text, DateOnly.Parse(date.Text));
            MessageBox.Show("ok");
            set_show_mod(pdbm.get_last_appeal_id());
        }

        public void remove_appeal()
        {
            MessageBox.Show("removed");
        }
    }
}
