namespace Feliz.Mantine

open Fable.Core
open Fable.Core.JsInterop
open Feliz
open Browser.Types

/// Mantine Core components module
[<RequireQualifiedAccess>]
module Mantine =
    
    /// MantineProvider - The root provider component for Mantine theme
    let inline mantineProvider (props: IReactProperty seq) =
        MantineInterop.reactElement (importDefault "@mantine/core") props
    
    /// Button component
    let inline button (props: IReactProperty seq) =
        MantineInterop.reactElement (import "Button" "@mantine/core") props
    
    /// TextInput component
    let inline textInput (props: IReactProperty seq) =
        MantineInterop.reactElement (import "TextInput" "@mantine/core") props
    
    /// Container component
    let inline container (props: IReactProperty seq) =
        MantineInterop.reactElement (import "Container" "@mantine/core") props
    
    /// Group component - horizontal layout
    let inline group (props: IReactProperty seq) =
        MantineInterop.reactElement (import "Group" "@mantine/core") props
    
    /// Stack component - vertical layout
    let inline stack (props: IReactProperty seq) =
        MantineInterop.reactElement (import "Stack" "@mantine/core") props
    
    /// Title component
    let inline title (props: IReactProperty seq) =
        MantineInterop.reactElement (import "Title" "@mantine/core") props
    
    /// Text component
    let inline text (props: IReactProperty seq) =
        MantineInterop.reactElement (import "Text" "@mantine/core") props
    
    /// Modal component
    let inline modal (props: IReactProperty seq) =
        MantineInterop.reactElement (import "Modal" "@mantine/core") props
    
    /// Loader component
    let inline loader (props: IReactProperty seq) =
        MantineInterop.reactElement (import "Loader" "@mantine/core") props

/// Type-safe props for Button component
type button =
    /// Button variant style
    static member inline variant (value: string) = MantineInterop.mkAttr "variant" value
    /// Button color
    static member inline color (value: string) = MantineInterop.mkAttr "color" value
    /// Button size
    static member inline size (value: string) = MantineInterop.mkAttr "size" value
    /// Radius
    static member inline radius (value: string) = MantineInterop.mkAttr "radius" value
    /// Full width
    static member inline fullWidth (value: bool) = MantineInterop.mkAttr "fullWidth" value
    /// Disabled state
    static member inline disabled (value: bool) = MantineInterop.mkAttr "disabled" value
    /// Loading state
    static member inline loading (value: bool) = MantineInterop.mkAttr "loading" value
    /// Click handler
    static member inline onClick (handler: MouseEvent -> unit) = MantineInterop.mkAttr "onClick" handler
    /// Children elements
    static member inline children (elements: ReactElement list) = prop.children elements
    /// Children element
    static member inline children (element: ReactElement) = prop.children element
    /// Children text
    static member inline children (text: string) = MantineInterop.mkAttr "children" text
    
/// Type-safe props for TextInput component
type textInput =
    /// Input label
    static member inline label (value: string) = MantineInterop.mkAttr "label" value
    /// Placeholder text
    static member inline placeholder (value: string) = MantineInterop.mkAttr "placeholder" value
    /// Input value
    static member inline value (value: string) = MantineInterop.mkAttr "value" value
    /// Change handler
    static member inline onChange (handler: string -> unit) = 
        MantineInterop.mkAttr "onChange" (fun (e: Event) -> 
            let target = e.target :?> HTMLInputElement
            handler target.value
        )
    /// Description text
    static member inline description (value: string) = MantineInterop.mkAttr "description" value
    /// Error message
    static member inline error (value: string) = MantineInterop.mkAttr "error" value
    /// Required indicator
    static member inline required (value: bool) = MantineInterop.mkAttr "required" value
    /// Disabled state
    static member inline disabled (value: bool) = MantineInterop.mkAttr "disabled" value
    /// Size
    static member inline size (value: string) = MantineInterop.mkAttr "size" value
    /// Radius
    static member inline radius (value: string) = MantineInterop.mkAttr "radius" value

