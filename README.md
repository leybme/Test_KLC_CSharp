# TestKLC

## Overview
TestKLC is a project designed to demonstrate and test the functionality of the KLCCommandLib_x64 library. It includes a simple application that interacts with the library to perform various operations.

## Project Structure
- **TestKLC.sln**: The solution file for the project.
- **TestKLC/**: The main project directory containing the source code and configuration files.
  - **App.config**: Configuration file for the application.
  - **KLCCommandLib_x64.dll**: The library used by the application.
  - **Program.cs**: The main entry point of the application.
  - **TestKLC.csproj**: The project file for the application.
  - **bin/**: Contains compiled binaries.
    - **Debug/**: Debug build output.
    - **Release/**: Release build output.
  - **obj/**: Intermediate files generated during the build process.
  - **Properties/**: Contains project properties and metadata.
    - **AssemblyInfo.cs**: Assembly metadata.

## How to Build
1. Open `TestKLC.sln` in Visual Studio.
2. Select the desired build configuration (Debug or Release).
3. Build the solution using the "Build" menu or by pressing `Ctrl+Shift+B`.

## How to Run
1. After building the project, navigate to the `bin/Debug` or `bin/Release` directory.
2. Run `TestKLC.exe` to execute the application.

## Dependencies
- **KLCCommandLib_x64.dll**: Ensure this library is present in the `bin` directory for the application to function correctly.

## Software for the KLC101 Controller

This section describes the process of testing the KLC101 Controller software using a C# application that interacts with the KLCCommandLib_x64.dll (a C++ DLL). The test application demonstrates how to control the KLC101 settings and operating modes programmatically.


### Implementation in C#
The test application uses P/Invoke to call functions from the C++ DLL (KLCCommandLib_x64.dll). 

### Notes
- Ensure that `KLCCommandLib_x64.dll` is present in the same directory as the compiled executable.
- The test application demonstrates basic functionality. Additional error handling and logging can be added as needed.
- The SDK provided with the software supports C++, LabVIEW™, and Python, but this example focuses on using the C++ DLL in a C# application.

## License
This project is licensed under the terms specified in the `LICENSE.txt` file.