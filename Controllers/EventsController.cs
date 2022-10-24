using EVENTS.Data;
using EVENTS.Feature.Events.Command;
using EVENTS.Feature.Events.Queries;
using EVENTS.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace EVENTS.Controllers
{
    public class EventsController : Controller
    {
        //private readonly EventDbContext _context;
        //private List<Source> _sources;public EventsController(){ _sources = new List<Source>{ new Source { SourceId =1 , SourceTitle= "M.Etisalat"},new Source { SourceId =2 , SourceTitle= "M.Sciience"}, new Source { SourceId  =3 , SourceTitle= "M.Sports"}};}


        private readonly IMediator _mediator;

        public EventsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        public async Task<IActionResult> Index()
        {
           return View(await _mediator.Send(new GetAllEventsquery()));
            
            //var Result = _mediator.Event.ToList();
        }
        public IActionResult Create()
        {
            //ViewBag.Sources = _Context.Sources.ToString();

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateEventCommand Command)
        {
            try
            {


                if (ModelState.IsValid)
                {
                    await _mediator.Send(Command);
                    return RedirectToAction(nameof(Index));
                 
                }
            }
            //   catch (Exception ex)
            catch (Exception )
            {
                ModelState.AddModelError("", "Unable to save changes.");
            }
            return View(Command);
        }
        public async Task<IActionResult> Details(int id)
        {
            return View(await _mediator.Send(new GetAllEventsquery() { EventId = id }));
        }  
    }
}
/* 
 public IActionResult Index()
        {
            return View();
        } */
