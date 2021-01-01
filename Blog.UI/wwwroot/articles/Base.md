## Bases

Base-2 = Binary (0 and 1)
e.g. 00010111

Base-8 = Octal (0 - 7)
e.g. 27 05 20

Base-10 = Decimal (0 - 9)
e.g. 1 2 3 4 5 6 7 8 9 10 11 12

Base-16 = Hexadecimal (0 - 9 and A - F)
e.g. 00FF A45D

Each base type can be converted from one to the other.

E.g.

- Base-2: 00010111
- Base-8: 27
- Base-10: 23
- Base-16: 17

Base is often noted in text useing a subscript next to the number.

E.g.

- Base-2: 00010111<sub>2</sub>
- Base-8: 27<sub>8</sub>
- Base-10: 23<sub>10</sub>
- Base-16: 17<sub>16</sub>

In C# and other C family languages Hexadecimal is denoted by prefixing with '0x'. 

E.g.

- 0xA46FD97C

## Binary (Base-2)

Binary is a series of bits that a read right to left. Each bit represents a number double the previous size. For example a simple 8 bit sequence (known as an unsigned byte) can represent a number between 0 and 255 by toggling the bits on and off;

```
0   0   0   0   0   0   0   0   = 0
1   1   1   1   1   1   1   1   = 255
0   0   0   1   0   1   1   1   = 23
128 064 032 016 008 004 002 001
```

### Unsigned

The means it does not support negative numbers. The above exmple being a 8 bit unsigned byte.


### Signed

This means it does support negative numbers, so the 8 bit signed byte supports number between -128 and +127. Signed bits use a system known as 2's completment.

In twos complement, the positive number are represented the same as in an unsigned byte, except the furthest left bit now represents the sign (0 = positive, 1 = negative), for example;

```
0   0   0   0   0   0   0   0   = 0
0   1   1   1   1   1   1   1   = 127
0   0   0   1   0   1   1   1   = 23
Sig 064 032 016 008 004 002 001
```

Then for negative numbers, they again count up, but start from a lower base examples include;

```
1   1   1   1   1   1   1   1   = -1
1   0   0   0   0   0   0   0   = -128
1   1   1   0   1   0   0   1   = -23
Sig 064 032 016 008 004 002 001
```

### Binary Lengths

Common named binary lenghts include;

- 1 = Bit
- 4 = Nibble
- 8 = Byte
- 16 = Short Word
- 32 = Word
- 64 = Long Word

### Octal (Base-8)


### Hexadecimal (Base-16)

