namespace Homework_21.Models
{
    public class PhoneBook
    {
        private List<Contact> contacts;

        public PhoneBook()
        {
            contacts = new List<Contact>();
        }

        public List<Contact> GetContacts()
        {
            return contacts;
        }

        public void AddContact(Contact contact)
        {
            contacts.Add(contact);
        }
    }
}
