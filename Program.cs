using Bean;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var crypter = new EncryptDecrypt();

app.MapGet("/", () => "please add /encrypt?user_input= and then the message you want to encrypt, you can also decrypt by /decrypt?user_input= and then your encrypted message!");

app.MapGet("/encrypt", (string user_input) => crypter.Encrypt(user_input));
app.MapGet("/decrypt", (string user_input) => crypter.Decrypt(user_input));

app.Run();

namespace Bean
{
    public class EncryptDecrypt
    {
        readonly char[] Alphabet = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
        public string Encrypt(string input)
        {
            input = input.ToLower();

            char[] secretMessage = input.ToCharArray();
            char[] encryptedMessage = new char[secretMessage.Length];

            for (int i = 0; i < secretMessage.Length; i++)
            {
                char letter = secretMessage[i];
                int letterPos = Array.IndexOf(Alphabet, letter);
                int newLetterPos = (letterPos + 3) % Alphabet.Length;
                char letterEncoded = Alphabet[newLetterPos];
                encryptedMessage[i] = letterEncoded;
            }
            string encodedString = string.Join("", encryptedMessage);
            return encodedString;
        }

        public string Decrypt(string input)
        {
            char[] encryptedMessage = input.ToCharArray();
            char[] decryptedMessage = new char[encryptedMessage.Length];

            for (int i = 0; i < encryptedMessage.Length; i++)
            {
                char letter = encryptedMessage[i];
                int letterPos = Array.IndexOf(Alphabet, letter);
                int newLetterPos = (letterPos - 3 + Alphabet.Length) % Alphabet.Length;
                char letterDecoded = Alphabet[newLetterPos];
                decryptedMessage[i] = letterDecoded;
            }

            string decodedString = new string(decryptedMessage);
            return decodedString;
        }

    }
}
