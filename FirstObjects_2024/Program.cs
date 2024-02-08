using FirstObjects_2024;


Deck decks = new();
foreach (var card in decks)
{
    Console.WriteLine(card);
}

Deck deck = new();
foreach (var card in deck)
{
    Console.WriteLine(card);
}

var cards = deck.Deal(5).ToList();
Console.WriteLine("I dealt some cards");
foreach (var card in cards)
{
    Console.WriteLine(card);
}

//creates a deck
/* List<Card> deck= [];
foreach (var suit in Suit.AllSuits)
{
    foreach (var value in Value.AceHighValues)
        deck.Add(new(suit, value));
}
*/
