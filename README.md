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

*Work In Progress*

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
