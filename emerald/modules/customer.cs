using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using data;

namespace emerald
{

    public partial class customer : UserControl
    {
        dbm pdbm;
        user current_user;

        int? checker_id;
        int? source_id;
        int? customer_id;

        


        
        public customer(ref dbm pdbm, ref user c_u)
        {
            this.current_user = c_u;
            this.pdbm = pdbm;
            InitializeComponent();
            this.Dock = DockStyle.Fill;

            
        }

       private bool check_form_edit()
        {
            // првоерка ввода имени клиента
            if (tb_cust_edit_fio.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Необходимо ввести имя нового клиента");
                return false;
            }
            // проверка установки описания клиента
            if (tb_cust_edit_desc.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Необходимо ввести описание нового клиента");
                return false;
            }
            // проверка установки источника клиента
            if (cb_cust_edit_source.Text == "")
            {
                MessageBox.Show("Необходимо ввести информацию об источнике прихода нового клиента");
                return false;
            }



            if (pnl_cust_edit_phones.Controls.Count == 0)
            {
                MessageBox.Show("Укажите номер телефона клиента. Это необходимо чтобы связаться с ним и в дальнейшем налаживать контакт");
                return false;
            }

            if (pnl_cust_edit_emails.Controls.Count == 0)
            {
                MessageBox.Show("Укажите почту клиента. Это необходимо чтобы связаться с ним и в дальнейшем налаживать контакт");
                return false;
            }

            if (pnl_cust_edit_webs.Controls.Count == 0)
            {
                MessageBox.Show("Укажите ссылки на соцсети или веб-ресурсы клиента. Это необязательно");
            }
            return true;
        }

        private bool check_form_add()
        {

            //ДОБАВИТЬ КРАСНУЮ ПОДСВЕТКУ ДЛЯ ЭЛЕМЕНТОВ ФОРМЫ КОТОРЫЕ НЕОБХОДИМО ЗАПОЛНИТЬ


            // првоерка ввода имени клиента
            if (tb_cust_add_fio.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Необходимо ввести имя нового клиента");
                return false;
            }
            // проверка установки описания клиента
            if (tb_cust_add_desc.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Необходимо ввести описание нового клиента");
                return false;
            }
            // проверка установки источника клиента
            if (cb_cust_add_source.Text == "")
            {
                MessageBox.Show("Необходимо ввести информацию об источнике прихода нового клиента");
                return false;
            }
            


            if (pnl_cust_add_phones.Controls.Count == 0)
            {
                MessageBox.Show("Укажите номер телефона клиента. Это необходимо чтобы связаться с ним и в дальнейшем налаживать контакт");
                return false;           
            }

            if (pnl_cust_add_emails.Controls.Count == 0)
            {
                MessageBox.Show("Укажите почту клиента. Это необходимо чтобы связаться с ним и в дальнейшем налаживать контакт");
                return false;
            }

            if (pnl_cust_add_webs.Controls.Count == 0)
            {
                MessageBox.Show("Укажите ссылки на соцсети или веб-ресурсы клиента. Это необязательно");
            }

            return true;
        }
        public void set_cust_edit(int id)
        {
            tssc_main.SelectTab(0);

            lbl_cust_edit_id.Text = "id - " + id.ToString();
            tb_cust_edit_fio.Text = lbl_cust_show_fio.Text;
            tb_cust_edit_desc.Text = lbl_cust_show_desc.Text;
            lbl_cust_edit_employee.Text = lbl_cust_show_employee.Text;
            lbl_cust_edit_checker.Text = lbl_cust_show_manager.Text;
            mtb_cust_edit_date.Text = lbl_cust_show_appear_date.Text;

            cb_cust_edit_source.Items.Clear();
            cb_cust_edit_source.Items.AddRange(pdbm.get_all_customer_sources());
            cb_cust_edit_source.Text = lbl_cust_show_source.Text;

            pnl_cust_edit_phones.Controls.Clear();
            pnl_cust_edit_emails.Controls.Clear();
            pnl_cust_edit_webs.Controls.Clear();
                     
            pnl_cust_edit_phones.Controls.AddRange(pdbm.get_customer_phones_edit(id, pnl_cust_edit_phones, pdbm));
            pnl_cust_edit_emails.Controls.AddRange(pdbm.get_customer_emails_edit(id, pnl_cust_edit_emails, pdbm));
            pnl_cust_edit_webs.Controls.AddRange(pdbm.get_customer_webs_edit(id, pnl_cust_edit_webs, pdbm));

        }

