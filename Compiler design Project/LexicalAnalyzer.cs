using System.Text.RegularExpressions;

public class LexicalAnalyzer
{
    public enum TokenType
    {
        Identifier,
        Number,
        Operator,
        Separator,
        Keyword,
        Error
    }

    public class Token
    {
        public TokenType Type { get; set; }
        public string Value { get; set; }
    }

    private readonly Dictionary<string, TokenType> keywords = new Dictionary<string, TokenType>
    {
        { "if", TokenType.Keyword },
        { "else", TokenType.Keyword },
        { "while", TokenType.Keyword },
        { "Console", TokenType.Keyword },
        { ".", TokenType.Keyword },
        { "WriteLine", TokenType.Keyword },
        { "Console.Writeline", TokenType.Keyword },
        // Add more keywords as needed
    };
    private readonly string[] operators = { "+", "-", "*", "/", "=", ">", "<", "==" /* Add more operators */ };
    private readonly char[] separators = { '(', ')', '{', '}', ',', ';' /* Add more separators */ };
    public List<Token> Analyze(string code)
    {
        List<Token> tokens = new List<Token>();
        string[] lines = code.Split('\n');
        foreach (string line in lines)
        {
            string[] words = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            foreach (string word in words)
            {
                Token token = new Token();
                // Check for Keywords
                if (keywords.ContainsKey(word))
                {
                    token.Type = keywords[word];
                    token.Value = word;
                }
                // Check for Operators
                else if (Array.Exists(operators, op => op == word))
                {
                    token.Type = TokenType.Operator;
                    token.Value = word;
                }
                // Check for Separators
                else if (Array.Exists(separators, sep => sep.ToString() == word))
                {
                    token.Type = TokenType.Separator;
                    token.Value = word;
                }
                // Check for Numbers
                else if (Regex.IsMatch(word, @"^\d+$"))
                {
                    token.Type = TokenType.Number;
                    token.Value = word;
                }
                // Check for Identifiers
                else if (Regex.IsMatch(word, @"^[a-zA-Z_]\w*$"))
                {
                    token.Type = TokenType.Identifier;
                    token.Value = word;
                }
                else
                {
                    token.Type = TokenType.Error;
                    token.Value = word;
                }

                tokens.Add(token);
            }
        }

        return tokens;
    }
}
