using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SeoulWEBSession3.Models;
using SeoulWEBSession3.Models.PropertyViewModel;

namespace SeoulWEBSession3.Controllers
{
    public class PropertiesController : Controller
    {
        private readonly SeoulStayWebsession3Context context;

        public PropertiesController (SeoulStayWebsession3Context ctx)
        {
            this.context = ctx;
        }
        public async Task<IActionResult> Index(string? searchTerm)
        {
            var user =  context.Users.FirstOrDefault(u=>u.Id == 3);
            ViewData["UserFullName"] = user?.FullName ?? "Guest";

            var itemQuery = context.Items.Include(i => i.Area)
                .Include(i => i.ItemPictures).AsQueryable();

            if(!string.IsNullOrWhiteSpace(searchTerm))
            {
                itemQuery = itemQuery.Where(i=>i.Area.Name.Contains(searchTerm) || i.Title.Contains(searchTerm));

            }

            var items = await itemQuery.
                Select(i => new PropertyViewModel
                {
                    Id = i.Id,
                    Title = i.Title,
                    Area = i.Area.Name,
                    Capacity = i.Capacity,
                    ImageUrl = i.ItemPictures.FirstOrDefault() != null
                        ? i.ItemPictures.FirstOrDefault().PictureFileName
                        : "default.jpg"
                }).ToListAsync();

            
            return View(items);
        }

        public async Task<IActionResult> Details(int id)
        {
            var property = await context.Items.
                Include(i => i.Area)
                .Include(i => i.ItemAmenities).
                ThenInclude(iA => iA.Amenity).
                Include(i => i.ItemPictures).
                FirstOrDefaultAsync(i => i.Id == id);

            if (property == null)
            {
                return NotFound();
            }

            var latesPrice = await context.ItemPrices.
                Where(p => p.ItemId == id).
                OrderByDescending(p => p.Date).
                Select(p => p.Price).
                FirstOrDefaultAsync();

            var viewModel = new PropertyDetailsViewModel
            {
                Title = property.Title,
                Area = property.Area.Name,
                Capacity = property.Capacity,
                NumberOfBathrooms = property.NumberOfBathrooms,
                NumberOfBedrooms = property.NumberOfBedrooms,
                NumberOfBeds = property.NumberOfBeds,
                Description = property.Description,
                HostRules = property.HostRules,
                Amenities = property.ItemAmenities.Select(a=>a.Amenity.Name).ToList(),
                Images = property.ItemPictures.Select(p=>p.PictureFileName).ToList(),
                Price = latesPrice

            };

            return View(viewModel);
        }

       
    }
}
