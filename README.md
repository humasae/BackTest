# BackTest
Prueba de proyecto back-end

## Instrucciones

- clonar el  repositorio
- compilar la  solución
- en laspropiedades del proyecto **WebApiTest** estableccer la URL como: http://localhost:61406/
- ejecutar la solución (se despliega en IIS Express)
- desde POSTMAN realizar las siguientes llamadas:

## ASIGNATURAS

### Obtener todas las asignaturas (GET)
http://localhost:61406/api/subject

### Obtener una asignatura por ID (GET)
http://localhost:61406/api/subject/1

### Crear una asignatura (POST)
http://localhost:61406/api/subject/

```
{
	"Id": "1",
	"Name": "primera asignatura",
	"Professor": "nombre del profesor",
	"RoomNumber": "12"
}
```

### Borrar una asignatura (DELETE)
http://localhost:61406/api/subject/2


### modificar una asignatura (PUT)
http://localhost:61406/api/subject/1
```
{
	"Id": "1",
	"Name": "asignatura cambiada",
	"Professor": "nombre del profesor",
	"RoomNumber": "12"
}
```

## ESTUDIANTES

### Obtener todos los estudiantes (GET)
http://localhost:61406/api/student

### Obtener un estudiante por ID (GET)
http://localhost:61406/api/student/1


### Crear un estudiante (POST)
http://localhost:61406/api/student
```
{
	"Id": "1",
	"LastName": "apellido1 apellido 2",
	"FirstName": "nombre",
	"City": "ciudad",
	"SubjectId": "3"
}
```

### Borrar un estudiante (DELETE)
http://localhost:61406/api/student/2


### modificar un estudiante (PUT)
http://localhost:61406/api/student/1
```
{
	"Id": "1",
	"LastName": "apellidos  cambiados",
	"FirstName": "nombre modificado",
	"City": "otra ciudad",
	"SubjectId": "3"
}
```
