#region FactoryPattern
class FactoryPattern
{
    interface IProduct
    {
        string ShipFrom();
    }

    class ProductA : IProduct
    {
        public String ShipFrom()
        {
            return " from South Africa";
        }
    }

    class ProductB : IProduct
    {
        public String ShipFrom()
        {
            return "from Spain";
        }
    }

    class DefaultProduct : IProduct
    {
        public String ShipFrom()
        {
            return "not available";
        }
    }

    class Creator
    {
        public IProduct FactoryMethod(int month)
        {
            if (month >= 4 && month <=11)
                return new ProductA();
            else
              if (month == 1 || month == 2 || month == 12)
                return new ProductB();
            else return new DefaultProduct();
        }
    }
}

#endregion

#region AdapterPattern

class Adaptee
{
    public double SpecificRequest(double a, double b)
    {
        return a/b;
    }
}

interface ITarget
{
    string Request(int i);
}

class Adapter : Adaptee, ITarget
{
    public string Request(int i)
    {
        return "Rough estimate is " + (int)Math.Round(SpecificRequest(i, 3));
    }
}

class Client
{
    //static void Main()
    //{
    //    Adaptee first = new Adaptee();
    //    Console.Write("Before the new standard\nPrecise reading: ");
    //    Console.WriteLine(first.SpecificRequest(5, 3));


    //    ITarget second = new Adapter();
    //    Console.WriteLine("\nMoving to the new standard");
    //    Console.WriteLine(second.Request(5));
    //}
}

#endregion

#region ChainwithStatePattern

class ChainwithStatePattern
{

    class Handler
    {
        Handler next;
        int id;
        public int Limit { get; set; }
        public Handler(int id, Handler handler)
        {
            this.id = id;
            Limit = id*1000;
            next = handler;
        }
        public string HandleRequest(int data)
        {
            if (data < Limit)
                return "Request for " +data+" handled at level "+id;
            else if (next!=null)
                return next.HandleRequest(data);
            else return ("Request for " +data+" handled BY DEFAULT at level "+id);
        }
    }

    static void Main()
    {

        Handler start = null;
        for (int i = 5; i>0; i--)
        {
            Console.WriteLine("Handler "+i+" deals up to a limit of "+i*1000);
            start = new Handler(i, start);
        }

        int[] a = { 50, 2000, 1500, 10000, 175, 4500 };
        foreach (int i in a)
            Console.WriteLine(start.HandleRequest(i));
    }
}
#endregion