[![npm package](https://img.shields.io/npm/v/com.william-brocklesby.unity-configurator)](https://www.npmjs.com/package/com.william-brocklesby.unity-configurator)
[![openupm](https://img.shields.io/npm/v/com.william-brocklesby.unity-configurator?label=openupm&registry_uri=https://package.openupm.com)](https://openupm.com/packages/com.william-brocklesby.unity-configurator/)
![Tests](https://github.com/william-brocklesby/unity-configurator/workflows/Tests/badge.svg)
[![License: MIT](https://img.shields.io/badge/License-MIT-green.svg)](https://opensource.org/licenses/MIT)

# configurator

This package provides a flexible and extensible framework for creating customizable UI settings menus within your Unity projects.

- [How to use](#how-to-use)
- [Install](#install)
  - [via npm](#via-npm)
  - [via OpenUPM](#via-openupm)
  - [via Git URL](#via-git-url)
  - [Tests](#tests)
- [Configuration](#configuration)

<!-- toc -->

## How to use

1.  **Defining Tunables**

    *   Add the `using Configurator` namespace to your C# scripts.
    *   Apply the `[Tunable]` attribute to static properties or fields within your classes to make them adjustable. Example:

        ```csharp
        public class GameSettings
        {
            [Tunable("masterVolume")]
            public static float MasterVolume { get; set; } = 0.8f;

            [Tunable("difficulty")] 
            public static int DifficultyLevel { get; set; } = 1;  
        }
        ```

2.  **Accessing and Modifying Tunables**

    *   Use the `Configurator.ControlPanel` class to get and set values:

        ```csharp
        using Configurator;

        // Get the current difficulty level
        int currentDifficulty = ControlPanel.GetValue<int>("difficulty"); 

        // Increase the master volume
        ControlPanel.SetValue<float>("masterVolume", 0.95f); 
        ```

3.  **Subscribing to Changes**

    *   Subscribe to the `Configurator.ControlPanel.OnChange` event to react when tunable values change:

        ```csharp
        using Configurator;

        ControlPanel.OnChange += (tunable) => {
            if (tunable.Key == "masterVolume") 
            {
                // Update audio mixer based on new volume
            }
        };
        ```

4.  **Saving and Loading Settings**

    * **Using PlayerPrefs:** For basic settings persistence, leverage the built-in `PlayerPrefsConfigurationManager`:

       ```csharp
       // Save settings
       Configurator.ControlPanel.Save<PlayerPrefsConfigurationManager>(); 
  
       // Load settings
       Configurator.ControlPanel.Load<PlayerPrefsConfigurationManager>(); 
       ```

    * **Custom Persistence:** For more complex data or alternative storage backends, provide your own implementation of the `IConfigurationManager` interface.

## Install

### via npm

Open `Packages/manifest.json` with your favorite text editor. Add a [scoped registry](https://docs.unity3d.com/Manual/upm-scoped.html) and following line to dependencies block:
```json
{
  "scopedRegistries": [
    {
      "name": "npmjs",
      "url": "https://registry.npmjs.org/",
      "scopes": [
        "com.william-brocklesby"
      ]
    }
  ],
  "dependencies": {
    "com.william-brocklesby.unity-configurator": "1.0.0"
  }
}
```
Package should now appear in package manager.

### via OpenUPM

The package is also available on the [openupm registry](https://openupm.com/packages/com.william-brocklesby.unity-configurator). You can install it eg. via [openupm-cli](https://github.com/openupm/openupm-cli).

```
openupm add com.william-brocklesby.unity-configurator
```

### via Git URL

Open `Packages/manifest.json` with your favorite text editor. Add following line to the dependencies block:
```json
{
  "dependencies": {
    "com.william-brocklesby.unity-configurator": "https://github.com/william-brocklesby/unity-configurator.git"
  }
}
```

### Tests

The package can optionally be set as *testable*.
In practice this means that tests in the package will be visible in the [Unity Test Runner](https://docs.unity3d.com/2017.4/Documentation/Manual/testing-editortestsrunner.html).

Open `Packages/manifest.json` with your favorite text editor. Add following line **after** the dependencies block:
```json
{
  "dependencies": {
  },
  "testables": [ "com.william-brocklesby.unity-configurator" ]
}
```

## Configuration

*Work In Progress*

## License

MIT License

Copyright © 2024 William Brocklesby
