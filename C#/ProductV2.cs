using System;
using System.Collections.Generic;
using System.Text;

class Product
{
    private int _productId;
    private string _productName;
    private DateTime _mfgDate;
    private int _warranty;
    private double _price;
    private int _stock;
    private int _gst;
    private int _discount;

    public int ProductId
    {
        get { return _productId; }
        set { _productId = value; }
    }

    public string ProductName
    {
        get { return _productName; }
        set { _productName = value; }
    }

    public DateTime MfgDate
    {
        get { return _mfgDate; }
        set { _mfgDate = value; }
    }

    public int Warranty
    {
        get { return _warranty; }
        set { _warranty = value; }
    }

    public double Price
    {
        get { return _price; }
        set { _price = value; }
    }

    public int Stock
    {
        get { return _stock; }
        set { _stock = value; }
    }

    public int GST
    {
        get { return _gst; }
        set { _gst = value; }
    }

    public int Discount
    {
        get { return _discount; }
        set { _discount = value; }
    }

    public void Display()
    {
        ProductDisplay.DisplayProductDetails(this);
    }
}

class ProductDisplay
{
    public static void DisplayProductList(List<Product> productList)
    {
        if (productList.Count == 0)
        {
            Console.WriteLine("No products to display.");
            return;
        }

        Console.WriteLine("List of Products:");
        foreach (var product in productList)
        {
            DisplayProductDetails(product);
        }
    }

    public static void DisplayProductDetails(Product product)
    {
        StringBuilder displayBuilder = new StringBuilder();
        displayBuilder.AppendLine($"Product ID: {product.ProductId}")
                      .AppendLine($"Product Name: {product.ProductName}")
                      .AppendLine($"Manufacturing Date: {product.MfgDate.ToShortDateString()}")
                      .AppendLine($"Warranty (in years): {product.Warranty}")
                      .AppendLine($"Price: {product.Price:C}")
                      .AppendLine($"Stock: {product.Stock}")
                      .AppendLine($"GST: {product.GST}")
                      .AppendLine($"Discount: {product.Discount}")
                      .AppendLine();

        Console.WriteLine(displayBuilder.ToString());
    }
}

class Program
{
    static void Main()
    {
        int choice;
        var productList = new List<Product>();
        do
        {
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. Display Products");
            Console.WriteLine("3. Find Products");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice: ");
            choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    AddProduct(productList);
                    break;
                case 2:
                    DisplayProducts(productList);
                    break;
                case 3:
                    FindProduct(productList);
                    break;
                case 4:
                    Console.WriteLine("Exiting...");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please enter a valid option.");
                    break;
            }

        } while (choice != 4);
    }

    static void AddProduct(List<Product> productList)
    {
        Console.Write("Enter the number of products you want to add : ");
        int numberOfProducts = Convert.ToInt32(Console.ReadLine());
        
        for (int i = numberOfProducts; i > 0; i--) 
        {
            var product = new Product();
            Console.Write("Enter Product ID (It should be greater than 0) : ");
            product.ProductId = Convert.ToInt32(Console.ReadLine());
            while(product.ProductId <= 0){
                Console.Write("(It should be greater than 0) : ");
                product.ProductId = Convert.ToInt32(Console.ReadLine());
            }
    
            Console.Write("Enter Product Name (At least 3 characters) : ");
            product.ProductName = Console.ReadLine();
            while(product.ProductName.Length < 3){
                Console.Write("(At least 3 characters) : ");
                product.ProductName = Console.ReadLine();
            }
    
            Console.Write("Enter Manufacturing Date (mm/dd/yyyy): ");
            product.MfgDate = Convert.ToDateTime(Console.ReadLine());
            while(product.MfgDate > DateTime.Today){
                Console.Write("ManufactureDate must be before today (mm/dd/yyyy): ");
                product.MfgDate = Convert.ToDateTime(Console.ReadLine());
            }
    
            Console.Write("Enter Warranty (in years, should be an integer): ");
            product.Warranty = Convert.ToInt32(Console.ReadLine());
    
            Console.Write("Enter Price (Greater than 0) : ");
            product.Price = Convert.ToDouble(Console.ReadLine());
            while (product.Price <= 0)
            {
                Console.WriteLine("Please enter a price greater than 0 : ");
                product.Price = Convert.ToDouble(Console.ReadLine());
            }
    
    
            Console.Write("Enter Stock : ");
            product.Stock = Convert.ToInt32(Console.ReadLine());
    
            List<int> validGST = new List<int> { 5, 12, 18, 28 };
            Console.Write("Enter GST (5, 12, 18, or 28): ");
            product.GST = Convert.ToInt32(Console.ReadLine());
            while (!validGST.Contains(product.GST))
            {
                Console.Write("It should be either of this (5, 12, 18, or 28): ");
                product.GST = Convert.ToInt32(Console.ReadLine());
            }
    
            Console.Write("Enter Discount (Between 1 and 30) : ");
            product.Discount = Convert.ToInt32(Console.ReadLine());
            while(product.Discount < 1 || product.Discount > 30){
                Console.Write("Enter discount between 1 and 30 : ");
                product.Discount = Convert.ToInt32(Console.ReadLine());
            }
            productList.Add(product);
            Console.WriteLine("Product added successfully!");
        }
    }

    static void DisplayProducts(List<Product> productList)
    {
        ProductDisplay.DisplayProductList(productList);
    }
    
    static void FindProduct(List<Product> productList){
        Console.Write("Enter the product id : ");
        int id = Convert.ToInt32(Console.ReadLine());
        foreach (var product in productList) 
        {
            if(id == product.ProductId){
                Console.WriteLine("Product found!!");
                product.Display();
                return;
            }
        }
        Console.WriteLine("No product found with given id.");
    }
}
