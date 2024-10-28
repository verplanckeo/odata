targetScope = 'subscription'

param namePrefix string
param environment string

module rg './resource-group/resource-group.bicep' = {
  name: 'rg-deployment'
  scope: subscription()
  params: {
    namePrefix: namePrefix
    environment: environment
  }
}
