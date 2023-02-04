
var dbConn = new FancyDBClassThing();
var secret = dbConn.GetSecretValueFromSecretPlace();


SteelFactory factory;
var factory2 = new SteelFactory();

var taffy = new Taffy();
var taffy2 = new Taffy("cherry");

var employee1 = new Confectioner()
{
    Name = "Willy Wonka",
    FavoriteCandy = "Jolly Ranchers"
};

var employee2 = new Confectioner();
employee2.Name = "Willy Wonka";
employee2.FavoriteCandy = "Jolly Rancher";

var employee3 = new Confectioner("Willy Wonka", "Jolly Rancher");

var employee4 = new Confectioner();
var employee5 = new Confectioner();

var factory1 = new TaffyFactory();
factory1.HireEmployee(employee1);

//factory2.HireEmployee(employee1);
//IFactory<Confectioner, Taffy> factory = new TaffyFactory();

public class FancyDBClassThing
{
    public FancyDBClassThing(List<int> validPorts)
    {
        Connection = GetSecretValueFromSecretPlace();

        foreach (var port in validPorts)
        {

        }
    }

    public FancyDBClassThing() { }

    

    public string Connection { get; }
    public string OtherSecretThing { get; } = "whatever";
    public int Port { get; private set; }

    private string GetSecretValueFromSecretPlace()
    {
        return "secret";
    }
}

public class TaffyFactory : IFactory<Confectioner, Taffy>
{
    public List<Confectioner> Employees { get; set; } = new List<Confectioner>();
    public List<Taffy> Inventory { get; set; } = new List<Taffy>();

    /*
        No compiler error.
    */
    public void HireEmployee(Confectioner employee)
    {
        Employees.Add(employee);
    }

    public void HireEmployees(List<Confectioner> employees)
    {
        employees.AddRange(employees);
    }
}

public class SteelFactory : IFactory<SteelWorker, Steel>
{
    public SteelFactory()
    {
        //every class has a default constructor that looks like this
        //the constructor creates a new instance of the class
    }


    public List<SteelWorker> Employees { get; set; }
    public List<Steel> Inventory { get; set; }

    public void HireEmployee(SteelWorker employee)
    {
        Employees.Add(employee);
    }

    public void HireEmployees(List<SteelWorker> employees)
    {
        Employees.AddRange(employees);
    }
}

public interface IFactory<T, U>
{
    List<T> Employees { get; set; }
    List<U> Inventory { get; set; }
    void HireEmployee(T employee);
    void HireEmployees(List<T> employees);
}

public class Confectioner
{
    public Confectioner(string name, string candy)
    {
        Name = name;
        FavoriteCandy = candy;
    }

    public Confectioner()
    {

    }

    public string Name { get; set; } 
    public string FavoriteCandy { get; set; }
    public void Confect()
    {
        //do something
    }
}

public class Taffy
{
    public Taffy(string flavor)
    {

    }
    public Taffy()
    {

    }
}

public class Steel
{

}

public class SteelWorker
{

}