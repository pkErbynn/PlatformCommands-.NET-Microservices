# PlatformCommands .NET Microservices

Platform with Commands .NET microservices architecture whereby a Platform has multiple Commands to be run on.

Platform service to register/track of company assets/platforms. Eg as Docker, Kubernetes, DotNet.

While the Commands service as command arguments repository for given Platform to aid automation of support processes.
Eg: - Commands for Docker platform are: `docker build`, `docker start`, `docker images`. - Commands for Kubernetes platform are: `kubectl get nodes`, `kubectl apply`, `kubectl get pods`. Similarly, - Commands for DotNet platform are: `dotnet build`, `dotnet run`.

These 2 services commununicate synchronously (using HTTP) and asynchronously (using Message Bus), and it involves use of Clean Architecture implementation, publishing services to Docker and deploying them to Kubernetes Cluster

## Technology stack

- Dotnet Core 6.0
- Asp.Net Web API
- InMemoryDB
- Entity Framework Core
- AutoMapper
- RabbitMQ
- Docker
- Kubernetes
- Minikube
- Docker Desktop

## Scope

- Command and Platform services accessed locally via endpoints
- Command and Platform services locally communicates synchronously
- Services published to Docker and accessible locally via Docker containers
- Services deployed into K8S Clusters using `kubectl` and accessible locally via K8S Clusters using Minikube
- Services communicates asynchronously locally using MessageBus

## Non-Scope

- Communication between services in K8S Clusters
- API Gateway in K8S cluster

## Usage

- Start Docker Desktop
- Start Minikube
- Run Minikube tunnel for a NodePod/LoadBalancer Service in K8S Cluster
