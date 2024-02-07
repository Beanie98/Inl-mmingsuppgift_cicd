var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello Hello!!!!");

app.MapGet("/encrypt", (string user_input) => Encrypt(user_input) );
app.MapGet("/decrypt", (string user_input) => Decrypt(user_input) );

app.Run();

string Encrypt(string input)
{
    return "Hello!! :D";
}

string Decrypt(string input)
{
    return "Goodbye!! D:";
}

