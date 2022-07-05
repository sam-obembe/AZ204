# CLI Commands

Conventions : 
* `<foobar>` : placeholder a value
* `[foobar]` : optional section

## Resource Groups
* **Create a resource group** : `az group create --name <rgName> --location centralus`
* **List resource groups** : `az group list [-o table]`
* **Delete resource groups** : `az group delete --name <name> --no-wait`

* **List locations** : `az account list-locations [--out table]`


## Storage commands
**Create storage account**  
```
az storage account create 
    --name <accountName> 
    --resource-group <rgName> 
    --location <location> 
    --sku <SKU> 
    --kind StorageV2
```

**Delete storage account**
```
az storage account delete 
    --name <storage-account> 
    --resource-group <resource-group>
```

**Create container**
```
az storage container create \
    --name $containerName \
    --account-name $storageAccount \
    --auth-mode login
```

**List containers**
```
az storage container list \
    --account-name $storageAccount \
    --auth-mode login
```

**Delete containers**
```
az storage container delete
    --name $containerName \
    --account-name $storageAccount \
    --auth-mode login
```

**Read and Write Container MetaData**
```
#!/bin/bash
storageAccount="<storage-account>"
containerName="demo-container-1"
containerPrefix="demo-container-"

# Create metadata string
metadata="key=value pie=delicious"

# Update named container metadata
az storage container metadata update \
    --name $containerName \
    --metadata $metadata \
    --account-name $storageAccount \
    --auth-mode login
```