using System.Data;
using System.Diagnostics;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Data.Sqlite;
//NOTE: IGNORER LES "NOT AVAILABLE" DE ANDROID. C'EST JUSTE PAS SUR L'ORDI

namespace start_maui;

public static class FileHandler
{
    private static readonly string dbPath = Path.Combine(FileSystem.AppDataDirectory, "app.db");
    private static SqliteConnection? sqlconnection;

    public static void BeginConnection()
    {
        if (sqlconnection != null && sqlconnection.State == ConnectionState.Open)
        {
            return;
        }
        sqlconnection = new SqliteConnection($"Data Source={dbPath}");
        string commandText = @"CREATE TABLE IF NOT EXISTS Checkboxes (
    ID TEXT PRIMARY KEY,
    Name TEXT,
    DueDate DATETIME,
    Checked BOOLEAN,
    CreationDate DATETIME,
    LastUpdate DATETIME
);
";
        sqlconnection.Open();

        Debug.Assert(sqlconnection.State == ConnectionState.Open);
        var connection = sqlconnection.CreateCommand();
        connection.CommandText = commandText;
        connection.ExecuteNonQuery();

        return;
    }
    public static void StopConnection()
    {
        sqlconnection?.Close();
        sqlconnection?.Dispose();
        return;
    }
    public static string InsertData(string name, DateTime dueDate, bool is_checked, DateTime creationDate, DateTime lastUpdate)
    {
        BeginConnection();

        var command = (sqlconnection?.CreateCommand()) ?? throw new InvalidDataException();
        string ID = Guid.NewGuid().ToString();

        string commandText =
            @"INSERT OR IGNORE INTO Checkboxes (ID, Name, DueDate, Checked, CreationDate, LastUpdate)
        VALUES (@ID, @Name, @DueDate, @Checked, @CreationDate, @LastUpdate);";

        using (command)
        {
            command.Parameters.AddWithValue("@ID", ID);
            command.Parameters.AddWithValue("@Name", name);
            command.Parameters.AddWithValue("@DueDate", dueDate);
            command.Parameters.AddWithValue("@Checked", is_checked);
            command.Parameters.AddWithValue("@CreationDate", creationDate);
            command.Parameters.AddWithValue("@LastUpdate", lastUpdate);
        }



        command.CommandText = commandText;
        command.ExecuteNonQuery();
        return ID;
    }

    public class RectangleData
    {
        private string id;
        private string name;
        private DateTime dueDate;
        private bool is_checked;
        private DateTime creationDate;
        private DateTime lastUpdate;

        public RectangleData(string Id, string name, DateTime dueDate, bool is_checked, DateTime creationDate, DateTime lastUpdate)
        {
            this.id = Id;
            this.lastUpdate = lastUpdate;
            this.creationDate = creationDate;
            this.is_checked = is_checked;
            this.dueDate = dueDate;
            this.name = name;
            // Private attributes
        }
        // Public properties
        public string ID
        {
            get { return id; }
            set { id = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public DateTime DueDate
        {
            get { return dueDate; }
            set { dueDate = value; }
        }

        public bool IsChecked
        {
            get { return is_checked; }
            set { is_checked = value; }
        }

        public DateTime CreationDate
        {
            get { return creationDate; }
            set { creationDate = value; }
        }

        public DateTime LastUpdate
        {
            get { return lastUpdate; }
            set { lastUpdate = value; }
        }
        public override string ToString()
        {
            string stuff = "{0}, {1}, {2}, {3}, {4}, {5}";
            stuff = string.Format(stuff, ID, Name, DueDate.ToString(), IsChecked.ToString(), CreationDate.ToString(), LastUpdate.ToString());
            return stuff;
        }
    }







    public static List<RectangleData> GetAllData()
    {
        BeginConnection();

        var command = (sqlconnection?.CreateCommand()) ?? throw new InvalidDataException();
        List<RectangleData> vector_of_data = new();
        string commandText =
        @"SELECT ID, Name, DueDate, Checked, CreationDate, LastUpdate FROM Checkboxes;";


        command.CommandText = commandText;
        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            vector_of_data.Add(new RectangleData(
                Id: reader.GetString(0),
                name: reader.GetString(1),
                dueDate: reader.GetDateTime(2),
                is_checked: reader.GetBoolean(3),
                creationDate: reader.GetDateTime(4),
                lastUpdate: reader.GetDateTime(5)
            ));



        }

        return vector_of_data;


    }
    public static RectangleData? GetDataFromUuid(string uuid)
    {
        BeginConnection();

        var command = (sqlconnection?.CreateCommand()) ?? throw new InvalidDataException();
        RectangleData? rectangleData = null;
        string commandText =
            @"SELECT ID, Name, DueDate, Checked, CreationDate, LastUpdate FROM Checkboxes WHERE ID = @ID;";
        command.Parameters.AddWithValue("@ID", uuid);
        command.CommandText = commandText;

        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            rectangleData = new RectangleData(
               Id: reader.GetString(0),
                name: reader.GetString(1),
                dueDate: reader.GetDateTime(2),
                is_checked: reader.GetBoolean(3),
                creationDate: reader.GetDateTime(4),
                lastUpdate: reader.GetDateTime(5)
            );



        }
        return rectangleData;

    }

    public static List<string> GetCheckboxesIDfromDB()
    {
        BeginConnection();

        var command = (sqlconnection?.CreateCommand()) ?? throw new InvalidDataException();
        string commandText = @"SELECT ID FROM Checkboxes";
        List<string> all_strings_from_db = [];
        command.CommandText = commandText;
        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            all_strings_from_db.Add(reader.GetString(0));
        }
        return all_strings_from_db;

    }

    public static List<string>? CompareUUIDsFromDbandUI(List<string> rectanglesid)

    {
        var db_ids = GetCheckboxesIDfromDB();
        var not_in_ui = db_ids.Except(rectanglesid).ToList();
        return not_in_ui;
    }
    public static void TableDrop()
    {
        BeginConnection();

        var command = (sqlconnection?.CreateCommand()) ?? throw new InvalidDataException();
        string commandText = @"DROP TABLE Checkboxes";
        command.CommandText = commandText;
        var _ = command.ExecuteNonQuery();
        return;


    }
    public static void UpdateCheckboxCheckStatus(string uuid, bool value)
    {
        BeginConnection();

        var command = (sqlconnection?.CreateCommand()) ?? throw new InvalidDataException();
        string commandText = @"UPDATE Checkboxes SET Checked = @value WHERE ID=@ID";
        command.Parameters.AddWithValue("@ID", uuid);
        command.Parameters.AddWithValue("@value", value);

        command.CommandText = commandText;
        var _ = command.ExecuteNonQuery();

    }
}

