# ApiStudio Extension for Visual Studio

## About

The ApiStudio Extension for Visual Studio provides ApiStudio integration in Visual Studio 2022 and newer.
Most of the extension UI lives in the Team Explorer pane, which is available from the View menu.

Official builds of this extension are available at the [Visual Studio Marketplace](https://marketplace.visualstudio.com/items?itemName=ApiStudio.ApiStudioExtensionforVisualStudio).

## Documentation
Visit the [documentation](https://ApiStudio.com/ApiStudio/VisualStudio/tree/master/docs) for details on how to use the features in the ApiStudio Extension for Visual Studio.

## Build requirements

* Visual Studio 2022
  * `.NET desktop development` workload
  * `.NET Core cross platform development` workload
  * `Visual Studio extension development` workload

The built VSIX will work with Visual Studio 2015 or newer

## Build

Clone the repository and its submodules.

Execute `build.cmd`

## Visual Studio Build

Build `api-studio.sln` using Visual Studio 2019.

## Troubleshooting

If you have issues building with failures similar to:

> "The type or namespace name does not exist..."
or

> "Unable to find project... Check that the project reference is valid and that the project file exists."*
Close Visual Studio and run the following command to update submodules and clean your environment.

```txt
clean.cmd
```

## More information
- TBC

## Contributing

details on how to participate.

## Copyright

Copyright 2021 - 2022 ApiStudio, Inc.

Licensed under the [MIT License](.\src\LICENSE.md)