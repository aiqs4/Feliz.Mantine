namespace Feliz.Mantine

open Fable.Core
open Fable.Core.JsInterop

/// Mantine Hooks module - bindings for @mantine/hooks
[<RequireQualifiedAccess>]
module Hooks =
    
    /// useDisclosure hook - returns [opened, { open, close, toggle }]
    let inline useDisclosure (initialState: bool) : bool * {| toggle: unit -> unit; ``open``: unit -> unit; close: unit -> unit |} =
        import "useDisclosure" "@mantine/hooks" initialState
    
    /// useToggle hook - toggle between two values
    let inline useToggle<'T> (initialValue: 'T) (options: 'T array) : 'T * (unit -> unit) =
        import "useToggle" "@mantine/hooks" (initialValue, options)
    
    /// useHover hook - track hover state
    let inline useHover () : {| hovered: bool; ref: obj |} =
        import "useHover" "@mantine/hooks" ()
    
    /// useClickOutside hook - detect clicks outside element
    let inline useClickOutside (handler: unit -> unit) : obj =
        import "useClickOutside" "@mantine/hooks" handler
    
    /// useLocalStorage hook - sync state with localStorage
    let inline useLocalStorage<'T> (key: string, defaultValue: 'T) : 'T * (('T -> 'T) -> unit) =
        import "useLocalStorage" "@mantine/hooks" {| key = key; defaultValue = defaultValue |}
    
    /// useMediaQuery hook - match CSS media query
    let inline useMediaQuery (query: string) : bool =
        import "useMediaQuery" "@mantine/hooks" query
    
    /// useViewportSize hook - get viewport dimensions
    let inline useViewportSize () : {| width: int; height: int |} =
        import "useViewportSize" "@mantine/hooks" ()
    
    /// useWindowScroll hook - get/set window scroll position
    let inline useWindowScroll () : {| x: int; y: int |} * {| scrollTo: {| x: int; y: int |} -> unit |} =
        import "useWindowScroll" "@mantine/hooks" ()
    
    /// useInterval hook - call function at interval
    let inline useInterval (fn: unit -> unit, interval: int) : {| start: unit -> unit; stop: unit -> unit; active: bool |} =
        import "useInterval" "@mantine/hooks" (fn, interval)
    
    /// useClipboard hook - copy to clipboard
    let inline useClipboard (timeout: int) : {| copy: string -> unit; copied: bool; reset: unit -> unit |} =
        import "useClipboard" "@mantine/hooks" {| timeout = timeout |}
    
    /// useDebouncedValue hook - debounce value
    let inline useDebouncedValue<'T> (value: 'T, wait: int) : 'T =
        import "useDebouncedValue" "@mantine/hooks" (value, wait)
    
    /// useCounter hook - counter with increment/decrement
    let inline useCounter (initialValue: int, options: {| min: int option; max: int option |}) : int * {| increment: unit -> unit; decrement: unit -> unit; set: int -> unit; reset: unit -> unit |} =
        import "useCounter" "@mantine/hooks" (initialValue, options)
    
    /// useId hook - generate unique ID
    let inline useId () : string =
        import "useId" "@mantine/hooks" ()
    
    /// useListState hook - manage list state
    let inline useListState<'T> (initialValue: 'T array) : 'T array * {| append: 'T -> unit; prepend: 'T -> unit; remove: int -> unit; setItem: int * 'T -> unit; setState: 'T array -> unit |} =
        import "useListState" "@mantine/hooks" initialValue
