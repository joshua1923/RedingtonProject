using calculator.Interfaces;
using calculator.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace calculator.Controllers
{
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        private readonly ILogger<CalculatorController> _logger;
        private readonly ICalculator _calculator;


        public CalculatorController(ILogger<CalculatorController> logger, ICalculator calculator)
        {
            _logger = logger;
            _calculator = calculator;
        }

        [HttpPost]
        [Route("api/getCalculation")]
        public int GetCalculation(Calculation calculator)
        {
            var result = _calculator.Calculate(calculator);
            _logger.LogInformation(JsonConvert.SerializeObject(calculator));

            return result;
        }

        [HttpGet]
        [Route("api/getFunctions")]
        public List<Functions> GetFunctions()
        {
            List<Functions> Functions = new();

            Functions.Add(new Functions() { FunctionName = "CombinedWith" });
            Functions.Add(new Functions() { FunctionName = "Either" });

            return Functions;
        }
    }
}
