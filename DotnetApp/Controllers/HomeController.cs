using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DotnetApp.Models;

namespace DotnetApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View(new UrlViewModel());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Shorten(UrlViewModel model)
    {
        if (string.IsNullOrWhiteSpace(model.LongUrl)
            || !Uri.TryCreate(model.LongUrl, UriKind.Absolute, out var uri)
            || (uri.Scheme != Uri.UriSchemeHttp && uri.Scheme != Uri.UriSchemeHttps))
        {
            ModelState.AddModelError(nameof(model.LongUrl), "Please enter a valid http/https URL.");
            return View("Index", model);
        }

        model.ShortUrl = $"sho.rt/{GenerateShortCode()}";
        return View("Index", model);
    }

    private static string GenerateShortCode()
    {
        const string chars = "abcdefghijklmnopqrstuvwxyz0123456789";
        return new string(Enumerable.Range(0, 5)
            .Select(_ => chars[Random.Shared.Next(chars.Length)])
            .ToArray());
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
