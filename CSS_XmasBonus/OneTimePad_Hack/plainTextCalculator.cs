using System.Text;

namespace CSS_XmasBonus.OneTimePad_Hack;

public class plainTextCalculator
{
    /// <summary>
    /// Calculate the plaintext for a given key and ciphertext.
    /// </summary>
    /// <param name="key"> key in ascii+hex form. </param>
    /// <param name="cipherText"> cipher in ascii+hex form. </param>
    /// <returns></returns>
    public static string CalculatePlainText(string key, string cipherText)
    {
        if(key.Length != cipherText.Length)
        {
            throw new ArgumentException("Key and ciphertext must be the same length.");
        }

        var sb = new StringBuilder();
        for(int i = 0; i < key.Length; i += 2)
        {
            // slide
            string cipherHex = cipherText.Substring(i, 2);
            string keyHex = key.Substring(i, 2);

            byte cipherByte = Convert.ToByte(cipherHex, 16);
            byte keyByte = Convert.ToByte(keyHex, 16);

            // do Xor
            byte plainByte = (byte)(cipherByte ^ keyByte);
            sb.Append((char)plainByte);
        }

        return sb.ToString();
    }
}