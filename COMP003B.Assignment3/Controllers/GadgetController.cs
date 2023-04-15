using COMP003B.Assignment3_.Models;
using Microsoft.AspNetCore.Mvc;
using COMP003B.Assignment3_.Models.Domain;
using COMP003B.Assignment3_.Data;
using Microsoft.EntityFrameworkCore;

namespace COMP003B.Assignment3_.Controllers
{
    public class GadgetController : Controller
    {
        private readonly MVCDemoDBContext mvcDemoDBContext;
        public GadgetController(MVCDemoDBContext mvcDemoDBContext)
        {
            this.mvcDemoDBContext = mvcDemoDBContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var gadgets = await mvcDemoDBContext.Gadgets.ToListAsync();
            return View(gadgets);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Addgadget addGadgetRequest)
        {
            var gadget = new gadget()
            {
                Id = Guid.NewGuid(),
                Name = addGadgetRequest.Name,
                Price = addGadgetRequest.Price,
            };

            await mvcDemoDBContext.AddAsync(gadget);
            await mvcDemoDBContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        
    }
}
