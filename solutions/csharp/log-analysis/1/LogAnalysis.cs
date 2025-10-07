using System.Runtime.CompilerServices;

public static class LogAnalysis 
{
    // TODO: define the 'SubstringAfter()' extension method on the `string` type
    public static string SubstringAfter(this string str, string delimiters)
    {
        return str.Substring(str.IndexOf(delimiters) + delimiters.Length);
    }

    //TODO: define the 'SubstringBetween()' extension method on the `string` type
    public static string SubstringBetween(this string str, string startDelimiter, string endDelimiter)
    {
        return str.Substring(str.IndexOf(startDelimiter) + startDelimiter.Length,  
            str.IndexOf(endDelimiter) - (str.IndexOf(startDelimiter) + startDelimiter.Length));
    }

    // TODO: define the 'Message()' extension method on the `string` type
    public static string Message(this string str)
    {
        return str.SubstringAfter(": ");
    }

    // TODO: define the 'LogLevel()' extension method on the `string` type
    public static string LogLevel(this string str)
    {
        return str.SubstringBetween("[", "]");
    }
}