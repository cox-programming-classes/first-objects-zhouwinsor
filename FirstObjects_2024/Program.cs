using FirstObjects_2024;

Random rnd = new();
Console.WriteLine("We are playing blackjack, u don't have a choice. Gambling is good!");
Deck deck = new();
deck.Shuffle();
Player dealer = new(), player = new();
int playerScore = 0;
int dealerScore = 0;
//playing the game...
while (deck.Count() >= 10)
{
    dealer.Hit(deck.DealOne());
    player.Hit(deck.DealOne());
    dealer.Hit(deck.DealOne());
    player.Hit(deck.DealOne());
    Console.WriteLine($"Player: {player}");
    Console.WriteLine($"Dealer: {dealer}");
    
    while(!dealer.DidStand) {
        if (dealer.Score <= 10)
            dealer.Hit(deck.DealOne());
        else if (dealer.Score < 21)
        {
            if (rnd.Next(2) == 0)
            { 
                dealer.Hit(deck.DealOne());
            }
        }
        else dealer.Stand();
    }

    while (!player.DidStand)
    {
        
        if (player.Score > 21)
        {
            player.Stand();
            Console.WriteLine("You went over 21!");
            break;
        }
        Console.WriteLine("use ur brain. [H]it or [S]tand?");
        var response = Console.ReadLine()!.ToUpperInvariant();
        if (response.StartsWith("H"))
        {
            player.Hit(deck.DealOne());
            Console.WriteLine($"Player: {player}");
        }

        else if (response.StartsWith("S"))
        {
            player.Stand();
        }
        else Console.WriteLine("Choose a better option, dum-dum");
    }

    Console.WriteLine($"Dealer: {dealer}");
    
//this doesn't seem to be very efficient
    if (dealer.Score > 21 && player.Score > 21)
    {
        Console.WriteLine("U both lose. L");
    }
    else if (dealer.Score > 21)
    {
        Console.WriteLine($"The player wins with a score of {player.Score}");
        playerScore += 1;
    }
    else if (player.Score > 21)
    {
        Console.WriteLine($"The dealer wins with a score of {dealer.Score}");
        dealerScore += 1;
    }
    else if (player.Score > dealer.Score)
    {
        Console.WriteLine($"The player wins with a score of {player.Score}");
        playerScore += 1;
    }
    else if (dealer.Score == player.Score)
    {
        Console.WriteLine($"Surprise, surprise. U guys tied with a score of {player.Score} ");
    }
    else
    {
        Console.WriteLine("The dealer won. womp womp");
        dealerScore += 1;
    }
    
    player.Reset();
    dealer.Reset();
    
    Console.WriteLine($"Your score is currently {playerScore}");
    Console.WriteLine($"The dealer's score is currently {dealerScore} ");
    Console.WriteLine();
}
Console.WriteLine($"Good game! Your final score is {playerScore}, and the dealer's final score is {dealerScore}");



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
