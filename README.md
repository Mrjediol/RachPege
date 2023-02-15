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
  
- [Armas](#Armas)

- [Resultados y conclusiones](#resultados-y-conclusiones)

- [Bibliografía](#bibliografía)


## Introducción

---

### Datos

---
> Título: RatchPege

> Alumno: Jeremy Díaz Olivares

> Curso: Creacion Videojuegos con Unity3D

> Fecha de entrega: 07/03/2023

> [RatchPege](https://gilwing.ddns.net)

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

## Tecnologías

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

#### Clockify

- Para la gestión del tiempo.


## Armas

---

- **Sword**: Ataque Melee que viene por defecto desbloqueado. Su daño escala con el nivel del personaje.

![Landing_pro](./png/void.png)

- **FireGun**: Arma a distancia que dispara un proyectil de fuego que puede quemar a los enemigos con cierta probabilidad, el daño, tamaño, velocidad de proyectil, cooldown. etc escalan con el nivel del arma. 

![Landing_pro](./png/void.png)

- **IceGun**: Arma a distancia que dispara un proyectil de hielo que puede congelar a los enemigos con cierta probabilidad, el daño, tamaño, velocidad de proyectil, cooldown. etc escalan con el nivel del arma. 

![Landing_pro](./png/void.png)

- **RayGun**: Arma a distancia que dispara un proyectil que teletransporta al player a la ubicaciones en la que se destruye, por cada enemigo que atraviese reinicia su duración y hace que llegue mas lejos, haciendo mas daño a cada enemigo y ganando mas experiencia por cada enemigo golpeado.

![Landing_pro](./png/void.png)

- **BlastGun**: Arma que crea una explosion en la posición del raton.


![Landing_pro](./png/void.png)

- **VoidGun**: Arma a distancia que instancia un proyectil en la posicion del mouse, el daño, tamaño, cooldown. etc escalan con el nivel del arma. 
![Landing_pro](./png/void.png)

- **AniquilitationGun**: Página inicial donde podremos encontrar las campañas y tendremos acceso a un buscador directo de las mismas.

![Landing_pro](./png/void.png)




## Resultados y conclusiones

---

Por lo general puedo decir que el proyecto ha resultado ser aproximadamente lo que esperaba. En general la cantidad de funcionalidades estimadas para el proyecto fueron las que al final se realizaron, habiendo algunas que se plantearon como posibles en el caso de que el tiempo fuera más que suficiente, las cuales finalmente se han descartado, como por ejemplo un sistema de votaciones para aceptar o denegar las transacciones, un sistema de devolución del dinero, y también algun sistema de recompensas automatizado.

Las únicas cosas que variaron de la visión inicial fue, por ejemplo, el sistema de perfiles de donaciones, el cual inicialmente ni se planteó, pero a medida que se diseñaba el smart contract vi que facilitaría mucho el sistema de donar varias veces con una misma cuenta.

Otro sistema que no plantee en un principio fue el de almacenamiento de Mis campañas y Mis donaciones ya que no se me ocurría una buena forma de hacerlo, pero durante el desarrollo me di cuenta de que podía utilizar la propia factory para almacenar las campañas que se requería, ya que actuaba como punto común entre todas las campañas.

En un futuro, como he mencionado antes se podrían añadir las funcionalidades de recompensas, votaciones y de devolución de ether. También una posible mejora a la personalización de las campañas, permitiendote modificar el título y descripción. Se podría añadir incluso una forma de subir imágenes a la campaña con el uso de urls, ya que en la blockchain no es recomendable el almacenamiento de imágenes.

## Bibliografía

- [ChatGpt](https://chat.openai.com/chat)

- [Stackoverflow](https://stackoverflow.co/)

- [Mui](https://mui.com/)
  