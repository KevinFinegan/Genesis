Option Strict On
Option Explicit On

Public Module Enums
    Public Enum State
        Expanded = 11
        Reduced = 17
    End Enum

    Public Enum Direction
        UpDown = 23
        LeftRight = 29
    End Enum
    'Both?

    Public Enum ImageSet
        PlusMinus = 2
        SingleArrow = 3
        DoubleArrow = 5
        TripleArrow = 7
    End Enum
End Module