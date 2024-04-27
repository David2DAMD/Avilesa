TAREA DESINF 2º CUATRIMESTRE

2. INTRODUCCIÓN
La empresa de autobuses AVILESA necesita una aplicación que gestiones sus líneas de autobuses
entre municipios. Para ello, se necesita almacenar tanto origen como destino y el itinerario recorrido
junto con el intervalo de tiempo en horas y minutos que se tarda desde la salida.

4. TIPOS DE DATOS
De un modo general, la aplicación manejará los siguientes datos:

 Línea. En este objeto se recogen los datos de la línea. Requerirá la siguiente información:
o Número de línea. Un número entero a partir de 1 para identificar de forma única la
línea
o Municipio origen. Municipio del que sale el autobús. Tanto para este campo como
para el siguiente, se puede usar el csv de municipios de la anterior actividad o uno
reducido.
o Municipio destino. Municipio al que llega el autobús.
o Hora inicial de salida. La primera hora del día a la que sale el bus.
o Intervalo entre buses. Intervalo expresado en HH:MM desde que sale un bus hasta el
siguiente.

 Paradas. Recogerá los datos de las paradas que de las que consta el itinerario a realizar. Debe
incluir la siguiente información:
o Número de línea. Línea a la que se refiere el itinerario.
o Municipio. Municipio por el que para el bus en el itinerario.
o Intervalo desde la hora de salida. Intervalo expresado en HH:MM desde que sale el
bus para llegar a ese destino.
El itinerario debe recoger todas las paradas excepto la salida, incluyendo el destino para saber a qué
hora se llega. Por supuesto, el destino es el que debe tener el mayor intervalo desde la salida.

5. FUNCIONALIDAD .NET
Como ya se ha explicado antes, la aplicación será capaz de gestionar una empresa de autobuses.
Existirá una pantalla principal desde la que se podrán realizar las principales funcionalidades de la
aplicación. La aplicación debe desarrollarse en WPF con .NET.

2
4.1. GESTIÓN DE LÍNEAS
La aplicación permitirá dar de alta, baja, modificar y consultar líneas de autobús. Todos los
formularios estarán validados. Las líneas estarán registradas en la aplicación y se podrán persistir
en un CSV, aunque esto es opcional.

4.2. GESTIÓN DE ITINERARIOS
Se permitirá dar de alta, baja, modificar y consultar itinerarios. Al igual que en el apartado anterior,
se podrán registrar en un archivo CSV.

4.3. PERSISTENCIA DE DATOS
El sistema permitirá almacenar los datos en ficheros, serializando para ello la información contenida
en las estructuras de datos utilizadas. Al arrancar el sistema se cargará toda la información
almacenada en estos ficheros. El sistema guardará la información en dichos ficheros cuando el
usuario realice modificaciones en el sistema. 
