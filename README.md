# CarRent

Mini-Projekt SAD

## 1.  Arbeitspaket - C4 Model

### 1.1. - Context
```mermaid
C4Context
    Person(Sachbearbeiter, "Sachbearbeiter")
    Person(Kunde, "Kunde")

    Boundary(b1, "", "") {
        System(CarRent, "CarRent", "Software System")
    }

    Rel(Sachbearbeiter, CarRent, "Manage all")
    Rel(Kunde, CarRent, "Read and Search")

    UpdateLayoutConfig($c4ShapeInRow="3", $c4BoundaryInRow="1")
```

### 1.2. - Containers
```mermaid
C4Container
    Person(Sachbearbeiter, "Sachbearbeiter")
    Person(Kunde, "Kunde")

    Boundary(CarRent, "", "") {
        Container(webapp, "Web Application", "", "")
        Container(api, "API", "", "Provides CarRent functionality via API")
        ContainerDb(database, "Database", "SQL", "Stores user, cars, Car classes, Reservations and Rental contracts")
    }

    Rel(Sachbearbeiter, webapp, "HTTPS")
    Rel(Kunde, webapp, "HTTPS")
    Rel(webapp, api, "Requests")
    Rel(api, database, "CRUD")

    UpdateLayoutConfig($c4ShapeInRow="2", $c4BoundaryInRow="1")
```

### 1.3. - Compontents
```mermaid
C4Component
    Container(webapp, "Web Application", "", "")

    Boundary(api, "", "") {
        Component(CarController, "CarController", "Component API", "Car Controller")
        Component(CustomerController, "CustomerController", "Component API", "Customer Controller")
        Component(ReservationController, "ReservationController", "Component API", "Reservation Controller")
        Component(ContractController, "ContractController", "Component API", "Contract Controller")
        Component(CarRepository, "CarRepository", "Component Repository", "Car Repository")
        Component(CustomerRepository, "CustomerRepository", "Component Repository", "Customer Repository")
        Component(ReservationRepository, "ReservationRepository", "Component Repository", "Reservation Repository")
        Component(ContractRepository, "ContractRepository", "Component Repository", "Contract Repository")
    }

    Boundary(b2, "", "") {
        ContainerDb(db, "Database", "Contianer: SQL Server Express", "Stores Car, Customer, Reservation and Contract")
    }

    Rel(webapp, CarController, "Car", "JSON/HTTPS")
    Rel(webapp, CustomerController, "Customer", "JSON/HTTPS")
    Rel(webapp, ReservationController, "Reservation", "JSON/HTTPS")
    Rel(webapp, ContractController, "Contract", "JSON/HTTPS")

    Rel(CarController, CarRepository, "", "")
    Rel(CustomerController, CustomerRepository, "", "")
    Rel(ReservationController, ReservationRepository, "", "")
    Rel(ContractController, ContractRepository, "", "")

    Rel(CarRepository, db, "Car", "CRUD")
    Rel(CustomerRepository, db, "Customer", "CRUD")
    Rel(ReservationRepository, db, "Reservation", "CRUD")
    Rel(ContractRepository, db, "Contract", "CRUD")

    UpdateLayoutConfig($c4ShapeInRow="4", $c4BoundaryInRow="1")
```

## 2.  Arbeitspaket – Domain Model und Use Cases

### 2.1 Domain Model

```mermaid
classDiagram
class Customer{
    ChstomerNr
    Name
    Address
}

class Reservation{
    ReservationNr
    StartDate
    endDate
    TotalCost
}

class RentalContract{
    ContractNr
}

class Car{
    CarNr
}

class Model{
    Name
}

class Brand{
    Name
}

class Category {
    DailyFee
}

class Luxury
class Midrange
class Economy

Customer "1" --> "0..*" Reservation : has
Reservation "1" --> "0..1" RentalContract : converted
Reservation "1" --> "1" Category : choose
RentalContract "*" --> "1" Car : associated
Car "1" --> "1" Brand : has
Car "1" --> "1" Model : has
Car "*" --> "1" Category : assigned
Luxury --|> Category
Midrange --|> Category
Economy --|> Category
```

### 2.2 Use Cases
| Nr     | Case                 | Actor          | Beschreibung                                                                                               |
| ------ | ----------------     | -------------- | ----------------------------------------------------------------------------------------------------------- |
| UC1 | Kunden verwalten     | Sachbearbeiter | Nach Kunden mit Namen und Adresse und Kundennummer im System verwalten (erfassen, bearbeiten, löschen).     |
| UC2 | Kunden suchen        | Sachbearbeiter | Nach Kunden mit dessen Namen oder Kundennummer suchen.                                                      |
| UC3 | Autos verwalten      | Sachbearbeiter | Kann Autos verwalten und suchen.                                                                            |
| UC4 | Autoklasse verwalten | Sachbearbeiter | Ein Auto einer bestimmten Klasse zuordnen und die Tagesgebür pro Klasse setzen.                          |
| UC5 | Reservation tätigen  | Kunde          | Der Kunde kann eine Reservation tätigen mit einem Auto aus einer bestimmten Klasse und die Anzahl Tage angeben. |
| UC6 | Reservation zu Mietvertrag umwandeln | Kunde    | Kunde holt sein reserviertes Auto ab. Die Reservation wird zu einen Mietvertrag umgewandelt.          |

## 3.Arbeitspaket – 4+1 Views

### 3.1 Deployment View
```mermaid
flowchart LR
    subgraph Client Tier
        subgraph Browser
        end
    end
    subgraph Application Tier
        subgraph IISExpress
        end
        subgraph API
        end
    end
    subgraph Data Tier
        subgraph MSSQL
        end
    end

    Browser -->|HTTP| IISExpress
    IISExpress --> API
    API -->|SQL| MSSQL
```

### 3.2 Logical View


## 4. Arbeitspaket – Implementierung

## 5. Arbeitspaket – Continuous Integration und Metriken

### 5.1 Continuous Integration

CI/CD: [GitHub Action](https://github.com/tsolenthaler/zbw-sad-carrent2124/actions)

### 5.2. Metriken

Metriken: [Sonarcloud](https://sonarcloud.io/summary/new_code?id=tsolenthaler_zbw-sad-carrent2124)

## 6. Arbeitspaket – Dokumentation (nach arc42)

Dokumentation gemäss folgenden Template [arc42](https://www.arc42.de/overview/)

01. [Introduction and Goals](./docs/01_introduction_and_goals.md)
02. [Architecture Constraints](./docs/02_architecture_constraints.md)
03. [System Scope and Context](./docs/03_system_scope_and_context.md)
04. [Solution Strategy](./docs/04_solution_strategy.md)
05. [Building block](./docs/05_building_block_view.md)
06. [Runtime View](./docs/06_runtime_view.md)
07. [Deployment View](./docs/07_deployment_view.md)
08. [Conepts](./docs/08_concepts.md)
09. [Architecture decisions](./docs/09_architecture_decisions.md)
10. [Quality Requirements](./docs/10_quality_requirements.md)
11. [Technical risks](./docs/11_technical_risks.md)
12. [Glossary](./docs/12_glossary.md)