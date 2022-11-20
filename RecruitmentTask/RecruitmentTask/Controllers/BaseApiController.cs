using Microsoft.AspNetCore.Mvc;
using RecruitmentTask.Data;

namespace RecruitmentTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseApiController : ControllerBase
    {
        protected readonly DataContext _ctx;

        public BaseApiController(DataContext context)
        {
            _ctx = context;
        }
    }
}
