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
            var sorted = _hand.OrderBy(card => (int)card.Value);
            foreach (var card in sorted)
            {
                if (card.Value == 11 || card.Value == 12 || card.Value == 13) {
                    total += 10;
                }
                else if (card.Value == 14) {
                    total += 11;
                    if (total > 21) {
                        total -= 10;
                    }
                }
                else
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