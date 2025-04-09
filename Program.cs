// See https://aka.ms/new-console-template for more information
List<ProductType>productTypes = new List<ProductType>()
{
new ProductType()
{
   Name = "Apparel",
   Id = 1 
},
new ProductType()
{
    Name = "Potions",
    Id = 2
},
new ProductType()
{
    Name = "Enchanted Objects",
    Id = 3
},
new ProductType()
{
    Name = "Wands",
    Id = 4
}
}; 

List<Product>products = new List<Product>()
{
new Product()
{
    Name = "Wizard Robes",
    Price = 39.99M,
    Sold = false,
    DayStocked = new DateTime(2025,4,1),
    ProductTypeId = 1
},
new Product()
{
    Name = "Wizard Staff",
    Price = 49.99M,
    Sold = false,
    DayStocked = new DateTime(2025,4,1),
    ProductTypeId = 4
},
new Product()
{
    Name = "Love Potion #9",
    Price = 41.99M,
    Sold = false,
    DayStocked = new DateTime(2025,4,1),
    ProductTypeId = 2
}
};
string greeting = @"Welcome to Reducto & Absurdum, your magical supplier for nearly 1000 years!";
Console.WriteLine(greeting);
string choice = null;
while (choice != "0")
{
Console.WriteLine(@"Choose an Option:
0. Exit
1. View All Products
2. View Products of Category
3. Add Product
4. Delete Product
5. Update Product");
choice = Console.ReadLine();
if (choice == "0")
{

}
else if (choice == "1")
{
    ListProducts();
}
else if (choice == "2")
{
    ListCategoryProducts();
}
else if (choice == "3")
{
    AddProduct();
}
else if (choice == "4")
{
    DeleteProduct();
}
else if (choice == "5")
{
    UpdateProduct();
}
else {
    Console.WriteLine("Please enter a valid choice.");
}
}

void ListProducts()
{
    int count = 1;
    Console.WriteLine("Products:");
    foreach (Product product in products)
    {
        Console.WriteLine($"{count}. {product.Name}: ${product.Price}");
        count++;
    }
}

int ListCategoryProducts()
{
    Console.WriteLine("Select Category:");
    foreach (ProductType productType in productTypes)
    {
        Console.WriteLine($"{productType.Id}. {productType.Name}");
    }
    string choice = null;
    choice = Console.ReadLine();
    foreach (Product product in products)
    {
        if (product.ProductTypeId == int.Parse(choice))
        {
        Console.WriteLine($"{product.Name}: ${product.Price}");
        }
    }
    return int.Parse(choice);
}

void AddProduct()
{
    Product newProduct = new Product()
    {
        Name = null,
        Price = 0.00M,
        Sold =false,
        DayStocked = DateTime.Now,
        ProductTypeId = 0
    };
    Console.WriteLine("Enter Product Name:");
    newProduct.Name = Console.ReadLine();
    Console.WriteLine("Enter Product Price:");
    newProduct.Price = decimal.Parse(Console.ReadLine());
    newProduct.ProductTypeId = ListCategoryProducts();
    products.Add(newProduct);
}

void DeleteProduct()
{
    ListProducts();
    Console.WriteLine("Select a Product to Delete:");
    string choice = Console.ReadLine();
    products.RemoveAt(int.Parse(choice)-1);

}

void UpdateProduct()
{
    ListProducts();
    Console.WriteLine("Select a Product to Update:");
    int productChoice = int.Parse(Console.ReadLine());
   string choice = null;
    while(choice != "0")
    {
         Console.WriteLine(@"Select a Property to Edit:
    0. Done
    1. Name
    2. Price
    3. Sold
    4. Day Stocked
    5. ProductTypeId");
     choice = Console.ReadLine();
        if (choice == "1")
        {
            Console.WriteLine("Enter a new Product Name:");
           products[productChoice-1].Name = Console.ReadLine();
        }
    else if (choice == "2")
    {
        Console.WriteLine("Enter a New Price:");
        products[productChoice - 1].Price = decimal.Parse(Console.ReadLine());
    }
    else if (choice == "3")
    {
        Console.WriteLine(@"Is Product Sold?
        1. Yes
        2. No");
        choice = Console.ReadLine();
        if (choice == "1")
        {
            products[productChoice - 1].Sold = true;
        }
        else
        {
            products[productChoice -1].Sold = false;
        }
    }
    else if (choice == "4")
    {
        int Day = 0;
        int Month = 0;
        int Year = 0;
        Console.WriteLine("Enter the Day Stocked:");
        Day = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter the Month Stocked:");
        Month = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter the Year Stocked:");
        Year = int.Parse(Console.ReadLine());
        DateTime newDate = new DateTime(Year,Month,Day);
        products[productChoice - 1].DayStocked = newDate;
    }
    else if (choice == "5")
    {
        Console.WriteLine("Select Category:");
    foreach (ProductType productType in productTypes)
    {
        Console.WriteLine($"{productType.Id}. {productType.Name}");
    }
        products[productChoice - 1].ProductTypeId = int.Parse(Console.ReadLine());

    }
    }

}