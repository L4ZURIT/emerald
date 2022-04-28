using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using emerald;

namespace data
{
    public partial class dbm
    {
        private ApplicationContext db;
        public dbm()
        {
            db = new ApplicationContext();
        }

        public int check_user(string? login, string? password)
        {
            List<string> login_list = new List<string> ();
            Dictionary<string, string> password_list = new Dictionary<string, string>();

            var users = db.users.ToList();

            foreach(var user in users)
            {
                login_list.Add (user.login);
                password_list.Add (user.login, user.password);
            }

            if (login_list.Contains(login))
            {
                if (password_list.Contains(new KeyValuePair<string, string>(login, password)))
                {
                    return 0 ;
                }
                else
                {
                    return 2;
                }
            }
            else
            {
                return 1;
            }


        }

        public void create_new_employee(string fio)
        {
            db.employee.Add(new employee { fio = fio });
            db.SaveChanges();   
        }

        public void create_new_user( string login, string password, int pref, int? person_id = null)
        {
            if (person_id is null) person_id = db.employee.ToList<employee>().Last<employee>().id;
            db.users.Add(new users { person_id = (int)person_id, login = login, password = password, admission_id = pref});
            db.SaveChanges ();
        }

     

        public user get_user_with_login(string login)
        {
            users us = db.users.Where(u => u.login == login).OrderBy(u => u.person_id).Last();
            employee empl = db.employee.Where(e => e.id == us.person_id).OrderBy(e => e.id).Last();

            return new user { id = empl.id, fio = empl.fio, admission = us.admission_id };
        }

    

        public int get_client_sorce_with_source_name(string name)
        {
            return db.sources.Where(s => s.source_name == name).OrderBy(s => s.id).Last().id;
        }

        public delegate void parent_method(object sender, EventArgs e);
        public List<customer_card> get_customer_cards(parent_method func)
        {
            List<customer_card> cards = new List<customer_card> ();
            
            foreach(customer cust in db.customer.ToList())
            {
                customer_card card = new customer_card(cust.id, cust.fio, cust.appear_date);
                card.icon.Click += new System.EventHandler(func);
                cards.Add(card);
                
            }

            return cards;
        }

        public customer_card? get_customer_card(parent_method func, int id)
        {
            customer cust = db.customer.Find(id);
            if (cust is not null)
            {
                return new customer_card(cust.id, cust.fio, cust.appear_date);
            }
            else
            {
                return null;
            }
            
        }

        public void update_customer(
            int id,     
            string fio, 
            string desc,
            string source,
            string date
                   )
        {
            customer cust = db.customer.Find(id);
            cust.fio = fio;
            cust.desc = desc;
            cust.source_id = get_client_sorce_with_source_name (source);
            cust.appear_date = DateTime.Parse(date).ToUniversalTime();
            db.SaveChanges ();
        }

        public  void insert_customer(
            
            string fio, 
            string appear_date, 
            string desc, 
            int employee,
            int? manager,
            int source,
            List<string[]> phones,
            List<string[]> emails,
            List<string[]> webs
            )
        {
           
                data.customer new_cust = new customer { 
                    fio = fio, 
                    appear_date = DateTime.Parse(appear_date).ToUniversalTime(), 
                    desc = desc,  
                    employee_id = employee,
                    checked_manager_id = manager,
                    source_id = source
                };

                db.customer.Add(new_cust);
                db.SaveChanges();
                

                new_cust = db.customer.OrderBy(c => c.id).Last();
                
                foreach (string[] phone in phones)
                {
                    db.phones.Add(new data.phones { person_id = new_cust.id, phone = phone[0], note = phone[1] });
                }

                foreach (string[] email in emails)
                {
                    db.emails.Add(new data.emails { person_id = new_cust.id, email = email[0], note = email[1] });
                }

                foreach (string[] web in webs)
                {
                    db.webs.Add(new data.webs { person_id = new_cust.id, web = web[0], note = web[1] });
                }

                db.SaveChanges();

             
        }



        public string[] get_all_customer_sources()
        {
            List<string> sources = new List<string>();
            foreach(sources s in db.sources.ToList())
            {
                sources.Add(s.source_name);
            }
            return sources.ToArray();
        }

      


        public void select_customer(
            int id,
            out string fio,
            out string desc,
            out string employee,
            out string? manager,
            out string appear_date,
            out string source)
        {
            customer cust = db.customer.Where(customer => customer.id == id).OrderBy(c => c.id).Last();

            fio = cust.fio;
            desc = cust.desc;
            employee = db.employee.Where(e => e.id == cust.employee_id).OrderBy(e => e.id).Last().fio;
            try
            {
                manager = db.employee.Where(e => e.id == cust.checked_manager_id).OrderBy(e => e.id).Last().fio;
            }
            catch (System.InvalidOperationException)
            {
                manager = null;
            }
            appear_date = cust.appear_date.ToString();
            source = db.sources.Where(s => s.id == cust.source_id).OrderBy(s => s.id).Last().source_name;
        }

        public void show_customer(
            int id, 
            out string fio, 
            out string desc,
            out string employee,
            out string? manager,
            out string appear_date,
            out string source,
            out conn_item_show[] phones,
            out conn_item_show[] emails,
            out conn_item_show[] webs
            )
        {

            select_customer(id, out fio, out desc, out employee, out manager, out appear_date, out source);

            phones = get_customer_phones_show(id);
            emails = get_customer_emails_show(id);
            webs = get_customer_webs_show(id);

        }

       

