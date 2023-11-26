using FoodPedia.Models;

namespace FoodPedia.Services;

public interface IBreakfastService
{
    void CreateBreakfast(Breakfast breakfast); // Used for create new breakfast data
    
    Breakfast GetBreakfast(Guid id); // Used for get an existing breakfast data
}