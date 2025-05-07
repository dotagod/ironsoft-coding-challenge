# Old Phone Pad Text Converter

## Overview

This project implements a solution for converting old phone keypad button presses into text. It simulates the behavior of traditional mobile phone keypads where each number key (2-9) is associated with multiple letters, and pressing a key multiple times cycles through the available letters.

## Problem Description

On an old phone keypad:
- Each digit key (2-9) has multiple letters assigned
- Pressing a key multiple times cycles through its letters
- A space indicates a pause (when typing two characters from the same key)
- '#' indicates end of input (send)
- '*' acts as a backspace

### Keypad Layout

```
1         2 ABC    3 DEF
4 GHI     5 JKL    6 MNO
7 PQRS    8 TUV    9 WXYZ
*         0        # (Send)
```

## Implementation

The solution is implemented in C# using .NET. The main functionality is provided by the `PhoneKeypad` class, which includes:

- `OldPhonePad(string input)`: Converts a string of keypad presses to text
- `AppendCurrentCharacter(StringBuilder result, char? digit, int presses)`: Helper method to append the correct letter based on the digit and number of presses

### Key Features

- **Efficient State Tracking**: Uses nullable char to track the last digit pressed and count of consecutive presses
- **Backspace Support**: Handles '*' as backspace to remove the last character from the result
- **Pause Handling**: Processes spaces to finalize the current character and reset the state
- **Cycling Letters**: Correctly cycles through letters when a key is pressed multiple times

## Project Structure

- **OldPhonePad/**: Main project
  - `PhoneKeypad.cs`: Core implementation of the phone keypad text converter
  - `Program.cs`: Example usage with test cases

- **OldPhonePadTests/**: Test project
  - `PhoneKeypadTests.cs`: Comprehensive test suite with 10 test cases

## Examples

```csharp
// Single character
PhoneKeypad.OldPhonePad("2#") // Returns "A"

// Multiple consecutive presses
PhoneKeypad.OldPhonePad("222#") // Returns "C"

// Space for pause (two characters from same key)
PhoneKeypad.OldPhonePad("2 2#") // Returns "AA"

// Backspace
PhoneKeypad.OldPhonePad("227*#") // Returns "A"

// Complex examples
PhoneKeypad.OldPhonePad("4433555 555666#") // Returns "HELLO"
PhoneKeypad.OldPhonePad("8 88777444666*664#") // Returns "TURING"
```

Additional examples:
- Pressing "2" once outputs "A"
- Pressing "2" twice in succession outputs "B"
- Pressing "2" three times in succession outputs "C"
- Pressing "2", pausing (space), then pressing "2" again outputs "AA"
- Input "222 2 22#" outputs "CAB" (C + pause + A + B)

## Running the Project

### Prerequisites

- .NET SDK 6.0 or later

### Running the Tests

```bash
dotnet test
```

### Running the Example Program

```bash
dotnet run --project OldPhonePad/OldPhonePad.csproj
```

## Testing

The solution includes comprehensive unit tests in the `OldPhonePadTests.cs` file. The tests cover:

- Single character inputs
- Multiple consecutive presses
- Cycling through letters
- Pauses for same-key characters
- Backspace functionality
- Complex examples
- Error handling

To run the tests, you'll need MSTest or another compatible testing framework.

## Technical Details

### Time Complexity

- **O(n)** where n is the length of the input string
- Each character is processed exactly once in a single pass

### Space Complexity

- **O(m)** where m is the length of the output string
- Uses a StringBuilder for efficient string building
- Minimal additional memory usage with simple state tracking variables

## Requirements

- .NET Framework 4.5+ or .NET Core 2.0+
- MSTest for running the unit tests

