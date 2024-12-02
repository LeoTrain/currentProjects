#!/bin/bash

RED="\\033[31m"
GREEN="\\033[32m"
RESET="\\033[0m"

echo -e "${GREEN}Checking .NET SDK...${RESET}"
if ! command -v dotnet &> /dev/null; then
    echo -e "${RED}.NET SDK is not installed. Installation in progress..${RESET}"

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
        echo -e "${RED}Not working for this OS. Install .NET manually.${RESET}"
        exit 1
    fi

    if ! command -v dotnet &> /dev/null; then
        echo -e "${RED}Error while installing .NET SDK.${RESET}"
        exit 1
    fi
    echo -e "${GREEN}.NET SDK installed with great success.${RESET}"
else
    echo -e "${GREEN}.NET SDK already installed.${RESET}"
fi

echo -e "${GREEN}Compiling and execution of the client...${RESET}"
dotnet build
if [ $? -ne 0 ]; then
    echo -e "${RED}Compilation was not a success.${RESET}"
    exit 1
fi

dotnet run --project ./Client.csproj
if [ $? -ne 0 ]; then
    echo -e "${RED}Error while running the client.${RESET}"
    exit 1
fi

echo -e "${GREEN}Client running successfully${RESET}"
