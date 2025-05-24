targetScope = 'subscription'

param applicationName string
param environment string

module rg './resource-group/resource-group.bicep' = {
  name: 'rg-deployment'
  scope: subscription()
  params: {
    applicationName: applicationName
    environment: environment
  }
}

module keyVault './keyvault/keyvault.bicep' = {
    name: 'keyvault-deployment'
    scope: resourceGroup(rg.outputs.resourceGroupName)
    params: {
        location: rg.outputs.location
        applicationName: applicationName
    }
}