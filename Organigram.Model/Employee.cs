namespace Organigram.Model
{
    using System.Collections.Generic;

    using Qi.Data;

    public class Employee : Entity
    {
        public string Forename { get; set; }

        public string Surname { get; set; }

        public ICollection<Media> Media { get; set; }
    }

    public class Media : Entity
    {        
    }

    public class Organigram : Entity
    {
        public string Name { get; set; }
    }
}