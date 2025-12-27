# Contributing to Feliz.Mantine

Thank you for your interest in contributing to Feliz.Mantine! This document provides guidelines for contributing to the project.

## How to Contribute

### Reporting Issues

- Check existing issues before creating a new one
- Provide a clear description of the problem
- Include steps to reproduce if applicable
- Mention your environment (OS, .NET version, Node version)

### Adding Component Bindings

The main way to contribute is by adding bindings for Mantine components and hooks. See `docs/GETTING_STARTED.md` for detailed instructions.

**Quick Steps:**
1. Check `docs/IMPLEMENTATION_STATUS.md` to find unimplemented components
2. Review the component in [Mantine Documentation](https://mantine.dev/)
3. Add the binding following existing patterns in `Core.fs` or create a new module
4. Add type-safe props
5. Build and test
6. Submit a pull request

### Code Style

- Follow existing code patterns in the repository
- Use `inline` for all component and hook bindings
- Use XML doc comments for public APIs
- Keep prop types simple initially (use `string`, `bool`, `int` over complex types)
- Name types using the same name as the component (lowercase)

Example:
```fsharp
/// Button component from @mantine/core
let inline button (props: IReactProperty seq) =
    MantineInterop.reactElement (import "Button" "@mantine/core") props

type button =
    static member inline variant (value: string) = MantineInterop.mkAttr "variant" value
```

### Pull Request Process

1. **Fork the repository** and create a new branch for your feature
2. **Make your changes** following the code style guidelines
3. **Test your changes** - ensure the project builds successfully
4. **Update documentation**:
   - Update `docs/IMPLEMENTATION_STATUS.md` to mark components as implemented
   - Add to `CHANGELOG.md` under "Unreleased"
5. **Commit your changes** with clear, descriptive commit messages
6. **Submit a pull request** with a description of what you've added

### Commit Message Format

Use clear, descriptive commit messages:

```
Add Button component binding

- Implement button component wrapper
- Add type-safe props for variant, color, size
- Add documentation comments
```

### Development Setup

See `docs/GETTING_STARTED.md` for detailed setup instructions.

Quick setup:
```bash
git clone https://github.com/aiqs4/Feliz.Mantine.git
cd Feliz.Mantine
git submodule update --init --recursive
npm install
dotnet build src/Feliz.Mantine/Feliz.Mantine.fsproj
```

### Priority Areas

High priority contributions:
1. **Core Components** - Layout, Typography, Inputs, Buttons
2. **Common Hooks** - useForm, useFetch, etc.
3. **Extension Packages** - @mantine/dates, @mantine/form
4. **Documentation** - Examples and guides
5. **Testing** - Example applications demonstrating usage

### Questions?

- Check existing documentation in `docs/`
- Review `.github/copilot-instructions.md`
- Open an issue with the `question` label

## Code of Conduct

Please be respectful and constructive in all interactions. We're all here to build something great together!

## License

By contributing to Feliz.Mantine, you agree that your contributions will be licensed under the MIT License.

## Recognition

Contributors will be recognized in the README and CHANGELOG. Thank you for helping make Feliz.Mantine better!
