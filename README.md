## for csharp language

- [https://github.com/sinlov/csharp-Playground](https://github.com/sinlov/csharp-Playground)

## env

- target dot net version `8.0.203` 
  - [dotnet 8.0](https://dotnet.microsoft.com/download/dotnet/8.0)
- `NuGet Version: 6.8.0.131`
- [mono download](https://www.mono-project.com/download/stable/) `mono version 6.12.0.182`

```bash
$ dotnet --version
8.0.203
$ nuget \?
NuGet Version: 6.8.0.131

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
- Target framework `net8.0`
- Language Version `C# 8.0`
- Nullable reference types(C# 8.0+) `Enable`

```xml
<PropertyGroup>
    <TargetFramework>net7.0</TargetFramework>
    <Nullable>enable</Nullable>
    <LangVersion>8</LangVersion>
</PropertyGroup>
```

### FakerDotNet

- [https://github.com/mrstebo/FakerDotNet](https://github.com/mrstebo/FakerDotNet)

### Xunit

- Output Type `Console application`
- Target framework `net8.0`
- Language Version `C# 8.0`

or

- Output Type `Class library`
- Target framework `.NetFramework 4.8`
- Language Version `C# 8.0`

### RunOn

- OS macOS

```
$ sw_vers
ProductName:		macOS
ProductVersion:		14.4.1
BuildVersion:		23E224
```

- IDE `JetBrains Rider`