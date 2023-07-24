using SQLite;
using System.Security.Cryptography;
using VaccPet.MVVM.Models;

namespace VaccPet.Data
{
    public sealed class DBConnection
    {
        private static DBConnection instance = null;
        private static readonly object padlok=new object();
        bool initialize = false;
        const string DatabaseFilename = "vaccpetdb.db3";
        internal SQLiteAsyncConnection Database;

        public const SQLiteOpenFlags Flags =
            SQLiteOpenFlags.ReadWrite | //*Abra o banco de dados no modo de leitura/gravação.
            SQLiteOpenFlags.Create | //*Crie o banco de dados se não existir.
            SQLiteOpenFlags.SharedCache; //*Habilita o acesso multi-threaded ao banco de dados.

        public static DBConnection Instance
        {
            get
            {
                lock (padlok)
                {
                    if (instance == null)
                    {
                        instance = new DBConnection();
                    }
                    return instance;
                }
            }
        }

        public async Task Initialize()
        {
            var path = Path.Combine(Environment.GetFolderPath(
                        Environment.SpecialFolder.LocalApplicationData), DatabaseFilename);

            Database = new SQLiteAsyncConnection(path);

            if (!initialize)
            {
                if (!Database.TableMappings.Any(x => x.MappedType.Name == typeof(PetModel).Name))
                    await Database.CreateTableAsync<PetModel>();

                if (!Database.TableMappings.Any(x => x.MappedType.Name == typeof(VaccineModel).Name))
                    await Database.CreateTableAsync<VaccineModel>();

                initialize = true;
            }
        }
    }
}
