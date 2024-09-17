using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuestRoomMVC.Data;
using QuestRoomMVC.Models;
using System.Diagnostics;

namespace QuestRoomMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly QRContext _context;

        public HomeController(QRContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string searchString, int? difficultyLevel, int? minPlayers, int? fearLevel)
        {
            var questRooms = _context.QuestRooms.AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                questRooms = questRooms.Where(q => q.Name.Contains(searchString));
            }

            if (difficultyLevel.HasValue)
            {
                questRooms = questRooms.Where(q => q.DifficultyLevel == difficultyLevel.Value);
            }

            if (minPlayers.HasValue)
            {
                questRooms = questRooms.Where(q => q.MinPlayers >= minPlayers.Value);
            }

            if (fearLevel.HasValue)
            {
                questRooms = questRooms.Where(q => q.FearLevel == fearLevel.Value);
            }

            return View(await questRooms.ToListAsync());
        }

        public async Task<IActionResult> Details(int id)
        {
            var questRoom = await _context.QuestRooms.FindAsync(id);

            if (questRoom == null)
            {
                return NotFound();
            }

            return View(questRoom);
        }
    }
}

