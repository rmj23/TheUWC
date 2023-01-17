using Source.Data;
using System.Collections.Generic;

namespace Source.Models
{
    public class ContactModelViewModel
    {
        public ContactModel Contact { get; set; }
        public List<ContactModel> AllContacts { get; set; }

        public ContactModelViewModel()
        {
            Repository repo = new Repository();

            AllContacts = repo.ContactSelectAllRequest();
            //AllContacts = ContactModelDb.SelectAll();
        }
    }
}