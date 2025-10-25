A secure, multi-user project demonstrating advanced full-stack concepts, entity relationships, and persistence.

Implementation Details
Data Modeling: Implements a one-to-many relationship: a User owns multiple Projects, and each Project contains multiple ProjectTask items.

Security: Authentication is handled by JWT (JSON Web Tokens). All data endpoints are secured with the [Authorize] attribute and enforce owner-only access.

Persistence: Uses Entity Framework Core (EF Core) with an automatically generated SQLite database (projectmanager.db).

Architecture: Multi-page frontend uses React Router DOM and Protected Routes to guard the dashboard and project pages.
<img width="1925" height="1095" alt="Screenshot 2025-10-25 092334" src="https://github.com/user-attachments/assets/f7d13365-da90-4f43-8a06-07c3bf64b91a" />
<img width="2089" height="1152" alt="Screenshot 2025-10-25 092324" src="https://github.com/user-attachments/assets/afc7809e-b30b-4bf8-98b9-bf66c4f94f3e" />
<img width="1930" height="1065" alt="Screenshot 2025-10-25 092352" src="https://github.com/user-attachments/assets/2cca17af-8b92-4da3-96a7-cb0715fce833" />
<img width="1947" height="1113" alt="Screenshot 2025-10-25 092437" src="https://github.com/user-attachments/assets/e9ddace8-afa4-49f4-9b15-b844a7a24b73" />
<img width="1359" height="1049" alt="Screenshot 2025-10-25 092515" src="https://github.com/user-attachments/assets/c8541330-5ede-414d-a3a2-25a5dbdb1881" />




Setup Instructions
The database must be initialized locally before the server can run.

Navigate to Backend:


Bash

cd Assignment2_ProjectMgr/ProjectManagerApi
Initialize Database (Creates Tables):

Bash

dotnet ef database update
Run Backend Server:

Bash

dotnet run
(The API will start on http://localhost:5025)

Run Frontend: Open a separate terminal and navigate to Assignment2_ProjectMgr/project-manager-ui.

Bash

npm install
npm start
Usage: Navigate to http://localhost:3000/register to create your first secure account.
