using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace FirstObjects_2024;

public class Player
{
    //don't need a constructor function bc there is nothing that needs to be defined.
    private Hand _hand = new();
    public bool DidStand { get; private set; } = false;

    public int Score
    {
        get
        {
            var total = 0;
            //there's smtg about Enumerables?
            foreach (var card in _hand)
            {
                total += card.Value;
            }
            //why are there errors if I put this outside of the "get" curly brackets?
            //for calculating AceHigh, if there is an ace, you can have the console ask the player what they want to do
            return total;
        }
        
    }
    
  
    public void Hit(Card c) { _hand.Add(c);}

    public void Stand() {DidStand = true; }

    public void Reset()
    {
        _hand = new();
        DidStand = false;
    }
    public override string ToString() => $"{_hand} => {Score}";
    
}