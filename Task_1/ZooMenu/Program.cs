using ZooMenu.Models;
namespace ZooMenu;

class MainClass
{
    static void Main(string[] args)
    {
        bool showMenu = true;
        while (showMenu)
        {
            showMenu = Menu.MainMenu();
        }
    }
}