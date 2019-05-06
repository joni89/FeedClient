using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedClient.Model
{
    public class User
    {
        private long? id;
        private string username;
        private string name;

        public long? Id { get => id; set => id = value; }
        public string Username { get => username; set => username = value; }
        public string Name { get => name; set => name = value; }
    }
}
