# TCP Project

This project implements a simple TCP client-server communication system in C#. It demonstrates real-time messaging between multiple clients through a centralized server.

## Features

### Server
- Accepts multiple client connections simultaneously.
- Broadcasts messages sent by a client to all other connected clients.
- Handles user connection and disconnection events gracefully.

### Client
- Allows users to connect to the server with a custom username.
- Supports real-time chat with color-coded messages for different users.
- Displays a formatted chat log with timestamps for each message.

## Components

### Files
1. **server.cs**: Implements the server logic, including managing connections and broadcasting messages.
2. **Client.cs**: Handles the client-side functionality, such as sending and receiving messages.
3. **Program.cs**: Entry point for the client-side application.
4. **messageDetails.cs**: Represents the structure of a message with details like timestamp and content.
5. **user.cs**: Defines the User class to represent connected users.
6. **run_serv.sh**: Shell script to build and run the server.
7. **run_cl.sh**: Shell script to build and run the client.

## Setup

### Prerequisites
- .NET SDK installed. The shell scripts (`run_serv.sh` and `run_cl.sh`) will attempt to install it if missing.
- Compatible with Linux, macOS, and Windows.

### Installation
1. Clone the repository:
   ```bash
   git clone https://github.com/LeoTrain/currentProjects.git
   cd currentProjects/TcpProject
   ```
2. Build the server and client using the provided scripts or manually with .NET CLI:
   ```bash
   ./run_serv.sh # For server
   ./run_cl.sh   # For client
   ```

## Usage

### Running the Server
1. Execute the `run_serv.sh` script:
   ```bash
   ./run_serv.sh
   ```
2. The server will start listening for client connections on the configured IP and port.

### Running the Client
1. Execute the `run_cl.sh` script:
   ```bash
   ./run_cl.sh
   ```
2. Enter your username when prompted and start chatting.

## Customization

### Server
- Configure the server IP and port in `server.cs`:
  ```csharp
  new Server("127.0.0.1", 6000);
  ```

### Client
- Change the server address and port in `Client.cs`:
  ```csharp
  private const string ServerAddress = "192.168.1.11";
  private const int Port = 6000;
  ```

## Limitations
- Basic error handling is implemented; improvements can be made for production use.
- No encryption for transmitted messages.
- Designed for learning and demonstration purposes.

## Contributing
Feel free to fork the repository and submit pull requests to enhance the project.

## License
This project is open-source.

