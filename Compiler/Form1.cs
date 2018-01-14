using System;
using System.Windows.Forms;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;

namespace FinalCompiler
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private int len = 0;
        private static bool IsEnter = false;
        private static string ReadString = "";

        private delegate void AddText(string msg);
        private delegate void IsVisible(bool msg);

        private struct snd
        {
            public List<Stack<string>> IN;
            public RichTextBox rtb;

            public snd(List<Stack<string>> a, RichTextBox b)
            {
                IN = a;
                rtb = b;
            }
        };

        private struct CaseStruct
        {
            public int one;
            public string two;
            public string three;

            public CaseStruct(int a, string b, string c)
            {
                one = a;
                two = b;
                three = c;
            }
        };

        private struct ConstIdent
        {
            public string Ident;
            public string Const;

            public ConstIdent(string a, string b)
            {
                Ident = a;
                Const = b;
            }
        };

        private void compileButton_Click(object sender, EventArgs e)
        {
            outputBox.ForeColor = Color.White;
            Scanner scan = new Scanner(codeBox.Text);
            Parser pars = new Parser(scan.TOKENS);
            if (pars.success == 1)
            {
                Shell shell = new Shell(pars.TokensShell, scan.IDENTIFIES, scan.CONSTANTS);
                snd[] snd1 = { new snd(shell.OUT, outputBox) };
                Thread RunThread = new Thread(Run);
                RunThread.Start(snd1);
            }
            else
                outputBox.ForeColor = Color.Red;
            outputBox.Text = pars.ResultMessage + "\n";


        }
      
        private void button1_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void newFileButton_Click(object sender, EventArgs e)
        {
            codeBox.Text = "";
            outputBox.Text = "";
        }

        private void openFileButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog OpnFDlg = new OpenFileDialog())
            {
                try
                {
                    OpnFDlg.Filter = "Pascal (*.pas)|*.pas|All files(*.*)|*.*";
                    OpnFDlg.FilterIndex = 1;
                    OpnFDlg.InitialDirectory = "D:\\";
                    if (OpnFDlg.ShowDialog() == DialogResult.OK)
                        using (StreamReader sr = new StreamReader(OpnFDlg.FileName, Encoding.Default))
                        {
                            string str = sr.ReadToEnd();
                            sr.Close();
                            codeBox.Text = str;
                        }
                }
                catch (Exception msg)
                {
                    MessageBox.Show("Ошибка",msg.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void saveFileButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog sd = new SaveFileDialog();
            sd.DefaultExt = "*.pas";
            sd.Filter = "Pascal (*.pas)|*.pas";
            if (sd.ShowDialog() == DialogResult.OK && sd.FileName.Length > 0)
            {
                outputBox.SaveFile(sd.FileName, RichTextBoxStreamType.PlainText);
            }
        }

        private static void Run(object INI)
        {
            snd[] snd1 = (snd[])INI;
            List<ConstIdent> CI = new List<ConstIdent>();
            for (int i = 0; i < snd1[0].IN.Count(); i++)
            {
                while (snd1[0].IN[i].Count() != 0)
                {
                    switch (snd1[0].IN[i].Peek())
                    {
                        case "05":
                            {
                                if (snd1[0].rtb.InvokeRequired)
                                    snd1[0].rtb.Invoke(new IsVisible((s) => snd1[0].rtb.ReadOnly = s), false);

                                snd1[0].IN[i].Pop();
                                snd1[0].rtb.Invoke(new AddText((s) => snd1[0].rtb.AppendText(s)), "Ввод:\n");

                                while (snd1[0].IN[i].Count != 0)
                                {
                                    int rr = 0;
                                    string b = "";
                                    string a = snd1[0].IN[i].Pop();
                                    snd1[0].rtb.Invoke(new AddText((s) => snd1[0].rtb.AppendText(s)), a + " = ");

                                    while (rr == 0)
                                    {
                                        while (IsEnter == false)
                                        {
                                            Thread.Sleep(100);
                                        }

                                        b = ReadString;
                                        b = b.Substring(a.Length + 2);

                                        try
                                        {
                                            int k = Convert.ToInt32(b);
                                            IsEnter = false;
                                            rr++;
                                        }
                                        catch
                                        {
                                            if (snd1[0].rtb.InvokeRequired)
                                                snd1[0].rtb.Invoke(new AddText((s) => snd1[0].rtb.AppendText(s)),
                                                    "Неправильный тип\n" + a + " = ");
                                            IsEnter = false;
                                        }
                                    }
                                    CI.Add(new ConstIdent(a, b));
                                }
                                IsEnter = false;
                                if (snd1[0].rtb.InvokeRequired)
                                    snd1[0].rtb.Invoke(new IsVisible((s) => snd1[0].rtb.ReadOnly = s), true);

                                break;
                            }
                        case "06":
                            {
                                snd1[0].rtb.Invoke(new AddText((s) => snd1[0].rtb.AppendText(s)), "Вывод:\n");
                                snd1[0].IN[i].Pop();

                                while (snd1[0].IN[i].Count != 0)
                                {
                                    for (int j = CI.Count - 1; j >= 0; j--)
                                    {
                                        if (snd1[0].IN[i].Peek() == CI[j].Ident)
                                        {
                                            try
                                            {
                                                Convert.ToInt32(CI[j].Const);
                                                if (snd1[0].rtb.InvokeRequired)
                                                    snd1[0].rtb.Invoke(new AddText((s) => snd1[0].rtb.AppendText(s)),
                                                        Convert.ToString(CI[j].Ident + " = " + CI[j].Const + "\n"));
                                            }
                                            catch
                                            {
                                                if (snd1[0].rtb.InvokeRequired)
                                                    snd1[0].rtb.Invoke(new AddText((s) => snd1[0].rtb.AppendText(s)), "");
                                            }
                                            snd1[0].IN[i].Pop();
                                            break;
                                        }
                                    }
                                }
                                break;
                            }
                        case "07":
                            {
                                Stack<string> s1 = new Stack<string>();
                                //присвоить indexident значение первого выражения
                                //сохраняем стек
                                //цикл ( пока значение indexident < значения второго выражения)
                                // 
                                // производим вычисления 
                                // indexident++

                                string three;
                                snd1[0].IN[i].Pop();
                                snd1[0].IN[i].Pop();
                                string indexIdent = snd1[0].IN[i].Pop();
                                snd1[0].IN[i].Pop();
                                string expr1 = Operation(snd1[0].IN[i], CI);
                                CI.Add(new ConstIdent(indexIdent, expr1));
                                int expr1i = Convert.ToInt32(expr1);
                                snd1[0].IN[i].Pop();

                                string expr2 = Operation(snd1[0].IN[i], CI);
                                int expr2i = Convert.ToInt32(expr2);
                                snd1[0].IN[i].Pop();

                                Stack<string> reserve = new Stack<string>();
                                string[] arr = snd1[0].IN[i].ToArray();
                                for (int j = arr.Length - 1; j != -1; j--)
                                {
                                    reserve.Push(arr[j]);
                                }

                                while (expr1i <= expr2i)
                                {
                                    while (reserve.Count != 0)
                                    {
                                        string two = reserve.Pop();
                                        reserve.Pop();
                                        three = Operation(reserve, CI);
                                        CI.Add(new ConstIdent(two, three));
                                        reserve.Pop();
                                    }
                                    expr1i++;
                                    CI.Add(new ConstIdent(indexIdent, expr1i.ToString()));
                                    for (int j = arr.Length - 1; j != -1; j--)
                                    {
                                        reserve.Push(arr[j]);
                                    }
                                }
                                while (snd1[0].IN[i].Count != 0)
                                    snd1[0].IN[i].Pop();




                                break;
                            }
                        default:
                            {
                                if (snd1[0].IN[i].Count() == 4)
                                {
                                    string a = snd1[0].IN[i].Pop();
                                    snd1[0].IN[i].Pop();
                                    string err = TryFind(snd1[0].IN[i].Pop(), CI);
                                    CI.Add(new ConstIdent(a, err));
                                    snd1[0].IN[i].Pop();
                                    break;
                                }
                                else
                                {
                                    string a = snd1[0].IN[i].Pop();
                                    snd1[0].IN[i].Pop();
                                    string ww = Operation(snd1[0].IN[i], CI);
                                    if (ww == "Переменная не установлена" || ww == "Деление на ноль")
                                        if (snd1[0].rtb.InvokeRequired)
                                            snd1[0].rtb.Invoke(new AddText((s) => snd1[0].rtb.AppendText(s)), ww + "\n");
                                    CI.Add(new ConstIdent(a, ww));
                                    snd1[0].IN[i].Pop();
                                }
                                break;
                            }
                    }
                }
            }
            snd1[0].rtb.Invoke(new AddText((s) => snd1[0].rtb.AppendText(s)), "Компиляция завершена\n");
        }

        private static string TryFind(string a, List<ConstIdent> ci)
        {
            int ret;
            int kol = 0;
            while (true)
            {
                try
                {
                    ret = Convert.ToInt32(a);
                    return a;
                }
                catch
                {
                    kol = 0;
                    for (int j = ci.Count - 1; j >= 0; j--)
                    {
                        if (ci[j].Ident == a)
                        {
                            a = ci[j].Const;
                            kol++;
                            break;
                        }
                    }
                    if (kol == 0)
                        return "Переменная не усановлена";
                }
            }
        }

        private static string Operation(Stack<string> a, List<ConstIdent> CI)
        {
            Stack<string> s1 = new Stack<string>();
            while (a.Peek() != "$")
            {
                switch (a.Peek())
                {
                    case "+":
                        {
                            a.Pop();
                            int b1, c1;
                            try
                            {
                                b1 = Convert.ToInt32(TryFind(s1.Pop(), CI));
                                c1 = Convert.ToInt32(TryFind(s1.Pop(), CI));
                            }
                            catch
                            {
                                return "Переменная не установлена";
                            }
                            if (a.Peek() != "$")
                                s1.Push(Convert.ToString(b1 + c1));
                            else
                                return Convert.ToString(b1 + c1);
                            break;
                        }
                    case "-":
                        {
                            a.Pop();
                            int b1, c1;
                            try
                            {
                                b1 = Convert.ToInt32(TryFind(s1.Pop(), CI));
                                c1 = Convert.ToInt32(TryFind(s1.Pop(), CI));
                            }
                            catch
                            {
                                return "Переменная не установлена";
                            }
                            if (a.Peek() != "$")
                                s1.Push(Convert.ToString(c1 - b1));
                            else
                                return Convert.ToString(c1 - b1);
                            break;
                        }
                    case "*":
                        {
                            a.Pop();
                            int b1, c1;
                            try
                            {
                                b1 = Convert.ToInt32(TryFind(s1.Pop(), CI));
                                c1 = Convert.ToInt32(TryFind(s1.Pop(), CI));
                                if (b1 == 0)
                                    return "Деление на ноль";
                            }
                            catch
                            {
                                return "Переменная не установлена";
                            }
                            if (a.Peek() != "$")
                                s1.Push(Convert.ToString(c1 * b1));
                            else
                                return Convert.ToString(c1 * b1);
                            break;
                        }
                    default:
                        {
                            s1.Push(a.Pop());
                            if (a.Peek() == "$" && s1.Count == 1)
                            {
                                return TryFind(s1.Pop(), CI);
                                return s1.Pop();
                            }
                            break;
                        }
                }
            }
            return "error";
        }

        private void outputBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (int)Keys.Control || e.KeyValue == (int)Keys.E || e.KeyValue == (int)Keys.J ||
                e.KeyValue == (int)Keys.R || e.KeyValue == (int)Keys.Z)
            {
                e.Handled = true;
            }
            if (e.KeyValue == (int)Keys.Control || e.KeyValue == (int)Keys.A)
            {
                e.Handled = true;
                int k = outputBox.Text.Length - outputBox.GetFirstCharIndexOfCurrentLine();
                outputBox.Select(outputBox.GetFirstCharIndexOfCurrentLine(), k);
                outputBox.Refresh();
            }
            if (e.KeyValue == (int)Keys.Control || e.KeyValue == (int)Keys.Home)
            {
                e.Handled = true;
            }
            if (e.KeyValue == (int)Keys.Up || e.KeyValue == (int)Keys.Down)
            {
                e.Handled = true;
            }
            if (e.KeyValue == (int)Keys.Left)
            {
                if (outputBox.SelectionStart <= len)
                {
                    e.Handled = true;
                }
            }
            if (e.KeyValue == (int)Keys.PageDown || e.KeyValue == (int)Keys.PageUp)
            {
                e.Handled = true;
            }
            if (e.KeyValue == (int)Keys.Back)
            {
                if (outputBox.SelectionStart <= len)
                {
                    e.Handled = true;
                }
            }
            if (e.KeyValue == (int)Keys.Enter)
            {
                if (outputBox.ReadOnly == false)
                {
                    ReadString =
                        outputBox.Lines[
                            outputBox.GetLineFromCharIndex(outputBox.GetFirstCharIndexFromLine(outputBox.SelectionStart - 1))];
                    IsEnter = true;
                }
                len = outputBox.SelectionStart = outputBox.Text.Length + 1;                
            }
        }
    }
}
