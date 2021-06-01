namespace RecipeBox.Models
{
  public class Rating
  {
    public int LucyStar;

    public LucyStar(int lucyStar)
    {
      LucyStar = lucyStar;
    }
    public virtual ICollection<RatingRecipe> JoinRR { get; }
  }
}
