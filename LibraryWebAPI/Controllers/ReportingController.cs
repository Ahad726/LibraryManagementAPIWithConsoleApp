using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryWebAPI.Core;
using LibraryWebAPI.Store.IServices;
using Microsoft.AspNetCore.Mvc;

namespace LibraryWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportingController : ControllerBase
    {

        private IReportingService _iReportingService;
        public ReportingController(IReportingService iReportingService)
        {
            _iReportingService = iReportingService;
        }


        //[HttpGet]
        //public object Get()
        //{
        //    return null;
        //}

        [HttpGet("/api/Reporting/{Id}")]
        public double CheckFine(int Id)
        {
            return _iReportingService.CalculateFine(Id);
        }

        [HttpPost]
        public void FineReceive(Student student)
        {
            _iReportingService.ReceiveFine(student.StudentId, student.Fine);
        }

    }
}