        public void set_cust_show(int id)
        {
            this.customer_id = id;
            tssc_main.SelectTab(2);

            // переменные для получения данных их метода 
            string fio;
            string desc;
            string employee;
            string? manager;
            string appear_date;
            string source;
            
            conn_item_show[] phones;
            conn_item_show[] emails;
            conn_item_show[] webs;
            // переменные ...

            pdbm.show_customer(
                id, 
                out fio, 
                out desc, 
                out employee, 
                out manager, 
                out appear_date, 
                out source,
                out phones,
                out emails,
                out webs
                );

            
            
            lbl_cust_show_id.Text = "id - " + id.ToString();
            lbl_cust_show_fio.Text = fio;
            lbl_cust_show_desc.Text = desc;
            lbl_cust_show_employee.Text = employee;
            lbl_cust_show_manager.Text = manager;
            lbl_cust_show_appear_date.Text = appear_date;
            lbl_cust_show_source.Text = source;

            pnl_cust_show_phones.Controls.Clear();
            pnl_cust_show_emails.Controls.Clear();
            pnl_cust_show_webs.Controls.Clear();

            pnl_cust_show_phones.Controls.AddRange(phones);
            pnl_cust_show_emails.Controls.AddRange(emails);
            pnl_cust_show_webs.Controls.AddRange(webs);


        }
        public void set_cust_add()
        {
            tssc_main.SelectTab(1);
            tb_cust_add_fio.Text = "";
            tb_cust_add_desc.Text = "";


            pnl_cust_add_phones.Controls.Clear();
            pnl_cust_add_emails.Controls.Clear();
            pnl_cust_add_webs.Controls.Clear();

            mtb_cust_add_date.Text = DateTime.Today.ToString();

          
            

            cb_cust_add_source.Items.Clear();
            cb_cust_add_source.Text = "";

            cb_cust_add_source.Items.AddRange(pdbm.get_all_customer_sources());
            
        }

        public void get_client_to_edit(object sender, EventArgs e)
        {
            if (check_form_edit())
            {
                MessageBox.Show("ok");
                pdbm.update_customer(
                    Convert.ToInt16(lbl_cust_edit_id.Text.Substring(5)), 
                    tb_cust_edit_fio.Text,
                    tb_cust_edit_desc.Text,
                    cb_cust_edit_source.Text,
                    mtb_cust_edit_date.Text
                   );
            }
            else
            {
                MessageBox.Show("not");
            }
        }

        public void get_client_to_add(object sender, EventArgs e)
        {
            if (check_form_add())
            {
                MessageBox.Show("OK");

                List<string[]> phones = new List<string[]>();

                foreach (conn_item_add item in pnl_cust_add_phones.Controls)
                {
                    phones.Add( new string[] { item.content, item.name});
                }

                List<string[]> emails = new List<string[]>();

                foreach (conn_item_add item in pnl_cust_add_emails.Controls)
                {
                    emails.Add(new string[] { item.content, item.name });
                }

                List<string[]> webs = new List<string[]>();

                foreach (conn_item_add item in pnl_cust_add_webs.Controls)
                {
                    webs.Add(new string[] { item.content, item.name });
                }

                


                pdbm.insert_customer(
                        tb_cust_add_fio.Text,
                        mtb_cust_add_date.Text,
                        tb_cust_add_desc.Text,
                        current_user.id,
                        this.checker_id,
                        pdbm.get_client_sorce_with_source_name(cb_cust_add_source.Text),
                        phones,
                        emails,
                        webs
                    );
            }
            else
            {
                MessageBox.Show("NOT");
            }
        }

        
        private Dictionary<int, string[]> get_customer_connection_from(Panel panel)
        {
            return new Dictionary<int, string[]>();
        }


        
        // добавление телефонов
        private void btn_cust_add_phone_Click(object sender, EventArgs e)
        {
            if (pnl_cust_add_phones.Controls.Count > 0)
            {
                conn_item_add? t = pnl_cust_add_phones.Controls[pnl_cust_add_phones.Controls.Count - 1] as conn_item_add;


                if (t.tb_content.Text.Replace(")", "").Replace("-", "").Replace("+7(", "").Replace(" ", "") == "")
                {
                    MessageBox.Show("Сначала заполните пустые поля");
                    return;
                }
                
            }           
            pnl_cust_add_phones.Controls.Add(new conn_item_add(pnl_cust_add_phones,"", "", "+7(000)00-00-000"));
        }
        // добавление почтовых адрессов
        private void btn_cust_add_email_Click(object sender, EventArgs e)
        {
            if (pnl_cust_add_emails.Controls.Count > 0)
            {
                conn_item_add t = pnl_cust_add_emails.Controls[pnl_cust_add_emails.Controls.Count - 1] as conn_item_add;


                if (t.tb_content.Text == "")
                {
                    MessageBox.Show("Сначала заполните пустые поля");
                    return;
                }

            }
            pnl_cust_add_emails.Controls.Add(new conn_item_add(pnl_cust_add_emails, "", "", ""));
        }
        // добавление ссылок на веб-ресурсы
        private void btn_cust_add_web_Click(object sender, EventArgs e)
        {
            if (pnl_cust_add_webs.Controls.Count > 0)
            {
                conn_item_add t = pnl_cust_add_webs.Controls[pnl_cust_add_webs.Controls.Count - 1] as conn_item_add;


                if (t.tb_content.Text == "")
                {
                    MessageBox.Show("Сначала заполните пустые поля");
                    return;
                }

            }
            pnl_cust_add_webs.Controls.Add(new conn_item_add(pnl_cust_add_webs, "", "", ""));
        }

