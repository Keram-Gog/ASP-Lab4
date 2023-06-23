using Lab4.Server.Data.Interface;
using Lab4.Shared;
using Microsoft.EntityFrameworkCore;
//Add-Migration MyMigration -context EFTypePLRepository
namespace Lab4.Server.Data
{
    public class EFTypePLRepository : DbContext, ITypePLRepository
    {
        public EFTypePLRepository(DbContextOptions<EFTypePLRepository> options) : base(options)
        {
        }
        public EFTypePLRepository( )  
        {
        }
        public DbSet<TypeLanguage> TypePLs { get; set; }

        public DbSet<ProgrammingLanguage> PLs { get; set; }

        public async Task AddTypePL(TypeLanguage data)
        {
            if (data.Id == Guid.Empty)
            {
                TypePLs.Add(data);
            }

            await SaveChangesAsync();
        }
        public Task DeleteTypePByIdAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        public IList<TypeLanguageDescription> GetLists() => TypePLs
                .OrderBy(x => x.TypeName)
                .Select(x => new { x.Id, x.TypeName })
                .ToList()
                .Select(x => new TypeLanguageDescription(x.Id, x.TypeName))
                .ToList();


        public TypeLanguage GetListsById(Guid Id)
        {
            try
            {
                //var List = Genres.Single(x => x.Id == Id);
                var List = TypePLs.Include(x => x.ProgrammingLanguages).Single(x => x.Id == Id);
                return List;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public async Task RemoveById(Guid Id)
        {
            TypePLs.Remove(TypePLs.Single(x => x.Id == Id));

            await SaveChangesAsync();
        }

        public TypeLanguage? GetTypePById(Guid? Id) =>
            TypePLs.Include(x => x.ProgrammingLanguages).Single(x => x.Id == Id);


        public TypeLanguage SaveTypeP(TypeLanguage typePL)
        {
            if (typePL.Id == Guid.Empty)
                TypePLs.Add(typePL);

            SaveChanges();
            return typePL;
        }

        public async Task DeleteTypePLyIdAsync(Guid id)
        {
            TypePLs.Remove(TypePLs.Single(x => x.Id == id));

            await SaveChangesAsync();
        }

        public async Task Update(TypeLanguage data)
        {
            TypePLs.Add(data);

            await SaveChangesAsync();
        }
    }
}
