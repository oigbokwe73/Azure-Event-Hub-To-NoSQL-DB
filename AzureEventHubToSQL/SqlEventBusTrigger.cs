using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs;
using Microsoft.Azure.Documents.SystemFunctions;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Xenhey.BPM.Core.Net6;
using Xenhey.BPM.Core.Net6.Implementation;

namespace AzureEventHubToNoSQLDB
{
    public  class SqlEventBusTrigger
    {

        private NameValueCollection nvc = new NameValueCollection();
        [FunctionName("SqlEventBusTrigger")]
        public  async Task Run([EventHubTrigger("training20230422", Connection = "EventHubConnectionAppSetting",ConsumerGroup = "nosqldb")] EventData[] events, ILogger log)
        {
            nvc.Add("x-api-key", "43EFE991E8614CFB9EDECF1B0FDED37F");
            var exceptions = new List<Exception>();


            foreach (EventData eventData in events)
            {
                try
                {
                    // Replace these two lines with your processing logic.


                    string messageBody = eventData.EventBody.ToString();

                    var results = orchrestatorService.Run(messageBody);
                    log.LogInformation(messageBody);
                    await Task.Yield();
                }
                catch (Exception e)
                {
                    // We need to keep processing the rest of the batch - capture this exception and continue.
                    // Also, consider capturing details of the message that failed processing so it can be processed again later.
                    exceptions.Add(e);
                }
            }

            // Once processing of the batch is complete, if any messages in the batch failed processing throw an exception so that there is a record of the failure.

            if (exceptions.Count > 1)
                throw new AggregateException(exceptions);

            if (exceptions.Count == 1)
                throw exceptions.Single();
        }

        private IOrchestrationService orchrestatorService
        {
            get
            {
                return new ManagedOrchestratorService(nvc);
            }
        }
    }
}
