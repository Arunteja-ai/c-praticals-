using System;
using System.Collections.Generic;

class InvalidExpenseAmountException : Exception
{
    public InvalidExpenseAmountException(string message)
        : base(message)
    {
    }
}

class EmptyDescriptionException : Exception
{
    public EmptyDescriptionException(string message)
        : base(message)
    {
    }
}

class Expense
{
    public int Id { get; set; }
    public string Description { get; set; }
    public double Amount { get; set; }
    public string Category { get; set; }

    public Expense(int id, string description, double amount, string category)
    {
        Id = id;
        Description = description;
        Amount = amount;
        Category = category;
    }

    public override string ToString()
    {
        return $"ID: {Id} | Description: {Description} | Amount: ₹{Amount:F2} | Category: {Category}";
    }
}

class ExpenseTracker
{
    private List<Expense> expenses = new List<Expense>();
    private int nextId = 1;

    public void AddExpense(string description, double amount, string category)
    {
        if (string.IsNullOrWhiteSpace(description))
            throw new EmptyDescriptionException("Expense description cannot be empty.");

        if (amount <= 0)
            throw new InvalidExpenseAmountException("Expense amount must be greater than zero.");

        expenses.Add(new Expense(nextId++, description, amount, category));

        Console.WriteLine("\nExpense added successfully!");
    }

    public void DisplayExpenses()
    {
        if (expenses.Count == 0)
        {
            Console.WriteLine("\nNo expenses available.");
            return;
        }

        Console.WriteLine("\n========== ALL EXPENSES ==========");

        foreach (Expense expense in expenses)
            Console.WriteLine(expense);
    }

    public void DisplayTotalExpense()
    {
        double total = 0;

        foreach (Expense expense in expenses)
            total += expense.Amount;

        Console.WriteLine($"\nTotal Expenses: ₹{total:F2}");
    }

    public void SearchByCategory(string category)
    {
        bool found = false;

        Console.WriteLine($"\n========== {category.ToUpper()} EXPENSES ==========");

        foreach (Expense expense in expenses)
        {
            if (expense.Category.Equals(category, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine(expense);
                found = true;
            }
        }

        if (!found)
            Console.WriteLine("No expenses found in this category.");
    }
}

class Program
{
    static void Main()
    {
        ExpenseTracker tracker = new ExpenseTracker();
        bool running = true;

        Console.WriteLine("======================================");
        Console.WriteLine("       EXPENSE TRACKING SYSTEM");
        Console.WriteLine("======================================");

        while (running)
        {
            Console.WriteLine("\n------------- MENU -------------");
            Console.WriteLine("1. Add Expense");
            Console.WriteLine("2. View All Expenses");
            Console.WriteLine("3. View Total Expenses");
            Console.WriteLine("4. Search by Category");
            Console.WriteLine("5. Exit");
            Console.WriteLine("--------------------------------");

            try
            {
                Console.Write("Enter your choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter description: ");
                        string description = Console.ReadLine();

                        Console.Write("Enter amount: ");
                        double amount = Convert.ToDouble(Console.ReadLine());

                        Console.Write("Enter category: ");
                        string category = Console.ReadLine();

                        try
                        {
                            tracker.AddExpense(description, amount, category);
                        }
                        catch (InvalidExpenseAmountException ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }
                        catch (EmptyDescriptionException ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }

                        break;

                    case 2:
                        tracker.DisplayExpenses();
                        break;

                    case 3:
                        tracker.DisplayTotalExpense();
                        break;

                    case 4:
                        Console.Write("Enter category: ");
                        string searchCategory = Console.ReadLine();

                        tracker.SearchByCategory(searchCategory);
                        break;

                    case 5:
                        running = false;
                        Console.WriteLine("\nThank you for using Expense Tracker!");
                        break;

                    default:
                        Console.WriteLine("Invalid choice! Please select 1-5.");
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("\nError: Please enter a valid number.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nUnexpected Error: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("--------------------------------");
            }
        }
    }
}
