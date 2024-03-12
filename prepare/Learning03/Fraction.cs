public class Fraction
{
    private int _top;
    private int _bottom;

    public Fraction()
    {
        SetTop(1);
        SetBottom(1);
    }

    public Fraction(int WholeNumber)
    {
        SetTop(WholeNumber);
        SetBottom(1);
    }

    public Fraction(int top, int bottom)
    {
        SetTop(top);
        SetBottom(bottom);
    }

    public int GetTop()
    {
        return _top;
    }

    public void SetTop(int top)
    {
        _top = top;
    }

    public int GetBottom()
    {
        return _bottom;
    }

    public void SetBottom(int bottom)
    {
        if (bottom != 0)
        {
            _bottom = bottom;
        }
        else
        {
            Console.WriteLine("Cannot divide by zero, denominator has been set to 1 instead.");
            _bottom = 1;
        }
    }

    public string GetFractionString()
    {
        return $"{_top}/{_bottom}";
    }

    public double GetDecimalValue()
    {
        return (double)_top / (double)_bottom;
    }
}