namespace FoodPedia.Contracts;

// Make contract for breakfast upsert response 
public record UpsertBreakfastRequest (
    Guid Id,
    string Name,
    string Description,
    DateTime StartDateTime,
    DateTime EndDateTime,
    List<string> Savory,
    List<string> Sweet
);