@description('Normalized Azure region short names (e.g. West-Europe -> weu)')
param location string

@description('Shortname of resource (e.g.: ResourceGroup -> rg, Keyvault -> kv)')
param resourceName string

var locationShortMap = {
    westeurope: 'weu'
    northeurope: 'neu'
    eastus: 'eus'
    westus: 'wus'
    westus2: 'wus2'
    westus3: 'wus3'
    southcentralus: 'scus'
    eastasia: 'ea'
    australiaeast: 'aue'
    australiasouteast: 'ause'
    // Extend new regions if needed
}

var normalizedLocation = toLower(replace(location, ' ', ''))

var locationShort = contains(locationShortMap, normalizedLocation)
    ? locationShortMap[normalizedLocation]
    : normalizedLocation
    
output short string = locationShort
output resourceShortName = '${resourceName}-${applicationName}-${shortener.outputs.short}'