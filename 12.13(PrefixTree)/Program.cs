using System;
using System.Collections.Generic;

public class Price
{
    public string ProductName { get; set; }
    public string ShopName { get; set; }
    public double PriceValue { get; set; }

    public Price(string productName, string shopName, double price)
    {
        ProductName = productName;
        ShopName = shopName;
        PriceValue = price;
    }
}

public class PrefixTree
{
    private class TrieNode
    {
        public Dictionary<char, TrieNode> Children { get; private set; }
        public Price PriceInfo { get; set; }

        public TrieNode()
        {
            Children = new Dictionary<char, TrieNode>();
            PriceInfo = null;
        }
    }

    private TrieNode root;

    public PrefixTree()
    {
        root = new TrieNode();
    }

    public void Insert(string word, Price price)
    {
        TrieNode node = root;
        foreach (char c in word)
        {
            if (!node.Children.ContainsKey(c))
            {
                node.Children[c] = new TrieNode();
            }
            node = node.Children[c];
        }
        node.PriceInfo = price;
    }

    public Price Search(string word)
    {
        TrieNode node = root;
        foreach (char c in word)
        {
            if (!node.Children.ContainsKey(c))
            {
                return null;
            }
            node = node.Children[c];
        }
        return node.PriceInfo;
    }
}

class Program
{
    static void Main(string[] args)
    {
        PrefixTree tree = new PrefixTree();

        Console.Write("Enter the number of products: ");
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            Console.Write("Product name: ");
            string productName = Console.ReadLine();
            Console.Write("Shop name: ");
            string shopName = Console.ReadLine();
            Console.Write("Price in UAH: ");
            double price = double.Parse(Console.ReadLine());
            Price priceInfo = new Price(productName, shopName, price);
            tree.Insert(productName, priceInfo);
        }

        Console.Write("Enter the product name to search: ");
        string searchProduct = Console.ReadLine();
        Price result = tree.Search(searchProduct);
        if (result != null)
        {
            Console.WriteLine($"Product information: {result.ProductName}, Shop: {result.ShopName}, Price: {result.PriceValue} UAH");
        }
        else
        {
            Console.WriteLine("Product not found.");
        }
        Console.ReadLine();
    }
}
