using System;
using System.Threading.Tasks;
using Piller.Data;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using SQLite;
using MvvmCross.Platform;
using MvvmCross.Plugins.File;

namespace Piller.Services
{
    public class PermanentStorageService : IPermanentStorageService
    {
        private readonly IMvxFileStore fileStore = Mvx.Resolve<IMvxFileStore> ();

        private readonly string databaseFileName = "piller.db";
        private SQLiteAsyncConnection connection;

        public PermanentStorageService ()
        {
            this.connection = new SQLiteAsyncConnection (this.fileStore.NativePath ("Piller") + databaseFileName);

            if (!this.TableExists<MedicationDosage>()) {
                this.connection.GetConnection ().CreateTable<MedicationDosage> ();
            }
        }

        public async Task<T> GetAsync<T> (int id) where T : new()
        {
            return await this.connection.FindAsync<T> (id);
        }

        public async Task SaveAsync<T> (T entity)
        {
            await this.connection.InsertAsync (entity);
        }

        public async Task<List<T>> List<T> (Expression<Func<T, bool>> predicate = null) where T : new()
        {
            if (predicate == null) {
                var query = this.connection.Table<T> ();
                return await query.ToListAsync ();
            }
            else {
                var query = this.connection.Table<T> ().Where (predicate);
                return await query.ToListAsync ();
            }
        }

        private bool TableExists<T>() where T : new()
        {
            var medicationDosageMapping = this.connection.GetConnection ().GetMapping<T> ();

            var cmd = this.connection.GetConnection ().CreateCommand ("SELECT COUNT(*) FROM sqlite_master WHERE type = 'table' AND name = ?", new object [] { medicationDosageMapping.TableName });
            var result = cmd.ExecuteScalar<int> ();
            return result != 0;
        }
    }
}
