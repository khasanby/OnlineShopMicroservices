# OnlineShopMicroservices


## 📦 Inventory.API
Inventory.API is a microservice responsible for managing product-related data within the system. It is built using the Vertical Slice Architecture combined with the CQRS (Command Query Responsibility Segregation) pattern to ensure a clear separation of concerns, modularity, and scalability.

This service exposes HTTP endpoints that allow clients to create, update, retrieve, and delete product records, acting as the central source of truth for all inventory-related operations.

The service is containerized using Docker and communicates with a PostgreSQL database for persistent storage. Each feature in the application is implemented as a vertical slice, bundling its UI entry point, application logic, domain rules, and infrastructure in a single cohesive unit.

### ✨ Core Features
📘 Vertical Slice Architecture: Feature-focused structure for maintainable and decoupled code.

⚡ CQRS: Separates command (write) and query (read) logic for better clarity and performance.

🗃 PostgreSQL Integration: Reliable relational database for inventory persistence.

☁️ Dockerized: Easily deployable via Docker Compose or other container orchestration tools.

🧪 Extensible for integration with messaging systems like RabbitMQ or MassTransit (if needed later).



## 🛒 CartAPI - Shopping Cart Service
The CartAPI is a lightweight, high-performance microservice designed to manage users' shopping carts within the OnlineShopMicroservices system.

It ensures a seamless and responsive shopping experience by combining fast in-memory data access with scalable, event-driven communication.

### ✨ Key Features
Distributed Caching with Redis
Cart data is stored in Redis to provide low-latency access and high scalability.
By caching cart information, the service minimizes database load and ensures fast responses even under heavy traffic.

Event-Driven Communication with RabbitMQ
CartAPI leverages RabbitMQ to publish and consume integration events, enabling reliable and decoupled interactions with other services.
For instance, when a user checks out, the cart publishes a CartCheckoutEvent, allowing the Order service to process the order asynchronously.

RESTful API Endpoints
The service offers clean and intuitive endpoints for managing cart operations:

GET /api/cart/{username} — Retrieve the current cart for a user.

POST /api/cart — Create or update a cart.

DELETE /api/cart/{username} — Delete a user's cart.

🛠️ Technology Stack
ASP.NET Core Web API

Redis (via StackExchange.Redis)

RabbitMQ (with MassTransit or Raw AMQP client)

Docker (for containerized development and deployment)

🚀 How It Works
When a user adds products to their cart, the cart data is stored in Redis.

If the user proceeds to checkout, CartAPI publishes an event to RabbitMQ.

Downstream services, such as the OrderAPI, subscribe to this event and initiate order creation workflows.

🌟 Benefits
Blazing fast cart operations through caching.

Decoupled, scalable architecture through messaging.

Smooth user experience with real-time cart management.
