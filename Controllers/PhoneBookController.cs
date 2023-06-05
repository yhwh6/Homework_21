using Homework_21.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

public class PhoneBookController : Controller
{
    private readonly PhoneBookContext _context;

    public PhoneBookController(PhoneBookContext context)
    {
        _context = context;
    }

    // GET: /PhoneBook/
    [Authorize(Roles = "Anonymous")]
    public IActionResult Index()
    {
        var contacts = _context.Contacts.ToList();
        return View(contacts);
    }

    // GET: /PhoneBook/Details/
    [Authorize(Roles = "Anonymous,Authorized,Administrator")]
    public IActionResult Details(int id)
    {
        var contact = _context.Contacts.FirstOrDefault(c => c.ID == id);
        if (contact == null)
        {
            return NotFound();
        }
        return View(contact);
    }

    // GET: /PhoneBook/Create
    [Authorize(Roles = "Authorized,Administrator")]
    public IActionResult Create()
    {
        return View();
    }

    // POST: /PhoneBook/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = "Authorized,Administrator")]
    public IActionResult Create(Contact contact)
    {
        if (ModelState.IsValid)
        {
            _context.Contacts.Add(contact);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        return View(contact);
    }

    // GET: /PhoneBook/Edit/
    [Authorize(Roles = "Administrator")]
    public IActionResult Edit(int id)
    {
        var contact = _context.Contacts.FirstOrDefault(c => c.ID == id);
        if (contact == null)
        {
            return NotFound();
        }
        return View(contact);
    }

    // POST: /PhoneBook/Edit/
    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = "Administrator")]
    public IActionResult Edit(int id, Contact contact)
    {
        if (id != contact.ID)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(contact);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactExists(contact.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(contact);
    }

    // GET: /PhoneBook/Delete/
    [Authorize(Roles = "Administrator")]
    public IActionResult Delete(int id)
    {
        var contact = _context.Contacts.FirstOrDefault(c => c.ID == id);
        if (contact == null)
        {
            return NotFound();
        }
        return View(contact);
    }

    // POST: /PhoneBook/Delete/
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = "Administrator")]
    public IActionResult DeleteConfirmed(int id)
    {
        var contact = _context.Contacts.Find(id);
        _context.Contacts.Remove(contact);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }

    private bool ContactExists(int id)
    {
        return _context.Contacts.Any(c => c.ID == id);
    }
}
