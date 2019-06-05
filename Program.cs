using System;
using System.Collections.Generic;

namespace exceptionExercise
{
    /*
        1. Add the required classes to make the following code compile.
        HINT: Use a Dictionary in the AddressBook class to store Contacts. The key should be the contact's email address.

        2. Run the program and observe the exception.

        3. Add try/catch blocks in the appropriate locations to prevent the program from crashing
            Print meaningful error messages in the catch blocks.
    */
    class Contact
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }
    class AddressBook
    {
        // public List<Contact>  { get; set; }
        public Dictionary< string , Contact > contactsDic = new Dictionary< string , Contact>();
        public void AddContact(Contact contactName)
            {
               contactsDic.Add( contactName.Email , contactName);
            }
        public Contact GetByEmail(string contactEmail)
            {
               return contactsDic[contactEmail];
            }
    }
    class Program
{

    static void Main(string[] args)
    {
        // Create a few contacts
        Contact bob = new Contact() {
            FirstName = "Bob", 
            LastName = "Smith",
            Email = "bob.smith@email.com",
            Address = "100 Some Ln, Testville, TN 11111"
        };
        Contact sue = new Contact() {
            FirstName = "Sue", 
            LastName = "Jones",
            Email = "sue.jones@email.com",
            Address = "322 Hard Way, Testville, TN 11111"
        };
        Contact juan = new Contact() {
            FirstName = "Juan", 
            LastName = "Lopez",
            Email = "juan.lopez@email.com",
            Address = "888 Easy St, Testville, TN 11111"
        };

        // Create an AddressBook and add some contacts to it
        AddressBook addressBook = new AddressBook();
        try
        {
        addressBook.AddContact(bob);
        addressBook.AddContact(sue);
        addressBook.AddContact(juan);



        // Try to addd a contact a second time
        addressBook.AddContact(sue);

        }

        catch(ArgumentException e)
        {
            Console.WriteLine("you are trying to add the same contact ");
        }


        // try
        // {
        // Create a list of emails that match our Contacts
        List<string> emails = new List<string>() {
            "sue.jones@email.com",
            "juan.lopez@email.com",
            "bob.smith@email.com",
        };

        // Insert an email that does NOT match a Contact
        emails.Insert(1, "not.in.addressbook@email.com");

        //  Search the AddressBook by email and print the information about each Contact
        foreach (string email in emails)
        {
            try
            {
            Contact contact = addressBook.GetByEmail(email);
            Console.WriteLine("----------------------------");
            Console.WriteLine($"FirstName: {contact.FirstName}");
            Console.WriteLine($"LastName: {contact.LastName}");
            Console.WriteLine($"Email: {contact.Email}");
            Console.WriteLine($"Address: {contact.Address}");
        }
        catch(KeyNotFoundException ex)
        {
            Console.WriteLine("couldn't find contact for this email");
        }
        }
    }
}
}
