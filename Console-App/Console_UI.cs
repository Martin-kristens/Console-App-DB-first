using shared.Services;

namespace Console_App;

public class Console_UI
{
    private readonly ProductService _productService;
    private readonly CustomerService _customerService;

    public Console_UI(ProductService productService, CustomerService customerService)
    {
        _productService = productService;
        _customerService = customerService;
    }

    // PRODUCTS
    public void CreateProduct_UI()
    {
        Console.Clear();

        Console.WriteLine("CREATE PRODUCT: ");

        Console.Write("Product Title: ");
        var title = Console.ReadLine()!;

        Console.Write("Product Price: ");
        decimal price = decimal.Parse(Console.ReadLine()!);

        Console.Write("Product Description: ");
        var description = Console.ReadLine()!;

        Console.Write("Product Category: ");
        var categoryName = Console.ReadLine()!;

        Console.Write("Product Manufacture: ");
        var manufactureName = Console.ReadLine()!;

        var result = _productService.CreateProduct(title, price, description, categoryName, manufactureName);

        if (result != null)
        {
            Console.Clear();
            Console.WriteLine("Product was created");
            Console.ReadKey();
        }

    }

    public void GetProducts_UI()
    {
        Console.Clear();

        var products = _productService.GetProducts();
        foreach (var product in products)
        {
            Console.Clear();
            Console.WriteLine("\tPRODUCTS\n");
            //Console.WriteLine("\tTITLE\tDESCRIPTION\tCategory Name\t Manufacture Name\t Price\n");
            Console.WriteLine($"TITLE: {product.Title}\nDESCRIPTION: {product.Description}\nCategory Name: {product.Category.CategoryName}\n" +
              $"Manufacture Name: {product.Manufacture.ManufactureName}\nPrice: ({product.Price} SEK)");
        }

        Console.WriteLine("Press any key to continue");

        Console.ReadKey();
    }

    public void UpdateProduct_UI()
    {
        Console.Clear();

        Console.Write("Enter product Id: ");
        var id = int.Parse(Console.ReadLine()!);

        var product = _productService.GetProductById(id);

        if (product != null)
        {
            Console.Clear();
            //Console.WriteLine("\tTITLE\tDESCRIPTION\tCategory Name\t Manufacture Name\t Price\n");
            Console.WriteLine($"TITLE: {product.Title}DESCRIPTION: {product.Description}Category Name: {product.Category.CategoryName}" +
                $"Manufacture Name: {product.Manufacture.ManufactureName}Price: ({product.Price} SEK)");


            Console.WriteLine();
            Console.Write("New Product Title: ");
            product.Title = Console.ReadLine()!;

            var newProduct = _productService.UpdateProduct(product);
            //Console.WriteLine("\tTITLE\tDESCRIPTION\tCategory Name\t Manufacture Name\t Price\n");
            Console.WriteLine($"TITLE: {product.Title}DESCRIPTION: {product.Description}Category Name: {product.Category.CategoryName}" +
                    $"Manufacture Name: {product.Manufacture.ManufactureName}Price: ({product.Price} SEK)");

        }
        else
        {
            Console.WriteLine("No product found");
        }

        Console.ReadKey();
    }

    public void DeleteProduct_UI()
    {
        Console.Clear();

        Console.Write("Enter product Id: ");
        var id = int.Parse(Console.ReadLine()!);

        var product = _productService.GetProductById(id);

        if (product != null)
        {
            _productService.DeleteProduct(product.Id);
            Console.WriteLine("Product was deleted.");

        }
        else
        {
            Console.WriteLine("No product found");
        }

        Console.ReadKey();
    }


    // CUSTOMER

    public void CreateCustomer_UI()
    {
        Console.Clear();

        Console.WriteLine("CREATE CUSTOMER");

        Console.Write("First NAME: ");
        var firstName = Console.ReadLine()!;

        Console.Write("Last Name: ");
        string lastName = Console.ReadLine()!;

        Console.Write("Email: ");
        var email = Console.ReadLine()!;

        Console.Write("Street Name: ");
        var streetName = Console.ReadLine()!;

        Console.Write("Postal Code: ");
        var postalCode = Console.ReadLine()!;

        Console.Write("City: ");
        var city = Console.ReadLine()!;

        var result = _customerService.CreateCustomer(firstName, lastName, email, streetName, postalCode, city);

        if (result != null)
        {
            Console.Clear();
            Console.WriteLine("Customer was created");
            Console.ReadKey();
        }

    }

    public void GetCustomers_UI()
    {
        Console.Clear();

        var customers = _customerService.GetCustomers();
        foreach (var customer in customers)
        {
            Console.Clear();
            Console.WriteLine("\tCUSTOMERS\n");
            //Console.WriteLine("FIRSTNAME\tLASTNAME\tEMAIL\t\t\tSTREETNAME\tPOSTALCODE\tCITY\n");
            Console.WriteLine($"FIRSTNAME: {customer.FirstName}LASTNAME: {customer.LastName}EMAIL: {customer.Email}" +
                $"STREETNAME: {customer.Address.StreetName}POSTALCODE: {customer.Address.PostalCode}CITY: {customer.Address.City}");
        }
        Console.WriteLine();
        Console.WriteLine("Press any key to continue");

        Console.ReadKey();
    }

    public void UpdateCustomer_UI()
    {
        Console.Clear();

        Console.Write("Enter customer Email: ");
        var email = Console.ReadLine()!;

        var customer = _customerService.GetCustomerByEmail(email);

        if (customer != null)
        {
            Console.Clear();
            //Console.WriteLine("FIRSTNAME LASTNAME EMAIL STREETNAME\tPOSTALCODE\tCITY\n");
            Console.WriteLine($"FIRSTNAME: {customer.FirstName}LASTNAME: {customer.LastName}EMAIL: {customer.Email}" +
                $"STREETNAME: {customer.Address.StreetName}POSTALCODE: {customer.Address.PostalCode}CITY: {customer.Address.City}");


            Console.WriteLine();
            Console.Write("New First Name: ");
            customer.FirstName = Console.ReadLine()!;

            Console.Write("New Last Name: ");
            customer.LastName = Console.ReadLine()!;

            Console.Write("New Email: ");
            customer.Email = Console.ReadLine()!;

            var newCustomer = _customerService.UpdateCustomer(customer);
            Console.WriteLine("FIRSTNAME\tLASTNAME\tEMAIL\t\t\tSTREETNAME\tPOSTALCODE\tCITY\n");
            Console.WriteLine($"FIRSTNAME: {customer.FirstName}LASTNAME: {customer.LastName}EMAIL: {customer.Email}" +
                $"STREETNAME: {customer.Address.StreetName}POSTALCODE: {customer.Address.PostalCode}CITY: {customer.Address.City}");

        }
        else
        {
            Console.WriteLine("No product found");
        }

        Console.ReadKey();
    }

    public void DeleteCustomer_UI()
    {
        Console.Clear();

        Console.Write("Enter customer email: ");
        var email = Console.ReadLine()!;

        var customer = _customerService.GetCustomerByEmail(email);

        if (customer != null)
        {
            _customerService.DeleteCustomer(customer.Email);
            Console.WriteLine("Customer was deleted.");

        }
        else
        {
            Console.WriteLine("No customer found");
        }

        Console.ReadKey();
    }

}