        // 
        private void btn_cust_edit_phone_Click(object sender, EventArgs e)
        {
            if (pnl_cust_edit_phones.Controls.Count > 0)
            {
                conn_item_edit? t = pnl_cust_edit_phones.Controls[pnl_cust_edit_phones.Controls.Count - 1] as conn_item_edit;


                if (t.tb_content.Text.Replace(")", "").Replace("-", "").Replace("+7(", "").Replace(" ", "") == "")
                {
                    MessageBox.Show("Сначала заполните пустые поля");
                    return;
                }

            }
            pnl_cust_edit_phones.Controls.Add(new conn_item_edit(pdbm, pnl_cust_add_phones, "phone", "", "", "+7(000)00-00-000", pdbm.insert_phone("", "", Convert.ToInt16(lbl_cust_edit_id.Text.Substring(5)))));
        }
        // добавление почтовых адрессов
        private void btn_cust_edit_email_Click(object sender, EventArgs e)
        {
            if (pnl_cust_edit_emails.Controls.Count > 0)
            {
                conn_item_edit? t = pnl_cust_edit_emails.Controls[pnl_cust_edit_emails.Controls.Count - 1] as conn_item_edit;


                if (t.tb_content.Text == "")
                {
                    MessageBox.Show("Сначала заполните пустые поля");
                    return;
                }

            }
            pnl_cust_edit_emails.Controls.Add(new conn_item_edit(pdbm, pnl_cust_add_emails,"email", "", "", "", pdbm.insert_email("", "", Convert.ToInt16(lbl_cust_edit_id.Text.Substring(5)))));
        }
        // добавление ссылок на веб-ресурсы
        private void btn_cust_edit_web_Click(object sender, EventArgs e)
        {
            if (pnl_cust_edit_webs.Controls.Count > 0)
            {
                conn_item_edit t = pnl_cust_edit_webs.Controls[pnl_cust_edit_webs.Controls.Count - 1] as conn_item_edit;


                if (t.tb_content.Text == "")
                {
                    MessageBox.Show("Сначала заполните пустые поля");
                    return;
                }

            }
            pnl_cust_edit_webs.Controls.Add(new conn_item_edit(pdbm, pnl_cust_edit_webs, "web", "", "", "", pdbm.insert_web("", "", Convert.ToInt16(lbl_cust_edit_id.Text.Substring(5)))));
        }

        private void btn_cust_edit_current_Click(object sender, EventArgs e)
        {
            set_cust_edit(Convert.ToInt16(lbl_cust_show_id.Text.Substring(5)));
        }

        private void btn_cust_show_new_appeal_Click(object sender, EventArgs e)
        {
            
            main_form? parent = this.Parent.Parent.Parent as main_form;
            if (parent != null && this.customer_id != null)
            {
                parent.add_new_appeal_card((int)this.customer_id);
            }
        }
    }



