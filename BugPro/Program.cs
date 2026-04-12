using System;
using Stateless;

namespace BugPro
{
    public enum State
    {
        New,
        Open,
        Analysis,
        Fixing,
        Testing,
        Closed
    }

    public enum Trigger
    {
        Assign,
        Analyze,
        Fix,
        Test,
        Close,
        Reopen
    }

    public class Bug
    {
        private StateMachine<State, Trigger> machine;

        public Bug()
        {
            machine = new StateMachine<State, Trigger>(State.New);

            machine.Configure(State.New)
                .Permit(Trigger.Assign, State.Open);

            machine.Configure(State.Open)
                .Permit(Trigger.Analyze, State.Analysis);

            machine.Configure(State.Analysis)
                .Permit(Trigger.Fix, State.Fixing);

            machine.Configure(State.Fixing)
                .Permit(Trigger.Test, State.Testing);

            machine.Configure(State.Testing)
                .Permit(Trigger.Close, State.Closed)
                .Permit(Trigger.Reopen, State.Open);

            machine.Configure(State.Closed)
                .Permit(Trigger.Reopen, State.Open);
        }

        public void Assign() => machine.Fire(Trigger.Assign);
        public void Analyze() => machine.Fire(Trigger.Analyze);
        public void Fix() => machine.Fire(Trigger.Fix);
        public void Test() => machine.Fire(Trigger.Test);
        public void Close() => machine.Fire(Trigger.Close);
        public void Reopen() => machine.Fire(Trigger.Reopen);

        public State GetState() => machine.State;
    }

    class Program
    {
        static void Main(string[] args)
        {
            Bug bug = new Bug();

            Console.WriteLine($"Initial: {bug.GetState()}");

            bug.Assign();
            bug.Analyze();
            bug.Fix();
            bug.Test();
            bug.Close();

            Console.WriteLine($"Final: {bug.GetState()}");
        }
    }
}
