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
/*
module keyVault './keyvault/keyvault.bicep' = {
    name: 'keyvault-deployment'
    scope: rg
    params: {
        location: rg.outputs.location
        applicationName: applicationName
        environment: environment
    }
}*/