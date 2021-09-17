using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkPrototypeConsoleApp
{
    /// <summary>
    /// Пользователь
    /// </summary>
    class TwitterUser
    {
        /// <summary>
        /// Никнейм пользователя
        /// </summary>
        public string Nick { get; set; }
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="Nick">Никнейм пользователя</param>
        public TwitterUser(string Nick)
        {
            this.Nick = $"@{Nick}";
        }
        /// <summary>
        /// Публикация сообщений
        /// </summary>
        /// <param name="Msg"></param>
        public void PublicMessage(string Msg)
        {
            var args = new TwitterMessageArgs()
            {
                Time = DateTime.Now.ToShortTimeString(),
                Message = Msg
            };
            Console.WriteLine($"Сообщение: \"{Msg}\" опубликовал пользователь {Nick}\n");

            post?.Invoke(this, args);
        }
        /// <summary>
        /// Публикация сообщений
        /// </summary>
        /// <param name="Msg"></param>
        public void PublicMessage(string Msg,params Content[] Docs)
        {
            var args = new TwitterMessageArgs()
            {
                Time = DateTime.Now.ToShortTimeString(),
                Message = Msg,
                Objs = Docs
            };
            Console.WriteLine($"Сообщение: \"{Msg}\" опубликовал пользователь {Nick}\n");

            post?.Invoke(this, args);
        }
        /// <summary>
        /// Создание события подписки
        /// </summary>
        private event Action<object, TwitterMessageArgs> post;
        /// <summary>
        /// Свойство к событию подписки
        /// </summary>
        public event Action<object, TwitterMessageArgs> Post
        {
            add // Организация подписки
            {
                Console.WriteLine($"У пользователя {this.Nick} новый подписчик {(value.Target as TwitterUser).Nick}");
                post += value; 
            }
            remove // Организация отписки
            {
                Console.WriteLine($"От пользователя {this.Nick} отписался {(value.Target as TwitterUser).Nick}");
                post -= value;
            }
        }

        /// <summary>
        /// Механизм отображения всех сообщений текущего пользователя в ленте
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Tape(object sender, TwitterMessageArgs e)
        {
            var user = sender as TwitterUser;

            Console.WriteLine($"--->Лента {this.Nick}: {user.Nick} опубликовал {e.Message}");
            if(e.Objs != null)
            {
                Console.Write(" и ");
                foreach(var args in e.Objs)
                {
                    Console.WriteLine(args.GetType().Name);
                }
            }
        }
    }
}
