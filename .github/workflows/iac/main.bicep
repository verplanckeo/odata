targetScope = 'subscription'

param namePrefix string = 'odata'
param environment string = 'dev'

module rg './resource-group/resource-group.bicep' = {
  name: 'rg-deployment'
  scope: subscription()
  params: {
    namePrefix: namePrefix
    environment: environment
  }
}
