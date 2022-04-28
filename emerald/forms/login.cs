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
    public partial class login : Form
    {
        dbm pdbm;
        public user? current_us;
        
        public login(ref dbm data_base_manager)
        {
            pdbm = data_base_manager;
            InitializeComponent();
            tssc_login.SelectTab(0);
            current_us = null;
            
        }

        private bool check_register_form()
        {
            if (tb_register_fio.Text.Replace(" ", "") == "")
            {
                return false;
            }
            else if(tb_register_login.Text.Replace(" ", "") == "")
            {
                return false;
            } 
            else if(tb_register_password.Text.Replace(" ", "") == "")
            {
                return false;
            }
            else if (tb_register_prefs.Text.Replace(" ", "") == "")
            {
                return false;
            }
            return true;
        }

        private void btn_enter_Click(object sender, EventArgs e)
        {
            switch (pdbm.check_user(tb_enter_login.Text, tb_enter_password.Text))
            {   // не найден пользователь с таким именем
                case 1:
                    MessageBox.Show("Нет пользователя с таким именем");
                    break;
                // пароль для входа неверный
                case 2:
                    MessageBox.Show("Пароль неверный");
                    break;
                // по сути 0 позволяет входить в приложение
                default:
                    current_us = pdbm.get_user_with_login(tb_enter_login.Text);
                    DialogResult res = MessageBox.Show("Вы хотите сохранить данные для следующего ввода?", "", MessageBoxButtons.YesNo);
                    if (res == DialogResult.Yes)
                    {
                        json_m.write_current_user(current_us);
                    }
                    this.Close();
                    break;
            }
               
                   
        }

        private void btn_to_enter_Click(object sender, EventArgs e)
        {
            tssc_login.SelectTab(0);
        }

        private void btn_to_register_Click(object sender, EventArgs e)
        {
            tssc_login.SelectTab(1);
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_register_Click(object sender, EventArgs e)
        {
            // сделать проверку и дописать messageboxы
            if (check_register_form())
            {
                pdbm.create_new_employee(tb_register_fio.Text);
                pdbm.create_new_user(tb_register_login.Text, tb_register_password.Text, Convert.ToInt16(tb_register_prefs.Text));
                MessageBox.Show("Новый пользователь успешно создан");            
            }
            else
            {
                MessageBox.Show("Не хватает каких-то данных");
            }
        }
    }
}
