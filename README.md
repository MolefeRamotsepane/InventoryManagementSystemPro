# InventoryManagementSystemPro

A simple, educational Inventory Management System built in C# as a console application. This project is similar to the expense management system, it was jsut meant to strengthen my understanding understanding of object-oriented programming, file persistence, and clean code architecture. I also learned how you actually use Git and Github in real workinging environments. Things such as the frequency of commiting. I also found out that comments, should always be descriptive because another programmer may not be able to understand thngs, the eay I understand them. I also improved my way of writing the README.md. 

## 🚧 Development Phases

### Phase 1: Basic CRUD Functionality
- Created core classes (`Item`, `InventoryManager`)
- Implemented adding, listing, updating, and deleting inventory items
- Built a basic menu system using console UI

### Phase 2: Improving Structure
- Separated concerns using multiple files (`Item.cs`, `InventoryManager.cs`, `Program.cs`)
- Used lists and loops for inventory tracking
- Introduced better naming conventions and error handling

### Phase 3: Persistence
- Added file persistence using `System.IO`
- Inventory is saved and loaded from a text file

### Phase 4: Preparing for GitHub
- Added `.gitignore` to avoid committing VS-generated files
- Committed code in meaningful steps to show real development progress
- Wrote documentation (this README)

## 🛠️ Technologies Used

- Language: C#
- IDE: Visual Studio / Visual Studio Code
- .NET: .NET Framework 8 / .NET Core Console App
- Git & GitHub for version control

## 🧱 Challenges Encountered

- **File Permission Issues:** Some `.vs` files caused permission errors when pushing to GitHub; resolved by properly setting `.gitignore`
- **Constructor Errors (CS7036):** Missed required constructor parameters during class instantiation

## Learnings & Growth
This project taught me how to:
- Write modular and maintainable C# code
- Use object-oriented programming practically
-- Implement basic file-based data persistence
-- Use Git & GitHub professionally
-- Debug and refactor with purpose

## ▶️ How to Run

1. Clone the repository: git clone https://github.com/yourusername/inventory-management-system.git
2. Open in Visual Studio or VS Code
3. Build the project
4. Run the application in terminal or using Ctrl + F5

## 👨‍💻 Author

**Molefe Ramotsepane**  
[GitHub Profile](https://github.com/MolefeRamotsepane)  
Aspiring Software Engineer and Web Developer

## 📜 License
MIT License

