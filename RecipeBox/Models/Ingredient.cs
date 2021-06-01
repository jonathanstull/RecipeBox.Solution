using System.Collections.Generic;

namespace RecipeBox.Models
{
  public class Ingredient
  {
    public Ingredient()
    {
      this.JoinIR = new HashSet<IngredientRecipie>();
    }
    public int IngredientsID {get; set;}
    public string Name {get; set;}
    public virtual ApplicationUser User {get; set;}
    public virtual ICollection<IngredientRecipe> JoinIR {get; set;}
  }
}