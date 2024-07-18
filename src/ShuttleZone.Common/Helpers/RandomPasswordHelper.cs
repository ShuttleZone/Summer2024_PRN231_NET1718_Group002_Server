namespace ShuttleZone.Common.Helpers;

public static class RandomPasswordHelper
{
    private static readonly Random _random = new Random();
    private const string UpperCaseLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    private const string LowerCaseLetters = "abcdefghijklmnopqrstuvwxyz";
    private const string Digits = "0123456789";
    private const string SpecialCharacters = "!@#$%^&*()_+<>?";

    public static string GenerateRandomPassword(int length)
    {
        if (length < 4)
            throw new ArgumentException("Password length must be at least 4 to include all character types.");

        var passwordCharacters = new List<char>
        {
            UpperCaseLetters[_random.Next(UpperCaseLetters.Length)],
            LowerCaseLetters[_random.Next(LowerCaseLetters.Length)],
            Digits[_random.Next(Digits.Length)],
            SpecialCharacters[_random.Next(SpecialCharacters.Length)]
        };

        var allCharacters = UpperCaseLetters + LowerCaseLetters + Digits + SpecialCharacters;

        for (int i = passwordCharacters.Count; i < length; i++)
        {
            passwordCharacters.Add(allCharacters[_random.Next(allCharacters.Length)]);
        }

        return new string(passwordCharacters.OrderBy(_ => _random.Next()).ToArray());
    }
}
