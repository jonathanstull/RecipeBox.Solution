using System.Collections.Generic;

namespace RecipeBox.Models
{
  public class Rating
  {
    public int RatingId;
    public int LucyStar;

    public Rating()
    {
      this.JoinRR = new HashSet<RatingRecipe>();
    }
    public virtual ICollection<RatingRecipe> JoinRR { get; }
  }
}
