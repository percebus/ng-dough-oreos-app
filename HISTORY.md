# ng-dough-oreos-app

## Your first Angular app

[See the full tutorial here](https://angular.dev/tutorials/first-app)

### Introduction

#### Node.js

1. `node --version` (for me it was `20.x`)
1. [Install `node.js`](https://nodejs.org/en/download/) (LTS version recommended). (`22.14.0`, as of 2025-04-11)

##### Windows

Open a command shell in "Administrator" mode and run the following commands:

1. `$> choco install nodejs-lts --version="22.14.0"`

##### Verify

1. `node --version` (should be `v22.14.0`)

#### npm

Open a command shell in "Administrator" mode and run the following commands:

1. `$> npm install -g --update npm`
1. `$> npm --version` (`11.3.0` as of 2025-04-11)

#### Angular CLI

1. `$> npm install -g --update @angular/cli`
1. `ng --version` (`19.2.7` as of 2025-04-11)

#### Visual Studio Code

##### Angular Language Service

- [Angular Language Service](https://marketplace.visualstudio.com/items?itemName=Angular.ng-template)

### 01. Hello world

[01-hello-world](https://angular.dev/tutorials/first-app/01-hello-world)

1. [Download the `.zip`](https://angular.dev/tutorials/first-app/01-hello-world)
1. `$> npm install`
1. `$> ng serve` (start and keeps running)
1. Added `.gitignore`
  - `Node.gitignore`
  - `VisualStudioCode.gitignore`
  - `angular.gitignore`

#### Before

![Screenshot](./assets/img/first-app/01-hello-world/01.png)

#### Change

1. Replace "Default" with "Hello world"

#### After

![Screenshot](./assets/img/first-app/01-hello-world/02.png)

### 02. Components

[02-HomeComponent](https://angular.dev/tutorials/first-app/02-HomeComponent)

1. `$> ng generate component home`
1. `$> ng serve`

#### Before

![Screenshot](./assets/img/first-app/01-hello-world/02.png)

#### Changes

- Change `app.component` to include `HomeComponent`

![Screenshot](./assets/img/first-app/02-HomeComponent/01.png)

- Change `home/home.component.*`

##### After

![Screenshot](./assets/img/first-app/02-HomeComponent/02.png)
