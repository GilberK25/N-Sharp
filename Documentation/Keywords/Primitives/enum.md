# Keywords/Primitives
## `enum`

An `enum`, or enumerated primitive (known now on as an "enum"), is a [primitive](Primitives.md) that is unlike the others. It is meant to contain a list of options, each given a constant value. Otherwise, it is very limited.
- Non-nullable.
- Can only derive from other enums.
- Only other enums can derive from an enum.
- Cannot be marked abstract.
- Cannot contain any constructor.
- Cannot contain any object (field, method, operator, type object, or otherwise).

An enum can only contain "options". They are text entered into the enum's body that are like a setting of the enum. They can be assigned a constant value, or one will automatically be given to them. Duplicate values are not allowed.

```
public namespace Example
{
    public enum TypeA
    {
        ValueA = 0,
        ValueB = 1,
        ValueC = 0, // 0 has been used, and cannot be used again.
        ValueD = 5, // Skipping increments is allowed.
    }

    public class TypeB
    {
        public TypeA FieldA = TypeA.ValueB;
    }
}
```

Enums also have an optional generic parameter. Any type you enter will become the type you assign options to. For example, if your object is an `enum<string>`, values such as `"value"` will be entered instead of numbers.

If your type parameter is an [`IIncrementable`](../../../Libraries/System/IIncremental.ns), including a value is optional, as the enum will automatically assign a value incremented by 1 from the previous value. The first value is set to `IIncrementable.Default`. If the type is not an `IIncrementable`, you must supply a constant value to each option.

```nsharp
public namespace Example
{
    public enum<string> TypeC
    {
        ValueA = "value_a",
        ValueB = "value_b",
        ValueC, // `string` is not an `IIncremental`, so this is not allowed.
    }
    public enum<byte> TypeD
    {
        ValueA,
        ValueB,
        ValueC,
        // This is legal. `byte` is an `IIncremental`.
    }
}
```

Deriving an enum follows similar rules. The options given are still accessible in the new enum.
