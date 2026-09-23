CSE 325 – Group Project Proposal
Institute Class Manager
Group Members
• Joseph Anucha
• Melchizedek Fernandez
• Isaac Lehi

1. Project Overview
   Institute Class Manager is a web application designed to help institute and seminary teachers manage their classes and provide students with easy access to class information and learning materials. The application will provide a centralized place where teachers can create and manage courses, organize class sessions, record student attendance, and upload class materials such as PowerPoint presentations and makeup-class documents. Students will be able to log in, view their own attendance records, and download materials provided by their teachers.
   The application is intended for institute and seminary teachers and students who need a simple way to organize class information and track attendance. The teacher will have access to management features, while students will have access to information related to their own enrollment and attendance. The application is valuable because it combines several common classroom management activities into one system rather than requiring teachers and students to manage information through separate documents or communication channels.
   This project also provides an opportunity for the group to apply the .NET development skills learned in this course to a practical application. One of our group members currently teaches a weekly institute class, which gives us an opportunity to understand the needs of real potential users and use realistic scenarios when testing the application.

2. Project Scope
   What's IN
   The following features are included in the scope of the semester project:
   • User registration and authentication.
   • Teacher and student roles with different permissions.
   • Course creation and management.
   • Student enrollment management.
   • Class session management.
   • Student attendance tracking.
   • Uploading and downloading class materials.
   • Student access to personal attendance information.
   • A responsive web interface that can be used on desktop, tablet, and mobile devices.

   What's OUT
   To keep the project realistic for the semester, the following features are outside the scope of the project:
   • Online payment processing.
   • Video conferencing or live online classes.
   • Built-in messaging or chat between teachers and students.
   • Automated grading or examination systems.
   • Integration with external school management systems.
   • Advanced analytics and reporting.
   • Native Android or iOS applications.
   • Automatic email or SMS notifications.
   Keeping these features outside the initial scope will allow the group to focus on building the core classroom-management functionality well within the semester.

3. App Features
   Feature 1: User Accounts and Authentication
   Users can create an account and log in to the application. The system will support different user roles, including teachers and students, and will restrict access to features according to the user's role.
   User Story:
   As a user, I want to create an account and log in so that I can securely access the features available to my role.

## Feature 2: Course Management

Teachers can create, view, edit, and delete courses. A course will contain basic information such as the course name, description, teacher, and other relevant details.
User Story:
As a teacher, I want to manage my courses so that I can keep my class information organized.

Feature 3: Student Enrollment
Teachers can manage the students enrolled in their courses. Students can view the courses in which they are enrolled.
User Story:
As a teacher, I want to manage course enrollments so that I know which students are participating in my class.

Feature 4: Class Session Management
Teachers can create and manage individual class sessions associated with a course. Sessions can contain information such as the date and basic class details.
User Story:
As a teacher, I want to create class sessions so that I can organize attendance and class activities by date.

Feature 5: Attendance Tracking
Teachers can record and update attendance for students during each class session. Students can view their own attendance records but cannot modify them.
User Story:
As a teacher, I want to record student attendance so that I can keep an accurate record of class participation.
User Story:
As a student, I want to view my attendance record so that I can monitor my participation in the class.

Feature 6: Class Materials
Teachers can upload class materials such as PowerPoint presentations and makeup-class documents. Students can view and download materials that have been made available to their class.
User Story:
As a teacher, I want to upload class materials so that students can access resources they need for the course.
User Story:
As a student, I want to download class materials so that I can review lessons and make up missed classes.

Feature 7: Role-Based Access
The application will provide different permissions for teachers and students. Teachers will be able to manage courses, sessions, attendance, enrollments, and materials, while students will primarily have access to their own information and course materials.
User Story:
As a teacher, I want administrative access to my classes so that I can manage class information.
User Story:
As a student, I want access to my own information so that other students cannot view or modify my attendance records.

4. Technical Considerations
   Data Storage
   The application will use a database to store information required by the system. The primary data entities will include:
   • Users
   • Courses
   • Enrollments
   • Class Sessions
   • Attendance Records
   • Class Materials
   The database will maintain relationships between these entities so that courses can have enrolled students, sessions can belong to courses, attendance can be associated with students and sessions, and materials can be associated with courses or sessions.

   User Accounts
   Users will need to create accounts and log in to use the application's protected features. The application will support at least two roles:
   • Teacher – Can manage courses, enrollments, sessions, attendance, and class materials.
   • Student – Can view enrolled courses, personal attendance information, and available class materials.

   External Services
   The initial version of the application is not expected to require external APIs. The group will focus on the core .NET application and database functionality.
   If an external service becomes necessary during development, the group will evaluate it based on its usefulness, security, cost, and compatibility with the project requirements.

   Device Compatibility
   The application will be developed as a responsive web application. Users should be able to access it from:
   • Desktop computers
   • Laptops
   • Tablets
   • Mobile phones
   The interface will be designed to remain usable on different screen sizes.

   Basic Security
   The application will use authentication and authorization to protect user information. Passwords will not be stored as plain text. Role-based authorization will be used to prevent students from accessing teacher-only management functions.
   The application will also validate user input and restrict access to attendance, enrollment, course, and material-management operations based on the user's permissions.

5. Technology
   The project will be developed using technologies from the .NET ecosystem as required by the course.
   The planned technologies include:
   • C# / .NET – Primary application development platform.
   • ASP.NET Core – Web application and server-side functionality.
   • Entity Framework Core – Database access and management.
   • SQL database – Persistent application data storage.
   • HTML/CSS – User interface structure and styling.
   • Blazor/NET 8 Blazor web application - Framework.
   • GitHub – Source-code management and team collaboration.
   • Trello – Project planning, task management, and progress tracking.

6. Project Links
   GitHub Repository
   https://github.com/zedfaceless/cse325-group-project
   The GitHub repository will be used for source-code management and collaboration among the group members.
   Trello Board
   Trello Board: https://trello.com/b/m41NXWUf/cse-325-team-3-project
   The Trello board will contain project features, user stories, development tasks, and other work items. Each core feature will be represented by a card with a brief description as required by the project instructions.

7. Project Goal
   The goal of Institute Class Manager is to create a practical .NET web application that makes it easier for institute and seminary teachers to manage classes and attendance while giving students convenient access to their attendance information and class materials.
   The group will focus on completing the core functionality within the semester rather than attempting to build a large classroom-management platform. By keeping the scope focused, the group will be able to demonstrate authentication, role-based authorization, database operations, CRUD functionality, file handling, and responsive web development while working together as a productive development team.