    // класс кнопки отметок тегов для клиентской части : Редактирование тегов // вырезан из бетаверсии

    public class cust_btn_tag_edit: btn_tag
    {
        public bool selecetd;

        //                                                                                `````````````````````           белый                   черный         темнофиолетовый        светлофиолетовый
        public cust_btn_tag_edit(int id, string tag, string module, FlowLayoutPanel place,  bool sel = false) : base(new int[] {255,255,255}, new int[] {0,0,0}, new int[] {17,15,48}, new int[] {134,133,164}, id, tag, module, place, sel)
        {
            this.selecetd = sel;
            this.b.Click += new System.EventHandler(this.cust_btn_tag_Click);
        }
        
        void cust_btn_tag_Click(object sender, EventArgs e)
        {
            this.selecetd = this.b.slct;
        }

    }

    public class cust_btn_tag_show: Button
    {
        public cust_btn_tag_show(string tag)
        {
            this.BackColor = System.Drawing.Color.FromArgb(134, 133, 164);
            this.ForeColor = System.Drawing.Color.FromArgb(0,0,0);
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.FlatAppearance.BorderSize = 0;
            this.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Location = new System.Drawing.Point(3, 111);
            this.Size = new System.Drawing.Size(126, 30);
            this.Text = "#" + tag;
            this.UseVisualStyleBackColor = false;
        }
    }

    public class conn_item_edit : conn_item_add
    {
        private dbm pdbm;
        private string _type;
        private string name;
        private string content;

      
        public conn_item_edit(dbm pdbm, Panel place, string _type, string name, string content, string mask, int id ) : base(place, name, content, mask, id)
        {
            this.pdbm = pdbm;
            this._type = _type;
            this.name = name;
            this.content = content;
            
        }

        override private protected void tb_content_EnterPressed(object sender, KeyEventArgs e)
        {
            name = this.tb_name.Text;
            content = this.tb_content.Text;
            base.tb_content_EnterPressed(sender, e);
            if (e.KeyCode == Keys.Enter)
            {
                switch (_type)
                {
                    case "phone":
                        if (remove == false)
                        {
                            pdbm.update_phone((int)this.id, name, content);
                        }
                        else
                        {
                            pdbm.delete_phone((int)this.id);
                        }
                        break;
                    case "email":
                        if (remove == false)
                        {
                            pdbm.update_email((int)this.id, name, content);
                        }
                        else
                        {
                            pdbm.delete_email((int)this.id);
                        }
                        break;
                    case "web":
                        if (remove == false)
                        {
                            pdbm.update_web((int)this.id, name, content);
                        }
                        else
                        {
                            pdbm.delete_web((int)this.id);
                        }
                        break;
                }
            }
            
        }
    }


    // панель компонентов для заполнения телефонов, почтовых ящиков и веб-ресурсов
    public class conn_item_add: Panel
    {
        public int? id;
        public string name;
        public string content;
        public TextBox tb_name;
        public MaskedTextBox tb_content;
        private Panel place;
        public bool remove;
        public conn_item_add(Panel place, string name,string content, string mask, int? id = null)
        {
            this.remove = false;
            this.id = id;
            this.name = name;
            this.content = content;
            this.place = place;
            this.Dock = DockStyle.Top;
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Size = new Size(this.Width, 63);

            tb_name = new TextBox();
            tb_content = new MaskedTextBox();

            tb_name.BorderStyle = BorderStyle.None;
            tb_content.BorderStyle = BorderStyle.None;

            tb_name.Text = name;
            tb_content.Text = content;

            tb_name.PlaceholderText = "Введите подпись";
            tb_content.Mask = mask;

            tb_content.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tb_content_EnterPressed);
            tb_content.TextChanged += new System.EventHandler(this.tb_content_OnTextChanged);
            tb_name.TextChanged += new System.EventHandler(this.tb_name_OnTextChanged);

            tb_name.TextAlign = HorizontalAlignment.Center;
            tb_name.Dock = DockStyle.Top;
            tb_name.BackColor = Color.FromArgb(123, 121, 164);
            tb_name.ForeColor = Color.FromArgb(0, 0, 0);
           

            tb_content.TextAlign = HorizontalAlignment.Center;
            tb_content.Dock = DockStyle.Fill;
            tb_content.BackColor = Color.FromArgb(49, 48, 73);
            tb_content.ForeColor = Color.FromArgb(255, 255, 255);
            tb_content.Font = new Font("Segoe UI", 13);

