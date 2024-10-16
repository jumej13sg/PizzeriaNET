using Pizza.Models;

namespace Pizza.Services;

public static class PizzaService
{
    static List<PizzaModel> Pizzas { get; }
    static int nextId = 3;
    static PizzaService()
    {
        Pizzas = new List<PizzaModel>
        {
            new PizzaModel { Id = 1, Name = "Classic Italian", IsGlutenFree = false },
            new PizzaModel { Id = 2, Name = "Veggie", IsGlutenFree = true }
        };
    }

    public static List<PizzaModel> GetAll() => Pizzas;

    public static PizzaModel? Get(int id) => Pizzas.FirstOrDefault(p => p.Id == id);

    public static void Add(PizzaModel pizza)
    {
        pizza.Id = nextId++;
        Pizzas.Add(pizza);
    }

    public static void Delete(int id)
    {
        var pizza = Get(id);
        if(pizza is null)
            return;

        Pizzas.Remove(pizza);
    }

    public static void Update(PizzaModel pizza)
    {
        var index = Pizzas.FindIndex(p => p.Id == pizza.Id);
        if(index == -1)
            return;

        Pizzas[index] = pizza;
    }
}