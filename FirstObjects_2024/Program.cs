﻿using FirstObjects_2024;

Console.WriteLine("Let's Play Cards!");


Deck decks = new();
foreach (var card in decks)
{
    Console.WriteLine(card);
}

//creates a deck
List<Card> deck= [];
foreach (var suit in Suit.AllSuits)
{
    foreach (var value in Value.AceHighValues)
        deck.Add(new(suit, value));
}