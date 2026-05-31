# Auto Repair Shop — Take-Home Code Exercise

Welcome, and thanks for taking the time to work through this exercise. We use it as a starting point for a deeper technical conversation in your next interview. We're more interested in *how* you build something than in checking every box on a feature list, so please don't feel you need to gold-plate every detail. Make decisions, jot down the ones worth calling out, and we'll talk about them together.

## The Scenario

A small auto repair shop runs everything on paper today: who the customer is, what car they brought in, what the mechanic is doing to it, and what it's going to cost. They've asked you to build the first version of an internal web application their staff can use to manage work orders from drop-off through pickup.

## Core Requirements

Your submission should be a working application that an employee can use to do the following:

1. **Log in.** Employees authenticate before using the system. How you implement authentication is up to you.
2. **Manage customers.** Create, view, edit, and (where it makes sense) remove customer records.
3. **Manage vehicles.** Each customer can have one or more vehicles. A vehicle belongs to exactly one customer.
4. **Create and update work orders.** A work order is opened for a specific vehicle and tracks the service being performed. It has a status that progresses through its lifecycle — the exact set of statuses is your call.
5. **Add line items to a work order.** A work order can have multiple line items representing parts and labor. Each line item has, at minimum, a description and a cost.
6. **View work orders.** Employees should be able to see a list of work orders and drill into the details of any one of them.

Beyond those relationships, you have full discretion on how the data is modeled, what fields exist on each entity, what validation rules apply, and what the UI looks like. 

## Optional / Stretch Goals

These are entirely optional. Pick any that interest you — none, one, or several.

- **User roles.** Differentiate between roles such as admin, service writer, and mechanic, with appropriate permissions.
- **Mechanic assignment.** Assign one or more mechanics to a work order and track their work.
- **Invoicing.** Generate a customer-facing invoice or receipt from a completed work order, including totals and tax.
- **Parts inventory.** Track parts on hand; deduct from inventory when added to a work order.
- **Service history.** Show all past work orders for a given customer or vehicle.
- **Search and filtering.** Filter work orders by status, customer, date range, or assigned mechanic.
- **Dashboard.** Show useful at-a-glance metrics (e.g., open work orders, revenue this week).
- **Audit trail.** Track who created or changed a work order and when.
- **Notifications.** Simulate notifying a customer when their vehicle is ready — it doesn't need to actually send anything.
- **Automated tests.** Unit, integration, or end-to-end — whatever makes sense.
- **Containerized setup.** A `docker-compose` (or equivalent) that lets us run everything with one command.
- **API documentation.** OpenAPI/Swagger or similar.

If something else would make the application better in your view, feel free to add it. We'd love to see what you come up with.

## Tech Stack

**Required:**

- **Backend:** .NET (current LTS or later).
- **Database:** PostgreSQL.
- **Runnable from a mainstream .NET IDE.** Your solution must open and run from Visual Studio, Visual Studio Code, or JetBrains Rider. You don't need to support all three — pick whichever you prefer — but please don't depend on tooling specific to one editor in a way that breaks the others.

**Your choice:**

- **Frontend framework:** React, Angular, Vue, Blazor, Razor Pages, whatever you're most comfortable with.
- **Data access:** EF Core, Dapper, raw SQL, another ORM — whatever fits your design.
- **Dependency injection, logging, validation libraries, authentication approach, project structure** — all up to you.

If you'd like to use a library or pattern that isn't in the list above, that's fine. We're interested in seeing the tools you'd reach for in a real project.


## Submission

Submit your work however is easiest for you:

- A link to a Git repository (GitHub, GitLab, etc.), or
- A zip file of your project (please exclude `bin/`, `obj/`, `node_modules/`, etc.).

Please include a short README in your submission that covers:

- How to run the application locally (including the database)
- Any setup steps, seed data, or default credentials
- Decisions or trade-offs you'd like us to know about
- What you would add or change if you had more time

## Questions

If anything in this prompt is unclear, please reach out. We're happy to clarify.
