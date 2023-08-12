# CarRent

## 1. C4 Model

### 1.1. - Context
```mermaid
C4Context
    Person(Sachbearbeiter, "Sachbearbeiter")
     Person(Kunde, "Kunde")

    Boundary(b1, "System", "System") {
        System(CarRent, "CarRent", "Software System")
    }

    Boundary(b2, "Boundary2", "") {
        SystemDb(Database, "Database", "Container MSSQL")
        Container(github, "GitHub", "Component Git", "GitHub")
    }

    Rel(Sachbearbeiter, CarRent, "Change Reservation")
    Rel(Kunde, CarRent, "Add Reservation")
    Rel(CarRent, Database, "")
    Rel(CarRent, github, "")

    UpdateLayoutConfig($c4ShapeInRow="2", $c4BoundaryInRow="1")
```

### 1.2. - Containers
```mermaid
C4Container
    title Container diagram for CarRent

```

### 1.3. - Compontents

### 1.4. - Classes

## 2. Use Cases

## 3. Domain Model

## 4. Deployment View

## 5. Logical View

## 6. Implementation 

## 6.1. - Continuous Integration 

## 6.2. - Metriken

## 6.3. - Dokumentation arc42