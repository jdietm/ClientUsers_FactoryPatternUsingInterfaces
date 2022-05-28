interface IClient
{
    string UserName { get; set; }
    string UserAuthString { get; set; }
    bool HasAccess { get; set; }
    void BuildAuthString();
}

interface IAccessBehaviour
{
    IClient Client { get; set; }
    bool HandleAccess();
}

public class User : IClient
{
    public User(string userName)
    {
        UserName = userName;
    }
    public string UserName { get; set; }
    public string UserAuthString { get; set; }
    public bool HasAccess { get; set; } = false;

    public void BuildAuthString()
    {
       UserAuthString = UserName;
    }

}

public class Manager : IClient
{
    public Manager(string userName)
    {
        UserName = userName;
    }
    public string UserName { get; set; }
    public string UserAuthString { get; set; } 
    public bool HasAccess { get; set; } = true;

    public void BuildAuthString()
    {
        UserAuthString = UserName + " MAN";

    }
}

public class Admin : IClient
{
    public Admin(string userName)
    {
        UserName = userName;
    }
    public string UserName { get; set; }
    public string UserAuthString { get; set; }
    public bool HasAccess { get; set; } = true;

    public void BuildAuthString()
    {
        UserAuthString = UserName + " ADMIN";
    }
}

public class CheckString : IAccessBehaviour
{
    IClient IAccessBehaviour.Client { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public bool HandleAccess()
    {
        // (which checks if the Client’s UserAuthString ends with “ADMIN” and returns the result as a boolean)

        return true;
    }
}

public class SwitchAuth : IAccessBehaviour
{
    IClient IAccessBehaviour.Client { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public bool  HandleAccess()
    {
        // which returns the Client’s HasAccess property, and then switches that property’s value
        return false;
    }
}

