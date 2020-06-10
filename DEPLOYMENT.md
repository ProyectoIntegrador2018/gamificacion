Misiones de mantenimiento
==========

- [Deployment](#deployment)
  - [Windows](#windows)
  - [macOS](#macos)
  - [Unity](#unity)
    - [Folders Containing Scenes](#folders-containing-scenes)
    - [Build Settings](#build-settings)


Windows
-------
Open the link at the bottom, and download the .zip file called “ProyectoDeGamificacion”, and unzip it, after unzipping it there should an .exe called “ProyectoIntegrador2.0”, run this program and that's the game with all the folders needed to play the latest version.
https://drive.google.com/drive/folders/1aP7QBDTwp58Ct18PvFNq4ans-q_YkC5d?usp=sharing

macOS
-------
Open the link at the bottom, and download the .zip file called “MisionesDeMantenimiento.zip”, and unzip it. After unzipping it there should an .app called “Misiones de mantenimiento”, run this application and that's the game with all the folders needed to play the latest version.
https://drive.google.com/drive/folders/1L6qkcO34Dmtm9hm9MM0NWsYWmhVz5D99

Unity
-------
Make sure you have the correct version of Unity. If you are using Unity Hub then download version 2019.3.6f1.

Download the latest copy of the master branch, inside it there will be multiple folders, to use them we will need to create an empty project where to put them. There are two ways to create an empty project:

- Using **Unity Hub:** Open Unity Hub Click on the blue button New, and select 2D project
- Using **Unity:** Open Unity and in the top left corner, click on file → New Project → 2D project

Once the new project opens, drag and drop all the folders from the master branch (this may take a minute to load all the components). After all the files are loaded you will need to add relevant scenes to the build.

Inside Unity, in the top left corner go to file → Build Settings → Drag and drop all the scenes needed to run.

Folders Containing Scenes
-------

 - **Overlay**
 	- OV1 → Scenes
 	- OV2 → Scenes
 	- OV3 → Scenes
 	- OV4 → Scenes
 	- OV1 → Misc
 NOTE: The scenes under “Misc” are non-functional, they are used as organization tools inside the build, in order to maintain order and check breaks of “Escenario”

 - **Escenarios**
 	- ES1 → Scenes → Preguntas
 	- ES2 → Scenes
 	- ES3 → Preguntas
 	- ES4 → Scenes
 	- ES5 → Scenes
 	- ES6 → Scenes
 	- ES7 → Scenes
 	- ES8 → Scenes
 	- ES9 → Scenes
 	- ES10 → Scenes

Build Settings
-------
There are 100 total scenes to be added and 10 that serve as organization tools. It’s of high importance that the first scene in the build is “Login.unity”, given that in the build it will be the first scene to be displayed.

Once all the scenes have been added to the build settings, press on “Build” and select a folder location for the executable to be stored. After the build is complete, open the scene “Login.unity” located in Overlay → OV3 → Scenes, and open it by double clicking the file. Then just press the play icon (▶)  at the top in the middle of the screen, and play.

