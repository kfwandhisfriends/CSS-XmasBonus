// See https://aka.ms/new-console-template for more information

using CSS_XmasBonus.OneTimePad_Hack;

class Program
{
    static void Main(string[] args)
    {
        OneTimePad_Hack();
    }

    static void OneTimePad_Hack()
    {
        Console.WriteLine("input plainText in original form: ");
        string plainTextOrigin = Console.ReadLine().Replace(" ", "");

        //make plainText to Ascii+Hex
        string plainText = AsciiHexConverter.toAsciiHex(plainTextOrigin);

        Console.WriteLine("CipherText in Ascii+Hex form: ");
        string cipherText = Console.ReadLine().Replace(" ", "");

        // check the correctness of inputs
        if (plainText.Length != cipherText.Length)
        {
            Console.WriteLine("bad input");
        }

        try
        {
            // calculate the key
            string key = KeyCalculator.CalculateKey(plainText, cipherText);
            Console.WriteLine($"the key is: {key}");

            // calculate the message(plaintext) based on the key
            Console.WriteLine("the Whole Cipher: ");
            string fullCipherText = Console.ReadLine().Replace(" ", "");

            Console.WriteLine("the Whole key: ");
            key = Console.ReadLine().Replace(" ", "");

            string decryptedMessage = plainTextCalculator.CalculatePlainText(key, fullCipherText);
            Console.WriteLine($"the decrypted message is: {decryptedMessage}");

        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

}