using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    class Context
    {
        Dictionary<string, int> variables;

        public Context()
        {
            variables = new Dictionary<string, int>();
        }
        public int GetValue(string name)
        {
            return variables[name];
        }
        public void SetValue(string name, int val)
        {
            if (variables.ContainsKey(name))
            {
                variables[name] = val;
            }
            else
            {
                variables.Add(name, val);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Context cont = new Context();

            cont.SetValue("Glory", 1400);
            cont.SetValue("to", 12);
            cont.SetValue("Nation", 100);

            Console.WriteLine(new MinusExpression(new PlusExpression(new NumberExpression("Glory"), new NumberExpression("Nation")), new NumberExpression("to")).Interpret(cont));
            Console.ReadLine();

        }
    }
    abstract class AbstractExpression
    {
        public abstract int Interpret(Context cont);
    }
    //Terminal
    class NumberExpression : AbstractExpression
    {
        string name;
        public NumberExpression(string _name)
        {
            name = _name;
        }
        public override int Interpret(Context cont)
        {
            return cont.GetValue(name);
        }
    }
    //NonTerminal
    class PlusExpression : AbstractExpression
    {
        AbstractExpression firstPart;
        AbstractExpression secondPart;

        public override int Interpret(Context cont)
        {
            return firstPart.Interpret(cont)+secondPart.Interpret(cont);
        }

        public PlusExpression(AbstractExpression f, AbstractExpression s)
        {
            firstPart = f;
            secondPart = s;
        }
    }
    //NonTerminal
    class MinusExpression: AbstractExpression
    {
        AbstractExpression firstPart;
        AbstractExpression secondPart;

        public override int Interpret(Context cont)
        {
            return firstPart.Interpret(cont) - secondPart.Interpret(cont);
        }

        public MinusExpression(AbstractExpression f, AbstractExpression s)
        {
            firstPart = f;
            secondPart = s;
        }
    }
}
