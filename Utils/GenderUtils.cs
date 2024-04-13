using bookstore.Entities;

namespace bookstore.Utils;

public static class GenderUtils
{
    public static Gender? GetEnumByName(string name)
    {
        var isGender = Enum.TryParse(name, true, out Gender gender);
        if (!isGender)
            return null;
        return gender;
    }
}
