using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GmJournal.Data.Configuration;
using GmJournal.Data.Entities;
using GmJournal.Logic.Services.Users;
using GmJournal.Data.ViewModels;

namespace GmJournal.WebApp.Controllers
{
    public class CharactersController : Controller
    {
        private readonly GmJournalDbContext _context;
        private readonly IUserAccessService _userAccessService;
        private User? _LoggedUser;

        public CharactersController(GmJournalDbContext context, IUserAccessService userAccessService)
        {
            _context = context;
            _userAccessService = userAccessService;

            if (_userAccessService.LoggedUser != null)
                _LoggedUser = _userAccessService.LoggedUser;
        }

        // GET: Characters
        public async Task<IActionResult> Index()
        {
              return _context.Characters != null ? 
                          View(await _context.Characters.ToListAsync()) :
                          Problem("Entity set 'GmJournalDbContext.Characters'  is null.");
        }

        // GET: Characters/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.Characters == null)
            {
                return NotFound();
            }

            var character = await _context.Characters
                .FirstOrDefaultAsync(m => m.Id == id);
            if (character == null)
            {
                return NotFound();
            }

            return View(character);
        }

        // GET: Characters/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Characters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("name,sex,age,race,social_standing,homeland,intelligence,reflex,dexterity,body,speed,empathy,craft,will,luck,Id,CreationDate")] characterModel characterModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(new Character(characterModel,_LoggedUser, /*TEST, TO CHANGE*/ _LoggedUser.Worlds.FirstOrDefault()));
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(characterModel);
        }

        // GET: Characters/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.Characters == null)
            {
                return NotFound();
            }

            var character = await _context.Characters.FindAsync(id);
            if (character == null)
            {
                return NotFound();
            }
            return View(character);
        }

        // POST: Characters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("hp,run,leap,stun,stamina,recovery,encumbrance,name,sex,age,race,social_standing,homeland,intelligence,reflex,dexterity,body,speed,empathy,craft,will,luck,Id,CreationDate")] Character character)
        {
            if (id != character.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(character);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CharacterExists(character.Id))
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
            return View(character);
        }

        // GET: Characters/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.Characters == null)
            {
                return NotFound();
            }

            var character = await _context.Characters
                .FirstOrDefaultAsync(m => m.Id == id);
            if (character == null)
            {
                return NotFound();
            }

            return View(character);
        }

        // POST: Characters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.Characters == null)
            {
                return Problem("Entity set 'GmJournalDbContext.Characters'  is null.");
            }
            var character = await _context.Characters.FindAsync(id);
            if (character != null)
            {
                _context.Characters.Remove(character);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CharacterExists(long id)
        {
          return (_context.Characters?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
