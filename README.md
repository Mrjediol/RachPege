# Gilwing

## Mecenazgo y donaciones descentralizadas

![logo](./src/assets/Gilwing1.png)

---

### Índice

- [Introducción](#introducción)

  - [Datos del proyecto](#datos)
  - [Descripción del proyecto](#descripción-del-proyecto)
  - [Objetivos](#objetivos)
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

Antes de empezar a usar la aplicación recomendamos usar esta guia para la instalación y configuración de Metamask:

#### [Como usar Metamask con Gilwing](./doc/howToUse/howToUse.md)

## Introducción

---

### Datos

---
> Título: Gilwing
> Alumno: Víctor Porlan Soto
> Cíclo: DAW DUAL
> Fecha de entrega: 08/06/2022
> [Despliegue del proyecto](https://gilwing.ddns.net)
Este proyecto se trata de mi proyecto final de grado de Desarrollo de Aplicaciones Web DUAL, y es una aplicación basada en Ethereum y en la blockchain para realizar donaciones totalmente transparentes y visibles para cualquier usuario que desee ver en qué se está usando el dinero que ha donado.

Este proyecto surje por dos motivos, el primero siendo el evidente incremento en el interés en todo este tipo de tecnologías descentralizadas y por el rumbo hacia la descentralización que está tomando la web, y el otro motivo se trata de nuestro tutor [David Gelpi](https://github.com/dfleta), el cual comentó que aún no habia visto ningún proyecto con esta temática. Al oír esto sentí bastante curiosidad y que era un desafío lo suficientemente interesante para el proyecto final.

### Descripción del proyecto

---

El objetivo de Gilwing es conseguir una plataforma de mecenazgo y donaciones totalmente descentralizada y tansparente, dando la posibilidad a cualquier usuario de ver las transacciones que ha realizado un proyecto y las donaciones que ha recibido. A la hora de crear un proyecto se pide un título, una descripción y un mínimo de donaciones en Wei.

En la página de detalles de una campaña los usuarios podrán ver los donantes y las transacciones realizadas, además de la cantidad de ether almacenado en el smart contract seleccionado. El mánager de la campaña verá una pestaña de transacciones en la que podrá enviar dinero dando una descripción y la dirección del receptor.

Un usuario normal verá una pestaña de donaciones en la cual podrá dar un nombre y poner un comentario a la donación. En el caso de que no se rellenen estos campos aparecerá como "Anon" y con el comentario: "Sin comentario". Si deseas donar por segunda vez con la misma dirección, se usará tu perfil de donante que se creó en la primera donación, haciendo que aparezca junto a las otras donaciones realizadas bajo esa dirección.

### Objetivos

---

#### Objetivos de software

Con Gilwing buscamos el poder hacer una plataforma de donaciones honesta y transparente, donde los dueños de las campañas se verán obligados a mostrar en todo momento de cuánto dinero disponen en la campaña y las transacciones realizadas.

Almacenando el dinero en el smart contract en lugar de en su cuenta podemos mantener un seguimiento de lo que se realiza con el dinero de las donaciones en todo momento, de esta forma la gente se sentirá mas tranquila a la hora de donar.

#### Objetivos personales

Con este proyecto pretendo mostrar las utilidades que aporta la web descentralizada y la web 3. La bnlockchain ofrece una gran transparencia y una seguridad muy robusta, ya que la capacidad computacional requerida para "hackearla" es cada vez más y más grande.

### Tecnologías

---

#### React

- Es el framework (o librería) principal utilizada para el frontend. Por lo general es uno de los frameworks más utilizados por mi parte y con el que mejor me manejo. Considero que los hooks aportan una gran utilidad cuando aprendes a utilizarlos, y la responsividad es una característica básica en cualquier frontend actualmente.

#### Extras de react

- React router (generación de rutas), Material ui (librería de diseño y componentes de react).