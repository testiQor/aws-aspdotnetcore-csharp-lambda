# AWS Lambda .NET Core Demo
This repository contains a demo AWS Lambda function built with ASP.NET Core that returns an HTML page.

## Prerequisites
- .NET SDK 8.0
- AWS CLI installed and configured
- AWS Lambda Tools for .NET CLI (`dotnet tool install -g Amazon.Lambda.Tools`)

## Project Structure
```
DemoLambdaFunction/
├── src/DemoLambdaFunction/
│   ├── Controllers/
│   │   ├── HomeController.cs    # Returns HTML page
│   │   └── ValuesController.cs  # API endpoints
│   ├── aws-lambda-tools-defaults.json
│   ├── serverless.template
│   └── Startup.cs
```

## Building and Deploying

1. Clone the repository:
```bash
git clone https://github.com/iqorgit/aws-lambda-dotnet.git
cd aws-lambda-dotnet/DemoLambdaFunction/src/DemoLambdaFunction
```

2. Build the project:
```bash
dotnet build
```

3. Deploy to AWS Lambda:
```bash
dotnet lambda deploy-serverless
```

## Testing

### Local Testing
1. Run the application locally:
```bash
dotnet run
```
2. Navigate to `http://localhost:5000` in your web browser
3. You should see the message "Calling from Lambda"

### Testing on AWS
After deployment:
1. The deployment will output an API Gateway URL
2. Open the URL in your web browser
3. You should see the "Calling from Lambda" message

## Configuration
- Runtime: .NET 8
- Memory: 256MB
- Timeout: 30 seconds
- Handler: DemoLambdaFunction::DemoLambdaFunction.LambdaEntryPoint::FunctionHandlerAsync

## Features
- Handles HTTP requests using Amazon.Lambda.AspNetCoreServer
- Returns HTML page with "Calling from Lambda" message
- Configured for .NET SDK 8
- Includes AWS Lambda Tools defaults
