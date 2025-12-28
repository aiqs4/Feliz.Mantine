# Getting Started with Feliz.Mantine Development

This guide will help you get started with developing Feliz.Mantine bindings.

## Prerequisites

- [.NET SDK 10.0+](https://dotnet.microsoft.com/download)
- [Node.js 20+](https://nodejs.org/)
- [Git](https://git-scm.com/)

## Setting Up Your Development Environment

### 1. Clone the Repository

```bash
git clone https://github.com/aiqs4/Feliz.Mantine.git
cd Feliz.Mantine
```

### 2. Initialize Submodules

The Mantine UI source code is included as a submodule for reference:

```bash
git submodule update --init --recursive
```

### 3. Install Dependencies

Install .NET dependencies:
```bash
dotnet restore src/Feliz.Mantine/Feliz.Mantine.fsproj
```

Install NPM dependencies:
```bash
npm install
```

### 4. Build the Project

```bash
npm run build
# or
dotnet build src/Feliz.Mantine/Feliz.Mantine.fsproj
```

## Project Structure

```
Feliz.Mantine/
├── src/
│   └── Feliz.Mantine/
│       ├── Interop.fs          # Core React interop helpers
│       ├── Core.fs             # @mantine/core bindings
│       ├── Hooks.fs            # @mantine/hooks bindings
│       ├── Dates.fs            # @mantine/dates bindings (TODO)
│       ├── Form.fs             # @mantine/form bindings (TODO)
│       └── Feliz.Mantine.fsproj
├── docs/
│   ├── IMPLEMENTATION_STATUS.md
│   └── GETTING_STARTED.md
├── mantine-ui/                 # Git submodule (Mantine source)
├── README.md
├── CHANGELOG.md
└── package.json
```

## Adding a New Component Binding

### Step 1: Find the Component in Mantine Docs

Visit [Mantine Documentation](https://mantine.dev/) and find the component you want to bind.

Example: [Button component](https://mantine.dev/core/button/)

### Step 2: Add the Component Binding

In `src/Feliz.Mantine/Core.fs` (or appropriate module), add:

```fsharp
/// YourComponent description
let inline yourComponent (props: IReactProperty seq) =
    MantineInterop.reactElement (import "YourComponent" "@mantine/core") props
```

### Step 3: Add Type-Safe Props

```fsharp
/// Type-safe props for YourComponent
type yourComponent =
    /// Prop description
    static member inline propName (value: string) = MantineInterop.mkAttr "propName" value
    /// Another prop
    static member inline anotherProp (value: bool) = MantineInterop.mkAttr "anotherProp" value
    /// Children elements
    static member inline children (elements: ReactElement list) = prop.children elements
```

### Step 4: Add Documentation

Use XML doc comments for IntelliSense:

```fsharp
/// <summary>
/// Your component description here.
/// See https://mantine.dev/core/your-component/
/// </summary>
let inline yourComponent (props: IReactProperty seq) =
    MantineInterop.reactElement (import "YourComponent" "@mantine/core") props
```

### Step 5: Update the .fsproj

If you create a new module file (e.g., `NewModule.fs`), add it to `Feliz.Mantine.fsproj`:

```xml
<ItemGroup>
  <Compile Include="Interop.fs" />
  <Compile Include="Core.fs" />
  <Compile Include="Hooks.fs" />
  <Compile Include="NewModule.fs" />  <!-- Add your new file -->
</ItemGroup>
```

### Step 6: Test the Binding

Build the project to verify there are no compilation errors:

```bash
dotnet build src/Feliz.Mantine/Feliz.Mantine.fsproj
```

## Adding a New Hook Binding

In `src/Feliz.Mantine/Hooks.fs`:

```fsharp
/// useYourHook - description
let inline useYourHook (param: string) : ReturnType =
    import "useYourHook" "@mantine/hooks" param
```

## Common Patterns

### Enum-Like Props

Use strings for now (discriminated unions can be added later):

```fsharp
type button =
    static member inline variant (value: string) = MantineInterop.mkAttr "variant" value
```

Later, you can add a discriminated union:

```fsharp
type ButtonVariant =
    | Filled
    | Outline
    | Light
    
    static member toString = function
        | Filled -> "filled"
        | Outline -> "outline"
        | Light -> "light"
        
type button =
    static member inline variant (value: ButtonVariant) = 
        MantineInterop.mkAttr "variant" (ButtonVariant.toString value)
```

### Event Handlers

```fsharp
open Browser.Types

type button =
    static member inline onClick (handler: MouseEvent -> unit) = 
        MantineInterop.mkAttr "onClick" handler
```

### Complex Props (Objects)

```fsharp
type myComponent =
    static member inline complexProp (value: obj) = 
        MantineInterop.mkAttr "complexProp" value
```

## Coding Guidelines

1. **Use `inline` for all bindings** - This allows the Fable compiler to optimize the code
2. **Follow Feliz naming conventions** - Lowercase module names, properties match HTML/React conventions
3. **Add XML documentation** - Helps with IntelliSense and discoverability
4. **Keep it minimal** - Only add the props that are commonly used initially
5. **Test your bindings** - Build and verify they compile without errors
6. **Update IMPLEMENTATION_STATUS.md** - Mark components as implemented

## Building for NuGet

When ready to publish:

```bash
npm run pack
# or
dotnet pack src/Feliz.Mantine/Feliz.Mantine.fsproj
```

The package will be created in `src/Feliz.Mantine/bin/Release/`.

## Resources

- [Mantine Documentation](https://mantine.dev/)
- [Feliz Documentation](https://zaid-ajaj.github.io/Feliz/)
- [Fable Documentation](https://fable.io/)
- [F# Documentation](https://learn.microsoft.com/en-us/dotnet/fsharp/)

## Getting Help

- Check the [Mantine Documentation](https://mantine.dev/) for component APIs
- Review existing bindings in `Core.fs` and `Hooks.fs` for patterns
- See `.github/copilot-instructions.md` for project-specific guidance
- Open an issue on GitHub for questions

## Next Steps

Check `docs/IMPLEMENTATION_STATUS.md` to see what needs to be implemented, pick a component or hook, and start binding!

Happy coding! 🚀
