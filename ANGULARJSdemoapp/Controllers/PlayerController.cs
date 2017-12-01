using ANGULARJSdemoapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ANGULARJSdemoapp.Controllers
{
    public class PlayerController : Controller
    {
        private CrudContext _context = null;
        public PlayerController()
        {
            _context = new CrudContext();
        }
        //// Get all players
        public JsonResult GetPlayers()
        {
            List<Player> listPlayers = _context.Players.ToList();
            return Json(new { list = listPlayers },
             JsonRequestBehavior.AllowGet);
        }



        ////Get by Id player

        public JsonResult GetPlayerbyId(int id)
        {
            Player player = _context.Players
            .Where(c => c.PlayerId == id).SingleOrDefault();
            return Json(new { player = player },
                JsonRequestBehavior.AllowGet
               );

        }


        //// post data or add a player

        public JsonResult AddPlayer(Player player)
        {
            _context.Players.Add(player);
            _context.SaveChanges();
            return Json(new { status = "player added sucessfully" }
     
              );
        }



        /// update data or edit any player
   public JsonResult  UpdatePlayer(Player player)
        {
            _context.Entry(player).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
            return Json(new { status = "player updated sucessfully" }
            );
        }
    

        /// delete data or record of a player
        public JsonResult DeletePlayer(int id)
        {
            Player player = _context.Players
            .Where(c => c.PlayerId == id).SingleOrDefault();
            _context.Players.Remove(player);
            _context.SaveChanges();
            return Json(new { status = "player deleted sucessfully" }
           );
        }

    }
}