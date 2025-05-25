targetScope = 'subscription'

param location string
param applicationName string
param environment string

//Bicep does not allow accessing outputs from a module declared at a different scope (like subscription → resource group)
var rgName = 'rg-${applicationName}-euw-${environment}'
module rg './resource-group/resource-group.bicep' = {
    name: 'resourcegroup-deployment'
    params: {
        location: rg.location
        name: rgName
    }
}

module keyVault './keyvault/keyvault.bicep' = {
    name: 'keyvault-deployment'
    scope: resourceGroup(rgName)
    params: {
        location: rg.location
        applicationName: applicationName
        environment: environment
    }
}