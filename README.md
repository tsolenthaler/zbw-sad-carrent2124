# CarRent

## 1.  Arbeitspaket 1 - C4 Model

### 1.1. - Context
```mermaid
C4Context
    Person(Sachbearbeiter, "Sachbearbeiter")
    Person(Kunde, "Kunde")

    Boundary(b1, "", "") {
        System(CarRent, "CarRent", "Software System")
    }

    Boundary(b2, "", "") {
        System_Ext(MailSystem, "E-Mail System", "Mail Service")
    }

    Rel(Sachbearbeiter, CarRent, "Manage all")
    Rel(Kunde, CarRent, "Read and Search")
    Rel(CarRent, MailSystem, "send E-Mail")

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
        ContainerDb(database, "Database", "Postgres", "Stores user, cars, Car classes, Reservations and Rental contracts")
    }

    Boundary(b2, "", "") {
        System_Ext(MailSystem, "E-Mail System", "Mail Service")
    }

    Rel(Sachbearbeiter, webapp, "HTTPS")
    Rel(Kunde, webapp, "HTTPS")
    Rel(webapp, api, "Requests")
    Rel(api, database, "CRUD")
    Rel(api, MailSystem, "send E-Mail")

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

        Component(car, "Car Repository", "Component API", "Car Controller")
    }

    Boundary(b2, "", "") {
        ContainerDb(db, "Database", "Contianer: Postgres", "Stores Car, Customer, Reservation and Contract")
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

## 2.  Arbeitspaket 2 – Domain Model und Use Cases

### 2.1 Domain Model / Klassen Diagramm

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

Customer "1" --> "0..n" Reservation : has
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
| Nr     | User           | Ziel                                                                                                        |
| ------ | -------------- | ----------------------------------------------------------------------------------------------------------- |
| UC-001 | Sachbearbeiter | Nach Kunden mit Namen und Adresse und Kundennummer im System verwalten (erfassen, bearbeiten, löschen).     |
| UC-002 | Sachbearbeiter | Nach Kunden mit dessen Namen oder Kundennummer suchen.                                                      |
| UC-003 | Sachbearbeiter | Kann Autos verwalten und suchen.                                                                            |
| UC-004 | Sachbearbeiter | Auto einer bestimmten Klasse zuordnen.                                                                      |
| UC-005 | Sachbearbeiter | Pro Klasse kann eine Tagesgebür gesetzt werden.                                                             |
| UC-006 | Kunde          | Kunde kann eine Reservation tätigen mit einem Auto aus einer bestimmten Klasse und die Anzahl Tage angeben. |
| UC-007 | Kunde          | Kunde holt sein reserviertes Auto ab. Die Reservation wird zu einen Mietvertrag umgewandelt.                |

## 3.Arbeitspaket 3 – 4+1 Views

### 3.1 Deployment View

### 3.2 Logical View

## 4. Arbeitspaket 4 – Implementierung

## 5. Arbeitspaket 5 – Continuous Integration und Metriken

### 5.1 Continuous Integration

### 5.2. Metriken

## 6. Arbeitspaket 6 – Dokumentation (nach arc42)