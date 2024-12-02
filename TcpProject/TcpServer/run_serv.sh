#!/bin/bash

RED="\033[31m"
GREEN="\033[32m"
RESET="\033[0m"

echo -e "${GREEN}Checking .NET SDK...${RESET}"
if ! command -v dotnet &> /dev/null; then
    echo -e "${RED}.NET SDK is not installed. Installing...${RESET}"

    OS=$(uname -s)
    if [[ "$OS" == "Linux" ]]; then
        wget https://dot.net/v1/dotnet-install.sh -O dotnet-install.sh
        chmod +x dotnet-install.sh
        ./dotnet-install.sh --install-dir ~/.dotnet
        export PATH="$PATH:~/.dotnet"
    elif [[ "$OS" == "Darwin" ]]; then
        brew install --cask dotnet
        export PATH="/usr/local/share/dotnet:$PATH"
    else
        echo -e "${RED}Unsupported system. Install .NET manually.${RESET}"
        exit 1
    fi

    if ! command -v dotnet &> /dev/null; then
        echo -e "${RED}.NET SDK installation failed.${RESET}"
        exit 1
    fi
    echo -e "${GREEN}.NET SDK installed successfully.${RESET}"
else
    echo -e "${GREEN}.NET SDK is already installed.${RESET}"
fi

echo -e "${GREEN}Building and running the server...${RESET}"
dotnet build
if [ $? -ne 0 ]; then
    echo -e "${RED}Build failed.${RESET}"
    exit 1
fi

dotnet run --project ./TcpServer.csproj
if [ $? -ne 0 ]; then
    echo -e "${RED}Failed to run the server.${RESET}"
    exit 1
fi

echo -e "${GREEN}Server started successfully.${RESET}"
