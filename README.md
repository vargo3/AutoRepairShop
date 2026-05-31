# AutoRepairShop
This is a coding exercise. This is a application built to handle the internal tracking of a theoretical auto repair shop's people, vehicles, materials, and labor.

* How to run the application locally (including the database)
	* load and run docker image
* Any setup steps, seed data, or default credentials
	* admin user login
		* username: admin
		* password: password
	* database is seeded with:
		* x customers
		* x employees
		* x vehicles
		* x labor entries
* Decisions or trade-offs you'd like us to know about
	* Using Docker to run the application and database locally, which may be more complex than using a simple local setup, but provides a consistent environment for testing and deployment.
	* Using EF Core for database CRUD interactions because it provides a robust and maintainable codebase.
	* Using Razor Pages for the frontend to have a more seamless integration with the backend logic.
	* Including Postgre db in the same docker image as the web service to ensure that the application can be easily tested without additional setup steps. In a real-world scenario, I would maintain the database separately from the application to allow for more flexibility and scalability long-term.
	* 
* What you would add or change if you had more time