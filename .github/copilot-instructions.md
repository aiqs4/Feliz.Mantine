# Feliz.Mantine - GitHub Copilot Instructions

## Project Overview

This repository contains **Feliz.Mantine**, a comprehensive set of F# bindings for Mantine UI v8.3.10+. The project provides type-safe, idiomatic F# wrappers around all Mantine React components, hooks, and utilities for use with Fable and Feliz.

## Repository Structure

```
/
├── src/
│   └── Feliz.Mantine/          # Main library project
│       ├── Core.fs             # Core components bindings
│       ├── Hooks.fs            # @mantine/hooks bindings
│       ├── Dates.fs            # @mantine/dates bindings
│       ├── Form.fs             # @mantine/form bindings
│       ├── Notifications.fs    # @mantine/notifications bindings
│       ├── Spotlight.fs        # @mantine/spotlight bindings
│       ├── Dropzone.fs         # @mantine/dropzone bindings
│       ├── Modals.fs           # @mantine/modals bindings
│       ├── NProgress.fs        # @mantine/nprogress bindings
│       ├── Tiptap.fs           # @mantine/tiptap bindings
│       ├── Carousel.fs         # @mantine/carousel bindings
│       └── Interop.fs          # Helper functions for JS interop
├── examples/                    # Example applications
├── docs/                        # Documentation
├── mantine-ui/                  # Git submodule of Mantine UI source
├── package.json                 # NPM dependencies
└── README.md                    # Main documentation
```

## Tech Stack

- **F# (.NET 10.0)**: Primary language for bindings
- **Fable**: F# to JavaScript compiler
- **Feliz**: F# DSL for React
- **Mantine UI v8.3.10**: React components library
- **Vite**: Development server and build tool
- **React 18.3.1**: Peer dependency

## Mantine UI Submodule

The Mantine UI source code is included as a git submodule in the `mantine-ui/` directory. This provides a reference for understanding component APIs, props, and implementation details.

### Working with the Submodule

```bash
# Initialize and update the submodule
git submodule update --init --recursive

# Update to latest version
cd mantine-ui
git fetch --tags
git checkout v8.3.10
cd ..
git add mantine-ui
git commit -m "Update Mantine UI submodule to v8.3.10"
```

## Binding Pattern

All bindings follow a consistent pattern using Fable's interop capabilities:

### Component Binding Pattern

```fsharp
// Import the component from @mantine/core
let inline button (props: IReactProperty seq) =
    Interop.reactApi.createElement(
        import "Button" "@mantine/core",
        createObj !!props
    )

// Type-safe props using computation expression style
type button =
    static member inline variant (value: string) = Interop.mkAttr "variant" value
    static member inline color (value: string) = Interop.mkAttr "color" value
    static member inline onClick (handler: MouseEvent -> unit) = Interop.mkAttr "onClick" handler
    static member inline children (elements: ReactElement seq) = prop.children elements
```

### Hook Binding Pattern

```fsharp
// Import hook from @mantine/hooks
let inline useDisclosure (initialState: bool) : bool * obj =
    import "useDisclosure" "@mantine/hooks" initialState
```

### Enum/Union Types

Use discriminated unions for type-safe enum values:

```fsharp
type ButtonVariant =
    | Filled
    | Outline
    | Light
    | Subtle
    | Default
    | Transparent
    
    static member toString = function
        | Filled -> "filled"
        | Outline -> "outline"
        | Light -> "light"
        | Subtle -> "subtle"
        | Default -> "default"
        | Transparent -> "transparent"
```

## NPM Dependencies

All Mantine packages are installed at version 8.3.10:
- `@mantine/core@8.3.10`
- `@mantine/hooks@8.3.10`
- `@mantine/dates@8.3.10`
- `@mantine/form@8.3.10`
- `@mantine/notifications@8.3.10`
- `@mantine/spotlight@8.3.10`
- `@mantine/dropzone@8.3.10`
- `@mantine/modals@8.3.10`
- `@mantine/nprogress@8.3.10`
- `@mantine/tiptap@8.3.10`
- `@mantine/carousel@8.3.10`

