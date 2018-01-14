using System;
using System.Collections.Generic;

namespace FinalCompiler
{
    class Shell
    {
        private List<string> IDENTIFIES = new List<string>();
        private List<string> CONSTANTS = new List<string>();
        private Stack<string> TokensStack = new Stack<string>();
        private int CounterIdentifies = 0;
        private int CounterConstants = 0;
        public List<Stack<string>> OUT = new List<Stack<string>>();
        private string OutAdd = "";
        private string[] priority = { "15", "14", "16" };
        
        public Shell(Stack<string> TOKENS, List<string> IDENTIFIES, List<string> CONSTANTS)
        {
            this.TokensStack = TOKENS;
            this.IDENTIFIES = IDENTIFIES;
            this.CONSTANTS = CONSTANTS;
            FindOperations();
        }

        private void FindOperations()
        {
            while (TokensStack.Peek() != "03")
            {
                if (TokensStack.Pop() == "20")
                {
                    CounterIdentifies++;
                }
            }
            while (TokensStack.Count != 0)
            {
                switch (TokensStack.Peek())
                {
                    case "05":
                        {
                            Stack<string> s1 = new Stack<string>();
                            Stack<string> s2 = new Stack<string>();
                            
                            s1.Push(TokensStack.Pop());
                            while (TokensStack.Peek() != "12")
                            {
                                if (TokensStack.Pop() == "20")
                                {
                                    s1.Push(IDENTIFIES[CounterIdentifies++]);
                                }
                            }
                            while (s1.Count != 0)
                                s2.Push(s1.Pop());
                            OUT.Add(s2);
                            break;
                        }
                    case "06":
                        {
                            Stack<string> s1 = new Stack<string>();
                            Stack<string> s2 = new Stack<string>();
                            s1.Push(TokensStack.Pop());
                            while (TokensStack.Peek() != "12")
                            {
                                if (TokensStack.Pop() == "20")
                                {
                                    s1.Push(IDENTIFIES[CounterIdentifies++]);
                                }
                            }
                            while (s1.Count != 0)
                                s2.Push(s1.Pop());
                            OUT.Add(s2);
                            break;
                        }
                    case "07":
                        {
                            Stack<string> s1 = new Stack<string>();
                            Stack<string> s2 = new Stack<string>();
                            s1.Push(TokensStack.Pop());
                            s1.Push("$");
                            // прочитать переменную
                            // прочитать все до to
                            // прочитать все до do
                            // profit
                            s1.Push(IDENTIFIES[CounterIdentifies++]);
                            for (int i = 0; i < 2; TokensStack.Pop(), i++) ;
                            s2 = Equal("08");
                            TokensStack.Pop();
                            while (s2.Count != 0)
                                s1.Push(s2.Pop());
                            s2 = Equal("09");
                            s2.Pop();
                            while (s2.Count != 0)
                                s1.Push(s2.Pop());

                            //////////////////////////////////////////
                            while (TokensStack.Pop() != "10")
                            {
                                if (TokensStack.Peek() == "10")
                                    break;
                                //s1.Push(CONSTANTS[CounterConstants++]);
                                for (int i = 0; i < 2/*4*/; TokensStack.Pop(), i++) ;
                                s1.Push(IDENTIFIES[CounterIdentifies++]);
                                s2 = Equal("12");
                                while (s2.Count != 0)
                                    s1.Push(s2.Pop());
                            }
                            while (s1.Count != 0)
                                s2.Push(s1.Pop());
                            OUT.Add(s2);
                            break;
                        }
                    case "13":
                        {
                            Stack<string> s1 = new Stack<string>();
                            Stack<string> s2 = new Stack<string>();
                            s1.Push(IDENTIFIES[CounterIdentifies++]);
                            TokensStack.Pop();
                            s2 = Equal("12");
                            while (s2.Count != 0)
                                s1.Push(s2.Pop());
                            while (s1.Count != 0)
                                s2.Push(s1.Pop());
                            OUT.Add(s2);
                            break;
                        }
                    default:
                        {
                            TokensStack.Pop();
                            break;
                        }
                }
            }
        }

        private Stack<string> Equal(string end)
        {
            Stack<string> s1 = new Stack<string>();
            Stack<string> s2 = new Stack<string>();
            s1.Push("$");
            Stack<string> operations = new Stack<string>();
            operations.Push("00");
            while (TokensStack.Peek() != end)
            {
                switch (TokensStack.Peek())
                {
                    case "20": { s1.Push(IDENTIFIES[CounterIdentifies++]); TokensStack.Pop(); break; }
                    case "21": { s1.Push(CONSTANTS[CounterConstants++]); TokensStack.Pop(); break; }
                    default:
                        {
                            //для унарного минуса
                            //если стек пуст и мы считываем минус
                            if (s1.Peek() == "$" && TokensStack.Peek() == "15")
                                s1.Push("0");
                            if (operations.Peek() == "17" && TokensStack.Peek() == "15")
                                s1.Push("0");
                            if (operations.Peek() == "17" || operations.Peek() == "00")
                            {
                                operations.Push(TokensStack.Pop());
                                break;
                            }
                            if (TokensStack.Peek() == "17")
                            {
                                operations.Push(TokensStack.Pop());
                                break;
                            }
                            if (TokensStack.Peek() == "18")
                            {
                                while (operations.Peek() != "17")
                                {
                                    s1.Push(BinOp(operations.Pop()));
                                }
                                TokensStack.Pop();
                                operations.Pop();
                                break;
                            }
                            if (Convert.ToInt32(TokensStack.Peek()) > Convert.ToInt32(operations.Peek()))
                            {
                                operations.Push(TokensStack.Pop());
                            }
                            else
                            {
                                while (Convert.ToInt32(TokensStack.Peek()) > Convert.ToInt32(operations.Peek()) || operations.Peek() != "17")
                                {
                                    if (operations.Peek() == "00")
                                        break;
                                    s1.Push(BinOp(operations.Pop()));
                                }
                            }
                            break;
                        }
                }
            }
            while (operations.Peek() != "00")
                s1.Push(BinOp(operations.Pop()));
            s1.Push("$");
            while (s1.Count != 0)
                s2.Push(s1.Pop());
            return s2;
        }

        private string BinOp(string str)
        {
            if (str == "14")
                return "+";
            if (str == "15")
                return "-";
            return "*";
        }
    }
}
