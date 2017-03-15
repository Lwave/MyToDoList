using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using MyToDoList.Models;

namespace MyToDoList.Data
{
    public class toDoListSampleData
    {
        public async static Task InitializeAsync(IServiceProvider serviceProvider)
        {
            var db = serviceProvider.GetService<ApplicationDbContext>();

            await db.Database.EnsureCreatedAsync();

            if (!db.toDoLists.Any())
            {
                db.toDoLists.AddRange(
                    new toDoList
                    {
                        Title = "Chores around the house",

                        toDoItems = new List<toDoItem>
                            {
                                new toDoItem
                                {
                                    ApplicationUserId = (db.ApplicationUsers.FirstOrDefault(u => u.FirstName == "Stephen")).Id,
                                    Description = "Clean you room",
                                    IsCompleted = false,
                                    toDoListId = 1

                                },
                                new toDoItem
                                {
                                    ApplicationUserId = (db.ApplicationUsers.FirstOrDefault(u => u.FirstName == "Stephen")).Id,
                                    Description = "Wash dishes",
                                    IsCompleted = false,
                                    toDoListId = 1
                                },
                                new toDoItem
                                {
                                    ApplicationUserId = (db.ApplicationUsers.FirstOrDefault(u => u.FirstName == "Stephen")).Id,
                                    Description = "Sweep",
                                    IsCompleted = false,
                                    toDoListId = 1
                                }
                            }
                    },
                    new toDoList
                    {
                        Title = "Grocery Shopping",
                        toDoItems = new List<toDoItem>
                        {
                            new toDoItem
                            {
                                ApplicationUserId = (db.ApplicationUsers.FirstOrDefault(u => u.FirstName == "Mike")).Id,
                                Description = "Buy Donuts",
                                IsCompleted = false,
                                toDoListId = 2
                            },
                            new toDoItem
                            {
                                ApplicationUserId = (db.ApplicationUsers.FirstOrDefault(u => u.FirstName == "Mike")).Id,
                                Description = "Milk",
                                IsCompleted = false,
                                toDoListId = 2
                            }

                        }
                    },

                    new toDoList
                    {
                        Title = "Pet stuff",
                        toDoItems = new List<toDoItem>
                        {
                            new toDoItem
                            {
                                ApplicationUserId = (db.ApplicationUsers.FirstOrDefault(u => u.FirstName == "Mike")).Id,
                                Description = "Take dog to Petsmart",
                                IsCompleted = false,
                                toDoListId = 3
                            },
                            new toDoItem
                            {
                                ApplicationUserId = (db.ApplicationUsers.FirstOrDefault(u => u.FirstName == "Mike")).Id,
                                Description = "Buy cat food",
                                IsCompleted = false,
                                toDoListId = 3
                            }
                        }
                    });


            }
        }
    }
}
