namespace CookieCookbook.Recipes.Ingredients;

public class IngredientsRegister : IIngredientsRegister
{
    public IEnumerable<Ingredient> All { get; } = new List<Ingredient>
    {
        new WheatFlour(),
        new SpeltFlour(),
        new Butter(),
        new Chocolate(),
        new Sugar(),
        new Cardamom(),
        new Cinnamon(),
        new CocoaPowder()
    };

    public Ingredient GetById(int id)
    {
        var allOfIngreditnsWithGivenId = All.Where(ingredient => ingredient.Id == id);

        if(allOfIngreditnsWithGivenId.Count() > 1)
        {
            throw new InvalidOperationException(
                $"More than one ingredients have the ID equal to {id}!");
        }

        if(All.Select(ingredient => ingredient.Id).Distinct().Count() != All.Count())
        {
            throw new InvalidOperationException(
                $"Some ingredients might have duplicated IDs!");
        }

        return allOfIngreditnsWithGivenId.FirstOrDefault();

    }
}

