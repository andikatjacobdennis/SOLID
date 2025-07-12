# SOLID Principles in C#

A hands-on repository demonstrating SOLID principles with clean C# examples, designed for interview preparation and quick reference.

## Repository Structure

```
SOLID/
│   SOLID_Principles.sln
│
├───1_SRP/
│       1_SRP.csproj
│       Anti-SRP.cs          # Violation example
│       Program.cs           # Main program
│       SRP-Diagrams.md      # Class & sequence diagrams
│       SRP-Solution.cs      # Proper implementation
│
├───2_OCP/
│       2_OCP.csproj
│       Anti-OCP.cs
│       OCP-Diagrams.md
│       OCP-Solution.cs
│       Program.cs
│
├───3_LSP/
│       3_LSP.csproj
│       Anti-LSP.cs
│       LSP-Diagrams.md
│       LSP-Solution.cs
│       Program.cs
│
├───4_ISP/
│       4_ISP.csproj
│       Anti-ISP.cs
│       ISP-Diagrams.md
│       ISP-Solution.cs
│       Program.cs
│
└───5_DIP/
        5_DIP.csproj
        Anti-DIP.cs
        DIP-Diagrams.md
        DIP-Solution.cs
        Program.cs
```

## How to Use

1. **Clone the repository**:
   ```bash
   git clone https://github.com/andikatjacobdennis/SOLID.git
   ```

2. **Open in Visual Studio**:
   - Load `SOLID_Principles.sln`
   - Each principle is in its own project

3. **Run Examples**:
   - Compare `Anti-*.cs` (violations) with `*-Solution.cs`
   - Execute `Program.cs` to see principles in action

## Quick Navigation

| Principle | Key Files | Description |
|-----------|-----------|-------------|
| **SRP** | `1_SRP/` | Single Responsibility - One class, one purpose |
| **OCP** | `2_OCP/` | Open/Closed - Extend without modifying |
| **LSP** | `3_LSP/` | Liskov Substitution - Substitutability |
| **ISP** | `4_ISP/` | Interface Segregation - Small, focused interfaces |
| **DIP** | `5_DIP/` | Dependency Inversion - Depend on abstractions |

## Study Guide

1. **For Each Principle**:
   - Read the anti-pattern (`Anti-*.cs`) first
   - Compare with the solution (`*-Solution.cs`)
   - Review diagrams (`*-Diagrams.md`)
   - Run the examples

2. **Interview Prep**:
   ```bash
   # Quick review command (Linux/Mac)
   grep -r "// Key Point" .
   ```

## Key Features

- **Isolated Examples**: Each principle in its own project
- **Visual Diagrams**: Mermaid diagrams for clear understanding
- **Side-by-Side Comparison**: Violations vs proper implementations
- **Ready-to-Run**: Fully functional code examples
- **Interview Focused**: Clean, concise examples perfect for discussion

## Contribution

Found an issue or have an improvement?
1. Fork the repository
2. Create a feature branch
3. Submit a pull request

## License 📄

MIT License - Free for learning and interview preparation
