# Keywords/Primitives
## `struct`

A `struct` (structure) is a type of [primitive](Primitives.md) keyword, with certain special properties.
- Non-nullable.
- Can derive from an interface or other structure.
- Only other structs can derive from a structure.
- Can be marked abstract
- Cannot contain an entry method.
- Can contain a static constructor.
- Must contain a parameterless constructor (or a default one will be used).
- Must assign every field in each constructor.
- Cannot assign any field in its declaration.

The key feature with structures are their non-nullable traits. A structure variable which is unassigned or set to its default value will automatically set itself to its parameterless constructor, even if it isn't told to. Structures can have other constructors, but a parameterless one must exist. If one does not, the structure will use a default constructor, which simply assigns every field belonging to it to its default value.

```nsharp
public namespace Example
{
    public struct TypeA
    {
        public int Field1;
        public int Field2 = 5; // Cannot assign `Field2` to the value `5` during its declaration.
        public int Field3;

        public TypeA()
        {
            Field1 = -1;
            Field2 = 5;

            // Missing Field3. This will throw a compiler error.
        }
        public TypeA(int var1, int var2, int var3)
        {
            Field1 = var1;
            Field2 = var2;
            Field3 = var3;

            // This is a legal constructor.

            Field1 = Field2; // Fields can be reassigned. They must be assigned at least once.
        }
    }

    public struct TypeB : TypeA
    {
        public static void Main()
        {
            // This can still exist, but will not be considered an entry method.
            TypeA varA; // If unassigned, this will be set to `new()`
        }
    }

    public class TypeC : TypeB { } // A class cannot derive from a structure.
}
```
