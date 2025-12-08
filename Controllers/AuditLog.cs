using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    public class AuditController : Controller
    {
        private readonly IAuditService _auditService;

        public AuditController(IAuditService auditService)
        {
            _auditService = auditService;
        }
//Audit
        public IActionResult Index()
        {
            var logs = _auditService.GetAllLogs();
            return View(logs);
        }
    }
}
