// top level statement model 
Console.WriteLine("Hello, World!");

// reading args
// dotnet run -- Hashan Eranga Perera
Console.WriteLine(args);
// System.String[]

// in order to print everything 
// need to for each 
// dotnet run -- Hashan Eranga Perera
foreach (string arg in args)
{
    Console.WriteLine(arg);
}

string[] answers =
{
    "It is certain.",       "Reply hazy, try again.",     "Don’t count on it.",
    "It is decidedly so.",  "Ask again later.",           "My reply is no.",
    "Without a doubt.",     "Better not tell you now.",   "My sources say no.",
    "Yes – definitely.",    "Cannot predict now.",        "Outlook not so good.",
    "You may rely on it.",  "Concentrate and ask again.", "Very doubtful.",
    "As I see it, yes.",
    "Most likely.",
    "Outlook good.",
    "Yes.",
    "Signs point to yes.",
};

// How to display a random answer
var index = new Random().Next(answers.Length);
Console.WriteLine(answers[index]);















