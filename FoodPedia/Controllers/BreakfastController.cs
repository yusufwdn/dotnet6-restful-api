using FoodPedia.Contracts;
using FoodPedia.Contracts.Breakfast;
using FoodPedia.Models;
using FoodPedia.Services;
using Microsoft.AspNetCore.Mvc;

namespace FoodPedia.Controllers;

[ApiController]
// indicates that in this controller, all prefix route are using controller name.
// example: controller name = "BreakfastControler", then prefix will be "Breakfast".
[Route("[controller]")] 
public class BreakfastController : ControllerBase
{
    private readonly IBreakfastService _breakfastService;

    // Call interface IBreakfastService for use service method
    public BreakfastController(IBreakfastService breakfastService)
    {
        // Assign breakfastService to _breakfastService attribute
        _breakfastService = breakfastService;
    }

    // POST, {{ base_url }}/Breakfast
    [HttpPost()]
    public IActionResult CreateBreakfast(CreateBreakfastRequest request)
    {
        // Map request data to Breakfast model
        var breakfastRequest = new Breakfast(
            Guid.NewGuid(), // Generate random Guid
            request.Name,
            request.Description,
            request.StartDateTime,
            request.EndDateTime,
            DateTime.UtcNow, // Generate current time
            request.Sweet,
            request.Savory
        );

        // TODO: save breakfast to database

        // using method CreateBreakfast method from IBreakfastService
        _breakfastService.CreateBreakfast(breakfastRequest);

        // Take result and generate them using BreakfastResponse
        var response = new BreakfastResponse(
            breakfastRequest.Id,
            breakfastRequest.Name,
            breakfastRequest.Description,
            breakfastRequest.StartDateTime,
            breakfastRequest.EndDateTime,
            breakfastRequest.LastModifiedDateTime,
            breakfastRequest.Sweet,
            breakfastRequest.Savory
        );

        // Send HTTP response 'created'
        return CreatedAtAction(
            actionName: nameof(GetBreakfast),
            routeValues: new { id = breakfastRequest.Id },
            value: response
        );
    }

    // GET, {{ base_url }}/Breakfast/{id:guid}
    [HttpGet("{id:guid}")]
    public IActionResult GetBreakfast(Guid id)
    {
        // Get breakfast data using GetBreakfast from IBreakfastService
        // This action will return Breakfast model format
        Breakfast breakfast = _breakfastService.GetBreakfast(id);

        // Format response from Breakfast model to BreakfastResponse
        var response = new BreakfastResponse(
            breakfast.Id,
            breakfast.Name,
            breakfast.Description,
            breakfast.StartDateTime,
            breakfast.EndDateTime,
            breakfast.LastModifiedDateTime,
            breakfast.Sweet,
            breakfast.Savory
        );

        return Ok(response);
    }

    // PUT, {{ base_url }}/Breakfast/{id:guid}
    [HttpPut("{id:guid}")]
    public IActionResult UpsertBreakfast(Guid id, UpsertBreakfastRequest request)
    {
        return Ok(request);
    }

    // DELETE, {{ base_url }}/Breakfast/{id:guid}
    [HttpDelete("{id:guid}")]
    public IActionResult DeleteBreakfast(Guid id)
    {
        return Ok(id);
    }
}