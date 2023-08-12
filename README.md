# CarRent

## 1. C4 Model

### 1.1. - Context
```mermaid
C4Context
    title System Context diagram for CarRent

    Person(Sachbearbeiter, "Sachbearbeiter")
    Person(Kunde, "Kunde")


    System(CarRent, "CarRent", "Software System")


    SystemDb(Database, "Database", "Container MSSQL")
    Container(github, "GitHub", "Component Git", "GitHub")

    BiRel(Sachbearbeiter, CarRent, "Change Reservation")
    BiRel(Kunde, CarRent, "Add Reservation")
```

### Test

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