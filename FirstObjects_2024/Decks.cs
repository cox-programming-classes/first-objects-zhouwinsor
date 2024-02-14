using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace FirstObjects_2024;
/// <summary>
/// represents a standard deck of playing cards
/// </summary>
public class Deck :IEnumerable<Card>{
    
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
    

    
    //Split is irrelevant but I feel bad deleting
    private (List<Card>, List<Card>) Split() {
        var pile1 = new List<Card>();
        var pile2 = new List<Card>();
        var count = _cards.Count;
        for (int i = 0; i < count; i++)
        {
            if (i % 2 == 0)
            {
                pile1.Add(DealOne());
            }
            else
            {
                pile2.Add(DealOne());
            }
        }

        return (pile1, pile2);
    }
    //shuffling a deck
    ///method: copy _cards to a new deck, make it empty, then start adding the cards randomly using the other method.
    public void Shuffle()
    {
        //do I need to make _cards null to re-add all of the cards randomly?
        (var pile1, var pile2) = Split();
        
        InsertCardsRandomly(pile1);
        InsertCardsRandomly(pile2);
        
        
        //carcass of old method
       /* for (int i =0; i<3; i++)
        {
            (var pile1, var pile2) = Split(_cards);
            InsertCardsRandomly(pile1);
            InsertCardsRandomly(pile2);
            // what do I do here
            // _cards = pile1 pile2;
            
        }
        */
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

    /// <summary>
    ///deals n cards from the deck, be sure to cast as a concrete type immediately
    /// </summary>
    /// <param name="n"> n = number of cards to return </param>
    /// <returns></returns>

    public IEnumerable<Card> Deal(int x)
    {
        for (int i = 0; i < x; i++)
        {
            yield return DealOne();
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



