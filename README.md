
![Banner del Sistema de Turnos](./img/turnos.jpg)

# Sistema de Turnos

## Descripción
Sistema de gestión de turnos permite asignar tickets a los usuarios, gestionar la atención en orden y mostrar la lista de atendidos ordenada alfabéticamente usando el algoritmo Counting Sort.

---

## Instalación de Git y conexión a GitHub

1. **Descargar e instalar Git:**
	 - Ve a [https://git-scm.com/downloads](https://git-scm.com/downloads) y descarga el instalador para tu sistema operativo.
	 - Sigue los pasos del instalador y verifica la instalación ejecutando en la terminal:
		 ```
		 git --version
		 ```

2. **Configurar Git y conectar a GitHub:**
	 - Configura tu nombre de usuario y correo:
		 ```
		 git config --global user.name "Tu Nombre"
		 git config --global user.email "tuemail@ejemplo.com"
		 ```
	 - Crea una cuenta en [GitHub](https://github.com/) si no tienes una.
	 - Genera una clave SSH y agrégala a tu cuenta de GitHub (opcional pero recomendado):
		 ```
		 ssh-keygen -t ed25519 -C "tuemail@ejemplo.com"
		 ```
	 - Sigue las instrucciones de GitHub para agregar tu clave SSH: [Guía oficial](https://docs.github.com/es/authentication/connecting-to-github-with-ssh)

---

## Configuración del entorno de trabajo en C#

1. Instala [.NET SDK](https://dotnet.microsoft.com/download) (recomendado .NET 8.0 o superior).
2. Instala un editor como [Visual Studio Code](https://code.visualstudio.com/) o [Visual Studio Community](https://visualstudio.microsoft.com/es/vs/community/).
3. (Opcional) Instala la extensión de C# para tu editor.

---

## Clonar el repositorio

```sh
git clone https://github.com/edwinquisbertm/Sistema-de-Gestion-de-Turnos.git
cd Sistema-de-Gestion-de-Turnos
```


---

## Cómo correr el proyecto

```sh
dotnet build
dotnet run
```

---

## Estructura y funcionamiento

```mermaid
stateDiagram
    direction LR
    [*] --> Inicio
    Inicio --> GenerarTickets
    GenerarTickets --> Encolar
    Encolar --> Atender
    Atender --> Registrar
    Registrar --> QuedanTurnos

    QuedanTurnos --> Atender: Sí
    QuedanTurnos --> Ordenar: No

    Ordenar --> MostrarLista
    MostrarLista --> [*]
```

---

## Autores

- Edwin Quisbert Montalvo
- Wilson Aguilar Lima
- David Jairo Vasquez Velarde

---

## Algoritmo de ordenamiento: Counting Sort

Para ordenar los nombres de los usuarios atendidos, se utiliza el algoritmo Counting Sort adaptado para cadenas de texto. Este método cuenta la frecuencia de cada carácter en cada posición del nombre (de derecha a izquierda) y reordena la lista de usuarios de manera eficiente, logrando un orden alfabético estable y rápido, especialmente útil cuando los nombres tienen longitud similar y el alfabeto es limitado.

---

## Posibles aplicaciones

- Gestión de turnos en bancos, hospitales, farmacias, oficinas públicas, etc.
- Sistemas de atención al cliente en empresas.
- Control de acceso y atención en eventos o instituciones educativas.
- Cualquier situación donde se requiera organizar la atención de personas en orden y registrar el historial de atención.

---