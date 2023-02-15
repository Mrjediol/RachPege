# RatchPege

## TopDown Rpg

<!-- ![logo](./src/assets/Gilwing1.png) -->

---

### Índice

- [Introducción](#introducción)

  - [Datos del proyecto](#datos)
  - [Descripción del proyecto](#descripción-del-proyecto)
  - [Objetivos personales](#Objetivos-personales)
  - [Tecnologías](#tecnologías)
  
- [Desarrollo](#desarrollo)
  
  - [Planificación](#planificación)

    - [Gantt](#gantt)
    - [Distribución del tiempo](#distribución-del-tiempo)

  - [Análisis previo](#análisis-previo)

    - [Historias de usuario](#historias-de-usuario)
    - [Modelo de datos](#modelo-de-datos)
    - [Wireframes](#wireframes)

  - [Proceso de implementación](#proceso-de-implementación)

    - [Fases](#fases)
    - [Problemas](#problemas)
    - [Metodologías](#metodologías)

  - [Producción](#producción)
  
    - [Resultado final](#resultado-final)
    - [Despliegue](#despliegue)

  - [Resultados y conclusiones](#resultados-y-conclusiones)

  - [Bibliografía](#bibliografía)


## Introducción

---

### Datos

---
> Título: RachPege
> Alumno: Jeremy Díaz Olivares
> Curso: Creacion Videojuegos con Unity3D
> Fecha de entrega: 07/03/2023
> [RachPege](https://gilwing.ddns.net)

Este proyecto se trata de mi proyecto final del curso de creación videojuegos con Unity3D, es un juego Rpg, con vista TopDown, en el que matas enemigos con un amplio catálogo de armas que también pueden de nivel.

Este proyecto surge por unir varios conceptos que me gustan mucho, como lo son los Rpgs, tener una gran cantidad de arsenal de armas (idea inspirada en la saga "Ratchet and Clank"), y el grindeo/farmeo de niveles.

Es mi primer juego, y ha sido realizado en un plazo de unos 2 meses, asi que todo esto es una exploración de conceptos y ejercicios para aprender.


### Descripción del proyecto

---

El objetivo de RatchPege es subir de nivel tanto el personaje como las armas, para ser lo suficientemente fuerte para matar al boss de cada zona y pasar a la siguiente, hasta que llegas al Boss final y al matarlo te has pasado el juego!, dando la posibilidad de que cada persona tenga sus propias estrategias de grindeo/farmeo, usando las combinaciones de armas que mas le gusten.

La idea del sistema de grindeo/farmeo, es la siguiente. Zonas amplias con muchos grupos de enemigos separados entre sí, grupos de enemigos, que al matar al último de cada grupo, se iniciará un contador de reaparición para ese grupo de enemigos. Cada zona tendrá diferentes disposiciones, tipos y cantidades de enemigos. 

Está pensado para que el jugador se haga su propia ruta de farmeo, dependiendo de lo rápido que mate a los grupos de enemigo de cada zona con su estrategia, de modo que su ruta termine donde empezó, y que al llegar al inicio, el primer grupo de enemigos ya haya reaparecido y pueda realizar esa ruta en Loop como método de farmeo.


#### Objetivos personales

Con este proyecto pretendo aprender y desarrollar mis habilidades para la creación de videojuegos en Unity, y aprender programación en C#.

### Tecnologías

---

#### Unity

- El motor de videojuegos multiplataformas que he usado para crear el juego.

#### C#

- El lenguaje de programación usado para programar todo el juego.

#### Aseprite

- Para la creación y edición de algunos de los Sprites usados en el juego.

#### Notion

- Para la gestión del proyecto y para tomar notas.

#### Github

- Para el control de versiones del proyecto.

## Desarrollo

---

### Planificación

---

### Gantt

---

![Gantt](./doc/readmePics/Gantt.png)

Esta fue la planificación inicial del tiempo que se estimó antes de empezar el desarrollo de la aplicación. Ha resultado ser bastante acertado en la distribución del tiempo como veremos más adelante. Algo a destacar es que se optó por eliminar la parte de un diseño de Gateways ya que se consideró innecesario para la estructura de la aplicación. Si se hubiera optado por el uso de una api si que hubiera sido garantizada la implementación de esta parte del proyecto.

### Distribución del tiempo

---

![Clockify](./doc/timeTrack/clockify.png)

Como he mencionado antes, la distribución del tiempo ha sido bastante acertada cuando la comparamos con el diagrama de Gantt, yendo gran parte del tiempo al diseño del frontend y a la funcionalidad del mismo. Una parte que se me olvidó incluir en el diagrama de Gantt fue el tiempo de despliegue, el cual fue bastante simple y rápido, asi que incluso se podría añadir en la parte de frontend.

### Análisis previo

---

### Historias de usuario

#### Crear una campaña

Primero, vamos a ver el proceso que seguría una persona que decide CREAR una campaña.

Accedemos al formulario de creación de campaña, en el que nos pedirán un título, una descripción y un mínimo en Wei (1 ethereum son 1,000,000,000,000,000,000 wei).

![Crear](./doc/readmePics/Crear_HU.png)

Una vez creada le redirige a su campaña, y en cualquier momento podrá acceder a esta desde la sección de "Mis campañas".

![Camp](./doc/readmePics/Campañas_HU.png)

Una vez haya creado su campaña podrá acceder a esta para usar el formulario de transacciones. En este tendrá que aportar una descripción, una dirección (address del usuario en la blockchain) para el envío y la cantidad a enviar.

![Transac](./doc/readmePics/Transacción_HU.png)

#### Donar a una campaña

Por último tenemos la historia de usuario de un donante.

Para encontrar campañas el usuario puede acceder a la landing page, donde encontrará diferentes campañas de muestra, y también podrá usar un buscador para encontrar campañas directas las cuales ya conozca.

![Landing](./doc/readmePics/Landing_HU.png)

Al seleccionar una campaña tendremos la opción de donar, mediante un formulario que nos pide un nombre, un comentario y una cantidad para donar. En el caso de que el nombre se deje vacío aparecerá como "Anon" y si no pone comentario aparecerá "Sin comentario".

![Donar](./doc/readmePics/PrimeraDon_HUpng.png)

Si el usuario así lo quiere podrá volver a donar a la misma campaña. Se recordará el perfil del donante a la hora de donar y se guardará la donación en la misma card que la otra donación bajo el mismo perfil.

![Donar](./doc/readmePics/DonarOtraVez_HU.png)

### Modelo de datos

---

![Modelo](./doc/readmePics/ModeloDeDatos.png)


### Wireframes

---

Aqui voy a mostrar los diseños iniciales que se crearon para la aplicación de las páginas principales, junto al diseño final que se ha hecho. Faltan algunos diseños de páginas que era muy simples, como por ejemplo un formulario de creación o una lista de campañas, las cuales no consideré necesarias diseñarles un wireframe por su simplicidad.

#### Landing page

![Landing_wire](./doc/wireframe/Landing_Page.png)

![Landing_final](./doc/wireframe/FinalLanding.png)

Como podemos comprobar se acabó optando por un diseño más funcional, el cual muestra una lista de campañas creadas para hacer que la página inicial sea más práctica y no tan solo informativa.

#### Detalles de campaña

![Details_wire](./doc/wireframe/Campaña_donaciones.png)

![Details_final](./doc/wireframe/DetailsCampaña.png)

En un pricipio se planteó el uso de una librería de generación aleatoria de fotos de perfil, las cuales se generarían en base a la address del usuario, pero sentí que rompería con la estética de la aplicación en gran medida, ya que algunos rompían la paleta de colores utilizada en la web. Las cards también crecieron en tamaño por el sistema de perfiles que se implementó en la aplicación durante el desarrollo.

### Proceso de implementación

---

#### Fases

---

- **Smart contracts**: El desarrollo de la aplicación empezó creando los dos smart contracts de la aplicación, Factory y Campaign. La Factory es simplemente un intermediario entre el usuario y la creación de las campañas para mantener el proceso bajo control, y en Campaign encontramos toda la lógica básica de la aplicación.

- **Testing**: En esta fase se hizo el testeo de las funciones básicas de los smart contracts.

- **Diseño de wireframes**: Durante esta fase se hicieron los wireframes y se encargó el logo de la aplicación.

- **Frontend**: Basándose en los wireframes anteriormente diseñados, se hizo un frontend reactivo con una paleta de colores homogénea y sin demasiados colores, optando por un tema oscuro y agradable a la vista. Durante esta fase también se hizo la unión entre el frontend y la blockchain, la cual se especuló en el anteproyecto que se haría con unos Gateways, pero esta idea fue finalmente descartada.

- **Despliegue**: Usando un servidor cloud de Ionos, se desplegó la aplicación utilizando Apache, y para poder utilizar **https** se utilizó un bot de generación de certificados SSL válidos llamado Certbot. (Recomendado por [Alejo Morell](https://github.com/Yukics))

#### Problemas

---

- **Webpack 5 y Web3**: Durante la implementación de la lógica del proyecto en el frontend usando web3 hubo un problema de compatibilidad de web3 con la última version de webpack, ya que eliminaron los polyfills de esta. La solución fue bajar la versión de react scripts a la versión 4 con un comando encontrado en un foro.

#### Metodologías

---

- **En cascada**: El desarrollo del proyecto fue en cascada, intentando obtener un producto mínimo en cada etapa del desarrollo antes de intentar pasar a la siguiente.

### Producción

---

#### Resultado final

---

- **Landing page**: Página inicial donde podremos encontrar las campañas y tendremos acceso a un buscador directo de las mismas.

![Landing_pro](./doc/readmePics/Main_ss.png)

- **Crear**: Formulario para crear una campaña, nos pedirán un título, una descripción y una cantidad mínima de donaciones para la campaña.

![Landing_pro](./doc/readmePics/Crear_ss.png)

- **Mis campañas**: Lista de las campañas que has creado y de las que eres mánager.

![Landing_pro](./doc/readmePics/MisCampañas_ss.png)

- **Mis donaciones**: Lista de las campañas a las que has donado.

![Landing_pro](./doc/readmePics/MisDonaciones_ss.png)

- **Campaign**: La página de detalles de la campaña donde prodrás ver las donaciones recibidas y las transacciones realizadas. Dependiendo de si eres el mánager o no, a la derecha aparecerá un formulario para donar o para hacer una transacción.

![Landing_pro](./doc/readmePics/MisCampañas_ss.png)

#### Despliegue

---

Con un servidor web cloud en IONOS se ha desplegado la aplicación utilizando Apache. Se generó una versión de producción en el servidor de la aplicación de react y se puso como directorio base en el archivo de configuración de apache.

Luego, usando Certbot se generó un certificado SSL para poder utilizar el protocolo **https**, principalmente para poder ser usado desde el navegador de Metamask en moviles, el cual solo acepta este protocolo por motivos de seguridad.

### Resultados y conclusiones

---

Por lo general puedo decir que el proyecto ha resultado ser aproximadamente lo que esperaba. En general la cantidad de funcionalidades estimadas para el proyecto fueron las que al final se realizaron, habiendo algunas que se plantearon como posibles en el caso de que el tiempo fuera más que suficiente, las cuales finalmente se han descartado, como por ejemplo un sistema de votaciones para aceptar o denegar las transacciones, un sistema de devolución del dinero, y también algun sistema de recompensas automatizado.

Las únicas cosas que variaron de la visión inicial fue, por ejemplo, el sistema de perfiles de donaciones, el cual inicialmente ni se planteó, pero a medida que se diseñaba el smart contract vi que facilitaría mucho el sistema de donar varias veces con una misma cuenta.

Otro sistema que no plantee en un principio fue el de almacenamiento de Mis campañas y Mis donaciones ya que no se me ocurría una buena forma de hacerlo, pero durante el desarrollo me di cuenta de que podía utilizar la propia factory para almacenar las campañas que se requería, ya que actuaba como punto común entre todas las campañas.

En un futuro, como he mencionado antes se podrían añadir las funcionalidades de recompensas, votaciones y de devolución de ether. También una posible mejora a la personalización de las campañas, permitiendote modificar el título y descripción. Se podría añadir incluso una forma de subir imágenes a la campaña con el uso de urls, ya que en la blockchain no es recomendable el almacenamiento de imágenes.

### Bibliografía

- [Ethereum and Solidity: The Complete Developer's Guide](https://www.udemy.com/course/ethereum-and-solidity-the-complete-developers-guide/)

- [Stackoverflow](https://stackoverflow.co/)

- [Mui](https://mui.com/)
  