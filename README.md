# Feliz.Mantine

[![NuGet](https://img.shields.io/nuget/v/Feliz.Mantine.svg)](https://www.nuget.org/packages/Feliz.Mantine/)

Feliz-style bindings for [Mantine UI](https://mantine.dev/) v8.3.10 - A fully featured React components library.

## Installation

### Install the NuGet package

```bash
dotnet add package Feliz.Mantine
```

### Install the NPM dependencies

```bash
npm install @mantine/core@8.3.10 @mantine/hooks@8.3.10 @emotion/react
```

For additional packages like dates, forms, notifications, etc., install the corresponding package:

```bash
npm install @mantine/dates@8.3.10
npm install @mantine/form@8.3.10
npm install @mantine/notifications@8.3.10
npm install @mantine/spotlight@8.3.10
npm install @mantine/dropzone@8.3.10
npm install @mantine/modals@8.3.10
npm install @mantine/nprogress@8.3.10
npm install @mantine/tiptap@8.3.10
npm install @mantine/carousel@8.3.10
```

## Usage

### Basic Example

```fsharp
open Feliz
open Feliz.Mantine

let myComponent = React.functionComponent(fun () ->
    Mantine.mantineProvider [
        mantine.theme.colorScheme.light
        mantine.children [
            Mantine.button [
                button.variant.filled
                button.color "blue"
                button.onClick (fun _ -> printfn "Button clicked!")
                button.children "Click me!"
            ]
        ]
    ]
)
```

### Using Hooks

```fsharp
open Feliz.Mantine.Hooks

let myComponent = React.functionComponent(fun () ->
    let opened, handlers = Hooks.useDisclosure false
    
    Html.div [
        Mantine.button [
            button.onClick (fun _ -> handlers.toggle())
            button.children "Toggle"
        ]
        if opened then
            Html.text "Content is visible!"
    ]
)
```

## Available Packages

Feliz.Mantine provides bindings for all Mantine packages:

- **@mantine/core** - Core components (Button, Input, Modal, etc.)
- **@mantine/hooks** - Custom React hooks
- **@mantine/dates** - Date/time picker components
- **@mantine/form** - Form management utilities
- **@mantine/notifications** - Notification system
- **@mantine/spotlight** - Spotlight search component
- **@mantine/dropzone** - File dropzone component
- **@mantine/modals** - Modal manager
- **@mantine/nprogress** - Navigation progress indicator
- **@mantine/tiptap** - Rich text editor
- **@mantine/carousel** - Carousel component

## Component Categories

### Layout
AppShell, Container, Center, Group, Stack, Flex, Grid, SimpleGrid, Space, Divider, AspectRatio, and more.

### Typography
Title, Text, Anchor, Code, Kbd, Table, List, Highlight, Mark, Blockquote, etc.

### Inputs
TextInput, PasswordInput, NumberInput, Select, MultiSelect, Autocomplete, Textarea, ColorInput, FileInput, and more.

### Buttons
Button, ActionIcon, UnstyledButton, CloseButton, CopyButton, FileButton.

### Navigation
Tabs, Pagination, Stepper, Breadcrumbs, NavLink, Menu, SegmentedControl.

### Overlays
Modal, Drawer, Tooltip, Popover, HoverCard, Overlay, Portal, Affix.

### Data Display
Avatar, Badge, Card, Table, Timeline, Accordion, Tree, Image, Paper.

### Feedback
Alert, Loader, Progress, RingProgress, Skeleton, LoadingOverlay.

And many more!

## Documentation

For detailed documentation on each component, please refer to the [official Mantine documentation](https://mantine.dev/).

## Development

This project uses:
- .NET SDK for F# compilation
- Node.js for npm dependencies
- Vite for development server

### Building the Project

```bash
dotnet build src/Feliz.Mantine/Feliz.Mantine.fsproj
```

### Running the Example App

```bash
npm run dev
```

## Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

## License

MIT

## Acknowledgments

- [Mantine UI](https://mantine.dev/) - The amazing React components library
- [Feliz](https://github.com/Zaid-Ajaj/Feliz) - The wonderful F# DSL for React
- [Fable](https://fable.io/) - The F# to JavaScript compiler