/// Type-safe props for Container component
type container =
    /// Container size
    static member inline size (value: string) = MantineInterop.mkAttr "size" value
    /// Fluid container
    static member inline fluid (value: bool) = MantineInterop.mkAttr "fluid" value
    /// Children elements
    static member inline children (elements: ReactElement list) = prop.children elements
    /// Children element
    static member inline children (element: ReactElement) = prop.children element

/// Type-safe props for Group component
type group =
    /// Spacing between elements
    static member inline gap (value: string) = MantineInterop.mkAttr "gap" value
    /// Justify content
    static member inline justify (value: string) = MantineInterop.mkAttr "justify" value
    /// Align items
    static member inline align (value: string) = MantineInterop.mkAttr "align" value
    /// Grow children
    static member inline grow (value: bool) = MantineInterop.mkAttr "grow" value
    /// Children elements
    static member inline children (elements: ReactElement list) = prop.children elements

/// Type-safe props for Stack component
type stack =
    /// Spacing between elements
    static member inline gap (value: string) = MantineInterop.mkAttr "gap" value
    /// Justify content
    static member inline justify (value: string) = MantineInterop.mkAttr "justify" value
    /// Align items
    static member inline align (value: string) = MantineInterop.mkAttr "align" value
    /// Children elements
    static member inline children (elements: ReactElement list) = prop.children elements

/// Type-safe props for Title component
type title =
    /// Title order (1-6)
    static member inline order (value: int) = MantineInterop.mkAttr "order" value
    /// Size
    static member inline size (value: string) = MantineInterop.mkAttr "size" value
    /// Children text
    static member inline children (text: string) = MantineInterop.mkAttr "children" text
    /// Children element
    static member inline children (element: ReactElement) = prop.children element

/// Type-safe props for Text component
type text =
    /// Text size
    static member inline size (value: string) = MantineInterop.mkAttr "size" value
    /// Text weight
    static member inline fw (value: int) = MantineInterop.mkAttr "fw" value
    /// Text color
    static member inline c (value: string) = MantineInterop.mkAttr "c" value
    /// Italic
    static member inline fs (value: string) = MantineInterop.mkAttr "fs" value
    /// Truncate
    static member inline truncate (value: bool) = MantineInterop.mkAttr "truncate" value
    /// Children text
    static member inline children (text: string) = MantineInterop.mkAttr "children" text
    /// Children element
    static member inline children (element: ReactElement) = prop.children element

/// Type-safe props for Modal component
type modal =
    /// Opened state
    static member inline opened (value: bool) = MantineInterop.mkAttr "opened" value
    /// Close handler
    static member inline onClose (handler: unit -> unit) = MantineInterop.mkAttr "onClose" handler
    /// Modal title
    static member inline title (value: string) = MantineInterop.mkAttr "title" value
    /// Size
    static member inline size (value: string) = MantineInterop.mkAttr "size" value
    /// Children elements
    static member inline children (elements: ReactElement list) = prop.children elements
    /// Children element
    static member inline children (element: ReactElement) = prop.children element

/// Type-safe props for Loader component
type loader =
    /// Loader size
    static member inline size (value: string) = MantineInterop.mkAttr "size" value
    /// Loader color
    static member inline color (value: string) = MantineInterop.mkAttr "color" value
    /// Loader type
    static member inline type' (value: string) = MantineInterop.mkAttr "type" value

/// Type-safe props for MantineProvider
type mantineProvider =
    /// Theme configuration
    static member inline theme (value: obj) = MantineInterop.mkAttr "theme" value
    /// Default color scheme
    static member inline defaultColorScheme (value: string) = MantineInterop.mkAttr "defaultColorScheme" value
    /// Children elements
    static member inline children (elements: ReactElement list) = prop.children elements
    /// Children element
    static member inline children (element: ReactElement) = prop.children element
