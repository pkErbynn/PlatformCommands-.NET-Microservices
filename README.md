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
- gRPC
- Docker
- Kubernetes
- Minikube
- Docker Desktop
- SwaggerUI / Insomia

## Scope

- Command and Platform services accessible via endpoints
- Services communicates synchronously using HTTP Client
- Services communicates synchronously using gRPC Protobuf
- Services communicates asynchronously using Mqtt MessageBus
- Services publish to Docker and accessible via Docker containers
- Services deploy into K8S Clusters using `kubectl` and accessible locally via K8S Clusters using Minikube

## Usage
- Spin Docker Desktop
- Start Minikube to setup K8S cluster, `$ minikube start`
- Apply rabbitmq and other deployment pods, `$ kubectl apply -f <DEPL_FILE>`
- Spin Minikube service tunnel for RabbitMq service and reconfigure ports in services, `$ minikube service rabbitmq-loadbalancer --url`
- Run services, `$ dotnet run <SERVICE_PROJECT>`
> NB: Access services in K8S Cluster through Minikube service tunnels