public struct CurrencyAmount
{
    private decimal amount;
    private string currency;

    public CurrencyAmount(decimal amount, string currency)
    {
        this.amount = amount;
        this.currency = currency;
    }

    // TODO: implement equality operators
    public static bool operator ==(CurrencyAmount amountA, CurrencyAmount amountB)
    {
        return amountA.currency == amountB.currency ? (amountA.amount == amountB.amount) : throw new ArgumentException();
    }
    public static bool operator !=(CurrencyAmount amountA, CurrencyAmount amountB)
    {
        return amountA.currency != amountB.currency ? throw new ArgumentException() : (amountA.amount != amountB.amount) ? true : false;
    }

    // TODO: implement comparison operators
    public static bool operator <(CurrencyAmount amountA, CurrencyAmount amountB)
    {
        return amountA.currency != amountB.currency ? throw new ArgumentException() : amountA.amount < amountB.amount ? true : false;
    }
    public static bool operator >(CurrencyAmount amountA, CurrencyAmount amountB)
    {
        return amountA.currency != amountB.currency ? throw new ArgumentException() : amountA.amount > amountB.amount ? true : false;
    }

    // TODO: implement arithmetic operators
    public static CurrencyAmount operator +(CurrencyAmount amountA, CurrencyAmount amountB)
    {
        return amountA.currency != amountB.currency ? throw new ArgumentException() : new CurrencyAmount(amountA.amount + amountB.amount, amountA.currency);
    }
    public static CurrencyAmount operator -(CurrencyAmount amountA, CurrencyAmount amountB)
    {
        return amountA.currency != amountB.currency ? throw new ArgumentException() : new CurrencyAmount(amountA.amount - amountB.amount, amountA.currency);
    }
    public static CurrencyAmount operator *(CurrencyAmount amountA, CurrencyAmount amountB)
    {
        return amountA.currency != amountB.currency ? throw new ArgumentException() : new CurrencyAmount(amountA.amount * amountB.amount, amountA.currency);
    }
    public static CurrencyAmount operator /(CurrencyAmount amountA, CurrencyAmount amountB)
    {
        return amountA.currency != amountB.currency ? throw new ArgumentException() : amountB.amount == 0 ? throw new DivideByZeroException() : new CurrencyAmount(amountA.amount / amountB.amount, amountA.currency);
    }

    // TODO: implement type conversion operators
    public static implicit operator decimal(CurrencyAmount c) => c.amount;
    public static explicit operator double(CurrencyAmount c) => (double)c.amount;
}
