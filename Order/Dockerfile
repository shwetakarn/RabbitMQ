FROM mcr.microsoft.com/dotnet/core/sdk:3.1 as base

WORKDIR /app
EXPOSE 7001
COPY . .
RUN dotnet build "Order/Order.csproj"
RUN dotnet publish "Order/Order.csproj" -c Release -o /app/out

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 
WORKDIR /app
COPY --from=base /app/out .
ENTRYPOINT [ "dotnet","Order.dll" ]