FROM mcr.microsoft.com/dotnet/core/sdk:3.1 as base

WORKDIR /app
EXPOSE 7002
COPY . .
RUN dotnet build "Payment/Payment.csproj"
RUN dotnet publish "Payment/Payment.csproj" -c Release -o /app/out

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 
WORKDIR /app
COPY --from=base /app/out .
ENTRYPOINT [ "dotnet","Payment.dll" ]