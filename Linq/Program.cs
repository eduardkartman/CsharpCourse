/*var stringsNoUpperCare = new string[]
{
    "quick", "brown" , "fox"
};
Console.WriteLine(IsAnyWordsUpperCase_Linq(stringsNoUpperCare));
var stringsWithUpperCare = new string[]
{
    "quick", "brown" , "FOX"
};
Console.WriteLine(IsAnyWordsUpperCase_Linq(stringsWithUpperCare));

Console.ReadKey();

static bool IsAnyWordsUpperCase_Linq(IEnumerable<string> words)
{
    return words.Any(word => word.All(letter => char.IsUpper(letter)));
}*/
//Refactoring CoockiesCookBook

using CookieCookbook.App;
using CookieCookbook.DataAccess;
using CookieCookbook.FileAccess;
using CookieCookbook.Recipes;
using CookieCookbook.Recipes.Ingredients;

const FileFormat Format = FileFormat.Json;

IStringsRepository stringsRepository = Format == FileFormat.Json ?
    new StringsJsonRepository() :
    new StringsTextualRepository();

const string FileName = "recipes";
var fileMetadata = new FileMetadata(FileName, Format);

var ingredientsRegister = new IngredientsRegister();

var cookiesRecipesApp = new CookiesRecipesApp(
    new RecipesRepository(
        stringsRepository,
        ingredientsRegister),
    new RecipesConsoleUserInteraction(
        ingredientsRegister));

cookiesRecipesApp.Run(fileMetadata.ToPath());


