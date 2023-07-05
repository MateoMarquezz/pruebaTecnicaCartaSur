
// boton para agregar empleado
document.getElementById('btn-agregar').addEventListener('click', agregarEmpleado);

// funcion para agregar un nuevo empleado al listado de activos o inactivos
function agregarEmpleado() {
    const nombre = document.getElementById('nombre').value;
    const apellido = document.getElementById('apellido').value;
    const estado = document.getElementById('estado').value;

    //verifica si esta el nombre y apellido y verifica si se encuentra activo o inactivo, se hizo uso de arrow functions 
    if (nombre || apellido) {
        const empleado = `<strong>${nombre} ${apellido}</strong> - Estado: ${estado}`; //agrega al empleado nuevo 
        const listaEmpleados = (estado === 'activo') ? 'lista-empleados-activos' : 'lista-empleados-inactivos'; //se verifica el estado del empleado para agregarlo 
        const nuevoLi = document.createElement('li'); //crea el elemento de lista donde estara el empleado

        nuevoLi.innerHTML = empleado + ' <button onclick="cambiarEstadoEmpleado(this.parentNode, \'' + estado + '\')">Cambiar Estado</button>'+ ' <button onclick="eliminarEmpleado(this.parentNode)" id="botonEliminar" class="fas fa-trash de"></button>'; // agrega al empleado con los dos botones 
        
        
        document.getElementById(listaEmpleados).appendChild(nuevoLi); // agrega el li a la lista de empleados segun corresponda 
        // limpia campos del formulario vacia el formulario una vez se carga un usuario 

        document.getElementById('nombre').value = '';
        document.getElementById('apellido').value = '';

    }
}
function eliminarEmpleado(li) { // funcion para eliminar un empleado 
    const empleado = li.innerText.split(' - ')[0];
    const estado = empleado.includes('Activo') ? 'activo' : 'inactivo';
    const listaEmpleados = (estado === 'activo') ? 'lista-empleados-activos' : 'lista-empleados-inactivos';
    li.parentNode.removeChild(li);
}
        

// función para cambiar el estado de un empleado de activo a inactivo y viceversa
function cambiarEstadoEmpleado(li, estado) {
    const empleado = li.innerText.split(' - ')[0]; // obtenemos los datos del empleado, con el split dividimos en dos 

    // elimina el empleado del listado actual
    li.parentNode.removeChild(li);

    // crea el nuevo elemento con el estado cambiado 
    const nuevoEstado = (estado === 'activo') ? 'inactivo' : 'activo'; //verifica cual era el estado 
    const nuevoListaEmpleados = (nuevoEstado === 'activo') ? 'lista-empleados-activos' : 'lista-empleados-inactivos'; // se agrega a su lista correspondiente segun el estado
    const nuevoLi = document.createElement('li'); // se crea el nuevo li para el empleado
    nuevoLi.innerHTML = `<strong>${empleado}</strong> - Estado: ${nuevoEstado} <button onclick="cambiarEstadoEmpleado(this.parentNode, '${nuevoEstado}')">Cambiar Estado</button>`+ ' <button onclick="eliminarEmpleado(this.parentNode)" id="botonEliminar" class="fas fa-trash de"></button>'; // se agrega el texto con los datos mas el boton para el empleado cuando hay cambio de estado, se repite lo de arriba 

    // agregamos el nuevo elemento al listado correspondiente
    document.getElementById(nuevoListaEmpleados).appendChild(nuevoLi);
}


//consumo de api con fetch 
const apiUrl = 'https://svct.cartasur.com.ar/api/dummy';

function estadoApi() {
    fetch(apiUrl)
    .then(response => {
        return response.text(); // pasamos la respuesta a texto puesto que no es json
    })
    .then(data => {
    //console.log(data) //para verificar en consola 
        if (data.includes('UP')) { // se verifica si el texto es "up"
            document.getElementById('status').textContent = 'La api conecto correctamente y su estado es "UP"';
            }
            else {document.getElementById('status').textContent = 'Hubo un error la api no conecto correctamente'; }
    })
}
//llamar a la función para obtener el estado de la API al cargar la página
estadoApi();



//fetch("https://svct.cartasur.com.ar/api/dummy")
//.then(res => console.log(res));
