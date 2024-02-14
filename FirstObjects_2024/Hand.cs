namespace FirstObjects_2024;

public class Hand
{
    private List<Card> _hand;

    public Hand() { _hand = []; }

    //static makes it so you can access it from any instance of deck, and it is independent of what other values are
    private static readonly Random rnd = new(); 
    public void Add(Card c) { _hand.Add(c); }
    
    public Card Take()
    {
        if (_hand.Count == 0)
        {
            throw new InvalidOperationException("Deck is Empty!");
        }

        var card = _hand.First();
        _hand.RemoveAt(0);
        return card;
    }

    public Card TakeRandomly()
    {
        if (_hand.Count == 0)
        {
            throw new InvalidOperationException("Deck is Empty!");
        }

        var n = rnd.Next(_hand.Count);
        var card = _hand[n];
        _hand.RemoveAt(n);
        return card;
    }

    public bool Has(Suit s) => _hand.Any(card => card.Suit== s);
    
    public bool Has(Value v) => _hand.Any(card => card.Value== v);
    
    public bool Has(Card c) => _hand.Any(card => card == c);
}