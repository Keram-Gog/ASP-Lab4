using Lab4.Shared;


namespace Lab4.Server.Data.Interface
{
    public interface ITypePLRepository
    {
        IList<TypeLanguageDescription> GetLists();

        TypeLanguage? GetTypePById(Guid? Id);

        TypeLanguage SaveTypeP(TypeLanguage typePL);

        Task DeleteTypePByIdAsync(Guid Id);
    }
}
