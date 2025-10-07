using System.Text.RegularExpressions;

public class LogParser
{
    private string[] ValidLogValues = ["TRC", "DBG", "INF", "WRN", "ERR", "FTL"];

    public bool IsValidLine(string text)
    {
        string pattern = @"^\[(?<value>.{3})\]";
        Match match = Regex.Match(text, pattern);
        return match.Success && ValidLogValues.Contains(match.Groups["value"].Value);
    }
    public string[] SplitLogLine(string text)
    {
        return Regex.Split(text, @"<[*^=-]*>");
    }
    public int CountQuotedPasswords(string lines)
    {
        return Regex.Count(lines, "\".*password.*\"", RegexOptions.IgnoreCase);
    }
    public string RemoveEndOfLineText(string line)
    {
        return Regex.Replace(line, @"end-of-line\d*", "");
    }
    public string[] ListLinesWithPasswords(string[] lines)
    {
        string[] res = [];
        string pattern = @"\bpassword\S+";
        foreach (var line in lines)
        {
            Match match = Regex.Match(line, pattern, RegexOptions.IgnoreCase);
            string password = match.Groups[0].Value;
            res = [.. res.Append($"{(password == string.Empty ? "--------" : password)}: {line}")];
        }
        return res;
    }
}
