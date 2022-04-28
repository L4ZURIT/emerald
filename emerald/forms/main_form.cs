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
    public partial class main_form : Form
    {
        customer cust_obj;
        dbm pdbm;
        user current_us;
        public main_form(ref dbm data_base_manager, ref user cur_user)
        {
            InitializeComponent();
            pan_cust.Hide();
            pan_extra.Hide();
            pan_ap.Hide();
            pan_cont.Hide();
            pan_task.Hide();
            pdbm = data_base_manager;
            current_us = cur_user;
            cust_obj = new customer(ref pdbm, ref current_us);
            tp_cust.Controls.Add(cust_obj);



        }
                

        private void btn_appeal_Click(object sender, EventArgs e)
        {
            tc_main.SelectedTab = tp_appeal;
            pan_extra.Hide();
                
        }

        private void btn_customer_Click(object sender, EventArgs e)
        {
            pan_extra.Hide();
            tc_main.SelectedTab = tp_customer;
            flp_customer_cards.Controls.Clear();
            flp_customer_cards.Controls.AddRange(pdbm.get_customer_cards(show_selected_customer).ToArray());

        }

        private void btn_contact_Click(object sender, EventArgs e)
        {
            pan_extra.Hide();
            tc_main.SelectedTab = tp_contact;
        }

        private void btn_task_Click(object sender, EventArgs e)
        {
            pan_extra.Hide();
            tc_main.SelectedTab = tp_task;
        }

        private void btn_settings_Click(object sender, EventArgs e)
        {
            pan_extra.Hide();
            tc_main.SelectedTab = tp_settings;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pan_extra.Show();
        }

        

        private void iamtestmsg(object sender, EventArgs e) 
        {
            if (sender is Button)
            {
                MessageBox.Show(Convert.ToString((sender as Button).Text));
            }
           
                  
        }

        private void btn_customer_extra_Click(object sender, EventArgs e)
        {
            pan_extra.Show();
            tc_extra.SelectTab(tp_extra_customer);
        }

        private void btn_extra_new_cust_Click(object sender, EventArgs e)
        {
            //скрываем виджет правого столбца 
            pan_extra.Hide();
            //выбираем страницу с клиентом
            tc_main.SelectTab(tp_cust);
            //включение вкладки 
            pan_cust.Show();
            btn_cust_open.Text = "Новый клиент";
            cust_obj.set_cust_add();

            
        }

        public void show_selected_customer(object sender, EventArgs e)
        {
            Button sended = sender as Button;
            //скрываем виджет правого столбца 
            pan_extra.Hide();
            //выбираем страницу с клиентом
            tc_main.SelectTab(tp_cust);
            //включение вкладки 
            pan_cust.Show();
            btn_cust_open.Text = "Новый клиент";

            cust_obj.set_cust_show(Convert.ToInt16(sended.Tag));
        }

        private void btn_cust_close_Click(object sender, EventArgs e)
        {
            pan_cust.Hide();
            tc_main.SelectTab(tp_customer);
        }

        private void btn_cust_open_Click(object sender, EventArgs e)
        {
            pan_extra.Hide();
            tc_main.SelectTab(tp_cust);
        }

        private void btn_appeal_extra_Click(object sender, EventArgs e)
        {
            pan_extra.Show();
            tc_extra.SelectTab(tp_extra_appeal);
        }

        private void btn_contact_extra_Click(object sender, EventArgs e)
        {
            pan_extra.Show();
            tc_extra.SelectTab(tp_extra_contact);
        }

        private void btn_task_extra_Click(object sender, EventArgs e)
        {
            pan_extra.Show();
            tc_extra.SelectTab(tp_extra_task);
        }

        private void btn_extra_new_ap_Click(object sender, EventArgs e)
        {
            pan_extra.Hide();
            MessageBox.Show("Выберете клиента в соответсвующем разделе и в его карточке добавьте новое обращение. Обращение можно Добавить только одитн раз");
            
        }

        public void add_new_appeal_card(int customer_id)
        {
            tc_main.SelectedTab = tp_appeal;
            appeal_card card = new appeal_card(show_selected_customer, pdbm, ref current_us, customer_id);
            this.pnl_appeal_cards.Controls.Add(card);
        }

        private void btn_extra_new_cont_Click(object sender, EventArgs e)
        {
            pan_extra.Hide();
            tc_main.SelectTab(tp_cont);
            pan_cont.Show();
            btn_cont_open.Text = "Новый контакт";
        }

        private void btn_extra_new_task_Click(object sender, EventArgs e)
        {
            pan_extra.Hide();
            tc_main.SelectTab(tp_tsk);
            pan_task.Show();
            btn_task_open.Text = "Новая задача";
        }

        private void btn_ap_close_Click(object sender, EventArgs e)
        {
            pan_ap.Hide();
            tc_main.SelectTab(tp_appeal);
        }

        private void btn_cont_close_Click(object sender, EventArgs e)
        {
            pan_cont.Hide();
            tc_main.SelectTab(tp_contact);
        }

        private void btn_task_close_Click(object sender, EventArgs e)
        {
            pan_task.Hide();
            tc_main.SelectTab(tp_task);
            
            
        }

        private void btn_ap_open_Click(object sender, EventArgs e)
        {
            pan_extra.Hide();
            tc_main.SelectTab(tp_ap);
        }

        private void btn_cont_open_Click(object sender, EventArgs e)
        {
            pan_extra.Hide();   
            tc_main.SelectTab(tp_cont);
        }

        private void btn_task_open_Click(object sender, EventArgs e)
        {
            pan_extra.Hide();
            tc_main.SelectTab(tp_tsk);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pan_extra.Hide();
            tc_main.SelectTab(tp_cust);
            pan_cust.Show();
            btn_cust_open.Text = "Новый клиент";

           
        }

        private void tb_cust_edit_find_tag_TextChanged(object sender, EventArgs e)
        {

        }

      
    }
}
