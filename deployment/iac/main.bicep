targetScope = 'subscription'

param location string
param applicationName string
param environment string

module rg './resource-group/resource-group.bicep' = {
  name: 'rg-deployment'
  scope: subscription()
  params: {
        location: location
        applicationName: applicationName
        environment: environment
  }
}

module keyVault './keyvault/keyvault.bicep' = {
    name: 'keyvault-deployment'
    scope: resourceGroup(rg.outputs.resourceGroup.name)
    params: {
        location: rg.outputs.resourceGroup.location
        applicationName: applicationName
        environment: environment
    }
}