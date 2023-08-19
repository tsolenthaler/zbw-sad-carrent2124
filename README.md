# CarRent

## 1. C4 Model

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

    Container_Boundary(CarRent, "CarRent", "") {
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
    Rel(api, database, "CRU(D)")
    Rel(api, MailSystem, "send E-Mail")

    UpdateLayoutConfig($c4ShapeInRow="2", $c4BoundaryInRow="1")
```

### 1.3. - Compontents
```mermaid
C4Component
    Container(webapp, "Web Application", "", "")

    Boundary(api, "") {
        Component(car, "Car Controller", "Component API", "Car Controller")
        Component(customer, "Customer Controller", "Component API", "Customer Controller")
        Component(reservation, "Reservation Controller", "Component API", "Reservation Controller")
        Component(contract, "Contract Controller", "Component API", "Contract Controller")
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



### 1.4. - Classes

## 2. Use Cases

## 3. Domain Model

## 4. Deployment View

## 5. Logical View

## 6. Implementation 

## 6.1. - Continuous Integration 

## 6.2. - Metriken

## 6.3. - Dokumentation arc42