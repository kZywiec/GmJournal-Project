using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GmJournal.Data.Configuration;
using GmJournal.Data.Entities;
using GmJournal.Logic.Services.Users;
using GmJournal.Data.ViewModels;

namespace GmJournal.WebApp.Controllers
{
    public class WorldsController : Controller
    {
        private readonly GmJournalDbContext _context;
        private readonly IUserAccessService _userAccessService;
        private User _LoggedUser;

        public WorldsController(GmJournalDbContext context, IUserAccessService userAccessService)
        {
            _context = context;
            _userAccessService = userAccessService;
            
            if(userAccessService.LoggedUser != null)
                _LoggedUser = userAccessService.LoggedUser;
        }

        // GET: Worlds
        public async Task<IActionResult> Index()
        {
            if(!_userAccessService.IsUserLogged())
                return RedirectToAction("Login", "Access");

            var userId = _LoggedUser.Id;
            var worlds = await _context.Worlds
                               .Where(w => w.Users.Any(u => u.Id == userId))
                               .ToListAsync();

            return worlds != null ?
                   View(worlds) :
                   NotFound();
        }

        // GET: Worlds/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.Worlds == null)
            {
                return NotFound();
            }

            var world = await _context.Worlds
                .FirstOrDefaultAsync(m => m.Id == id);
            if (world == null)
            {
                return NotFound();
            }

            return View(world);
        }

        // GET: Worlds/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Worlds/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Description,NextSessionDate,Id")] worldModel worldModel)
        {
            if (!_userAccessService.IsUserLogged())
                return Unauthorized();

            World world = new(worldModel, _LoggedUser);

            if (ModelState.IsValid)
            {
                _context.Worlds.Add(world);

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(worldModel);
        }

        // GET: Worlds/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.Worlds == null)
            {
                return NotFound();
            }

            var world = await _context.Worlds.FindAsync(id);
            if (world == null)
            {
                return NotFound();
            }
            return View(world);
        }

        // POST: Worlds/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Name,Description,NextSessionDate,Id,CreationDate")] worldModel worldModel)
        {
            if (id != worldModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    World world = await _context.Worlds.FindAsync(id);
                    world.Edit(worldModel);
                    _context.Entry(world).State = EntityState.Modified;
                    
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorldExists(id))
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
            return View(worldModel);
        }

        // GET: Worlds/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.Worlds == null)
            {
                return NotFound();
            }

            var world = await _context.Worlds
                .FirstOrDefaultAsync(m => m.Id == id);
            if (world == null)
            {
                return NotFound();
            }

            return View(world);
        }

        // POST: Worlds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.Worlds == null)
            {
                return Problem("Entity set 'GmJournalDbContext.Worlds'  is null.");
            }
            var world = await _context.Worlds.FindAsync(id);
            if (world != null)
            {
                var usersWithWorld = from user in _context.Users.Include(u => u.Worlds)
                                     where user.Worlds.Contains(world)
                                     select user;

                _context.Worlds.Remove(world);
                _context.Characters.RemoveRange(world.Characters);


            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorldExists(long id)
        {
          return (_context.Worlds?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
