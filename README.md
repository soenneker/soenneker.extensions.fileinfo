[![](https://img.shields.io/nuget/v/Soenneker.Extensions.FileInfo.svg?style=for-the-badge)](https://www.nuget.org/packages/Soenneker.Extensions.FileInfo/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.extensions.fileinfo/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.extensions.fileinfo/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/Soenneker.Extensions.FileInfo.svg?style=for-the-badge)](https://www.nuget.org/packages/Soenneker.Extensions.FileInfo/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.extensions.fileinfo/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.extensions.fileinfo/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Extensions.FileInfo

Checks and removes `System.IO.FileAttributes` flags through `FileInfo`.

## Installation

```bash
dotnet add package Soenneker.Extensions.FileInfo
```

## Check attributes

```csharp
using System.IO;
using Soenneker.Extensions.FileInfo;

var file = new FileInfo("report.csv");

bool protectedOrArchived = file.HasReadOnlyOrArchivedAttribute();
bool both = file.HasAttributeSet(FileAttributes.ReadOnly | FileAttributes.Archive);
```

`HasReadOnlyOrArchivedAttribute()` returns true when either flag is present. `HasAttributeSet()` requires every requested flag to be present. Passing `0` to `HasAttributeSet()` returns true, following normal bitmask semantics.

Reading `FileInfo.Attributes` accesses filesystem metadata and can throw when the path is missing, inaccessible, or unsupported by the platform.

## Remove attributes

```csharp
file.RemoveReadOnlyOrArchivedAttribute();

// Or remove a specific combination:
file.RemoveAttribute(FileAttributes.ReadOnly | FileAttributes.Hidden);
```

Both methods modify the file’s attributes on disk. `RemoveAttribute()` does nothing when none of the requested flags are present; after a write it refreshes the `FileInfo` metadata. Filesystem access, permission, and platform exceptions propagate to the caller.

`RemoveAttribute()` accepts any `FileAttributes` flags, not only cosmetic flags. Avoid removing structural or platform-specific flags unless that is explicitly intended.
