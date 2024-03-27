using Learning.EFCore.Domain;
using Learning.EFCore.Repository;
using Microsoft.EntityFrameworkCore.ChangeTracking;

using (var context = new SchoolContext())
{
    context.Database.EnsureCreated();

    var grd1 = new Grade() { GradeName = "1st Grade" };
    var std1 = new Student() { FirstName = "Yash", LastName = "Malhotra", Grade = grd1 };

    //context.Students.Add(std1);
    //context.SaveChanges();

    foreach (var s in context.Students)
        Console.WriteLine($"First Name: {s.FirstName}, Last Name: {s.LastName}");

    var student = context.Students.FirstOrDefault();
    student.LastName = "Friss";

    context.Students.Add(new Student() { FirstName = "Bill", LastName = "Gates" });

    DisplayStates(context.ChangeTracker.Entries());

}

Console.ReadLine();


static void DisplayStates(IEnumerable<EntityEntry> entries)
{
    foreach (var entry in entries)
    {
        Console.WriteLine($"Entity:{entry.Entity.GetType().Name},State: { entry.State.ToString()}");
    }
}
