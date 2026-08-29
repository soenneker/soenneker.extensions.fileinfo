[![](https://img.shields.io/nuget/v/Soenneker.Extensions.FileInfo.svg?style=for-the-badge)](https://www.nuget.org/packages/Soenneker.Extensions.FileInfo/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.extensions.fileinfo/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.extensions.fileinfo/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/Soenneker.Extensions.FileInfo.svg?style=for-the-badge)](https://www.nuget.org/packages/Soenneker.Extensions.FileInfo/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.extensions.fileinfo/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.extensions.fileinfo/actions/workflows/codeql.yml)

# ![]({Package:Icon75x75}) Soenneker.Extensions.FileInfo
A collection of helpful FileInfo extension methods.

## Installation

```bash
dotnet add package Soenneker.Extensions.FileInfo
```

## Quick start

```csharp
using Soenneker.Extensions.FileInfo;

// Given an existing System.IO.FileInfo named value:
var result = value.HasReadOnlyOrArchivedAttribute();
```

## Common operations

- `HasReadOnlyOrArchivedAttribute()` - Determines whether the specified file has either the ReadOnly or Archive attribute set.
- `RemoveReadOnlyOrArchivedAttribute()` - Removes the read-only and archived attributes from the specified file, if they are set. This method modifies the file's attributes in place.
- `HasAttributeSet()` - Determines whether the specified set of file attributes is present on the file represented by this `System.IO.FileInfo` instance.
- `RemoveAttribute()` - Removes the specified file attributes from the current file represented by the given `System.IO.FileInfo` instance.
