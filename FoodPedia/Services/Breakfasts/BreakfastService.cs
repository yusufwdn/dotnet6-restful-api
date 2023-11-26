using FoodPedia.Models;

namespace FoodPedia.Services.Breakfasts;

// This service is implement IBreakfastService interface, so we have to create all the methods
// based on the interface. If an interface has 2 methods, this class should have them too.
public class BreakfastService : IBreakfastService
{
    private static readonly Dictionary<Guid, Breakfast> _breakfasts = new();

    public void CreateBreakfast(Breakfast breakfast)
    {
        _breakfasts.Add(breakfast.Id, breakfast);
    }

    public Breakfast GetBreakfast(Guid id)
    {
        return _breakfasts[id];
    }
}