using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler_design_Project
{
    public  class SyntaxAnalyzer
    {
        public bool ParseExpression(List<LexicalAnalyzer.Token> tokens)
        {
            // Simplified syntax analysis for an arithmetic expression
            // Check if the expression follows the pattern: Number Operator Number
            if (tokens.Count == 3 &&tokens[0].Type == LexicalAnalyzer.TokenType.Number && 
                tokens[1].Type == LexicalAnalyzer.TokenType.Operator &&
                tokens[2].Type == LexicalAnalyzer.TokenType.Number)
            {
                return true; // Valid expression
            }
            return false; // Invalid expression
        }
    }
}
