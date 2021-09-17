using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkPrototypeConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Создание пользователей
            TwitterUser user1 = new TwitterUser("user1");
            TwitterUser user2 = new TwitterUser("user2");
            TwitterUser user3 = new TwitterUser("user3");
            TwitterUser user4 = new TwitterUser("user4");

            // подписка пользователей методом Tape (отображение сообщений на стене) на событие Post,
            // которое будет вызвано в методе публикации сообщений пользователя 1
            user1.Post += user2.Tape;
            user1.Post += user3.Tape;
            user1.Post += user4.Tape;

            // Публикация сообщения пользователем 1
            user1.PublicMessage("Всем привет!");

            Console.ReadKey();
        }
    }
}
