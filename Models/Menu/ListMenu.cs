namespace rep.Models.Menu
{
    public class ListMenu
    {
        public List<ItemMenu> HeaderMenu = new List<ItemMenu>()
        {
            new ItemMenu("Home","Index","Школково"),
            new ItemMenu("Home","Lessons", "Уроки"),
            new ItemMenu("Home", "Materials", "Материалы"),
            new ItemMenu("Home", "Teachers", "Преподаватели"),
            new ItemMenu("Authentication", "Login", "Войти"),
        };
        public List<ItemMenu> UserHeaderMenu = new List<ItemMenu>()
        {
            new ItemMenu("Home","Index","Школково"),
            new ItemMenu("Home","Lessons", "Уроки"),
            new ItemMenu("Home", "Materials", "Материалы"),
            new ItemMenu("Home", "Teachers", "Преподаватели"),
            new ItemMenu("Authentication", "Exit", "Выйти"),
        };
        public List<ItemMenu> TeacherHeaderMenu = new List<ItemMenu>()
        {
            new ItemMenu("Home","Index","Школково"),
            new ItemMenu("Home","Lessons", "Уроки"),
            new ItemMenu("Home", "Materials", "Материалы"),
            new ItemMenu("Home", "Teachers", "Преподаватели"),
            new ItemMenu("Home", "Marks", "Выставление оценок"),
             new ItemMenu("Home", "Students", "Студенты"),
            new ItemMenu("Authentication", "Exit", "Выйти"),
        };
        public List<ItemMenu> AdminHeaderMenu = new List<ItemMenu>()
        {
            new ItemMenu("Home","Index","Школково"),
            new ItemMenu("Home","Lessons", "Уроки"),
            new ItemMenu("Home", "Materials", "Материалы"),
            new ItemMenu("Home", "Teachers", "Преподаватели"),
             new ItemMenu("Home", "Students", "Студенты"),
            new ItemMenu("Authentication", "Exit", "Выйти"),
        };
        public List<ItemMenu> GuestFooterMenu = new List<ItemMenu>()
        {
            new ItemMenu("Main","Index","О нас"),
            new ItemMenu("Main", "Reviews", "Отзывы"),
        };
        public List<ItemMenu> UserFooterMenu = new List<ItemMenu>()
        {
            new ItemMenu("Main","Index","О нас"),
            new ItemMenu("Main", "Reviews", "Отзывы"),
            new ItemMenu("Main", "Marks", "Оценки"),
        };
        public List<ItemMenu> AdminFooterMenu = new List<ItemMenu>()
        {
            new ItemMenu("Main","Index","О нас"),
            new ItemMenu("Main","Users", "Пользователи"),
            new ItemMenu("Main", "Reviews", "Отзывы"),
        };
        public List<ItemMenu> TeacherFooterMenu = new List<ItemMenu>()
        {
            new ItemMenu("Main","Index","О нас"),
            new ItemMenu("Main", "Reviews", "Отзывы"),
        };
    }
}
