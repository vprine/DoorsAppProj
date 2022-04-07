using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DoorModels;

namespace DoorsAppProj.Controllers
{
    public class DoorController : Controller
    {
        // GET: Door  
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult AddDoor([FromBody] Door stu)
        {
            if (stu != null)
            {
                using (var dbContext = new DoorsContext())
                {
                    dbContext.Doors.Add(stu);
                    dbContext.SaveChanges();
                    return Json(stu);
                }
            }
            else
            {
                return Json("Some Error Occured");
            }
        }
        [HttpPost]
        public string UpdateDoor([FromBody] Door stu)
        {
            if (stu != null)
            {
                using (var dbContext = new DoorsContext())
                {
                    Door lstDoor = dbContext.Doors.Where(x => x.Id == stu.Id).FirstOrDefault();
                    lstDoor.GivenName = stu.GivenName;
                    lstDoor.IsClosed = stu.IsClosed;
                    lstDoor.IsLocked = stu.IsLocked;
                    dbContext.SaveChanges();
                    return "Door Updated";
                }
            }
            else
            {
                return "Oops! something went wrong.";
            }
        }
        public JsonResult GetDoorList()
        {
            using (var dbContext = new DoorsContext())
            {
                List<Door> doorList = dbContext.Doors.ToList();
                return Json(doorList);
            }
        }
        [HttpPost]
        public string DeleteDoor([FromBody] Door stu)
        {
            if (stu.Id != 0)
            {
                using (var dataContext = new DoorsContext())
                {
                    // int id = Convert.ToInt32(Id);  
                    var lstStud = dataContext.Doors.Where(x => x.Id == stu.Id).FirstOrDefault();
                    dataContext.Doors.Remove(lstStud);
                    dataContext.SaveChanges();
                    return "Door has been deleted succhessfully.";
                }
            }
            else
            {
                return " Oops! Error occered.";
            }
        }
    }
}