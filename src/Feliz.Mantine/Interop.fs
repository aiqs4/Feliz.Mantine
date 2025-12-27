namespace Feliz.Mantine

open Fable.Core
open Fable.Core.JsInterop
open Feliz

/// Helper module for React interop with Mantine components
[<AutoOpen>]
module MantineInterop =
    open Fable.React
    
    /// Helper to create a property attribute
    let inline mkAttr (key: string) (value: obj) : IReactProperty = unbox (key, value)
    
    /// Create a React element from an imported component  
    let inline reactElement (comp: obj) (props: IReactProperty seq) : ReactElement =
        ReactBindings.React.createElement(comp, createObj !!props, [||])
