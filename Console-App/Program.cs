using Console_App;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using shared.Contexts;
using shared.Repositories;
using shared.Services;

var builder = Host.CreateDefaultBuilder().ConfigureServices(services =>
{
    services.AddDbContext<DataContext>(x => x.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Education\CSharp\VisualStudio\Console-App-DB-first\shared\Data\console-db.mdf;Integrated Security=True;Connect Timeout=30"));

    services.AddScoped<AddressRepository>();
    services.AddScoped<CategoryRepository>();
    services.AddScoped<CustomerRepository>();
    services.AddScoped<ManufactureRepository>();
    services.AddScoped<ProductRepository>();

    services.AddScoped<AddressService>();
    services.AddScoped<CategoryService>();
    services.AddScoped<CustomerService>();
    services.AddScoped<ManufactureService>();
    services.AddScoped<ProductService>();

    services.AddSingleton<Console_UI>();

}).Build();

var consoleUI = builder.Services.GetRequiredService<Console_UI>();
consoleUI.CreateProduct_UI();
//consoleUI.GetProducts_UI();
//consoleUI.UpdateProduct_UI();
//consoleUI.DeleteProduct_UI();

//consoleUI.CreateCustomer_UI();
//consoleUI.GetCustomers_UI();
//consoleUI.UpdateCustomer_UI();
//consoleUI.DeleteCustomer_UI();