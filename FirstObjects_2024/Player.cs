using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace FirstObjects_2024;

public class Player
{
    private Hand _hand;
    public bool DidStand = false;
    public int score;
    public Player()
    {
        _hand = new();
    }

    public void Hit(Card c) { _hand.Add(c);}

    public void Stand() {DidStand = true; }

    public void Reset() { _hand = new();}

    public void Score()
    {
    }


}