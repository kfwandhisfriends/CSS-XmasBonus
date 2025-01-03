namespace CSS_XmasBonus.OneTimePad_Hack;

public class KeyCalculator
{
    /// <summary>
    /// Calculate the key for a given plaintext and ciphertext.
    /// </summary>
    /// <param name="plainText"> plainText in Ascii+Hex </param>
    /// <param name="cipherText"> cipherText in Ascii+Hex </param>
    /// <returns> the calculated key(part). </returns>
    /// <exception cref="ArgumentException"> if both Arguments don't have the same length. </exception>
    public static string CalculateKey(string plainText, string cipherText)
    {
        if(plainText.Length != cipherText.Length)
        {
            throw new ArgumentException("Plaintext and ciphertext must be the same length.");
        }

        // Convert the input into byte[]
        byte[] plainBytes = ConvertHexToByteArray(plainText);
        byte[] cipherBytes = ConvertHexToByteArray(cipherText);

        // store the key
        byte[] keyBytes = new byte[plainBytes.Length];

        // Do Xor
        for (int i = 0; i < plainBytes.Length; i++)
        {
            keyBytes[i] = (byte)(plainBytes[i] ^ cipherBytes[i]);
        }

        return BitConverter.ToString(keyBytes).Replace("-", "");
    }

    /// <summary>
    /// Convert a given hex string to a byte array.
    /// </summary>
    /// <param name="hex"></param>
    /// <returns></returns>
    private static byte[] ConvertHexToByteArray(string hex)
    {
        int length = hex.Length;
        byte[] byteArray = new byte[length / 2];
        for (int i = 0; i < length; i += 2)
        {
            byteArray[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
        }
        return byteArray;
    }
}