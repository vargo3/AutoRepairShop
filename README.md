# AutoRepairShop
This is a coding exercise. This is a application built to handle the internal tracking of a theoretical auto repair shop's people, vehicles, materials, and labor.

* How to run the application locally (including the database)
	* load and run docker image
* Any setup steps, seed data, or default credentials
	* admin user login
		* username: admin
		* password: admin
	* database is seeded with:
		* 4 accounts
		* 2 vehicles
		* 1 work orders
* Decisions or trade-offs you'd like us to know about
	* Using Docker to run the application and database locally, which may be more complex than using a simple local setup, but provides a consistent environment for testing and deployment.
	* Including Postgre db in the same docker image as the web service to ensure that the application can be easily tested without additional setup steps. In a real-world scenario, I would maintain the database separately from the application to allow for more flexibility and scalability long-term.
	* Using EF Core for database CRUD interactions because it provides a robust and maintainable codebase.
	* I am setting up db tables and seed data with sql scripts that run during docker initialization rather than using EF Core Migrations because I believe a db should be setup and maintained with intentionality and not as a by-product of the front-end.
	* Using Razor Pages for the frontend to have a more seamless integration with the backend logic.
	* Using simple user authentication to prevent un-authenticated interactions
	* 
* What you would add or change if you had more time
	* add vehicle ownership log to better track when ownership could change
	* add admin screens for changing certain cfg tables
	* expand account roles with permission controls. ex: allow customers to have view-only access to their own data.
	* Unit tests
	* I would take more time to refine the UI and UX
	* use async methods instead of the serial versions to improve scalability
	* use caching to reduce redundant db calls
	* add more data validations for UI form submissions
	