        private conn_item_show[] get_customer_phones_show(int cust_id)
        {
            List<conn_item_show> _items = new List<conn_item_show>();
            foreach(phones phone in db.phones.Where(p => p.person_id == cust_id).ToList())
            {
                _items.Add(new conn_item_show(phone.note, phone.phone));
            }

            return _items.ToArray();
        }

        private conn_item_show[] get_customer_emails_show(int cust_id)
        {
            List<conn_item_show> _items = new List<conn_item_show>();
            foreach (emails email in db.emails.Where(e => e.person_id == cust_id).ToList())
            {
                _items.Add(new conn_item_show(email.note, email.email));
            }

            return _items.ToArray();
        }

        private conn_item_show[] get_customer_webs_show(int cust_id)
        {
            List<conn_item_show> _items = new List<conn_item_show>();
            foreach (webs web in db.webs.Where(w => w.person_id == cust_id).ToList())
            {
                _items.Add(new conn_item_show(web.note, web.web));
            }

            return _items.ToArray();
        }

        public conn_item_edit[] get_customer_phones_edit(int cust_id, Panel place, dbm pdbm)
        {
            List<conn_item_edit> _items = new List<conn_item_edit>();
            foreach (phones phone in db.phones.Where(p => p.person_id == cust_id).ToList())
            {
                _items.Add(new conn_item_edit(pdbm, place, "phone", phone.note, phone.phone, "+7(000)00-00-000", phone.id));
            }
            return _items.ToArray();
        }

        public conn_item_edit[] get_customer_emails_edit(int cust_id, Panel place, dbm pdbm)
        {
            List<conn_item_edit> _items = new List<conn_item_edit>();
            foreach (emails email in db.emails.Where(e => e.person_id == cust_id).ToList())
            {
                _items.Add(new conn_item_edit(pdbm, place, "email", email.note, email.email, "", email.id));
            }
            return _items.ToArray();
        }

        public conn_item_edit[] get_customer_webs_edit(int cust_id, Panel place, dbm pdbm)
        {
            List<conn_item_edit> _items = new List<conn_item_edit>();
            foreach (webs web in db.webs.Where(w => w.person_id == cust_id).ToList())
            {
                _items.Add(new conn_item_edit(pdbm, place, "web", web.note, web.web, "", web.id));
            }
            return _items.ToArray();
        }

        public int insert_phone(string name, string phone, int id)
        {
            db.phones.Add(new phones { note = name, phone= phone, person_id = id });
            db.SaveChanges();
            return db.phones.ToList().Last().id;
        }
        public int insert_email(string name, string email, int id)
        {
            db.emails.Add(new emails { note = name, email = email, person_id = id });
            db.SaveChanges();
            return db.emails.ToList().Last().id;
        }

        public int insert_web(string name, string web, int id)
        {
            db.webs.Add(new webs { note = name, web = web, person_id = id });
            db.SaveChanges();
            return db.webs.ToList().Last().id;
        }

        public void update_phone(int id, string name, string content)
        {
            phones phone =  db.phones.Where(p => p.id == id).ToList().Last();
            phone.note = name;
            phone.phone = content;  
            db.SaveChanges();
        }

        public void update_email(int id, string name, string content)
        {
            MessageBox.Show(id.ToString());
            emails email = db.emails.Where(p => p.id == id).ToList().Last();
            email.note = name;
            email.email = content;
            db.SaveChanges();
        }

        public void update_web(int id, string name, string content)
        {
            webs web = db.webs.Where(p => p.id == id).ToList().Last();
            web.note = name;
            web.web = content;
            db.SaveChanges();
        }

        public void delete_phone(int id)
        {
            db.phones.Remove(db.phones.Where(p => p.id == id).ToList().Last());
            db.SaveChanges();

        }

        public void delete_email(int id)
        {
            db.emails.Remove(db.emails.Where(p => p.id == id).ToList().Last());
            db.SaveChanges();

        }

        public void delete_web(int id)
        {
            db.webs.Remove(db.webs.Where(p => p.id == id).ToList().Last());
            db.SaveChanges();

        }


        public string[] get_appeal_statuses()
        {
            List<string> a_s = new List<string>();
            foreach (appeal_statuses status in db.appeal_statuses.ToList())
            {
                a_s.Add(status.status);
            }
            return a_s.ToArray();
        }

        public void insert_new_appeal(int customer_id, int employee_id, int status_id, string content, string price, DateOnly date)
        {
            db.appeals.Add(
                new appeals
                {
                    customer_id = customer_id,
                    employee_id = employee_id,
                    status = status_id,
                    content = content,
                    price = price,
                    date = date
                });
            db.SaveChanges();
        }

        public void select_appeal(int id, out string? customer, out string? employee, out string status, out string content, out string price, out string date )
        {
            appeals app = db.appeals.Find(id);
           
                customer = db.customer.Find(app.customer_id).fio;
                employee = db.employee.Find(app.employee_id).fio;
                status = db.appeal_statuses.Find(app.status).status;
                content = app.content;
                price = app.price;
                date = app.date.ToString();
            
        }
        public int get_appeal_status_id_by_name(string name)
        {
            return db.appeal_statuses.Where(s => s.status == name).ToList().Last().id;
        }
        public int get_last_appeal_id()
        {
            return db.appeals.OrderBy(a => a.id).Last().id;
        }
    }


    
}
