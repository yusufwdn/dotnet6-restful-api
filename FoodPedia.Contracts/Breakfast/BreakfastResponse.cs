namespace FoodPedia.Contracts.Breakfast;

// Make contract for breakfast get response 
public record BreakfastResponse (
    Guid Id,
    string Name,
    string Description,
    DateTime StartDateTime,
    DateTime EndDateTime,
    DateTime LastModifiedDateTime,
    List<string> Savory,
    List<string> Sweet
);