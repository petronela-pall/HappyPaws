using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HappyPaws.Model.ViewModel
{
    public class PetClientViewModel
    {
        public ApplicationUser  UserObj { get; set; }
        public IEnumerable<Pet>Pets { get; set; }

    }
}
