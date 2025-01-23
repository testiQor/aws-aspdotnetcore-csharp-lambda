using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace DemoLambdaFunction.Controllers;

public class HomeController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        var html = @"<!DOCTYPE html>
<html>
<head>
    <title>AWS Lambda</title>
</head>
<body>
    <h1>Calling from Lambda</h1>
</body>
</html>";
        
        return Content(html, "text/html");
    }
}
