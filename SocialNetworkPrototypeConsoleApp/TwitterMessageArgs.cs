using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkPrototypeConsoleApp
{
    public class TwitterMessageArgs
    {
        public string Time { get; set; }
        public string Message { get; set; }
        public Content[] Objs { get; set; }
    }
}
