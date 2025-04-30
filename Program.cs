using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Data;
using Models;
using Services;

static async Task Main(string[] args)
{
   
    var services = new ServiceCollection();

    services.AddDbContext<AppDbContext>(options =>
        options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=GameAppDb;Trusted_Connection=True;"));

    services.AddScoped<UserService>();

    var provider = services.BuildServiceProvider();
    var userService = provider.GetRequiredService<UserService>();

    
    var user = new User
    {
        FirstName = "Ivan",
        LastName = "Ivanov",
        Age = 25,
        Username = "ivan25",
        Password = "pass1234",
        Email = "ivan@email.com"
    };
    await userService.AddAsync(user);
    Console.WriteLine("1. Създаден потребител.");

    
    var fetched = await userService.GetByIdAsync(user.Id);
    Console.WriteLine($"2. Прочетен: {fetched.FirstName} {fetched.LastName}");

    
    fetched.LastName = "Petrov";
    await userService.UpdateAsync(fetched);
    Console.WriteLine("3. Актуализиран потребител.");

    
    var updated = await userService.GetByIdAsync(user.Id);
    Console.WriteLine($"    Нова фамилия: {updated.LastName}");

    
    await userService.DeleteAsync(user.Id);
    Console.WriteLine("4. Потребител изтрит.");
}