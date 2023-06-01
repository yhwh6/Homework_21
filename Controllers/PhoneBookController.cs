using Homework_19.Models;
using Microsoft.AspNetCore.Mvc;

public class PhoneBookController : Controller
{
    private PhoneBook phoneBook;

    public PhoneBookController()
    {
        phoneBook = new PhoneBook();
    }

    public IActionResult Index()
    {
        var contacts = phoneBook.GetContacts();
        return View(contacts);
    }

    public IActionResult Details(int id)
    {
        var contacts = phoneBook.GetContacts();
        var contact = contacts.FirstOrDefault(c => c.ID == id);
        return View(contact);
    }
}