# FundTransfers

## Index

- [Overview](#overview)
- [Project Folder Structure](#project-folder-structure)
- [Solution Structure](#solution-structure)
- [Standardized Architecture Patterns](#standardized-architecture-patterns)
- [Building Blocks](#building-blocks)
- [Get Started - Run Microservice](#getting-started)
- [DDD Implementation Guide](#ddd-implementation-guide)
- [Sequence Flow](#sequence-flow)

## Overview

`FundTransfers` is a ASP.NET Core Web API project designed using DDD (Domain Driven Design) approach.

> This project was created using Inizio - Dotnet Starterkit (Powered by Neudesic, an IBM Company)

## Project Folder Structure
- `dapr` - This folder contains the dapr related component(s)
- `deploy` - This folder contains the deployment script(s)
- `src` - This folder contains the source project(s) and related file(s)
- `README.md` - Project Readme content

## Solution Structure
- `FundTransfers.BankingService.API` - Web API Project which contains the ASP.Net Web API core file(s) e.g. Controllers, Middleware configurations etc
- `FundTransfers.BankingService.Application` - Application Layer which contains Core Business Logic, Commands, Queries etc
- `FundTransfers.BankingService.Domain` - Domain Layer which contains Aggregate Models, Events etc
- `FundTransfers.BankingService.Infrastructure` - Infrastructure Layer which contains External Infrastructure integrations e.g. DB using Entity Framework Core, Event Bus etc
- `FundTransfers.BankingService.Tests` - Unit Tests project which contains tests

## Standardized Architecture Patterns

Below are the standardized patterns which are followed in this solution:
- `Clean (Onion) Architecture` - API, Application Core, Domain & Infrastructure
- `Domain Driven Design` - Domain, Aggregates, Entities, Value Objects
- `Ports & Adaptors` - Standardized Contracts and Service Implementations
- `MediatR Pattern` - Command (Write) Query (Read) Responsibility Seperation
- `Repositories` - For DB interactions

## Building Blocks

When building application each building block make use of different service as listed below:

| Building Blocks    | Service                   |
|--------------------|---------------------------|
| Service Invocation | Grpc                 |
| State Store        | Redis                     |
| Pub Sub            | Apache Kafka                     |
| Tracing            | Zipkin                    |
| Secret Store       | local file/Azure Keyvault |
| Config Store       | Redis                     |

## Getting Started

Follow below steps to get started with FundTransfers - Web API:

### Pre-requisite
- .NET 7 SDK - [Download .NET 7 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/7.0)
- Visual Studio 2022 - [Download Visual Studio](https://visualstudio.microsoft.com/vs/) OR Visual Studio Code [Download VS Code](https://code.visualstudio.com/download)
- Docker Desktop - [Download Docker Desktop](https://www.docker.com/products/docker-desktop/)
- SQL Server - [Download SQL Server](https://microsoft.com/en-in/sql-server/sql-server-downloads)
- Dapr* - [Download Dapr CLI](https://docs.dapr.io/getting-started/install-dapr-cli/)
- Helm - [Install helm](https://helm.sh/docs/intro/install/)
    
### Run the Microservice using Docker Compose

> **Note:** You need to update Web API project - `appsettings.json` file with relevant configurations e.g. connection strings, app insights, azure ad settings etc.

Use below commands from the project root directory using any command line tool (e.g. Command Prompt, Windows Terminal)

To run application using docker-compose:

#### Using Commandline:

```powershell
docker-compose build
docker-compose up
```

#### Using Visual Studio:

- Open `FundTransfers.Context.sln` solution in Visual Studio
- Set `docker-compose` as startup project
- `Build` & `Run` the solution to start the microservice


To run application using tye:


You should be able to browse the Microservice by using the below URL, if there is no change to the port:

[http://localhost:5001/swagger/index.html](http://localhost:5001/swagger/index.html)


## DDD implementation guide

This project uses Domain Driven Design approach. Each layer has got logical bounderies.
 
>  **Note:**
> 
>  Domain Service would need, when there is a domain logic spawn across two or more aggregates.
    
```mermaid
flowchart LR
    api(FundTransfers.BankingService.API) -.-> application(FundTransfers.BankingService.Application)  
    application(FundTransfers.BankingService.Application)  -.-> domainsvc(Domain Service)        
    subgraph FundTransfers.BankingService.Domain  
    
        subgraph ag1 [Aggregate]
            direction TB
            re1[Root Entity] -.-> entity1[Entity]          
            re1[Root Entity] -.-> value1[Value Object]
        end
    
        subgraph ag2 [Aggregate]
            direction TB
            re2[Root Entity] -.-> entity2[Entity]          
            re2[Root Entity] -.-> value2[Value Object]
        end
    
    domainsvc(Domain Service) -.-> ag1
    domainsvc(Domain Service) -.-> ag2
    
    ag1 -.-> de1(Domain Event)
    ag2 -.-> de2(Domain Event)
    
    end
```

To create Root entity, you must inherit from entity and IAggregateRoot
```csharp    
    public class Root : Entity, IAggregateRoot
    {

    }
```

## Sequence Flow

 Sequence flow diagram for CreateBankingCommand flow 

```mermaid
sequenceDiagram
  autonumber

  participant api as FundTransfers.BankingService.API 
  participant application as FundTransfers.BankingService.Application 
  participant domain as FundTransfers.BankingService.Domain
  participant infra as FundTransfers.BankingService.Infrastructure

  api ->>+ application: Process CreateBankingcommand request 
  
  application ->>+ domain: Build domain model
  
  domain -->>- application: Response of CreateBankingCommand
  
  application ->>+ infra: Response of CreateBankingCommand

  infra -->>- application: Response of CreateBankingCommand

  application -->>- api: Response of CreateBankingCommand
```
