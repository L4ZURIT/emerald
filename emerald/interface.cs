using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace emerald
{
    
    
    internal class panel:Panel
    {
        public panel(string fio, string source)
        {

            

            TableLayoutPanel tableLayoutPanel = new TableLayoutPanel();
            tableLayoutPanel.Margin = new Padding(0);
            tableLayoutPanel.Padding = new Padding(0);
            tableLayoutPanel.Dock = DockStyle.Fill;
            tableLayoutPanel.ColumnCount = 2;
            tableLayoutPanel.RowCount = 1;  

            Label lbl_fio = new Label();
            lbl_fio.Margin = new Padding(0);
            lbl_fio.Padding = new Padding(0);
            lbl_fio.Text = fio;
            lbl_fio.Dock = DockStyle.Left;
            lbl_fio.ForeColor = Color.White;
            lbl_fio.BackColor = Color.Black;
            tableLayoutPanel.Controls.Add(lbl_fio);

            Panel panel_fio = new Panel();
            panel_fio.Margin = new Padding(0);
            panel_fio.Padding = new Padding(0);
            panel_fio.Dock = DockStyle.Right;
            panel_fio.BackColor = Color.Green;
            tableLayoutPanel.Controls.Add(panel_fio);

            this.Controls.Add(tableLayoutPanel);

            this.Margin = new Padding(3);
            this.Padding = new Padding(0);
            Label lbl_s = new Label();
            lbl_s.Text = source;
            lbl_s.Dock = DockStyle.Top;
            lbl_s.ForeColor = Color.Black;
            lbl_s.BackColor = Color.White;
            this.Controls.Add(lbl_s);

            Label lbl_date = new Label();
            lbl_date.Margin = new Padding(0);
            lbl_date.Padding = new Padding(0);
            lbl_date.Text = Convert.ToString(DateTime.Now);
            lbl_date.Dock = DockStyle.Bottom;
            lbl_date.ForeColor = Color.Black;
            lbl_date.BackColor = Color.White;
            this.Controls.Add(lbl_date);


            this.Size = new Size(150,150);


            

        }
    }
}