Peer dependencies:
- `react@18.3.1`
- `react-dom@18.3.1`
- `@emotion/react`

## Build Commands

```bash
# Restore .NET dependencies
dotnet restore src/Feliz.Mantine/Feliz.Mantine.fsproj

# Build the library
dotnet build src/Feliz.Mantine/Feliz.Mantine.fsproj

# Pack for NuGet
dotnet pack src/Feliz.Mantine/Feliz.Mantine.fsproj

# Install npm dependencies
npm install

# Run development server (if example app exists)
npm run dev

# Build for production
npm run build
```

## Component Implementation Checklist

When implementing bindings for a new Mantine component:

1. **Check Mantine Documentation**: Review the component's props and API at https://mantine.dev/
2. **Create Binding**: Add the component binding in the appropriate .fs file (Core.fs, Dates.fs, etc.)
3. **Define Props**: Create type-safe props using static members
4. **Handle Variants**: Use discriminated unions for enum-like props
5. **Add Documentation**: Include XML doc comments for IntelliSense
6. **Create Example**: Add usage example in the examples/ directory
7. **Test**: Verify the binding works correctly

## Mantine Component Categories

### Core (@mantine/core)
- **Layout**: AppShell, Container, Group, Stack, Grid, Flex, Space, Divider
- **Typography**: Title, Text, Anchor, Code, Kbd, Mark, Highlight
- **Buttons**: Button, ActionIcon, UnstyledButton, CloseButton, CopyButton, FileButton
- **Inputs**: TextInput, Select, MultiSelect, NumberInput, Textarea, Autocomplete, ColorInput
- **Overlays**: Modal, Drawer, Tooltip, Popover, HoverCard, Menu, Portal
- **Navigation**: Tabs, Pagination, Stepper, Breadcrumbs, NavLink, SegmentedControl
- **Data Display**: Avatar, Badge, Card, Table, Timeline, Accordion, Image, Paper
- **Feedback**: Alert, Loader, Progress, RingProgress, Skeleton, LoadingOverlay
- **Misc**: Checkbox, Radio, Switch, Rating, Slider, ColorPicker, Transition

### Hooks (@mantine/hooks)
70+ custom React hooks for common functionality like:
- State management (useDisclosure, useToggle, useListState)
- DOM interactions (useClickOutside, useHover, useFocusTrap)
- Effects (useDebounce, useThrottle, useInterval)
- Browser APIs (useLocalStorage, useMediaQuery, useFullscreen)

## Code Style Guidelines

- Use `inline` for all component and hook bindings
- Follow Feliz naming conventions (lowercase for module names)
- Use `IReactProperty` for component props
- Use `createObj !!props` for converting props to JS objects
- Add XML documentation comments with `///` for public APIs
- Group related components in the same module
- Use meaningful type names (e.g., `ButtonVariant`, not `Variant`)

## Testing

Test bindings with:
1. Example applications demonstrating usage
2. Visual verification in browser
3. Type-checking in F# IDE
4. Documentation examples that compile

## Important Notes

- **Minimal changes**: Only add bindings as needed, don't implement everything at once
- **Type safety**: Prefer type-safe discriminated unions over raw strings
- **Documentation**: Keep docs in sync with Mantine's official documentation
- **Version pinning**: Use exact versions for Mantine packages (8.3.10)
- **No polyfills**: Mantine v8 requires modern browsers, no legacy support needed

## Future Maintenance

When updating to newer Mantine versions:
1. Update the submodule to the new tag
2. Check Mantine's changelog for breaking changes
3. Update NPM package versions
4. Test all existing bindings
5. Add bindings for new components/features
6. Update version in fsproj
7. Update README and CHANGELOG

## Resources

- [Mantine Documentation](https://mantine.dev/)
- [Feliz Documentation](https://zaid-ajaj.github.io/Feliz/)
- [Fable Documentation](https://fable.io/)
- [F# Language Reference](https://learn.microsoft.com/en-us/dotnet/fsharp/)

## Contact & Support

For questions and issues, please use GitHub Issues in this repository.
