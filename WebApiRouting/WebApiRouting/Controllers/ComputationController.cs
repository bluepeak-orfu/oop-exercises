using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiBasics.Controllers
{
    [Route("compute")]
    [ApiController]
    public class ComputationController : ControllerBase
    {
        [HttpGet("message")]
        public string Message(string myMessage)
        {
            return $"Ditt meddelande är: {myMessage}";
        }

        [HttpGet("upper/{message}")] 
        public string Upper(string message)
        {
            // /compute/upper/hej hej hej
            // compute <- Mappar till klass
            // upper
            // hej hej hej
            return message.ToUpper();
        }

        [HttpGet("concat/{message1}")]
        public string Concat(string message1, string message2)
        {
            return message1 + message2;
        }

        [HttpGet("add")]
        public string Add(int value1, int value2)
        {
            int sum = value1 + value2;
            return sum.ToString();
            // return $"{value1 + value2}";
        }

        [HttpGet("add2/{value1}/{value2}")]
        public string Add2(int value1, int value2)
        {
            int sum = value1 + value2;
            return sum.ToString();
            // return $"{value1 + value2}";
        }

        [HttpGet("multi")]
        public string MultiGreeter(int count, string message)
        {
            string result = "";
            for (int i = 0; i < count; i++)
            {
                result += message;
            }
            return result;
        }

        [HttpGet("multi2/{count}/{message}")]
        public string MultiGreeter2(int count, string message)
        {
            string result = "";
            for (int i = 0; i < count; i++)
            {
                result += message;
            }
            return result;
        }
    }
}
