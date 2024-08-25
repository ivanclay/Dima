﻿namespace Dima.Core.Models;

public class Product
{
    public long Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Slug { get; set; } = string.Empty;
    public bool IsActive { get; set; } = true;
    public decimal Price { get; set; }

    //public Dictionary<string, string> Properties { get; set; } = null!;
    //Bom para buscas
    //cor:vermelha
    //altura:1m ETC
}