            this.Controls.Add(tb_content);
            this.Controls.Add(tb_name);

            
        }

        private protected virtual void tb_content_EnterPressed(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (tb_content.Text.Replace(")", "").Replace("-", "").Replace("+7(", "").Replace(" ", "") == "")
                {
                    DialogResult res = MessageBox.Show("Вы уверены что хотите удалить это поле?","", MessageBoxButtons.YesNo);
                    if (res == DialogResult.Yes)
                    {
                        place.Controls.Remove(this);
                        remove = true;
                    }
                }
            }
        }

        private void tb_content_OnTextChanged(object sender, EventArgs e)
        {
            this.content = tb_content.Text;
        }

        private void tb_name_OnTextChanged(object sender, EventArgs e)
        {
            this.name = tb_name.Text;
        }

    } 


    public class conn_item_show : Panel
    {
        public conn_item_show(string name, string content)
        {
            Label lbl_note = new Label();
            Label lbl_content = new Label();

            this.Controls.Add(lbl_note);
            this.Controls.Add(lbl_content);

            lbl_note.Text = name;
            lbl_content.Text = content;

            lbl_note.BackColor = Color.FromArgb(123,121,164);
            lbl_note.ForeColor = Color.White;

            lbl_content.BackColor = Color.FromArgb(134,133,164);
            lbl_content.ForeColor = Color.Black;

            lbl_note.Dock = DockStyle.Top;
            lbl_content.Dock = DockStyle.Fill;
            this.Dock = DockStyle.Top;

            lbl_note.TextAlign = ContentAlignment.MiddleCenter;
            lbl_content.TextAlign = ContentAlignment.MiddleCenter;

            lbl_note.AutoSize = false;
            lbl_content.AutoSize = false;

            lbl_note.Size = new Size(lbl_note.Width, 20);
            this.Size = new Size(this.Width, 64);
        }
    }

    public class customer_card : Panel
    {
        public int id;
        public Button icon;
        public Label lbl_id;
        public Label lbl_fio;
        public main_form widget;
  
        
        public customer_card(int id, string fio, DateTime appear_date)
        {
             
            this.id = id;         

            lbl_id = new Label();
            Label lbl_date = new Label();
            lbl_fio = new Label(); 
            icon = new Button();
                       

            this.Controls.Add(icon);
            this.Controls.Add(lbl_fio);
            this.Controls.Add(lbl_date);
            this.Controls.Add(lbl_id);

            lbl_id.Text =  "id - " +id.ToString();
            lbl_id.BackColor = System.Drawing.Color.FromArgb(134,133,164);
            lbl_id.TextAlign = ContentAlignment.TopLeft;
            lbl_id.Size = new Size(lbl_id.Width, 25);
            lbl_id.Dock = DockStyle.Top;

            lbl_date.Text = appear_date.ToShortDateString();
            lbl_date.BackColor = System.Drawing.Color.FromArgb(134, 133, 164);
            lbl_date.TextAlign = ContentAlignment.TopRight;
            lbl_date.Size = new Size(lbl_id.Width, 25);
            lbl_date.Dock = DockStyle.Bottom;

            lbl_fio.Text = fio;
            lbl_fio.BackColor = System.Drawing.Color.FromArgb(49, 48, 73);
            lbl_fio.TextAlign = ContentAlignment.MiddleCenter;
            lbl_fio.Size = new Size(lbl_id.Width, 48);
            lbl_fio.Dock = DockStyle.Bottom;
            lbl_fio.ForeColor = Color.White;
            lbl_fio.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);

            icon.Text = "";
            icon.BackColor = System.Drawing.Color.FromArgb(49, 48, 73);
            icon.Image = System.Drawing.Bitmap.FromFile("E:\\ImpFiles\\c#_apps\\emerald\\emerald\\icons\\customers\\user.png");
            icon.ImageAlign = ContentAlignment.MiddleCenter;
            icon.Dock = DockStyle.Fill;
            icon.FlatAppearance.BorderSize = 0;
            icon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            icon.Tag = id.ToString();

            



            this.Size = new Size(217, 249);
            //this.Padding = new System.Windows.Forms.Padding(3);
            this.Margin = new System.Windows.Forms.Padding(3);

           
        }


       
    }
    
}
