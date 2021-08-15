using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Restaurant.Domain.Domain;
using Restaurant.Domain.DTO;
using Restaurant.Service.Interface;

namespace Restaurant.Web.Controllers
{
    public class FoodsController : Controller
    {
        private readonly IFoodService _foodService;

        public FoodsController(IFoodService foodService)
        {
            _foodService = foodService;
        }

        // GET: Foods
        public IActionResult Index()
        {
            var allFoods = this._foodService.GetAllFoods();
            return View(allFoods);
        }

        public IActionResult Index1()
        {
            var allFoods = this._foodService.GetAllFoods();
            return View(allFoods);
        }

        public IActionResult Index2()
        {
            var allFoods = this._foodService.GetAllFoods();
            return View(allFoods);
        }


        public IActionResult AddProductToCard(Guid? id)
        {
            var model = this._foodService.GetShoppingCartInfo(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddProductToCard([Bind("FoodId", "Quantity")] AddToShoppingCardDto item)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var result = this._foodService.AddToShoppingCart(item, userId);

            if (result)
            {
                return RedirectToAction("Index", "Foods");
            }

            return View(item);
        }



        // GET: Foods/Details/5
        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var food = this._foodService.GetDetailsForFood(id);
            if (food == null)
            {
                return NotFound();
            }

            return View(food);
        }

        // GET: Foods/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Foods/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Name,Type,Image,Description,Rating,Price,Id")] Food food)
        {
            if (ModelState.IsValid)
            {
                this._foodService.CreateNewFood(food);
                return RedirectToAction(nameof(Index));
            }
            return View(food);
        }

        // GET: Foods/Edit/5
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var food = this._foodService.GetDetailsForFood(id);
            if (food == null)
            {
                return NotFound();
            }
            return View(food);
        }

        // POST: Foods/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, [Bind("Name,Type,Image,Description,Rating,Price,Id")] Food food)
        {
            if (id != food.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    this._foodService.UpdeteExistingFood(food);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FoodExists(food.Id))
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
            return View(food);
        }

        // GET: Foods/Delete/5
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var food = this._foodService.GetDetailsForFood(id);
            if (food == null)
            {
                return NotFound();
            }

            return View(food);
        }

        // POST: Foods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            this._foodService.DeleteFood(id);
            return RedirectToAction(nameof(Index));
        }

        private bool FoodExists(Guid id)
        {
            return this._foodService.GetDetailsForFood(id) != null;
        }
    }
}
