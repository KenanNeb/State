using System;

namespace MyApp
{


    public interface StateBase
    {
        void Handle(Context context);
    }


    public class Context
    {

        public StateBase State { get; set; }
        public Context(StateBase state)
        {

            State = state;
            Console.WriteLine("Create object of context class with initial State.");

        }

        public void Request()
        {
            State.Handle(this);
        }

    }



    public class StateCar : StateBase
    {

        public void Handle(Context context)
        {

            context.State = new StateShip();
            Console.WriteLine("Change state from Car to Ship.");
        }

    }



    public class StateShip : StateBase
    {
        public void Handle(Context context)
        {
            context.State = new StatePlane();
            Console.WriteLine("Change state from Ship to Plane.");
        }

    }


    public class StatePlane : StateBase
    {

        public void Handle(Context context)
        {

            context.State = new StateSpacecraft();
            Console.WriteLine("Change state from Plane to Spacecraft.");

        }

    }

    public class StateSpacecraft : StateBase
    {

        public void Handle(Context context)
        {

            context.State = new StateCar();
            Console.WriteLine("Change state from Spacecraft to Car.");

        }

    }


    internal class Program
    {
        static void Main(string[] args)
        {
            Context context = new Context(new StateCar());
            context.Request();
            context.Request();
            context.Request();
            context.Request();
        }
    }
}