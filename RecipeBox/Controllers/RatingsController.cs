using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using RecipeBox.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;

namespace RecipeBox.Controllers
{
  [Authorize]
  public class RatingsController : Controller
  {
    private readonly RecipeBoxContext _db;
    private readonly UserManager<ApplicationUser> _userManager;
    public RatingsController(UserManager<ApplicationUser> userManager, RecipeBoxContext db)
    {
        _userManager = userManager;
      _db = db;
    }
      public async Task<ActionResult> Index()
{
    var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    var currentUser = await _userManager.FindByIdAsync(userId);
    var userRatings = _db.Ratings.Where(entry => entry.User.Id == currentUser.Id).ToList();
    return View(userRatings);
}
  public ActionResult Create()
    {
      ViewBag.RecipeId = new SelectList(_db.Recipes, "RecipeId", "Title");
      return View();
    }
      [HttpPost]
public async Task<ActionResult> Create(Rating rating, int RecipeId)
{
    var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;//not sure if I need to change NameIdentifyer to TitleIdentifyer
    var currentUser = await _userManager.FindByIdAsync(userId);
    rating.User = currentUser;
    _db.Ratings.Add(rating);
    _db.SaveChanges();
    if (RecipeId != 0)
    {
        _db.RatingRecipes.Add(new RatingRecipe() { RecipeId = RecipeId, RatingId = rating.RatingId });
    }
    _db.SaveChanges();
    return RedirectToAction("Index");
}
 public ActionResult Details(int id)
    {
      var thisRating = _db.Ratings
          .Include(rating => rating.JoinRR)
          .ThenInclude(join => join.Recipe)
          .FirstOrDefault(rating => rating.RatingId == id);
      return View(thisRating);
    }
     public ActionResult Edit(int id)
    {
      var thisRating = _db.Ratings.FirstOrDefault(rating => rating.RatingId == id);
      ViewBag.RecipeId = new SelectList(_db.recipes, "RecipeId", "Title");
      return View(thisRating);
    }
     [HttpPost]
    public ActionResult Edit(Rating rating, int CategoryId)
    {
      if (RecipeId != 0)
      {
        _db.RecipeRating.Add(new RecipeRating() { CategoryId = CategoryId, RatingId = rating.RatingId });
      }
      _db.Entry(rating).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
     public ActionResult AddRecipe(int id)
    {
      var thisRating = _db.Ratings.FirstOrDefault(rating => rating.RatingId == id);
      ViewBag.RecipeId = new SelectList(_db.Recipes, "RecipeId", "Title");
      return View(thisRating);
    }
    [HttpPost]
    public ActionResult AddRecipe(Rating rating, int RecipeId)
    {
      if (RecipeId != 0)
      {
      _db.RatingRecipes.Add(new RatingRecipe() { RecipeId = RecipeId, RatingId = rating.RatingId });
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult Delete(int id)
    {
      var thisRating = _db.Ratings.FirstOrDefault(rating => rating.RatingId == id);
      return View(thisRating);
    }
    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisRating = _db.Ratings.FirstOrDefault(rating => rating.RatingId == id);
      _db.Ratings.Remove(thisRating);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
        [HttpPost]
    public ActionResult DeleteRecipe(int joinId)
    {
      var joinEntry = _db.RatingRecipes.FirstOrDefault(entry => entry.RatingRecipesId == joinId);
      _db.RatingRecipes.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}