using Realms;
using System;

namespace ProjetoCondominioSmart.Models
{
    public class Scheduling : RealmObject
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Massage { get; set; }
        public int Hour { get; set; }
        public int Minute { get; set; }
    }
}
