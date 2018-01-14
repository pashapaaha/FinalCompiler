using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace FinalCompiler
{
    internal class Scanner
    {
        private const int IdentLength = 12;
        private string Code;
        private int FindInt = 0;
        public string Error = "";
        public int kolError = 0;

        private struct SyntaxElem
        {
            public string Words;
            public string WordKey;

            public SyntaxElem(string a, string b)
            {
                Words = a;
                WordKey = b;
            }

        }

        private SyntaxElem[] KEYWORDS =
        {
            new SyntaxElem("VAR", "01"), new SyntaxElem("INTEGER", "02"), new SyntaxElem("BEGIN", "03"),
            new SyntaxElem("END", "04"), new SyntaxElem("READ", "05"), new SyntaxElem("WRITE", "06"),
            new SyntaxElem("FOR", "07"), new SyntaxElem("TO", "08"), new SyntaxElem("DO", "09"),
            new SyntaxElem("END_FOR", "10")
        };

        private SyntaxElem[] SYMBOLS =
        {
            new SyntaxElem(":", "11"), new SyntaxElem(";", "12"), new SyntaxElem("=", "13"),
            new SyntaxElem("+", "14"), new SyntaxElem("-", "15"), new SyntaxElem("*", "16"),
            new SyntaxElem("(", "17"), new SyntaxElem(")", "18"), new SyntaxElem(",", "19")
        };

        
        private string rgz = @"(?<char>[^:;\(\)\=\+\-\*\s\,]*)(?<separator>[:;\(\)\=\+\-\*\s\,]{1})?";

        //список полученных токенов, идентификаторов, констант
        public Stack<string> TOKENS = new Stack<string>();
        public List<string> IDENTIFIES = new List<string>();
        public List<string> CONSTANTS = new List<string>();

        public Scanner()
        {
            this.Error = "Lexer error.\n";
        }

        public Scanner(string Code)
        {
            this.Code = Code;
            string pattern = "( )+";
            string replacement = " ";
            if (this.Code.Length == 0)
            {
                this.Error += "Error: No entry.\n";
            }
            else
            {
                //удаление лишних пробелов, перевод в вверхний регистр
                Regex rgx = new Regex(pattern);
                this.Code = rgx.Replace(this.Code, replacement);
                this.Code = this.Code.ToUpper();
            }
            ScannerOut();
        }

        private void ScannerOut()
        {
            Match match = Regex.Match(this.Code, this.rgz);
            while (match.Success)
            {
                if (match.Groups["char"].Length > 0)
                    if (!IsKeyword(match.Groups["char"].ToString(), KEYWORDS))
                        if (!IsIdenOrConst(match.Groups["char"].ToString(),
                            "[^0-9]+", "21", CONSTANTS, int.MaxValue.ToString().Length))
                        {
                            IDENTIFIES.Add(match.Groups["char"].ToString());
                            AddError(match.Groups["char"].ToString());
                        }
                if ((match.Groups["separator"].ToString() != " ") && (match.Groups["separator"].ToString() != "\n"))
                    IsKeyword(match.Groups["separator"].ToString(), SYMBOLS);
                match = match.NextMatch();
            }
        }

        private bool IsKeyword(string word, SyntaxElem[] kwd)
        {
            bool TOF = false;
            for (int i = 0; i < kwd.Count(); i++)
            {
                if (kwd[i].Words == word)
                {
                    TOKENS.Push(kwd[i].WordKey);
                    TOF = true;
                    if (word == "BEGIN")
                        FindInt = IDENTIFIES.Count;
                    break;
                }
            }
            return TOF;
        }


        private bool IsIdenOrConst(string word, string regular, string ID, List<string> lst, int len)
        {
            bool TOF = true;
            if (Regex.Match(word, regular).Success)
                TOF = false;
            else
            {
                TOKENS.Push(ID);
                lst.Add(word);
            }
            return TOF;
        }

        private void AddError(string word)
        {
            int kol = 0;
            for (int i = 0; i < 5; i++)
            {
                switch (i)
                {
                    case 0: { if (Regex.Match(word, @"[^A-Z0-9:;\(\)\=\+\-\*\s\,]").Success) { kol++; TOKENS.Push("91"); } break; }
                    case 1: { if (word.Length > IdentLength) { kol++; TOKENS.Push("92"); } break; }
                    case 2: { int k2 = 0; if (FindInt == 0) for (int j = 0; j < IDENTIFIES.Count; j++) if (word == IDENTIFIES[j]) k2++; if (k2 > 1) { kol++; TOKENS.Push("93"); } break; }
                    case 3: { int k2 = 1; if (FindInt != 0) { k2 = 0; for (int j = 0; j < FindInt; j++) if (word == IDENTIFIES[j]) k2++; } if (k2 == 0) { kol++; TOKENS.Push("94"); } break; }
                    case 4: { if (Regex.Match(word, "[^A-Z]").Success) { kol++; TOKENS.Push("95"); } break; }
                }
            }
            if (kol == 0)
                TOKENS.Push("20");
        }
    }

}
