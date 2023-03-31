FROM mcr.microsoft.com/dotnet/sdk:7.0

ENV DOTNET_URLS=http://+:9000

WORKDIR /app/src

ENTRYPOINT ["sleep", "infinity"]