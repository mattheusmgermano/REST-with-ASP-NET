using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace REST_with_ASP_NET.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {


        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{path}/{firstNumber}/{secondNumber}")]
        public IActionResult Get(string path, string firstNumber, string secondNumber)
        {
            return OperacoesMatematicas(path, firstNumber, secondNumber);
        }

        private IActionResult OperacoesMatematicas(string path, string firstNumber, string secondNumber)
        {
            switch (path)
            {
                case "sum":
                    if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
                    {
                        var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
                        return Ok(sum.ToString());
                    }
                    return BadRequest("Invalid input.");

                case "sub":
                    if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
                    {
                        var sub = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);
                        return Ok(sub.ToString());
                    }
                    return BadRequest("Invalid input.");

                case "mult":
                    if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
                    {
                        var mult = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);
                        return Ok(mult.ToString());
                    }
                    return BadRequest("Invalid input.");

                case "div":
                    if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
                    {
                        var div = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);
                        return Ok(div.ToString());
                    }
                    return BadRequest("Invalid input.");

                case "avg":
                    if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
                    {
                        var avg = (ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber)) / 2;
                        return Ok(avg.ToString());
                    }
                    return BadRequest("Invalid input.");

                default:
                    return BadRequest("Invalid input.");
            }
        }

        [HttpGet("sqrt/{firstNumber}")]
        public IActionResult Sqrt(string firstNumber)
        {
            if (IsNumeric(firstNumber))
            {
                var sqrt = Math.Sqrt(ConvertToDouble(firstNumber));
                return Ok(sqrt.ToString());
            }
            return BadRequest("Invalid input.");
        }
        private decimal ConvertToDecimal(string strNumber)
        {
            decimal decimalValue;
            if (decimal.TryParse(strNumber, out decimalValue))
            {
                return decimalValue;
            }
            return 0;
        }
        private double ConvertToDouble(string strNumber)
        {
            double doubleValue;
            if (double.TryParse(strNumber, out doubleValue))
            {
                return doubleValue;
            }
            return 0;
        }

        private bool IsNumeric(string strNumber)
        {

            double number;
            var isNumber = double.TryParse(strNumber,
                System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo, out number);
            return isNumber;
        }
    }
}
