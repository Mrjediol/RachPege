<center>


# **RatchPege**
 <h1 align="center">RatchPege</h1>
 
### **TopDown Rpg**

 
![logo](./png/RachtPegeLogo.png) 

---

## **Índice**

---

</p>
</center>

- [Introducción](#introducción)

  - [Datos del proyecto](#datos)
  - [Descripción del proyecto](#descripción-del-proyecto)
  - [Tecnologías](#tecnologías)
  
- [ScreenShots](#screenshots)

- [Armas](#armas)

- [Resultados y conclusiones](#resultados-y-conclusiones)

- [Bibliografía](#bibliografía)

<center>

---

## **Introducción**

</center>

---

## Datos




> Título: RatchPege

> Alumno: Jeremy Díaz Olivares

> Curso: Creacion Videojuegos con Unity3D

> Fecha de entrega: 07/03/2023

> Web: [RatchPege.com](https://mrjediol.netlify.app/)

> Itch.io: [RatchPege.io](https://mrjediol16.itch.io/rachpege?secret=HYsQAgDSmXK0KOOoa30pDmBjRM)

> Trailer: [RatchPege](https://mrjediol.netlify.app/)


Este proyecto se trata de mi proyecto final del curso de creación videojuegos con Unity3D, es un juego Rpg, con vista TopDown, en el que matas enemigos con un amplio catálogo de armas que también pueden de nivel.

Este proyecto surge por unir varios conceptos que me gustan mucho, como lo son los Rpgs, tener una gran cantidad de arsenal de armas (idea inspirada en la saga "Ratchet and Clank"), y el grindeo/farmeo de niveles.

Es mi primer juego, y ha sido realizado en un plazo de unos 2 meses, asi que todo esto es una exploración de conceptos y ejercicios para aprender.

<center>

---

## **Descripción del proyecto**

</center>

---

El objetivo de RatchPege es subir de nivel tanto el personaje como las armas, al desbloquear cada arma puedes destruir la barrera de cada zona y pasar a la siguiente, hasta que llegas al Boss final y al matarlo te has pasado el juego!, dando la posibilidad de que cada persona tenga sus propias estrategias de grindeo/farmeo, usando las combinaciones de armas que mas le gusten.

La idea del sistema de grindeo/farmeo, es la siguiente. Zonas amplias con muchos grupos de enemigos separados entre sí, grupos de enemigos, que al matar al último de cada grupo, se iniciará un contador de reaparición para ese grupo de enemigos. Cada zona tendrá diferentes disposiciones, tipos y cantidades de enemigos. 

Está pensado para que el jugador se haga su propia ruta de farmeo, dependiendo de lo rápido que mate a los grupos de enemigo de cada zona con su estrategia, de modo que su ruta termine donde empezó, y que al llegar al inicio, el primer grupo de enemigos ya haya reaparecido y pueda realizar esa ruta en Loop como método de farmeo.


### Objetivos personales

Con este proyecto pretendo aprender y desarrollar mis habilidades para la creación de videojuegos en Unity, y aprender programación en C#.
<center>

---

## **Tecnologías**

</center>

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


<center>

---

## **ScreenShots**

</center>

---


<center>


![Imagen 4](./png/StartScreem.png)

![Imagen 1](./png/FightingSword.png)

![Imagen 5](./png/UnlockFire.png)

![Imagen 2](./png/firelimit.png)

![Imagen 3](./png/icelimit.png)

![Imagen 6](./png/pauseMenu.png)







---



</center>



<center>

## **Armas**

</center>

---

- **Sword**: Ataque Melee que viene por defecto desbloqueado. Su daño escala con el nivel del personaje.

---

<center>

**FireGun** 

</center>

Arma a distancia que dispara un proyectil de fuego que puede quemar a los enemigos con cierta probabilidad, el daño, tamaño, velocidad de proyectil, cooldown. etc escalan con el nivel del arma. 

<center>

| In Menu | In Game |
| :---: | :---: |
| ![Imagen 1](./png/fireMenu.png) | ![Imagen 2](./png/fireingame.png) |

---

</center>

<center>

**IceGun** 

</center>

Arma a distancia que dispara un proyectil de hielo que puede congelar a los enemigos con cierta probabilidad, el daño, tamaño, velocidad de proyectil, cooldown. etc escalan con el nivel del arma.

<center>

| In Menu | In Game |
| :---: | :---: |
| ![Imagen 1](./png/IceMenu.png) | ![Imagen 2](./png/IceInGame.png) |

---



**RayGun** 

</center>

Arma a distancia que dispara un proyectil que teletransporta al player a la ubicaciones en la que se destruye, por cada enemigo que atraviese reinicia su duración y hace que llegue mas lejos, haciendo mas daño a cada enemigo y ganando mas experiencia por cada enemigo golpeado.

<center>

| In Menu | In Game |
| :---: | :---: |
| ![Imagen 1](./png/RayGunMenu.png) | ![Imagen 2](./png/RayGunInGame.png) |

---

</center>


<center>

**Blast** 

</center>

Arma que crea una explosion en la posición del raton despues de 6.5 segundos, esta pensada para usarse junto a Vortex.

<center>

| In Menu | In Game |
| :---: | :---: |
| ![Imagen 1](./png/BlastMenu.png) | ![Imagen 2](./png/blastingame.png) |

---

</center>

<center>

**Vortex** 

</center>

Arma a distancia que instancia un proyectil en la posicion del mouse, el daño, tamaño, cooldown. etc escalan con el nivel del arma. 

<center>

| In Menu | In Game |
| :---: | :---: |
| ![Imagen 1](./png/VortexMenu.png) | ![Imagen 2](./png/voidingame.png) |

---

</center>


<center>

**Quilava** 

</center>

Arma que con 2 instancias, en la primera se decide la posición inicial del proyectil, y en la empieza una cadena de explosiones que van desde la posición de la primera instancia hasta la posición de la segunda. 

<center>

| In Menu | In Game |
| :---: | :---: |
| ![Imagen 1](./png/QuilavaMenu.png) | ![Imagen 2](./png/quilavaingame.png) |

---

</center>


<center>

## **Resultados y conclusiones**

</center>

---

Por lo general puedo decir que el proyecto ha resultado ser aproximadamente lo que esperaba. En general la cantidad de funcionalidades estimadas para el proyecto fueron las que al final se realizaron, habiendo algunas que se plantearon como posibles en el caso de que el tiempo fuera más que suficiente, las cuales finalmente se han descartado, como por ejemplo un sistema de votaciones para aceptar o denegar las transacciones, un sistema de devolución del dinero, y también algun sistema de recompensas automatizado.

Las únicas cosas que variaron de la visión inicial fue, por ejemplo, el sistema de perfiles de donaciones, el cual inicialmente ni se planteó, pero a medida que se diseñaba el smart contract vi que facilitaría mucho el sistema de donar varias veces con una misma cuenta.

Otro sistema que no plantee en un principio fue el de almacenamiento de Mis campañas y Mis donaciones ya que no se me ocurría una buena forma de hacerlo, pero durante el desarrollo me di cuenta de que podía utilizar la propia factory para almacenar las campañas que se requería, ya que actuaba como punto común entre todas las campañas.

En un futuro, como he mencionado antes se podrían añadir las funcionalidades de recompensas, votaciones y de devolución de ether. También una posible mejora a la personalización de las campañas, permitiendote modificar el título y descripción. Se podría añadir incluso una forma de subir imágenes a la campaña con el uso de urls, ya que en la blockchain no es recomendable el almacenamiento de imágenes.

<center>

---

## **Bibliografía**

---

</center>

- [ChatGpt](https://chat.openai.com/chat)

- [Stackoverflow](https://stackoverflow.co/)

- [Mui](https://mui.com/)
  
