using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Contact_List_Exercise.Models;

namespace Contact_List_Exercise.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly ContactContext _context;
        private  List<Contact> _contacts = new List<Contact>();

        public ContactsController(ContactContext context)
        {
            _context = context;
            //EnableTestData();
        }

        private void EnableTestData()
        {
            _context.Contacts.Add(new Contact("Jakob", "Aschauer", "test@mymail.com"));
            _context.Contacts.Add(new Contact("Max", "Mustermann", "max@mustermann.com"));
            _context.SaveChanges();
        }

        [HttpGet]
        public IActionResult GetAllItems()
        {
            return Ok(_context.Contacts.ToList());
        }

        // GET: api/Contacts/1
        [HttpGet("findByName")]
        public ActionResult<Contact> GetContact(string nameFilter)
        {
            var contacts = _context.Contacts.Where(p => p.Lastname.StartsWith(nameFilter));
            if (contacts.ToList().Count > 0)
                return Ok(contacts);
            else
                return NotFound();
        }


        // POST: api/Contacts
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public ActionResult<Contact> PostContact(Contact contact)
        {
            _context.Contacts.Add(contact);
            _context.SaveChanges();
            return CreatedAtAction("GetContact", new { id = contact.Id }, contact);
        }

        // DELETE: api/Contacts/5
        [HttpDelete("{personId}")]
        public ActionResult<Contact> DeleteContact(int personId)
        {
            try
            {
                Contact contact = _context.Contacts.Find(personId);
                _context.Contacts.Remove(contact);
                _context.SaveChanges();

                return NoContent();
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e);
                return NotFound();
            }
        }
    }
}
