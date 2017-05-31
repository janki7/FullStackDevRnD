﻿using FullstackPluralsightProjectToLearn.DTO;
using FullstackPluralsightProjectToLearn.Models;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Http;

namespace FullstackPluralsightProjectToLearn.Controllers
{



    [Authorize]
    public class AttendancesController : ApiController
    {
        private ApplicationDbContext _context;

        public AttendancesController()
        {
            _context = new ApplicationDbContext();
        }
        [HttpPost]
        public IHttpActionResult Attend(AttendanceDto dto)
        {
            var userId = User.Identity.GetUserId();

            var exists = _context.Attendences.Any(a => a.AttendeeId == userId && a.GigId == dto.GigId );
            if(exists)
            {
                return BadRequest("Attendance Already Exists");
            }

            var attendance = new Attendance
            {
                GigId = dto.GigId,
                AttendeeId = userId

            };
            _context.Attendences.Add(attendance);
            _context.SaveChanges();

            return Ok();
        }

    }
}