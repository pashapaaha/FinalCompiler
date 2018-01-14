using System.Collections.Generic;

namespace FinalCompiler
{
    class Parser
    {
        private Stack<string> Tokens = new Stack<string>();
        private Stack<string> TokensStack = new Stack<string>();
        private Stack<string> StatesStack = new Stack<string>();
        public string ResultMessage = "";
        public int success;
        public Stack<string> TokensShell = new Stack<string>();
        public Parser(Stack<string> Tokens)
        {
            this.Tokens = Tokens;
            success = Parsing();
        }
        //создаем список состояний
        string[,] States = { { "04", "53", "03", "12", "02", "11", "51", "00", "", "", "" },
                             { "54", "12", "18", "51", "17", "00", "", "", "", "", "" },
                             { "54", "12", "10", "64", "09", "63", "08", "58", "13", "20", "00" },
                             { "54", "12", "58", "13", "00", "", "", "", "", "", "" },
                             { "12", "58", "13", "00", "", "", "", "", "", "", "" },
                             { "57", "55", "11", "00", "", "", "", "", "", "", "" },
                             { "60", "18", "58", "00", "", "", "", "", "", "", "" } };
        //записываем лексемы в стек
        private void ToStack()
        {
            TokensStack.Push("$");
            while (Tokens.Count != 0)
            {
                TokensStack.Push(Tokens.Peek());
                TokensShell.Push(Tokens.Pop());
            }                
        }
        //парсер
        private int Parsing()
        {
            ToStack();
            StatesStack.Push("$");
            StatesStack.Push("50");
            while ((StatesStack.Count != 0) || (TokensStack.Count != 0))
            {
                switch (StatesStack.Pop())
                {
                    case "50":
                        {
                            switch (TokensStack.Pop())
                            {
                                case "01": { int i = 0; while (States[0, i] != "00") StatesStack.Push(States[0, i++]); break; }
                                default: { ResultMessage = "Ожидалось \"VAR\""; return 0; }
                            }
                            break;
                        }
                    case "51":
                        {
                            switch (TokensStack.Pop())
                            {
                                case "20": { StatesStack.Push("52"); break; }
                                case "91": { ResultMessage = "Недопустимый код"; return 0; }
                                case "92": { ResultMessage = "Превышена длина названия переменной"; return 0; }
                                case "93": { ResultMessage = "Повторное объявление переменной"; return 0; }
                                case "94": { ResultMessage = "Необъявленная переменная"; return 0; }
                                case "95": { ResultMessage = "Неверное имя переменной"; return 0; }
                                default: { ResultMessage = "Ожидалась переменная"; return 0; }
                            }
                            break;
                        }
                    case "52":
                        {
                            switch (TokensStack.Pop())
                            {
                                case "19": { StatesStack.Push("51"); break; }
                                case "11": { StatesStack.Pop(); break; }
                                case "18": { StatesStack.Pop(); break; }
                                default: { ResultMessage = "Синтаксическая ошибка"; return 0; }
                            }
                            break;
                        }
                    case "53":
                        {
                            switch (TokensStack.Pop())
                            {
                                case "05": { int i = 0; while (States[1, i] != "00") StatesStack.Push(States[1, i++]); break; }
                                case "06": { int i = 0; while (States[1, i] != "00") StatesStack.Push(States[1, i++]); break; }
                                case "07": { int i = 0; while (States[2, i] != "00") StatesStack.Push(States[2, i++]); break; }
                                case "20": { int i = 0; while (States[3, i] != "00") StatesStack.Push(States[3, i++]); break; }
                                case "91": { ResultMessage = "Недопустимый код"; return 0; }
                                case "92": { ResultMessage = "Превышена длина названия переменной"; return 0; }
                                case "93": { ResultMessage = "Повторное объявление переменной"; return 0; }
                                case "94": { ResultMessage = "Необъявленная переменная"; return 0; }
                                case "95": { ResultMessage = "Неверное имя переменной"; return 0; }
                                default: { ResultMessage = "Синтаксическая ошибка"; return 0; }
                            }
                            break;
                        }
                    case "54":
                        {
                            switch (TokensStack.Peek())
                            {
                                case "05": { StatesStack.Push("53"); break; }
                                case "06": { StatesStack.Push("53"); break; }
                                case "07": { StatesStack.Push("53"); break; }
                                case "20": { StatesStack.Push("53"); break; }
                                case "04": { StatesStack.Pop(); TokensStack.Pop(); break; }
                                case "10": { break; }
                                case "91": { ResultMessage = "Недопустимый код"; return 0; }
                                case "92": { ResultMessage = "Превышена длина названия переменной"; return 0; }
                                case "93": { ResultMessage = "Повторное объявление переменной"; return 0; }
                                case "94": { ResultMessage = "Необъявленная переменная"; return 0; }
                                case "95": { ResultMessage = "Неверное имя переменной"; return 0; }
                                default: { ResultMessage = "Синтаксическая ошибка"; return 0; }
                            }
                            break;
                        }
                    case "55":
                        {
                            switch (TokensStack.Pop())
                            {
                                case "20": { int i = 0; while (States[4, i] != "00") StatesStack.Push(States[4, i++]); break; }
                                case "91": { ResultMessage = "Недопустимый код"; return 0; }
                                case "92": { ResultMessage = "Превышена длина названия переменной"; return 0; }
                                case "93": { ResultMessage = "Повторное объявление переменной"; return 0; }
                                case "94": { ResultMessage = "Необъявленная переменная"; return 0; }
                                case "95": { ResultMessage = "Неверное имя переменной"; return 0; }
                                default: { ResultMessage = "Синтаксическая ошибка"; return 0; }
                            }
                            break;
                        }
                    case "56":
                        {
                            switch (TokensStack.Pop())
                            {
                                case "21": { int i = 0; while (States[5, i] != "00") StatesStack.Push(States[5, i++]); break; }
                                default: { ResultMessage = "Синтаксическая ошибка"; return 0; }
                            }
                            break;
                        }
                    case "57":
                        {
                            switch (TokensStack.Peek())
                            {
                                case "21": { StatesStack.Push("56"); break; }
                                case "09": { TokensStack.Pop(); break; }
                                default: { ResultMessage = "Синтаксическая ошибка"; return 0; }
                            }
                            break;
                        }
                    case "58":
                        {
                            switch (TokensStack.Peek())
                            {
                                case "15": { TokensStack.Pop(); StatesStack.Push("59"); break; }
                                case "17": { StatesStack.Push("59"); break; }
                                case "20": { StatesStack.Push("59"); break; }
                                case "21": { StatesStack.Push("59"); break; }
                                case "91": { ResultMessage = "Недопустимый код"; return 0; }
                                case "92": { ResultMessage = "Превышена длина названия переменной"; return 0; }
                                case "93": { ResultMessage = "Повторное объявление переменной"; return 0; }
                                case "94": { ResultMessage = "Необъявленная переменная"; return 0; }
                                case "95": { ResultMessage = "Неверное имя переменной"; return 0; }
                                default: { ResultMessage = "Некорректное выражение"; return 0; }
                            }
                            break;
                        }
                    case "63":
                        {
                            switch (TokensStack.Peek())
                            {
                                case "15": { TokensStack.Pop(); StatesStack.Push("59"); break; }
                                case "17": { StatesStack.Push("59"); break; }
                                case "21": { StatesStack.Push("59"); break; }
                                case "91": { ResultMessage = "Недопустимый код"; return 0; }
                                case "92": { ResultMessage = "Превышена длина названия переменной"; return 0; }
                                case "93": { ResultMessage = "Повторное объявление переменной"; return 0; }
                                case "94": { ResultMessage = "Необъявленная переменная"; return 0; }
                                case "95": { ResultMessage = "Неверное имя переменной"; return 0; }
                                default: { ResultMessage = "Некорректное выражение"; return 0; }
                            }
                            break;
                        }
                    case "64":
                        {
                            switch (TokensStack.Pop())
                            {
                                case "20": { int i = 0; while (States[3, i] != "00") StatesStack.Push(States[3, i++]); break; }
                                case "91": { ResultMessage = "Недопустимый код"; return 0; }
                                case "92": { ResultMessage = "Превышена длина названия переменной"; return 0; }
                                case "93": { ResultMessage = "Повторное объявление переменной"; return 0; }
                                case "94": { ResultMessage = "Необъявленная переменная"; return 0; }
                                case "95": { ResultMessage = "Неверное имя переменной"; return 0; }
                                default: { ResultMessage = "Синтаксическая ошибка"; return 0; }
                            }
                            break;
                        }

                    case "59":
                        {
                            switch (TokensStack.Pop())
                            {
                                case "17": { int i = 0; while (States[6, i] != "00") StatesStack.Push(States[6, i++]); break; }
                                case "20": { StatesStack.Push("60"); break; }
                                case "21": { StatesStack.Push("60"); break; }
                                case "91": { ResultMessage = "Недопустимый код"; return 0; }
                                case "92": { ResultMessage = "Превышена длина названия переменной"; return 0; }
                                case "93": { ResultMessage = "Повторное объявление переменной"; return 0; }
                                case "94": { ResultMessage = "Необъявленная переменная"; return 0; }
                                case "95": { ResultMessage = "Неверное имя переменной"; return 0; }
                                default: { ResultMessage = "Синтаксическая ошибка"; return 0; }
                            }
                            break;
                        }
                    case "60":
                        {
                            switch (TokensStack.Pop())
                            {
                                case "14": { StatesStack.Push("59"); break; }
                                case "15": { StatesStack.Push("59"); break; }
                                case "16": { StatesStack.Push("59"); break; }
                                case "08": { StatesStack.Pop(); break; }
                                case "12": { StatesStack.Pop(); break; }
                                case "18": { StatesStack.Pop(); break; }
                                default: {if (StatesStack.Peek() == "09") { StatesStack.Pop(); break; }
                                        ResultMessage = "Синтаксическая ошибка"; return 0; }
                            }
                            break;
                        }
                    case "02":
                        {
                            switch (TokensStack.Pop())
                            {
                                case "02": { break; }
                                default: { ResultMessage = "Ожидалось \"integer\""; return 0; }
                            }
                            break;
                        }
                    case "03":
                        {
                            switch (TokensStack.Pop())
                            {
                                case "03": { break; }
                                default: { ResultMessage = "Ожидалось \"begin\""; return 0; }
                            }
                            break;
                        }
                    case "12":
                        {
                            switch (TokensStack.Pop())
                            {
                                case "12": { break; }
                                default: { if(TokensStack.Peek() == "12" ) { TokensStack.Pop(); break; }
                                        ResultMessage = "Ожидалось \";\""; return 0; }
                            }
                            break;
                        }
                    case "13":
                        {
                            switch (TokensStack.Pop())
                            {
                                case "13": { break; }
                                default: {if (TokensStack.Peek() == "13") { TokensStack.Pop(); break; }
                                        ResultMessage = "Ожидалось \"=\""; return 0; }
                            }
                            break;
                        }
                    case "11":
                        {
                            switch (TokensStack.Pop())
                            {
                                case "11": { break; }
                                default: { ResultMessage = "Ожидалось \":\""; return 0; }
                            }
                            break;
                        }
                    case "17":
                        {
                            switch (TokensStack.Pop())
                            {
                                case "17": { break; }
                                default: { ResultMessage = "Ожидалось \"(\""; return 0; }
                            }
                            break;
                        }
                    case "18":
                        {
                            switch (TokensStack.Pop())
                            {
                                case "18": { break; }
                                default: { ResultMessage = "Ожидалось \")\""; return 0; }
                            }
                            break;
                        }
                    case "$":
                        {
                            switch (TokensStack.Pop())
                            {
                                case "$": { break; }
                                default: { ResultMessage = "Некорректное завершение"; return 0; }
                            }
                            break;
                        }
                    default: { break; }
                }
            }
            ResultMessage = "Компиляция прошла успешно";
            return 1;
        }
    }
}
