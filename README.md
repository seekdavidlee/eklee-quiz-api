# Introduction

Use this project to host your own quiz API. Note that this is just a backend API. You are free to create your own frontend or use an existing frontend project I have created.

## local.settings.json
To run this project locally, you will need to have the following. You will need to register an application in your Azure Active Directory (AAD). From there, you will be able to get your Application Id and Tenant Id (directory Id). From here, you can use your AAD credentials to get a bearer token to invoke APIs.

```
{
	"IsEncrypted": false,
	"Values": {
		"AzureWebJobsStorage": "",
		"FUNCTIONS_WORKER_RUNTIME": "dotnet"
	},
	"Connection": "UseDevelopmentStorage=true",
	"Prefix": "dev",
	"Security": {
		"Audience": "<AppId>",
		"Issuers": "https://sts.windows.net/<TenantId>"
	},
	"Host": {
		"LocalHttpPort": 7071,
		"CORS": "*"
	}
}
```

# Serverless
This project uses [https://www.nuget.org/packages/Eklee.Azure.Functions.GraphQl](https://www.nuget.org/packages/Eklee.Azure.Functions.GraphQl) as the GraphQL backend.