using System.Collections.Generic;
using System.Threading.Tasks;

namespace NSharp.Compiler
{
    public class Interpreter
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

                // So far, this code has looped over each character, and checked for comments, quotes,
                // and semicolons. It does not check for groups with things like { } yet. But, that's
                // fine, because we'll sort that out in step 2.

                // Just FYI: I have not tested this yet. So it may be completely broken. TODO
            }

            // Step 2: Take each command, parse what it's doing using the pieces, and convert them to
            // a simpler language. TODO
            // Note: to make things easier, when we get a method in the code, we'll probably just copy
            // its code when its called.

            // After that, we're done with the compilation. The rest of the process will be done at
            // runtime by executing the `ExecuteCode()` function.
        }

        public async Task ExecuteCode()
        {
            // Take each "command" parsed in the initialization, and execute it. We will have to store a
            // list of variables with their data (probably stored in simplest form), along with their
            // accessibility levels, other information, and garbage collection. Fun stuff. TODO
        }
    }
}
