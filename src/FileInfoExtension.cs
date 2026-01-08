using System.Diagnostics.Contracts;
using System.IO;
using System.Runtime.CompilerServices;

namespace Soenneker.Extensions.FileInfo;

/// <summary>
/// A collection of helpful FileInfo extension methods
/// </summary>
public static class FileInfoExtension
{
    /// <summary>
    /// Determines whether the specified file has either the ReadOnly or Archive attribute set.
    /// </summary>
    /// <remarks>This method checks the file's attributes to determine if either the ReadOnly or Archive flag
    /// is present. Use this method to quickly assess if a file is marked as read-only or is flagged for
    /// archiving.</remarks>
    /// <param name="value">The <see cref="System.IO.FileInfo"/> instance to check for the ReadOnly or Archive attribute. Cannot be null.</param>
    /// <returns><see langword="true"/> if the file has the ReadOnly or Archive attribute set; otherwise, <see
    /// langword="false"/>.</returns>
    [Pure, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool HasReadOnlyOrArchivedAttribute(this System.IO.FileInfo value)
    {
        FileAttributes attrs = value.Attributes;
        return (attrs & (FileAttributes.Archive | FileAttributes.ReadOnly)) != 0;
    }

    /// <summary>
    /// Removes the read-only and archived attributes from the specified file, if they are set.
    /// </summary>
    /// <remarks>This method modifies the file's attributes in place. If the file does not have the read-only
    /// or archived attributes set, no changes are made. The method does not throw an exception if the attributes are
    /// not present, but will throw if the file does not exist or is inaccessible.</remarks>
    /// <param name="value">The <see cref="System.IO.FileInfo"/> instance representing the file from which to remove the read-only and
    /// archived attributes. Cannot be null.</param>
    public static void RemoveReadOnlyOrArchivedAttribute(this System.IO.FileInfo value)
    {
        value.RemoveAttribute(FileAttributes.Archive | FileAttributes.ReadOnly);
    }

    /// <summary>
    /// Determines whether the specified set of file attributes is present on the file represented by this <see
    /// cref="System.IO.FileInfo"/> instance.
    /// </summary>
    /// <remarks>This method checks whether all of the specified attributes are set. If multiple attributes
    /// are provided, the method returns true only if every attribute in the combination is present on the
    /// file.</remarks>
    /// <param name="value">The <see cref="System.IO.FileInfo"/> instance representing the file to check.</param>
    /// <param name="attributes">A bitwise combination of <see cref="System.IO.FileAttributes"/> values to test for on the file.</param>
    /// <returns>true if all specified attributes are set on the file; otherwise, false.</returns>
    [Pure, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool HasAttributeSet(this System.IO.FileInfo value, FileAttributes attributes)
    {
        return (value.Attributes & attributes) == attributes;
    }

    /// <summary>
    /// Removes the specified file attributes from the current file represented by the given <see
    /// cref="System.IO.FileInfo"/> instance.
    /// </summary>
    /// <remarks>This method updates the file's attributes by removing the specified flags and refreshes the
    /// <see cref="System.IO.FileInfo"/> instance to reflect the changes. If none of the specified attributes are set,
    /// no changes are made.</remarks>
    /// <param name="value">The <see cref="System.IO.FileInfo"/> object representing the file whose attributes are to be modified. Cannot be
    /// null.</param>
    /// <param name="attributes">A bitwise combination of <see cref="System.IO.FileAttributes"/> values to remove from the file's current
    /// attributes.</param>
    public static void RemoveAttribute(this System.IO.FileInfo value, FileAttributes attributes)
    {
        FileAttributes current = value.Attributes;
        FileAttributes updated = current & ~attributes;

        // Avoid unnecessary IO write + Refresh
        if (current == updated)
            return;

        value.Attributes = updated;
        value.Refresh();
    }
}