public class Orm : IDisposable
{
    private Database database;
    private bool disposed = false;

    public Orm(Database database)
    {
        this.database = database;
    }

    public void Begin()
    {
        try
        {
            database.BeginTransaction();
        }
        catch (InvalidOperationException e)
        {
            database.Dispose();
        }
    }

    public void Write(string data)
    {
        try
        {
            database.Write(data);
        }
        catch (InvalidOperationException e)
        {
            database.Dispose();
        }
    }

    public void Commit()
    {
        try
        {
            database.EndTransaction();
        }
        catch (InvalidOperationException e)
        {
            database.Dispose();
        }
    }
    public void Dispose()
    {
        database.Dispose();
    }
}
