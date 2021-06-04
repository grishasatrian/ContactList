using System;

namespace ContactList
{
    class Program
    {
        static void Main(string[] args)
        {
            var phoneBook = new PhoneBook();
            phoneBook.MainMenuShow();
            var userInput = Console.ReadLine();
            while (true)
            {
                switch (userInput)
                {
                    case "1":
                        Console.WriteLine(" Input contact full name:");
                        var name = Console.ReadLine();
                        Console.WriteLine(" Input contact Phone Number:");
                        var email = Console.ReadLine();
                        Console.WriteLine(" Input contact Email:");
                        var phone = Console.ReadLine();
                        Console.WriteLine(" Input contact physical address:");
                        var address = Console.ReadLine();                        
                        Console.Clear();
                        phoneBook.MainMenuShow();
                        phoneBook.AddContact(name, email, phone, address);
                        break;
                    case "2":
                        phoneBook.DisplayAllContact();
                        break;
                    case "3":
                        Console.WriteLine(" Please input user ID");
                        var searchId = Console.ReadLine();
                        phoneBook.SearchContactById(searchId);
                        break;
                    case "4":
                        Console.WriteLine(" Please input user Name");
                        var searchByName = Console.ReadLine();
                        phoneBook.SearchContactByName(searchByName);
                        break;
                    case "5":
                        Console.WriteLine(" Please input user ID");
                        var editId = Console.ReadLine();
                        int index = phoneBook.CanEdit(editId);
                        if(index < 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(" Contact not found!");
                            Console.ResetColor();
                            break;
                        }
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(" If you do not write anything, the contact details will remain the same \n");
                        Console.ResetColor();
                        Console.WriteLine(" Input contact full name:");
                        name = Console.ReadLine();
                        Console.WriteLine(" Input contact Email:");
                        email = Console.ReadLine();
                        Console.WriteLine(" Input contact Phone number:");
                        phone = Console.ReadLine();
                        Console.WriteLine(" Input contact physical address:");
                        address = Console.ReadLine();
                        phoneBook.EditContact(index,name, email, phone, address);
                        break;
                    case "6":
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(" Please input contact ID:");
                        Console.ResetColor();
                        var removeId = Console.ReadLine();
                        int index1 = phoneBook.CanEdit(removeId);
                        if (index1 < 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(" Contact not found!");
                            Console.ResetColor();
                            break;
                        }
                        phoneBook.RemoveContactById(index1, removeId);
                        break;
                    case "x":
                        return;
                    case "X":
                        return;
                    case "c":
                        phoneBook.CleanConsoleFromMenue(userInput);
                        break;
                    case "C":
                        phoneBook.CleanConsoleFromMenue(userInput);
                        break;
                    default:
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.Beep(1500, 500);
                        Console.WriteLine(" Unidentified operation!");
                        Console.ResetColor();
                        break;
                }
                Console.WriteLine(" * Select option *");
                userInput = Console.ReadLine();
            }
        }
    }
}
