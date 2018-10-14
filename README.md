# BackTest
Prueba de proyecto back-end

## Instrucciones

- clonar el  repositorio
- compilar la  solución
- en laspropiedades del proyecto **WebApiTest** estableccer la URL como: http://localhost:61406/
- ejecutar la solución (se despliega en IIS Express)
- desde POSTMAN rrealizar las siguientes llamadas:

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
	"City": "ciudad"
}
```

### Borrar un estudiante (DELETE)
http://localhost:61406/api/student/2


### modificar un estudiante (PUT)
http://localhost:61406/api/student
```
{
	"Id": "1",
	"LastName": "apellidos  cambiados",
	"FirstName": "nombre modificado",
	"City": "otra ciudad"
}
```
