using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieAsp.Data;
using MovieAsp.Models;

namespace MovieAsp.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MovieDBContext _context;

        public MoviesController(MovieDBContext context)
        {
            _context = context;
        }

        // GET: Movies
        public async Task<IActionResult> Index()
        {
            return View(await _context.Movies.ToListAsync());
        }

        // GET: Movies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movies
                .FirstOrDefaultAsync(m => m.ID == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // GET: Movies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Title,Summary,ReleaseDate,Genre,Price,Rated,PicturePath")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            if (movie.PictureUpload != null)
            {
                string path =
                Path.Combine(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images"),
                Path.GetFileName(movie.PictureUpload.FileName));
                using (var stream = System.IO.File.Create(path))
                {
                    movie.PictureUpload.CopyTo(stream);
                }
                string pathInDb = "/images/" + Path.GetFileName(movie.PictureUpload.FileName);
                movie.PicturePath = pathInDb;
            }
            else
            {
                //Kiem bat ky hinh No Image tren internet
                movie.PicturePath = "/images/no-image.jpg";
            }

            var db = new MovieDBContext();
            ViewBag.ListGenre = db.Genres.Select(x => new SelectListItem()
            { Text = x.Name, Value = x.ID.ToString() }).Distinct().ToList();

            _context.Add(movie);

            return View(movie);
        }

        // GET: Movies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movies.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Title,Summary,ReleaseDate,Genre,Price,Rated,PicturePath")] Movie movie)
        {
            if (id != movie.ID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    if (movie.PictureUpload != null)
                    {
                        string path =
                        Path.Combine(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images"),
                        Path.GetFileName(movie.PictureUpload.FileName));
                        using (var stream = System.IO.File.Create(path))
                        {
                            movie.PictureUpload.CopyTo(stream);
                        }
                        string pathInDb = "/images/" + Path.GetFileName(movie.PictureUpload.FileName);
                        movie.PicturePath = pathInDb;
                    }
                    else
                    {
                        //Kiem bat ky hinh No Image tren internet
                        movie.PicturePath = "/images/no-image.jpg";
                    }
                    _context.Update(movie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(movie.ID))
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
            return View(movie);
        }

        // GET: Movies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movies
                .FirstOrDefaultAsync(m => m.ID == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieExists(int id)
        {
            return _context.Movies.Any(e => e.ID == id);
        }

        public ActionResult AddToCart(int id)
        {
            //Kiem tra Id movie ton tai hay khong
            var movie = _context.Movies.Where(x => x.ID
            == id).FirstOrDefault();
            if (movie == null)
            {
                return RedirectToAction("Index");
            }
            var hoaDon =
            HttpContext.Session.Get<HoaDon>("HoaDon");
            if (hoaDon == null)
            {
                hoaDon = new HoaDon();
                hoaDon.NgayLap = DateTime.Now;
                hoaDon.ChiTietHoaDons = new
                List<ChiTietHoaDon>();
                _context.HoaDons.Add(hoaDon);
            }

            //Kiem tra don hang da co truoc do
            var chiTietHoaDon =
            hoaDon.ChiTietHoaDons.Where(x => x.MovieObj.ID ==
            id).FirstOrDefault();
            if (chiTietHoaDon == null)
            {
                chiTietHoaDon = new ChiTietHoaDon();
                chiTietHoaDon.MaMovie = id;
                chiTietHoaDon.MovieObj = movie;
                chiTietHoaDon.HoaDonObj = hoaDon;
                chiTietHoaDon.SoLuong = 1;
                hoaDon.ChiTietHoaDons.Add(chiTietHoaDon);
            }
            else
            {
                chiTietHoaDon.SoLuong++;
            }
            HttpContext.Session.Set<HoaDon>("HoaDon", hoaDon);
            _context.SaveChanges();

            return View(hoaDon);
        }

        public ActionResult RemoveFromCart(int maMovies)
        {
            var hoaDon = HttpContext.Session.Get<HoaDon>("HoaDon");
            var chiTietHoaDon = hoaDon.ChiTietHoaDons.Where(x =>
            x.MovieObj.ID == maMovies).FirstOrDefault();
            hoaDon.ChiTietHoaDons.Remove(chiTietHoaDon);
            return View("AddToCart", hoaDon);
        }

        [HttpPost]
        public ActionResult Checkout(ShippingDetail detail)
        {
            var hoaDon = HttpContext.Session.Get<HoaDon>("HoaDon");
            if (hoaDon.ChiTietHoaDons.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty!");
            }
            if (ModelState.IsValid)
            {
                StringBuilder body = new StringBuilder()
                .AppendLine("A new order has been submitted")
                .AppendLine("---")
                .AppendLine("Items:");
                foreach (var hoaDonChiTiet in hoaDon.ChiTietHoaDons)
                {
                    var subtotal = hoaDonChiTiet.MovieObj.Price * hoaDonChiTiet.SoLuong;
                    body.AppendFormat("{0} x {1} (subtotal: {2:c}", hoaDonChiTiet.SoLuong,
                    hoaDonChiTiet.MovieObj.Title,
                    subtotal);
                }
                body.AppendFormat("Total order value: {0:c}", hoaDon.TongTien)
                .AppendLine("---")
                .AppendLine("Ship to:")
                .AppendLine(detail.Name)
                .AppendLine(detail.Address)
                .AppendLine(detail.Mobile.ToString());

                HttpContext.Session.Set<HoaDon>("HoaDon", null);
                return View("CheckoutCompleted");
            }
            else
            {
                return View(new ShippingDetail());
            }

        }       
    }
}
