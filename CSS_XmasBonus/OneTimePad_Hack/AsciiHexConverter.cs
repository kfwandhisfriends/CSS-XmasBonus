namespace CSS_XmasBonus.OneTimePad_Hack;

public class AsciiHexConverter
{
    /// <summary>
    /// Convert a given plainText in form of "abcd1234" to Ascii+Hex.
    /// </summary>
    /// <param name="plainText"></param>
    /// <returns></returns>
    public static string toAsciiHex(string plainText)
    {
        char[] plainTextOrigin = plainText.ToCharArray();
        //make plainText to Ascii+Hex
        string asciiHex = "";
        foreach(char c in plainTextOrigin)
        {
            asciiHex += ((int)c).ToString("X");
        }

        return asciiHex;
    }
}