targetScope = 'subscription'

param location string
param applicationName string
param environment string

//Bicep does not allow accessing outputs from a module declared at a different scope (like subscription → resource group)
var rgName = 'rg-${applicationName}-euw-${environment}'

// Create the Resource Group (subscription scope)
module rg './resource-group/resource-group.bicep' = {
    name: 'resourcegroup-deployment'
    params: {
        location: location
        name: rgName
    }
}

// Deploy App Service into that resource group
module appInsights './application-insights/application-insights.bicep' = {
    name: 'applicationinsights-deployment'
    scope: resourceGroup(rgName)
    params: {
        applicationName: applicationName
        environment: environment
        location: rg.outputs.location
    }
}

// Deploy App Service into that resource group
module appService './app-service/app-service.bicep' = {
    name: 'appservice-deployment'
    scope: resourceGroup(rgName)
    params: {
        applicationName: applicationName
        environment: environment
        location: rg.outputs.location
        applicationInsightsConnectionString: appInsights.outputs.connectionString
    }
}

// Deploy Key Vault into the same resource group
module keyVault './keyvault/keyvault.bicep' = {
    name: 'keyvault-deployment'
    scope: resourceGroup(rgName)
    params: {
        location: rg.outputs.location
        applicationName: applicationName
        environment: environment
        principalId: appService.outputs.appServicePrincipalId
    }
}