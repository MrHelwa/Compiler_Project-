using Compiler_design_Project;
class Program
{
    static void Main()
    {
        string code = @"int a = 10 ; if ( a > 5 ) { Console.WriteLine ( "" Hello, World! "" ) ; } ";

        LexicalAnalyzer lexer = new LexicalAnalyzer();
        List<LexicalAnalyzer.Token> tokens = lexer.Analyze(code);
        Console.WriteLine("Tokens:");
        foreach (var token in tokens)
        {
            Console.WriteLine($"Type: {token.Type}, Value: {token.Value}");
        }

        string code2 = "5 + 3";

        LexicalAnalyzer lexer2 = new LexicalAnalyzer();
        List<LexicalAnalyzer.Token> tokens2 = lexer2.Analyze(code2);

        SyntaxAnalyzer syntaxAnalyzer = new SyntaxAnalyzer();
        bool isValid = syntaxAnalyzer.ParseExpression(tokens2);

        Console.WriteLine($"Is Expression Valid? {isValid}");
    }
}
