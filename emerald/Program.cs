using data;


namespace emerald
{
    internal static class Program
    {
       
        [STAThread]
        static void Main()
        {   
            // �������� ��������� ������ �� �� �����
            dbm data_base_manager = new dbm();
            ApplicationConfiguration.Initialize();
            user? cur_user = json_m.get_user_from_file();
            // ���� � ��� ��� ������������ ������������
            if (cur_user is null)
            {
                // �� ���������� ����������� ���� � �������
                login login_form = new login(ref data_base_manager);
                Application.Run(login_form);
                // � ���������������� ������ �������� ������������ ��� ���� ����� �������� ����������� ��� ��������
                cur_user = login_form.current_us;
                //���� ��� �� ��� ���� ������� �������� ������ ������������
                if (cur_user is not null)
                {   //�� ��������� ����������
                    Application.Run(new main_form(ref data_base_manager, ref cur_user));
                }
            }
            else
            {   // ���� ���� �� ������ ��������� ����������
                Application.Run(new main_form(ref data_base_manager, ref cur_user));
            }
            
        }
    }
}