﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using hw11.Data;
using hw11.Models;
using Microsoft.EntityFrameworkCore;

namespace hw11.Controllers
{
    public class NoteController : Controller
    {
        private readonly ApplicationDbContext _context; 

        public NoteController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Note> notes = _context.Notes;    
            return View(notes);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Note note )
        {
           if(ModelState.IsValid)
           {
                note.CreatedAt = DateTime.Now;  
                _context.Notes.Add(note);
                _context.SaveChanges();
                return RedirectToAction("Index");   
           }

           return View(note);   
        }

        public IActionResult Edit(int id)
        {
            var note = _context.Notes.Find(id);
            if (note == null)
            {
                return NotFound();
            }
            return View(note);  
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Note note)
        {
           if (ModelState.IsValid)
           {
                _context.Notes.Update(note);
                _context.SaveChanges();
                return RedirectToAction("Index");
           }
           return View(note);   
        }

        public IActionResult Delete(int? id)
        {
            var note = _context.Notes.Find(id);
            if (note == null)
            {
                return NotFound();
            }
            return View(note);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteNote(int? id)
        {
            var note = _context.Notes.Find(id);
            if (note == null)
            {
                return NotFound();
            }
            _context.Notes.Remove(note);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
