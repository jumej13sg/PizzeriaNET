using Pizza.Models;
using Pizza.Services;
using Microsoft.AspNetCore.Mvc;

namespace Pizza.Controllers;

[ApiController]
[Route("[controller]")]
public class PizzaController : ControllerBase
{
    public PizzaController()
    {
    }

    // GET all action
    [HttpGet]
    public ActionResult<List<PizzaModel>> GetAll() =>
        PizzaService.GetAll();

    // GET by Id action
    [HttpGet("{id}")]
    public ActionResult<PizzaModel> Get(int id)
    {
        var pizza = PizzaService.Get(id);

        if(pizza == null)
            return NotFound();
        return pizza;
    }

    /*Ejemplo de POST
    [HttpPost]
    public IActionResult Create(Pizza pizza)
    {            
        This code will save the pizza and return a result
    }*/

    [HttpPost]
    public IActionResult Create(PizzaModel pizza)
    {            
        PizzaService.Add(pizza);
        return CreatedAtAction(nameof(Get), new { id = pizza.Id }, pizza);
    }

    /*Ejemplo de PUT
    [HttpPut("{id}")]
    public IActionResult Update(int id, Pizza pizza)
    {
        This code will update the pizza and return a result
    }*/

    [HttpPut("{id}")]
    public IActionResult Update(int id, PizzaModel pizza)
    {
        if (id != pizza.Id)
            return BadRequest();
            
        var existingPizza = PizzaService.Get(id);
        if(existingPizza is null)
            return NotFound();
    
        PizzaService.Update(pizza);           
    
        return NoContent();
    }

    /*Ejemplo de DELETE
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        This code will delete the pizza and return a result
    }*/

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var pizza = PizzaService.Get(id);
    
        if (pizza is null)
            return NotFound();
        
        PizzaService.Delete(id);
    
        return NoContent();
    }

}