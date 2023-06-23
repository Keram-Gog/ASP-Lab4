using Lab4.Server.Data.Interface;
using Lab4.Shared;
using System;

namespace Lab4.Server.Data
{
    public class InMemoryTypePLRepository : ITypePLRepository
    {
        private readonly List<TypeLanguage> typePLs = new();

        public Task DeleteTypePByIdAsync(Guid Id) => Task.Run(() =>
        {
            typePLs.Remove(typePLs.Single(x => x.Id == Id));
        });

        public IList<TypeLanguageDescription> GetLists()
        {
            return typePLs.Select(x => new TypeLanguageDescription(x.Id, x.TypeName)).ToList();
        }

        public TypeLanguage? GetTypePById(Guid? Id)
        {
            if (Id == null) return null;
            return typePLs.Single(x => x.Id == Id);
        }

        public TypeLanguage SaveTypeP(TypeLanguage typePL)
        {
            if (typePL.Id == Guid.Empty)
            {
                var savedTypePL = new TypeLanguage(Guid.NewGuid(), typePL.TypeName, typePL.ProgrammingLanguages);
                typePLs.Add(savedTypePL);
                return savedTypePL;
            }

            return typePL;
        }
    }
}
