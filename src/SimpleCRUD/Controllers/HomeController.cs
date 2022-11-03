namespace SimpleCRUD.Controllers;

using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;

public class HomeController : Controller
{
    private readonly ApplicationContext _context;
    private readonly ILogger<HomeController> _logger;

    public HomeController(ApplicationContext context, ILogger<HomeController> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _context.Users.ToListAsync());
    }

    public IActionResult Create()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");
    }
    
    [HttpPost]
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) return NotFound();
        
        var user = new User { Id = id.Value };
        _context.Entry(user).State = EntityState.Deleted;
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");
    }
    
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();
        
        var user = await _context.Users.FirstOrDefaultAsync(p=> p.Id == id);
        
        if (user == null) return NotFound();
        
        return View(user);
    }
    [HttpPost]
    public async Task<IActionResult> Edit(User user)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
    }
}