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
- SwaggerUI / Insomia

## Scope

- Command and Platform services accessible via endpoints
- Command and Platform services communicates synchronously using HTTP Client
- Services communicates asynchronously using Mqtt MessageBus
- Services published to Docker and accessible via Docker containers
- Services deployed into K8S Clusters using `kubectl` and accessible locally via K8S Clusters using Minikube

## Usage

- Start Docker Desktop
- Start Minikube to setup K8S cluster
- Run Minikube tunnel for NodePode or LoadBalancer services in the cluster. Example, for Rabbit MessageBus, `$minikube service rabbitmq-loadbalancer --url`