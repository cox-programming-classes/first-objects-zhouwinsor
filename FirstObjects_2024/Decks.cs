using System.Collections;

namespace FirstObjects_2024;
/// <summary>
/// represents a standard deck of playing cards
/// </summary>
public class Deck:IEnumerable<Card>
{
    private List<Card> _cards;

    private Random rnd = new Random();
    // check if there are cards left in the deck:
    public bool IsEmpty => _cards.Count == 0;
// adding card(s) to the bottom of a deck;
    public void AddToBottom(Card card) => _cards.Add(card);
    public void AddToBottom(IEnumerable<Card> cards) => _cards.AddRange(cards);
    
    // Inserting a card randomly 
    public void InsertCardRandomly(Card card)
    {
        _cards.Insert(rnd.Next(_cards.Count), card);
    }
    
    //adding multiple cards to a deck randomly
    public void InsertCardsRandomly(IEnumerable<Card> cards)
    {
        foreach (var card in cards)
        {
            InsertCardRandomly(card);
        }
    }
    
    //shuffling a deck
    /* method:
     split the deck in half, then take one deck and insert it randomly into the other; repeat 3 times
     */
    
    private (List<Card>, List<Card>) Split(List<Card> cards) {
        var pile1 = new List<Card>();
        var pile2 = new List<Card>();
        var count = cards.Count;
        for (int i = 0; i < count; i++)
        {
            if (i % 2 == 0)
            {
                pile1.Add(cards[0]); 
                cards.RemoveAt(0);
            }
            else
            {
                pile2.Add(cards[0]); 
                cards.RemoveAt(0);
            }
        }

        return (pile1, pile2);
    }
    //i didn't finish this...
    public void Shuffle()
    {
        for (int i =0; i<3; i++)
        {
            
        }
    }
    
    public Deck()
    {
        _cards = [];
        foreach (var suit in Suit.AllSuits)
        {
            foreach (var value in Value.AceHighValues)
                _cards.Add(new(suit, value));
        }
    }

    public Card DealOne()
    {
        if (_cards.Count == 0)
        {
            throw new InvalidOperationException("Deck is Empty!");
        }

        var card = _cards.First();
        _cards.RemoveAt(0);
        return card;

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




