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

[Hello world](https://angular.dev/tutorials/first-app/01-hello-world)

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

### 02. Create Home component

[Create Home component](https://angular.dev/tutorials/first-app/02-HomeComponent)

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

### 03. Create the application’s HousingLocation component

[Create the application’s HousingLocation component](https://angular.dev/tutorials/first-app/03-HousingLocation)

1. `$> ng generate component housingLocation`
1. `$> ng serve` (leave running)
1. Add `housing-location` to `house` `component`.

![Screenshot](./assets/img/first-app/03-HousingLocation/01.png)

### 04. Creating an interface

[Creating an interface](https://angular.dev/tutorials/first-app/04-interfaces)

#### Interface

1. `$> ng generate interface housinglocation`
1. `$> ng serve` (leave running)
1. Replace contents of `app/housinglocation.ts`

### Dummy "Test House" data

1. Add `housingLocation:HousingLocation` on `HomeComponent` class.

### 05. Add an input parameter to the component

[Add an input parameter to the component](https://angular.dev/tutorials/first-app/05-inputs)

1. Add `@Input()` to `HousingLocationComponent` class.

### 06. Add a property binding to a component’s template

[Add a property binding to a component’s template](https://angular.dev/tutorials/first-app/06-property-binding)

1. Add a property binding to `housing-location` in `home.component.html`

### 07. Add an interpolation to a component’s template

[Add an interpolation to a component’s template](https://angular.dev/tutorials/first-app/07-dynamic-template-values)

1. Add HTML to `housing-location.component.ts`

![Screenshot](./assets/img/first-app/07-dynamic-template-values/01.png)

### 08. Use *ngFor to list objects in component

[Use `*ngFor` to list objects in component](https://angular.dev/tutorials/first-app/08-*ngFor)

1. Replace `housingLocation` w/ `housingLocationList` in `home.component.ts`
1. Add `*ngFor` to `housing-location` in `home.component.html`

![Screenshot](./assets/img/first-app/08-ngFor/01.png)

### 09. Angular services

[Angular services](https://angular.dev/tutorials/first-app/09-services)

1. `$> ng generate service housing --skip-tests`
1. Copy `houseLocationList` to `housing.service.ts`
1. `inject` `HousingService` into `HomeComponent` `constructor`

### 10. Add routes to the application

[Add routes to the application](https://angular.dev/tutorials/first-app/10-routing)

#### DetailsComponent

1. `$> ng generate component details`

#### Routing

##### routes.ts

1. Create `src/app/routes.ts` file.
