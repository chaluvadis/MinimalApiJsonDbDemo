namespace Products.Api.Utility;
public static class Extentions
{
    public static Enum GetRandomEnumValue(this Type t)
        => Enum.GetValues(t)
            .OfType<Enum>()
            .OrderBy(_ => Guid.NewGuid())
            .FirstOrDefault();
}