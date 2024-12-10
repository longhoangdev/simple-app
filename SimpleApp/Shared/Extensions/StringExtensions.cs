using System.Text.Json;
using System.Text.RegularExpressions;

namespace SimpleApp.Shared.Extensions;
public static class StringExtensions
{
    public static bool IsBlank(this string? str)
    {
        return string.IsNullOrWhiteSpace(str);
    }

    public static bool IsNotBlank(this string? str)
    {
        return !string.IsNullOrWhiteSpace(str);
    }

    public static string ToCamelCase(this string propertyName, bool ignoreFirstSplit = true)
    {
        if (string.IsNullOrWhiteSpace(propertyName))
            return string.Empty;

        if (ignoreFirstSplit)
        {
            var indexOfSplit = propertyName.IndexOf('.');
            if (indexOfSplit > -1)
                propertyName = propertyName[(indexOfSplit + 1)..];
        }

        string convertedToCamel;

        if (!propertyName.Contains('.'))
            convertedToCamel = JsonNamingPolicy.CamelCase.ConvertName(propertyName);
        else
        {
            var fullName = from prop in propertyName.Split('.', StringSplitOptions.RemoveEmptyEntries)
                           select JsonNamingPolicy.CamelCase.ConvertName(prop);

            convertedToCamel = string.Join('.', fullName);
        }

        return convertedToCamel;
    }
    public static string ToSnakeCase(this string input)
    {
        string snakeCase = Regex.Replace(input, "([a-z])([A-Z])", "$1_$2").ToLower();
        return snakeCase;
    }


    public static bool EqualsTo(this string? str1, string? str2, bool ignoreCase = true)
    {
        if (str1 == null || str2 == null) return false;
        if (ignoreCase)
        {
            return str1.Equals(str2, StringComparison.OrdinalIgnoreCase);
        }

        return str1.Equals(str2);
    }

    public static bool HasIndexIn(this string? str, params string[] strArr)
    {
        if (strArr.Length == 0) return false;

        foreach (string str2 in strArr)
        {
            if (str.EqualsTo(str2)) return true;
        }

        return false;
    }
}