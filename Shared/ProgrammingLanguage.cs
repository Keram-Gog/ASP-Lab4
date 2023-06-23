using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using System.Security.AccessControl;


namespace Lab4.Shared;

public record class ProgrammingLanguage (Guid Id, string Name, string Rating)
{
    [JsonConstructor]
    public ProgrammingLanguage(string _name, string _rating):this(Guid.NewGuid(), _name, _rating) { }
}

[Serializable]
public record class TypeLanguage(Guid Id, string TypeName, 
    IList<ProgrammingLanguage> ProgrammingLanguages) : TypeLanguageDescription(Id, TypeName)
{
    public TypeLanguage() : this(Guid.Empty, string.Empty, new List<ProgrammingLanguage>())  { }

    [JsonConstructor]
    public TypeLanguage(string nameType) : this(Guid.Empty,nameType, new List<ProgrammingLanguage>()) { }
}

public record class TypeLanguageDescription(Guid Id, string TypeName)
{
    public TypeLanguageDescription() : this(Guid.Empty, string.Empty) { }

    public TypeLanguageDescription(Guid Id) : this(Id, string.Empty) { }

    public TypeLanguageDescription(string Name) : this(Guid.Empty, Name) { }
}


public class IndexViewModel
{
    public IList<TypeLanguageDescription> TypePL { get; set; }
    public Guid SelectedTypePLId { get; set; }
    public IList<ProgrammingLanguage> PLs { get; set; }

    public IndexViewModel()
    {

    }

    [JsonConstructor]
    public IndexViewModel(IList<TypeLanguageDescription> TypePL,
        Guid SelectedTypePLId,
        IList<ProgrammingLanguage> PLs)
    {
        this.TypePL = TypePL;
        this.SelectedTypePLId = SelectedTypePLId;
        this.PLs = PLs;
    }
}


public class AddPLViewModel
{
    public Guid TypePLId { get; set; }
    public string Name { get; set; }
    public string Rating { get; set; }

    [JsonConstructor]
    public AddPLViewModel(Guid TypePLId, string Name, string Rating)
    {
        this.TypePLId = TypePLId;
        this.Name = Name;
        this.Rating = Rating;
    }
}


public record TypeLanguageManagerModelView(IList<TypeLanguageDescription> typelangDescriptions);

