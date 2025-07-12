# SOLID Principles in C#

A comprehensive reference for SOLID principles with practical C# examples, designed for interview preparation and software design mastery.

## Repository Structure

```bash
SOLID/
├── .gitignore
├── interview-questions.md      # Common interview questions
├── LICENSE
├── README.md                   # This file
└── code/                       # All implementation code
    ├── SOLID_Principles.sln    # Main solution file
    ├── 1_SRP/                  # Single Responsibility Principle
    │   ├── 1_SRP.csproj
    │   ├── Anti-SRP.cs         # Violation example
    │   ├── Program.cs          # Demo program
    │   ├── SRP-Diagrams.md     # Visual diagrams
    │   └── SRP-Solution.cs     # Proper implementation
    ├── 2_OCP/                  # Open/Closed Principle
    │   ├── 2_OCP.csproj
    │   ├── Anti-OCP.cs
    │   ├── OCP-Diagrams.md
    │   ├── OCP-Solution.cs
    │   └── Program.cs
    ├── 3_LSP/                  # Liskov Substitution Principle
    │   ├── 3_LSP.csproj
    │   ├── Anti-LSP.cs
    │   ├── LSP-Diagrams.md
    │   ├── LSP-Solution.cs
    │   └── Program.cs
    ├── 4_ISP/                  # Interface Segregation Principle
    │   ├── 4_ISP.csproj
    │   ├── Anti-ISP.cs
    │   ├── ISP-Diagrams.md
    │   ├── ISP-Solution.cs
    │   └── Program.cs
    └── 5_DIP/                  # Dependency Inversion Principle
        ├── 5_DIP.csproj
        ├── Anti-DIP.cs
        ├── DIP-Diagrams.md
        ├── DIP-Solution.cs
        └── Program.cs

```

## How to Use This Repository

### For Study

1. **Explore by Principle**:

   ```bash
   cd code/1_SRP   # Start with SRP
   dotnet run      # Execute the examples
   ```

2. **Compare Implementations**:
   - `Anti-*.cs` → Violation pattern
   - `*-Solution.cs` → Correct implementation
   - `*-Diagrams.md` → Visual representation

### For Interview Prep

1. **Review Questions**:

   ```bash
   interview-questions.md
   ```

2. **Quick Reference**:
   - Each principle has its own folder
   - Diagrams provide visual memory aids

## SOLID Principles Cheat Sheet

| Principle | Definition                                                                                                         | Example Location   |
|-----------|--------------------------------------------------------------------------------------------------------------------|--------------------|
| **S**RP   | A class should have only one reason to change                                                                      | `code/1_SRP/`      |
| **O**CP   | Software entities (classes, modules, functions, etc.) should be open for extension, but closed for modification    | `code/2_OCP/`      |
| **L**SP   | Derived or child classes must be substitutable for their base or parent classes                                    | `code/3_LSP/`      |
| **I**SP   | Do not force any client to implement an interface which is irrelevant to them                                      | `code/4_ISP/`      |
| **D**IP   | High-level modules should not depend on low-level modules. Both should depend on abstractions                      | `code/5_DIP/`      |

## Development Setup

1. **Requirements**:
   - .NET 6+ SDK
   - Visual Studio 2022 or VS Code

2. **Open Solution**:

   ```bash
   cd code
   start SOLID_Principles.sln
   ```

3. **Run All Tests**:

   ```bash
   dotnet test
   ```

## Contribution Guidelines

1. **Reporting Issues**:
   - Check existing issues first
   - Include reproduction steps

2. **Suggesting Improvements**:
   - Fork the repository
   - Create a feature branch
   - Submit a pull request

## License

MIT License - See [LICENSE](LICENSE) for details.
