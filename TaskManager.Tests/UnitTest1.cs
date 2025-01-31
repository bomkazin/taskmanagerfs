using TaskManager.Models;
using System;
using System.ComponentModel.DataAnnotations;
using Xunit;
using FluentAssertions;
namespace TaskManager.Tests;
public class TaskItemsTests
{
    [Fact]
    public void TaskItems_Name_ShouldBeRequired()
    {
        var task = new TaskItems
        {
            Name = string.Empty // Intentionally leave Name empty
        };
        
        var validationResults = new System.Collections.Generic.List<ValidationResult>();
        var validationContext = new ValidationContext(task);
        
        var isValid = Validator.TryValidateObject(task, validationContext, validationResults, true);

        isValid.Should().BeFalse();
        validationResults.Should().Contain(r => r.MemberNames.Contains("Name"));
    }

    [Fact]
    public void TaskItems_ShouldHaveValidDueDate()
    {
        var task = new TaskItems
        {
            DueDate = DateTime.Now // Set a valid DueDate
        };

        task.DueDate.Should().BeCloseTo(DateTime.Now, precision: TimeSpan.FromSeconds(1));
    }

    [Fact]
    public void TaskItems_ShouldHaveDefaultIsCompletedAsFalse()
    {
        var task = new TaskItems();

        task.IsCompleted.Should().BeFalse(); // Default value is false
    }

    [Fact]
    public void TaskItems_ShouldHaveEmptyDescriptionByDefault()
    {
        var task = new TaskItems();

        task.Description.Should().BeEmpty(); // Default value is empty
    }

    [Fact]
    public void TaskItems_ShouldHavePriorityAsNullable()
    {
        var task = new TaskItems();
        
        task.Priority.Should().BeNull(); // Priority is nullable
    }
}
