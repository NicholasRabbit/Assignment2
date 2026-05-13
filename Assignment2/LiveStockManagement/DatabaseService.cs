namespace LiveStockManagement;

public class DatabaseService
{
    private readonly SQLiteConnection _conn;

    public DatabaseService()
    {
        var dbName = "FarmData.db";
        // db install path (production)
        var dbPath = Path.Combine(FileSystem.AppDataDirectory, dbName);

        // During debug, copy to desktop.
        //var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "debug" + dbName);
        if (File.Exists(dbPath) == false)
        { 
            using Stream stream = Current.OpenAppPackageFileAsync(dbName).Result;
            using MemoryStream memoryStream = new ();
            stream.CopyTo(memoryStream);
            File.WriteAllBytes(dbPath, memoryStream.ToArray());
        }

        _conn = new SQLiteConnection(dbPath);

    }

    public List<LiveStock> ReadItems()
    { 
        var liveStocks = new List<LiveStock>();
        var lst1 = _conn.Table<Cow>().ToList();
        liveStocks.AddRange(lst1);
        var lst2 = _conn.Table<Sheep>().ToList();
        liveStocks.AddRange(lst2);
        return liveStocks;
    }

    public int InssertItem(LiveStock item)
    {
        return _conn.Insert(item);
    }

    public int DeleteItem(LiveStock item)
    { 
        return _conn.Delete(item);
    }

    public int UpdateItem(LiveStock item)
    { 
        return _conn.Update(item);
    }
        
}
