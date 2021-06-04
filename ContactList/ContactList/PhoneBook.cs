using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ContactList
{
    class PhoneBook
    {
        List<Contact> _contacts = new List<Contact>();
        int _id = 1;

        private void DisplayContactDetails(Contact contact)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($" Contact's ID : {contact.Id}");
            Console.ResetColor();
            Console.WriteLine($" Contact's name: {contact.Name} \n" +
                $" Contact's number: {contact.Email} \n" +
                $" Contact's email: {contact.Phone} \n" +
                $" Contact's address: {contact.Address} \n ");
        }
        private void DisplayContactDetails(List<Contact> contacts)
        {
            foreach (var contact in contacts)
            {
                DisplayContactDetails(contact);
            }
        }
        // Display all contacts
        public void DisplayAllContact()
        {
            if (_contacts.Count() == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" Contact List is empty!");
                Console.ResetColor();
                return;
            }
            DisplayContactDetails(_contacts);
            CleanConsole();
        }
        // Search contact by ID
        public void SearchContactById(string id)
        {
            // Handling exeptions with inputed string ...
            int input = 0;
            if (!Int32.TryParse(id, out input))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" ID is number !!!");
                Console.ResetColor();
                return;
            }            
            if (id == "")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" Please input ID");
                Console.ResetColor();
                return;
            }
            else
            {
                foreach (var contact in _contacts)
                {
                    if (contact.Id == Int32.Parse(id))
                    {
                        DisplayContactDetails(contact);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        CleanConsole();
                        return;
                    }
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" Contact not found!");
                Console.ResetColor();
                return;
            }
        }
        public void SearchContactByName(string name)
        {
            if (name == "")
            {
                Console.WriteLine(" Please input Contact name");
                return;
            }
            else
            {
                bool found = false;
                foreach (var contact in _contacts)
                {
                    if (contact.Name.Contains(name))
                    {
                        DisplayContactDetails(contact);
                        found = true;
                    }
                }
                if (!found)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" Contact not found!");
                    Console.ResetColor();
                }
                CleanConsole();
            }
        }
        // Edit contact
        public int CanEdit(string editId)
        {
            // Handling exeptions with inputed string ...
            int id = 0;
            if (!Int32.TryParse(editId,out id))
                return -1;
            for (int i = 0; i< _contacts.Count; i++)
            {
                if(_contacts[i].Id == Int32.Parse(editId))
                {
                    return i;
                }
            }
            return -1;
        }
        // Adding new contact
        public void AddContact(string name, string email, string phone, string address)
        {
            if (name.Length == 0)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine(" Please input name!");
                Console.ResetColor();
                return;
            }
            if (email.Length == 0)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine(" Please input email!");
                Console.ResetColor();
                return;
            }
            if (phone.Length == 0)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine(" Please input phone!");
                Console.ResetColor();
                return;
            }
            if (address.Length == 0)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine(" Please input address!");
                Console.ResetColor();
                return;
            }
            _contacts.Add(new Contact(_id++,name, email, phone, address));
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($" Contact {name} Successfully added!");
            Console.ResetColor();
            return;
        }
        // Edit contact
        public void EditContact(int index, string name, string email, string phone, string address)
        {
            
            if (name != "")
            {
                _contacts[index].Name = name;
            }
            if (email != "")
            {
                _contacts[index].Email = email;
            }
            else if (phone != "")
            {
                _contacts[index].Phone = phone;
            }
            else if (address != "")
            {
                _contacts[index].Address = address;
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($" Contact details edited successfully \n");
            Console.ResetColor();
            CleanConsole();
        }
        // Remove contact
        public void RemoveContactById(int index, string id)
        {
            // Handling exeptions with inputed string ...
            int input = 0;
            if (!Int32.TryParse(id, out input))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" ID is number !!!");
                Console.ResetColor();
                return;
            }
            if (id == "")
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine(" Please input contact ID");
                Console.ResetColor();
                return;
            }
            if (_contacts[index].Id != Int32.Parse(id) )
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine($" Contact with {id} not found! ");
                Console.ResetColor();
                return;
            }
            else
            {
                for (int i = 0; i < _contacts.Count; i++)
                {
                    if(_contacts[i].Id == Int32.Parse(id))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(" Contact Removed Succesfully!");
                        Console.ResetColor();
                        _contacts.RemoveAt(i);
                        return;
                    }
                }
                Console.Clear();
                CleanConsole();
            }
        }

        public void MainMenuShow()
        {
            Console.Title = "Hello and welcome to Phone book, done by Grisha";
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(" \n ========== Welcome to Phone Book ========== \n ");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("   * Select option *");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(" 1.");
            Console.ResetColor();
            Console.WriteLine(" Add contact");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(" 2.");
            Console.ResetColor();
            Console.WriteLine(" View all contacts");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(" 3.");
            Console.ResetColor();
            Console.WriteLine(" Search contact by ID");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(" 4.");
            Console.ResetColor();
            Console.WriteLine(" Search contact by Name");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(" 5.");
            Console.ResetColor();
            Console.WriteLine(" Edit contact");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(" 6.");
            Console.ResetColor();
            Console.WriteLine(" Remove contact \n");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(" ==> PRESS 'C / c' to clean Console <== ");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" ==> PRESS 'X' to Exit <== \n");
            Console.ResetColor();
        }
        // Cleaning console methods
        public void CleanConsole()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(" Press 'C/c' to clear Console ");
            Console.ResetColor();
            var userInput = Console.ReadLine();
            switch (userInput)
            {
                case "c":
                    Console.Clear();
                    MainMenuShow();
                    break;
                case "C":
                    Console.Clear();
                    MainMenuShow();
                    break;
                default:
                    return;
            }
        }
        public void CleanConsoleFromMenue(string clean)
        {
            switch (clean)
            {
                case "c":
                    Console.Clear();
                    MainMenuShow();
                    break;
                case "C":
                    Console.Clear();
                    MainMenuShow();
                    break;
                default:
                    return;
            }
        }

    }
}
