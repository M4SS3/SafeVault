using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeIt.DAL
{
    public class Idea
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

 //       public int UpVotes { get; set; }

 //       public int DownVotes { get; set; }

//        public int Petition { get; set; }

        public virtual IList<User> Users { get; set; }
    }
}
