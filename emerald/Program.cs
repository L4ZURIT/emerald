using data;


namespace emerald
{
    internal static class Program
    {
       
        [STAThread]
        static void Main()
        {   
            // написать получение данных бд из файла
            dbm data_base_manager = new dbm();
            ApplicationConfiguration.Initialize();
            user? cur_user = json_m.get_user_from_file();
            // елси у нас нет сохраненного пользователя
            if (cur_user is null)
            {
                // то необходимо осущетсвить вход в систему
                login login_form = new login(ref data_base_manager);
                Application.Run(login_form);
                // и инициализировать объект текущего пользователя для того чтобы понимать ограничения его действий
                cur_user = login_form.current_us;
                //если все же нам таки удалось получить объект пользователя
                if (cur_user is not null)
                {   //то запускаем приложение
                    Application.Run(new main_form(ref data_base_manager, ref cur_user));
                }
            }
            else
            {   // если есть то просто запускаем приложение
                Application.Run(new main_form(ref data_base_manager, ref cur_user));
            }
            
        }
    }
}