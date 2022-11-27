## for csharp language

- [https://github.com/sinlov/csharp-Playground](https://github.com/sinlov/csharp-Playground)

## env

- dotnet `6.0.101`
- `NuGet Version: 6.3.1.1`
- `mono version 6.12.0.182`

```bash
$ dotnet --version
6.0.101
$ nuget \?
NuGet Version: 6.3.1.1

# show dependencies
$ dotnet list package

# if build error, please check at nuget config at
$ cat ~/.nuget/NuGet/NuGet.Config
# powershell
> cat "$Env:APPDATA\NuGet\NuGet.Config"
```

- xml

```xml
  <packageSources>
    <add key="nuget.org" value="https://api.nuget.org/v3/index.json" protocolVersion="3" />
  </packageSources>
```

### NUnit

- Output Type `Class library`
- Target framework `net6.0`
- Language Version `C# 8.0`
- Nullable reference types(C# 8.0+) `Enable`

```xml
<PropertyGroup>
    <TargetFramework>net6.0</TargetFramework>
    <Nullable>enable</Nullable>
    <LangVersion>8</LangVersion>
</PropertyGroup>
```

### FakerDotNet

- [https://github.com/mrstebo/FakerDotNet](https://github.com/mrstebo/FakerDotNet)

### Xunit

- Output Type `Console application`
- Target framework `net6.0`
- Language Version `C# latest minor`

or

- Output Type `Class library`
- Target framework `.NetFramework 4.8`
- Language Version `C# 7.3`

### RunOn

- OS macOS

```
$ sw_vers
ProductName:	macOS
ProductVersion:	12.6.1
BuildVersion:	21G217
```

- IDE `JetBrains Rider`