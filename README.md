# Data Ingestion into Azure EventHub to NoSQL DB.

## Architecture Diagram

![image](https://user-images.githubusercontent.com/15838780/152089372-b0b851eb-8da5-4e02-81f1-f8f784028940.png)

## Training video
https://meetings.dialpad.com/getmp4/fe6535ae848411ecbdb47d69f386681c.mp4?amp_device_id=CI3O9y4s6k53rNaBj6DzK0![image](https://user-images.githubusercontent.com/15838780/152278381-1d0a18e5-32df-4fb9-81e8-76ec7575d106.png)

## Appplication Setting 

|Key|Value | Comment|
|:----|:----|:----|
|AzureWebJobsStorage|[CONNECTION STRING]|RECOMMENDATION :  store in AzureKey Vault.|
|ConfigurationPath| [CONFIGURATION FOLDER PATH] |Folder is optional
|ApiKeyName|[API KEY NAME]|Will be passed in the header  :  the file name of the config.
|AppName| [APPLICATION NAME]| This is the name of the Function App. Used in log analytics|
|StorageAcctName|[STORAGE ACCOUNT NAME]|Example  "AzureWebJobsStorage"|
|EventHubConnectionAppSetting|[EVENT HUB CONNECTION STRING]|Example  "EventHubConnectionAppSetting"|


> **Note:**  Look at the configuration file in the **Config** Folder and created a Table to record information.

## Function App  Configuration 

> **Note:** The **Configuration** is located in the  FunctionApp  in a **Config** Folder.

|FileName|Description|
|:----|:----|
|43EFE991E8614CFB9EDECF1B0FDED37A.json| **Upload File** Parse CSV file --> Write Batched Files To Storage|
|43EFE991E8614CFB9EDECF1B0FDED37D.json| **Blob Trigger** Read Parsed CSV files --> Converts To JSON --> Sends To Event Hub|
|43EFE991E8614CFB9EDECF1B0FDED37B.json| **Event Hub Trigger** Read JSON Array from Event Hub --> Writes to a NoSQL DB|
|43EFE991E8614CFB9EDECF1B0FDED37C.json| **Search** NoSQL DB for ingested records|

> Create the following blob containers and share in azure storage.

|ContainerName|Description|
|:----|:----|
|config|Location for the configuration files|
|pickup|Thes are files that are copied from the SFTP share and dropped in the pickup container. Used  |
|processed|These are files the have been parsed and dropped in th processed container|
|eventhubmessages|Hold message retrieved from eventhub |

|Table|Description|
|:----|:----|
|csvbatchfiles|Track the CSV parsed files|
|training[YYYYMMDD]|No SQL table to store uploaded CSV Files|



> Create the following blob containers and share in azure storage.

|Table|Description|
|:----|:----|
|training[YYYYMMDD]|consumer group name|



> Create eventhub namespace and consumergroup.

|Table|Description|
|:----|:----|
|training[YYYYMMDD]|consumer group name|



  
  
  ## Products

|products|links|Comments|
|:----|:----|:----|
|Azure Getting Started |https://azure.microsoft.com/en-us/free/| Create free account + $200 in Credit|
|Sample Data Sets|https://www.kaggle.com/datasets| Useful site for pulling sample payload|
|Azure Storage Explorer|https://azure.microsoft.com/en-us/features/storage-explorer/#features|useful view and query data in azure table storage|
|Postman|https://www.postman.com/downloads/|Postman supports the Web or Desktop Version|
|VsCode| https://visualstudio.microsoft.com/downloads/ |  Required extensions. Azure Functions, Azure Account
|VS Studio Community Edition |https://visualstudio.microsoft.com/downloads/| Recommended. Nice intergration with Azure. software is free.

  
  
  ## Contact
  
For questions related to this project, can be reached via email :- support@xenhey.com
