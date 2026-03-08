using System;
using System.Collections.Generic;

public class PromptBag
{
    private List<string> _items;
    private Queue<string> _bag;
    private Random _random;

    public PromptBag(IEnumerable<string> items)
    {
        _items = new List<string>(items);
        _bag = new Queue<string>();
        _random = new Random(Guid.NewGuid().GetHashCode());
        RefillAndShuffle();
    }

    public string Next()
    {
        if (_bag.Count == 0)
        {
            RefillAndShuffle();
        }

        return _bag.Dequeue();
    }

    private void RefillAndShuffle()
    {
        List<string> temp = new List<string>(_items);

        for (int i = temp.Count - 1; i > 0; i--)
        {
            int j = _random.Next(i + 1);
            string swap = temp[i];
            temp[i] = temp[j];
            temp[j] = swap;
        }

        _bag.Clear();
        foreach (string item in temp)
        {
            _bag.Enqueue(item);
        }
    }
}