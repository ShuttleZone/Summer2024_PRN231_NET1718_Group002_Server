using System.Text;

namespace ShuttleZone.Common.Helpers;

public static class StringInterpolationHelper
{
    private static readonly Random Random = new Random();
    private static StringBuilder? _builder;
    private static StringBuilder Builder
    {
        get
        {
            if (_builder is null)
            {
                _builder = new StringBuilder();
            }

            return _builder;
        }
    }
    public static String BuildAndClear()
    {
        var result = Builder.ToString();
        Builder.Clear();
        return result;
    }

    public static void AppendWithDefaultFormat(string content)
    {
        Builder.Append($" - {content}");
    }

    public static void AppendToStart(string content)
    {
        Builder.Clear();
        Builder.Append(content);
    }

    public static void Clear()
    {
        Builder.Clear();
    }

    public static void Append(string content)
    {
        Builder.Append(content);
    }

    public static string TrimSpaceString(this string content)
    {
        return content.Replace(" ", "");
    }
    
    public static string GenerateUniqueName(string name, int length = 10)
    {
        if (length <= 0) throw new Exception("Invalid Length");
        var originalName = name.Split(".")[0].Replace(" ","");
        var extenstionName = name.Split(".")[1];
         var uniqueFileName = originalName + GenerateRandomString(length) + "." + extenstionName;
        return uniqueFileName.TrimSpaceString();
    }
    
    private static string GenerateRandomString(int length)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        const string specialChars = "!@#$%^&*()_+";
        return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[Random.Next(s.Length)])
            .ToArray()
            .Append(specialChars[Random.Next(specialChars.Length)]).ToArray());
    }
}