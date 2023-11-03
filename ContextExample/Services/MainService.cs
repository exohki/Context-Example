using ContextExample.Data;
using ContextExample.Services;
using System;
using System.Linq;

public class MainService : IMainService
{
    private readonly IContext _context;

    public MainService(IContext context)
    {
        _context = context;
    }

    public void Invoke()
    {
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("Select an option:");
            Console.WriteLine("1. Get movie by Id");
            Console.WriteLine("2. Get movie by title");
            Console.WriteLine("3. Find list of movies matching title");
            Console.WriteLine("4. Exit");

            var option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    Console.WriteLine("Enter movie ID:");
                    if (int.TryParse(Console.ReadLine(), out int id))
                    {
                        var movieById = _context.GetById(id);
                        if (movieById != null)
                        {
                            Console.WriteLine($"Movie found: {movieById.Title}");
                        }
                        else
                        {
                            Console.WriteLine("Movie not found.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid ID format.");
                    }
                    break;
                case "2":
                    Console.WriteLine("Enter movie title:");
                    var title = Console.ReadLine();
                    var movieByTitle = _context.GetByTitle(title);
                    if (movieByTitle != null)
                    {
                        Console.WriteLine($"Movie found: {movieByTitle.Title}");
                    }
                    else
                    {
                        Console.WriteLine("Movie not found.");
                    }
                    break;
                case "3":
                    Console.WriteLine("Enter search string for movie title:");
                    var searchString = Console.ReadLine();
                    var movies = _context.FindMovie(searchString);
                    if (movies.Any())
                    {
                        Console.WriteLine("Movies found:");
                        foreach (var movie in movies)
                        {
                            Console.WriteLine(movie.Title);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No movies found with that title.");
                    }
                    break;
                case "4":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option, please try again.");
                    break;
            }
        }
    }
}
