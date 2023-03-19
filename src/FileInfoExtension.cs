using System.IO;

namespace Soenneker.Extensions.FileInfo;

public static class FileInfoExtension
{
    public static bool HasReadOnlyOrArchivedAttribute(this System.IO.FileInfo value)
    {
        if (HasAttributeSet(value, FileAttributes.Archive))
            return true;

        if (HasAttributeSet(value, FileAttributes.ReadOnly))
            return true;

        return false;
    }

    public static void RemoveReadOnlyOrArchivedAttribute(this System.IO.FileInfo value)
    {
        RemoveAttribute(value, FileAttributes.Archive);
        RemoveAttribute(value, FileAttributes.ReadOnly);
    }

    public static bool HasAttributeSet(this System.IO.FileInfo value, FileAttributes pAttributes)
    {
        return pAttributes == (value.Attributes & pAttributes);
    }

    public static void RemoveAttribute(this System.IO.FileInfo value, FileAttributes pAttributes)
    {
        value.Attributes = value.Attributes & ~pAttributes;
        value.Refresh();
    }
}