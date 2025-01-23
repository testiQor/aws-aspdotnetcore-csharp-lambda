# AWS Lambda .NET Core Demo
This repository contains a demo AWS Lambda function built with ASP.NET Core that returns an HTML page.

## Prerequisites
- .NET SDK 8.0
- AWS CLI installed and configured with appropriate permissions
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
│   ├── api-gateway.json         # API Gateway configuration
│   ├── lambda-url-config.json   # Lambda Function URL configuration
│   └── Startup.cs
```

## Deployment Options

### Option 1: Direct Lambda Deployment
1. Build and package:
```bash
dotnet lambda package --configuration Release
```

2. Create Lambda function:
```bash
aws lambda create-function \
  --function-name aws-lambda-dotnet \
  --runtime dotnet8 \
  --handler DemoLambdaFunction::DemoLambdaFunction.LambdaEntryPoint::FunctionHandlerAsync \
  --role YOUR_LAMBDA_ROLE_ARN \
  --zip-file fileb://bin/Release/net8.0/DemoLambdaFunction.zip
```

3. Create Lambda Function URL (Optional):
```bash
aws lambda create-function-url-config \
  --function-name aws-lambda-dotnet \
  --auth-type NONE \
  --cli-input-json file://lambda-url-config.json
```

### Option 2: API Gateway Integration
1. Deploy Lambda function (follow Option 1 steps 1-2)

2. Create API Gateway:
```bash
aws apigateway import-rest-api \
  --body file://api-gateway.json \
  --region us-east-1
```

3. Create deployment:
```bash
aws apigateway create-deployment \
  --rest-api-id YOUR_API_ID \
  --stage-name prod
```

### Option 3: Serverless Deployment
```bash
dotnet lambda deploy-serverless \
  --stack-name aws-lambda-dotnet \
  --s3-bucket YOUR_S3_BUCKET
```

## Testing

### Local Testing
1. Run locally:
```bash
dotnet run
```
2. Navigate to `http://localhost:5000`
3. You should see "Calling from Lambda"

### Testing on AWS

#### Lambda Function URL
```bash
curl https://YOUR_FUNCTION_URL.lambda-url.us-east-1.on.aws
```

#### API Gateway
```bash
curl https://YOUR_API_ID.execute-api.us-east-1.amazonaws.com/prod
```

## Configuration
- Runtime: .NET 8
- Memory: 256MB
- Timeout: 30 seconds
- Region: us-east-1
- Handler: DemoLambdaFunction::DemoLambdaFunction.LambdaEntryPoint::FunctionHandlerAsync

## Features
- Handles HTTP requests using Amazon.Lambda.AspNetCoreServer
- Returns HTML page with "Calling from Lambda" message
- Multiple deployment options (direct Lambda, API Gateway, serverless)
- CORS-enabled Lambda Function URL support
- Comprehensive API Gateway integration
