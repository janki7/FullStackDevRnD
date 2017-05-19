using FullstackPluralsightProjectToLearn.Models;
using FullstackPluralsightProjectToLearn.ViewModel;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Mvc;

namespace FullstackPluralsightProjectToLearn.Controllers
{
    public class GigsController : Controller
    {
        //coz only initialised in constructor, rest all places within this class its being only used to read
        private readonly ApplicationDbContext _context;
        public GigsController()
        {
            _context = new ApplicationDbContext();
        }

        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new GigFormViewModel
            {
                Genres = _context.Genres.ToList()
            };
            return View(viewModel);
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GigFormViewModel viewModel)
        {
            //convert to gig object to save changes
            //var artistId = User.Identity.GetUserId();
            //// 3 round trips extra.. if fetch seperately 

            //var artist = _context.Users.Single(u => u.Id == artistId );
            //var genre = _context.Genres.Single(g => g.Id == viewModel.Genre);

            if (!ModelState.IsValid)
            {
                viewModel.Genres = _context.Genres.ToList();
                return View("Create", viewModel);
            }

            var gig = new Gig
            {
                ArtistId = User.Identity.GetUserId(),
                GenreId = viewModel.Genre,
                DateTime = viewModel.GetDateTime(),  // controller should not do things, but just manage , should be view model who does conversions 
                Venue = viewModel.Venue
            };

            _context.Gigs.Add(gig);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}