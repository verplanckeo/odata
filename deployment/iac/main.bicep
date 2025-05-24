targetScope = 'subscription'

param location string
param applicationName string
param environment string

resource rg 'Microsoft.Resources/resourceGroups@2025-04-01' = {
  name: 'rg-${applicationName}-euw-${environment}'
  location: location
}

module keyVault './keyvault/keyvault.bicep' = {
    name: 'keyvault-deployment'
    scope: resourceGroup(rg.name)
    params: {
        location: rg.location
        applicationName: applicationName
        environment: environment
    }
}