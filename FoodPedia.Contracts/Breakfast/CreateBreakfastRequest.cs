namespace FoodPedia.Contracts;

// Make contract for breakfast create response 
public record CreateBreakfastRequest (
    string Name,
    string Description,
    DateTime StartDateTime,
    DateTime EndDateTime,
    List<string> Savory,
    List<string> Sweet
);