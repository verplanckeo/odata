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

// Register an app in app registrations
module ar './app-registration/app-registration.bicep' = {
    name: 'app-registration'
    params: {
        applicationName: applicationName
        environment: environment
    }
}

// Deploy App Service into that resource group
module appService './app-service/app-service.bicep' = {
    name: 'appservice-deployment'
    scope: resourceGroup(rgName)
    params: {
        applicationName: applicationName
        environment: environment
        location: location
    }
}

// Deploy Key Vault into the same resource group
module keyVault './keyvault/keyvault.bicep' = {
    name: 'keyvault-deployment'
    scope: resourceGroup(rgName)
    params: {
        location: rg.location
        applicationName: applicationName
        environment: environment
    }
}

// Assign RBAC to App Service on Key Vault (also scoped to RG)
module keyVaultRbac './keyvault/keyvault-rbac.bicep' = {
    name: 'keyvault-rbac-deployment'
    scope: resourceGroup(rgName)
    params: {
        keyVaultId: keyVault.outputs.keyVaultId
        principalId: appService.outputs.appServicePrincipalId
    }
}