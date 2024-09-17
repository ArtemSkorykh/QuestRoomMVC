using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuestRoomMVC.Data;
using QuestRoomMVC.Models;
using System.Linq;

namespace QuestRoomMVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly QRContext _context;

        public AdminController(QRContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ManageRooms()
        {
            var rooms = _context.QuestRooms.ToList(); 
            return View(rooms); 
        }

        public IActionResult EditRoom(int id)
        {
            var room = _context.QuestRooms.FirstOrDefault(r => r.Id == id);
            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditRoom(QuestRoom room)
        {
            if (ModelState.IsValid)
            {
                _context.QuestRooms.Update(room);
                _context.SaveChanges();
                return RedirectToAction(nameof(ManageRooms));
            }

            return View(room);
        }

        public IActionResult CreateRoom()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateRoom(QuestRoom room)
        {
            if (ModelState.IsValid)
            {
                _context.QuestRooms.Add(room);
                _context.SaveChanges();
                return RedirectToAction(nameof(ManageRooms));
            }

            return View(room);
        }

        public IActionResult DeleteRoom(int id)
        {
            var room = _context.QuestRooms.FirstOrDefault(r => r.Id == id);
            if (room == null)
            {
                return NotFound();
            }

            _context.QuestRooms.Remove(room);
            _context.SaveChanges();
            return RedirectToAction(nameof(ManageRooms));
        }
    }
}