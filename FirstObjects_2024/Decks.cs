using System.Collections;

namespace FirstObjects_2024;
/// <summary>
/// represents a standard deck of playing cards
/// </summary>
public class Deck:IEnumerable<Card>
{
    private List<Card> _cards;

    public Deck()
    {
        _cards = [];
        foreach (var suit in Suit.AllSuits)
        {
            foreach (var value in Value.AceHighValues)
                _cards.Add(new(suit, value));
        }
    }

    #region Enumerable Stuff
    public IEnumerator<Card> GetEnumerator()
    {
        return _cards.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((IEnumerable)_cards).GetEnumerator();
    }
    #endregion Enumerables.
}


