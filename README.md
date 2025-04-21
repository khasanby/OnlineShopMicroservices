# OnlineShopMicroservices

📦 Inventory.API
Inventory.API is a microservice responsible for managing product-related data within the system. It is built using the Vertical Slice Architecture combined with the CQRS (Command Query Responsibility Segregation) pattern to ensure a clear separation of concerns, modularity, and scalability.

This service exposes HTTP endpoints that allow clients to create, update, retrieve, and delete product records, acting as the central source of truth for all inventory-related operations.

The service is containerized using Docker and communicates with a PostgreSQL database for persistent storage. Each feature in the application is implemented as a vertical slice, bundling its UI entry point, application logic, domain rules, and infrastructure in a single cohesive unit.

✨ Core Features
📘 Vertical Slice Architecture: Feature-focused structure for maintainable and decoupled code.

⚡ CQRS: Separates command (write) and query (read) logic for better clarity and performance.

🗃 PostgreSQL Integration: Reliable relational database for inventory persistence.

☁️ Dockerized: Easily deployable via Docker Compose or other container orchestration tools.

🧪 Extensible for integration with messaging systems like RabbitMQ or MassTransit (if needed later).
