# Proyecto MCP Server // Crunchloop Dotnet-interview

## Introducción
Este proyecto extiende una API y añade un servidor MCP que se comunica con dicha API. La API y la base de datos están contenidas en un archivo docker-compose, mientras que el servidor MCP se inspecciona con la herramienta `@modelcontextprotocol/inspector`.

## Precondiciones
Tener instalados:
- Docker y Docker Compose (instalado y corriendo)
- Node.js
- Git
- @modelcontextprotocol/inspector (`npm i @modelcontextprotocol/inspector`)
- VS Code

## Pasos a ejecutar

- Clonar este repositorio a local
- Ir a la ruta /TodoAPI/.devcontainer
- Abrir un cmd en esta ruta, y ejecutar el comando "docker-compose up -d"
- Esperar a que se ejecute la API. Se puede ver el status con `docker logs devcontainer-app-1`

![image](https://github.com/user-attachments/assets/d2323803-36f6-43f1-b758-d3c5240b83d6)

- Ir a VS Code, abrir la ruta/MCPServer/dotnet-interview-mcp-server
- Abrir una nueva terminal y ejecutar el comando `npx @modelcontextprotocol/inspector dotnet run`
- Una vez se muestre el mensaje "🔍 MCP Inspector is up and running at http://127.0.0.1:6274 🚀" podremos avanzar al siguiente paso

![image](https://github.com/user-attachments/assets/568483cb-34c7-458c-bbf9-fbf01db84000)
 
- Ir a un navegador y abrir la url: http://127.0.0.1:6274. Se desplegará un sitio llamado MCP Inspector

![image](https://github.com/user-attachments/assets/560d9f18-e56c-4cee-b520-6592695afadb)
  
- En el panel de la izquierda, hacer click en Connect. Deberá mostrar el estado `Connected` y una seccion con el título `Tools`
- Click en `List tools`, esto listará las tools del servidor MCP

![image](https://github.com/user-attachments/assets/f280505b-9633-4cc2-966b-a7b990dfc888)



## Contacto

Email: brunobic2010@hotmail.com
