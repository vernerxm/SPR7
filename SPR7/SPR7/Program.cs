namespace SPR_7;

//Handler

class CowFarmHandler
{
    private CowFarmHandler nextHandler;

    public CowFarmHandler()
    {
        nextHandler = null;
    }

    public CowFarmHandler SetNext(CowFarmHandler nextHandler)
    {
        this.nextHandler = nextHandler;
        return nextHandler;
    }

    public virtual string FarmProductHandler (string product)
    {
        string[] products = { "meat", "sour cream", "cheese", "meat trimmings", "bones", "milk" };
        bool existingProducts = false;
        
        for (int i = 0; i < products.Length; i++)
        {
            if (product == products[i])
            {
                existingProducts = true;
                break;
            }
        }
        if (nextHandler !=null && existingProducts)
        {
            return nextHandler.FarmProductHandler(product);
        }
        else
        {
            return "No one ordered((";
        }
    }
    ~CowFarmHandler(){}
}

//ConcreteHandler 

class MeatMarket : CowFarmHandler
{
    public override string FarmProductHandler(string product)
    {
        if (product == "meat") return "The meat market ordered : " + product;
         return base.FarmProductHandler(product);
    }
}

class YogurtFactory : CowFarmHandler
{
    public override string FarmProductHandler(string product)
    {
        if (product == "sour cream" || product == "cheese") return "A yogurt factory ordered : " + product;
        return base.FarmProductHandler(product);
    }
}

class ZooSupplyDepartment : CowFarmHandler
{
    public override string FarmProductHandler(string product)
    {
        if (product == "meat trimmings"|| product == "bones" || product == "milk") return "Zoo Supply Department ordered : " + product;
        return base.FarmProductHandler(product);
    }
}

class Program
{
  public  static void Main()
    {
        MeatMarket meatMarket = new MeatMarket();
        YogurtFactory yogurtFactory = new YogurtFactory();
        ZooSupplyDepartment zooSupplyDepartment = new ZooSupplyDepartment();

        zooSupplyDepartment.SetNext(yogurtFactory);
        yogurtFactory.SetNext(meatMarket);
        meatMarket.SetNext(zooSupplyDepartment);
        
        Console.WriteLine(zooSupplyDepartment.FarmProductHandler("bones"));
        Console.WriteLine(zooSupplyDepartment.FarmProductHandler("sour cream"));
        Console.WriteLine(zooSupplyDepartment.FarmProductHandler("meat"));
        Console.WriteLine(zooSupplyDepartment.FarmProductHandler("milk"));
        Console.WriteLine(zooSupplyDepartment.FarmProductHandler("serum"));
        
    }
}