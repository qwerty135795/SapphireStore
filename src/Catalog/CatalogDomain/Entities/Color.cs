namespace CatalogDomain.Entities;

public class Color
{
    public string ItemColor { get; set; }
    public string PhotoUrl { get; set; }

    public Color()
    {
        
    }

    public Color(string itemColor, string photoUrl)
    {
        ItemColor = itemColor;
        PhotoUrl = photoUrl;
    }
}
