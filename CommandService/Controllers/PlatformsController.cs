// Need this controller in Command service cus it's the parent for the Command
using AutoMapper;
using CommandService.Data;
using Microsoft.AspNetCore.Mvc;

// Platform is a parent of the Command
namespace CommandService.Controllers
{
    [Route("api/c/[controller]")]
    [ApiController]
    public class PlatformsController: ControllerBase
    {
        private readonly ICommandRepo _repository;
        private readonly IMapper _mapper;

        public PlatformsController(ICommandRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost]
        public ActionResult TestInboundConnection()
        {
            Console.WriteLine("---> Inbound post # command service");
            return Ok("Inbound test from Platforms controller");
        }
    }

}
