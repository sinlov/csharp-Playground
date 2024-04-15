
[![ci](https://github.com/sinlov/csharp-Playground/actions/workflows/ci.yml/badge.svg)](https://github.com/sinlov/csharp-Playground/actions/workflows/ci.yml)

[![GitHub license](https://img.shields.io/github/license/sinlov/csharp-Playground)](https://github.com/sinlov/csharp-Playground)
[![GitHub latest SemVer tag)](https://img.shields.io/github/v/tag/sinlov/csharp-Playground)](https://github.com/sinlov/csharp-Playground/tags)
[![GitHub release)](https://img.shields.io/github/v/release/sinlov/csharp-Playground)](https://github.com/sinlov/csharp-Playground/releases)

## for csharp language

- [https://github.com/sinlov/csharp-Playground](https://github.com/sinlov/csharp-Playground)

## Contributing

[![Contributor Covenant](https://img.shields.io/badge/contributor%20covenant-v1.4-ff69b4.svg)](.github/CONTRIBUTING_DOC/CODE_OF_CONDUCT.md)
[![GitHub contributors](https://img.shields.io/github/contributors/sinlov/csharp-Playground)](https://github.com/sinlov/csharp-Playground/graphs/contributors)

We welcome community contributions to this project.

Please read [Contributor Guide](.github/CONTRIBUTING_DOC/CONTRIBUTING.md) for more information on how to get started.

请阅读有关 [贡献者指南](.github/CONTRIBUTING_DOC/zh-CN/CONTRIBUTING.md) 以获取更多如何入门的信息

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

- OS windows

```
systeminfo
OS 名称:          Microsoft Windows 11 专业版
OS 版本:          10.0.22631 暂缺 Build 22631
系统类型:         x64-based PC
```

- IDE `JetBrains Rider`

## dev

### CleanArchitecture

- [https://github.com/ardalis/CleanArchitecture](https://github.com/ardalis/CleanArchitecture)

```bash
$ dotnet new clean-arch -o CleanTestsArchitecture --dry-run
```

## test coverage

### ReportGenerator

```bash
dotnet tool install -g dotnet-reportgenerator-globaltool
```

### dotnet-coverage

- [https://learn.microsoft.com/en-us/dotnet/core/additional-tools/dotnet-coverage](https://learn.microsoft.com/en-us/dotnet/core/additional-tools/dotnet-coverage)

```bash
dotnet tool install --global dotnet-coverage
```