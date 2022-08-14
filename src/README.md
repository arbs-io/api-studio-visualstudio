# Api Studio - Visual Studio

## Project Structure

Summary of each projects within the solution:

- **api-studio.package**: vsix package artefacts
- **api-studio.designer**: Domain Specific Language and VS-Designer tool
- **api-studio.linter**: Rulesets to validate standard design principles are followed
- **api-studio.vs**: Visual Studio interopt
- **api-studio.common**: Shared objects e.g. Models
- **api-studio.utility**: Shared helper function e.g. Extenstion
- **api-studio.build**: Code generation tools and interripter routing
  - **api-studio.codegen.csharp-azurefunction-dotnet6**
  - **api-studio.codegen.csharp-minimalapi-dotnet6**
  - **api-studio.codegen.python-fastapi-python3x**
