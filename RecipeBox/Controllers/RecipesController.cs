using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecipeBox.Models;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RecipeBox.Controllers
{
  public class RecipesController : Controller
  {
    private readonly RecipeBoxContext _db;
    private readonly UserManager<ApplicationUser> _userManager;
    
    public RecipesController(UserManager<ApplicationUser> userManager, RecipeBoxContext db)
    {
      _userManager = userManager;
      _db = db;
    }

    public async Task<ActionResult> Index()
    {
      var userId = this._userManager.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      var userItems = _db.Recipes.Where(entry => entry.User.Id == currentUser.Id).ToList();
      return View(userRecipes);
    }

    public ActionResult Create()
    {
      ViewBag.IngredientId = new SelectList(_db.Ingredients, "IngredientId", "IngredientName");
      return View();
    }

    // Overload with three ingredient arguments
    [HttpPost]
    [ActionName("Create")]
    public async Task<ActionResult> CreateThree(Recipe recipe, int IngredientId1, int IngredientId2, int IngredientId3)
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      recipe.User = currentUser;
      _db.Recipes.Add(recipe);
      _db.SaveChanges();
      if (IngredientId1 != 0 && IngredientId2 != 0 && IngredientId3 != 0)
      {
        _db.IngredientRecipe.Add(new IngredientRecipe() { IngredientId = IngredientId1, RecipeId = recipe.RecipeId });
        _db.IngredientRecipe.Add(new IngredientRecipe() { IngredientId = IngredientId2, RecipeId = recipe.RecipeId });
        _db.IngredientRecipe.Add(new IngredientRecipe() { IngredientId = IngredientId3, RecipeId = recipe.RecipeId });
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    // Overload with two ingredient arguments
    [ActionName("Create")]
    [HttpPost]
    public async Task<ActionResult> CreateTwo(Recipe recipe, int IngredientId1, int IngredientId2)
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      recipe.User = currentUser;
      _db.Recipes.Add(recipe);
      _db.SaveChanges();
      if (IngredientId1 != 0 && IngredientId2 != 0 && IngredientId3 != 0)
      {
        _db.IngredientRecipe.Add(new IngredientRecipe() { IngredientId = IngredientId1, RecipeId = recipe.RecipeId });
        _db.IngredientRecipe.Add(new IngredientRecipe() { IngredientId = IngredientId2, RecipeId = recipe.RecipeId });
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    // Overload with one ingredient argument
    [HttpPost]
    public async Task<ActionResult> CreateOne(Recipe recipe, int IngredientId1)
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      recipe.User = currentUser;
      _db.Recipes.Add(recipe);
      _db.SaveChanges();
      if (IngredientId1 != 0 && IngredientId2 != 0 && IngredientId3 != 0)
      {
        _db.IngredientRecipe.Add(new IngredientRecipe() { IngredientId = IngredientId1, RecipeId = recipe.RecipeId });
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisRecipe = _db.Recipes
            .Include(recipe => recipe.JoinIR)
            .ThenInclude(join => join.Ingredient)
            .Include(recipe => recipe.JoinRR)
            .ThenInclude(join => join.Rating)
            .FirstOrDefault(recipe => recipe.RecipeId == id);
      return View(thisRecipe);
    }

    public ActionResult Edit(int id)
    {
      var thisRecipe = _db.Recipes.FirstOrDefault(recipe => recipe.RecipeId == id);
      ViewBag.RatingId = new SelectList(_db.Ratings, "RatingId", "LucyStar");
      ViewBag.IngredientId = new SelectList(_db.Ingredients, "IngredientId", "IngredientId");
      return View(thisRecipe);
    }

    // Next up: Edit POST route!
  }
}