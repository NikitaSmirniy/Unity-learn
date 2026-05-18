using System.Collections.Generic;

public class ContainerOccupiedItems
{
    private List<Item> _items = new List<Item>();

    public bool TryAddItem(Item item)
    {
        if (_items.Contains(item) == false)
        {
            _items.Add(item);

            return true;
        }

        return false;
    }

    public void RemoveItem(Item item)
    {
        if (_items.Contains(item))
            _items.Remove(item);
    }
}