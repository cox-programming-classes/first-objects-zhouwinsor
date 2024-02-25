using FirstObjects_2024;
Console.WriteLine("We are playing blackjack, u don't have a choice. Gambling is good!");
Deck deck = new();
deck.Shuffle();
Player dealer = new(), player = new();
dealer.Hit(deck.DealOne());
player.Hit(deck.DealOne());
dealer.Hit(deck.DealOne());
player.Hit(deck.DealOne());
Console.WriteLine($"Player: {player}");

while (!player.DidStand)
{
    if (dealer.Score < 18)
        dealer.Hit(deck.DealOne());
    else dealer.Stand();
    
    Console.WriteLine("use ur brain. [H]it or [S]tand?");
    var response = Console.ReadLine()!.ToUpperInvariant();
    if (response.StartsWith("H"))
        player.Hit(deck.DealOne());
    else if (response.StartsWith("S"))
    {
        player.Stand();
    }
    else Console.WriteLine("Choose a better option, dum-dum");
}
while (!dealer.DidStand)
{
    if (dealer.Score < 18)
    {
        dealer.Hit(deck.DealOne());
    }
    else dealer.Stand();
}
Console.WriteLine($"Dealer: {dealer}");
Console.WriteLine($"Player: {player}");
//this doesn't seem to be very efficient
if (dealer.Score > 21 && player.Score > 21)
{
    Console.WriteLine("U both lose. L");
}
else if (dealer.Score > 21)
{
    Console.WriteLine($"The player wins with a score of {player.Score}");
}
else if (player.Score > 21)
{
    Console.WriteLine($"The dealer wins with a score of {dealer.Score}");
}
else if (player.Score > dealer.Score)
{
    Console.WriteLine($"The dealer wins with a score of {dealer.Score}");
}

//I could keep going but I feel like it's sorta a waste of time


/*
Deck deck = new();
deck.Shuffle();
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
*/

//creates a deck
/* List<Card> deck= [];
foreach (var suit in Suit.AllSuits)
{
    foreach (var value in Value.AceHighValues)
        deck.Add(new(suit, value));
}
*/
