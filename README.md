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
        Component(car, "Car Controller", "Component API", "Car Controller")
        Component(customer, "Customer Controller", "Component API", "Customer Controller")
        Component(reservation, "Reservation Controller", "Component API", "Reservation Controller")
        Component(contract, "Contract Controller", "Component API", "Contract Controller")
    }

    Boundary(b2, "", "") {
        ContainerDb(db, "Database", "Contianer: SQL Server Express", "Stores Car, Customer, Reservation and Contract")
    }

    Rel(webapp, car, "Car", "JSON/HTTPS")
    Rel(webapp, customer, "Customer", "JSON/HTTPS")
    Rel(webapp, reservation, "Reservation", "JSON/HTTPS")
    Rel(webapp, contract, "Contract", "JSON/HTTPS")

    Rel(car, db, "Car", "CRUD")
    Rel(customer, db, "Customer", "CRUD")
    Rel(reservation, db, "Reservation", "CRUD")
    Rel(contract, db, "Contract", "CRUD")

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

CI/CD - [GitHub Action](https://github.com/tsolenthaler/zbw-sad-carrent2124/actions)

### 5.2. Metriken

Metriken - 

## 6. Arbeitspaket – Dokumentation (nach arc42)