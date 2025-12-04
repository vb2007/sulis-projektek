using KobolduldozokLib.Helpers;

namespace KobolduldozokLib.Entities;

public interface IEntity
{
    string Name { get; }
    CustomColors CustomColor { get; }
    bool CanMove { get; }
    char DisplaySymbol { get; }
}
