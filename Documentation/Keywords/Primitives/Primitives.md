# Keywords/Primitives
## Primitives

A primitive defines an object to have a certain base characteristics. There are 4 primitives, and they are each a keyword.
- [`class`](class.md)
- [`struct`](struct.md)
- [`interface`](interface.md)
- [`enum`](enum.md)

The primitive keyword goes before the type name, but after any instance and protection keywords.

In order to define a type, a primitive keyword **must** be before the name, but there must only be one.

```nsharp
public namespace Example
{
    public static class TypeA { }
    // The primitive keyword is in the correct place.

    struct public static TypeB { }
    // `struct` must be directly before `TypeB`

    interface TypeC { }
    // This is legal.

    public static TypeD { }
    // There is a missing primitive keyword.

    static interface struct TypeE { }
    // This has one too many primitive keywords.
} 
```
