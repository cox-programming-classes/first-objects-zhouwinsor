namespace FirstObjects_2024;

/// <summary>
/// Class representing a standard Playing Card.
/// </summary>
public class Card : IComparable
{
    /// <summary>
    /// The Suit of this Card.
    /// </summary>
    public Suit Suit { get; }
    /// <summary>
    /// The Value of this Card.
    /// </summary>
    public Value Value { get; }

    /// <summary>
    /// Create an instance of a new Playing Card
    /// </summary>
    /// <param name="suit"></param>
    /// <param name="value"></param>
    public Card(Suit suit, Value value)
    {
        Suit = suit;
        Value = value;
    }

    /// <summary>
    /// Define what happens when you print a Card as text.
    /// </summary>
    /// <returns></returns>
    public override string ToString() => $"{Suit}{Value}";

    // a #region tag allows you to label a section of code so you
    // can find it easily later.  This has no impact on your code.
    #region Comparison Operators

    /// <summary>
    /// Used when comparing Cards or sorting Cards in a collection.
    /// </summary>
    /// <param name="obj">The thing that you're comparing this to</param>
    /// <returns></returns>
    public int CompareTo(object? obj)
    {
        return Value.CompareTo(obj);
    }

    // These methods define the behavior of the comparison operators.
    // This allows you to use comparison of Cards directly in
    // conditional statements.
    
    public static bool operator >(Card a, Card b) => a.Value > b.Value;
    public static bool operator <(Card a, Card b) => a.Value < b.Value;
    public static bool operator >=(Card a, Card b) => a.Value >= b.Value;
    public static bool operator <=(Card a, Card b) => a.Value <= b.Value;
    public static bool operator ==(Card a, Card b) => a.Value == b.Value;
    public static bool operator !=(Card a, Card b) => a.Value != b.Value;
    
    
    public bool Equals(Card other)
    {
        return Value == other.Value;
    }

    /// <summary>
    /// Define what it means for this Card to be Equal to something else.
    /// </summary>
    /// <param name="obj">The thing you are comparing to.</param>
    /// <returns>true if and only if `obj` is a Card with the same value.</returns>
    public override bool Equals(object? obj)
    {
        return obj is Card other && Equals(other);
    }

    /// <summary>
    /// This is not an important method to think about, but it is something
    /// that is used behind the scenes.  super not important to know what
    /// it means right now.
    /// C# complains if you define the Equals() method and don't define this.
    /// </summary>
    /// <returns>Computes the HashCode based on this Card's String representation.</returns>
    public override int GetHashCode()
    {
        return $"{this}".GetHashCode();
    }    
    
    #endregion // Comparison Operators.
}

/// <summary>
/// Suits of a Standard Playing Card
/// Only predefined values are usable.
/// All Suits are Read-Only!
/// </summary>
public readonly struct Suit
{
    
    public static readonly Suit Spades = new('\u2660');
    public static readonly Suit Hearts = new('\u2661');
    public static readonly Suit Clubs = new('\u2663');
    public static readonly Suit Diamonds = new('\u2662');

    /// <summary>
    /// Use this list when Creating a Deck
    /// </summary>
    public static readonly Suit[] AllSuits = [Spades, Hearts, Clubs, Diamonds];
    
    private readonly char _symbol;
    private Suit(char symbol)
    {
        _symbol = symbol;
    }

    /// <summary>
    /// Implicitly Convert a Suit to a Character
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static implicit operator char(Suit s) => s._symbol;
    
    public override string ToString() => $"{_symbol}";
}


/// <summary>
/// Value of a standard Playing Card.
/// Accounts for AceHigh and AceLow games.
/// Only predefined values are used.
/// All Values are Read-Only!
/// </summary>
public readonly struct Value : IComparable
{
    public static readonly Value AceLow = new(1);
    public static readonly Value Two = new(2);
    public static readonly Value Three = new(3);
    public static readonly Value Four = new(4);
    public static readonly Value Five = new(5);
    public static readonly Value Six = new(6);
    public static readonly Value Seven = new(7);
    public static readonly Value Eight = new(8);
    public static readonly Value Nine = new(9);
    public static readonly Value Ten = new(10);
    public static readonly Value Jack = new(11);
    public static readonly Value Queen = new(12);
    public static readonly Value King = new(13);
    public static readonly Value AceHigh = new(14);

    public static readonly Value[] AceLowValues =
    [
        AceLow,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King
    ];
    
    
    public static readonly Value[] AceHighValues =
    [
        AceHigh,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King
    ];
    private readonly int _value;

    /// <summary>
    /// Implicitly Convert a Value to its internal
    /// value so that you can use it for keeping score!
    /// </summary>
    /// <param name="v"></param>
    /// <returns>The value of this Value object</returns>
    public static implicit operator int(Value v) => v._value;
    
    private Value(int value)
    {
        _value = value;
    }
    
    public override string ToString() => _value switch
    {
        1 or 14 => "A",
        > 1 and < 11 => $"{_value}",
        11 => "J",
        12 => "Q",
        13 => "K",
        _ => "X"
    };

    public int CompareTo(object? obj)
    {
        return _value.CompareTo(obj);
    }

    public static bool operator >(Value a, Value b) => a._value > b._value;
    public static bool operator <(Value a, Value b) => a._value < b._value;
    public static bool operator >=(Value a, Value b) => a._value >= b._value;
    public static bool operator <=(Value a, Value b) => a._value <= b._value;
    public static bool operator ==(Value a, Value b) => a._value == b._value;
    public static bool operator !=(Value a, Value b) => a._value != b._value;
    
    public bool Equals(Value other)
    {
        return _value == other._value;
    }

    public override bool Equals(object? obj)
    {
        return obj is Value other && Equals(other);
    }

    public override int GetHashCode()
    {
        return _value;
    }
}