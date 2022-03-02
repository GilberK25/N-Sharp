using System.Collections.Generic;

namespace NSharp.Compiler
{
    public class InterpreterV1
    {
        public const string VERSION = "1.0";

        private List<string[]> commands;

        public InterpreterV1(TextReader code) : this(code.ReadToEnd()) { }
        public InterpreterV1(string code)
        {
            commands = new();

            // Step 1: Split each command into its own string, and remove any unnecessary spacing.
            // Also split each command into its seperate pieces.
            // Be careful for things like quotes and comments.

            List<string> cmd = new();
            string piece = "";
            bool singleQ = false, doubleQ = false, lineComment = false, blockComment = false;
            for (int i = 0; i < code.Length; i++)
            {
                if (code[i] == '\n') lineComment = false;
                else if (code[i] == '\'' && !doubleQ) singleQ = !singleQ;
                else if (code[i] == '"' && !singleQ) doubleQ = !doubleQ;
                else if (code[i] == '/' && i != code.Length - 1 && code[i + 1] == '/') lineComment = true;

                if (lineComment || blockComment) continue;

                if ((code[i] == ' ' || code[i] == '\t') && !singleQ && !doubleQ)
                {
                    if (!string.IsNullOrWhiteSpace(piece))
                    {
                        piece = piece.Trim();
                        cmd.Add(piece);
                        piece = "";
                    }
                    continue;
                }
                else if (code[i] == ';' && !singleQ && !doubleQ)
                {
                    if (!cmd.Any(x => !string.IsNullOrWhiteSpace(x)))
                    {
                        commands.Add(cmd.Where(x => !string.IsNullOrWhiteSpace(x)).ToArray());
                        cmd.Clear();
                    }
                    continue;
                }

                piece += code[i];
            }
        }
    }
}
