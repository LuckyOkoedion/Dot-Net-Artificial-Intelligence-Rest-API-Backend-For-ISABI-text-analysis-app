using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Azure;
using System.Globalization;
using Azure.AI.TextAnalytics;
// using Microsoft.Azure.CognitiveServices.Language.TextAnalytics.TextAnalyticsClient;
using IsabiTextAnalysisApi.Models;

namespace IsabiTextAnalysisApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpinionMiningController : ControllerBase
    {


        private readonly TextAnalyticsClient _textAnalyticsClient;

        public OpinionMiningController(TextAnalyticsClient textAnalyticsClient)
        {
            _textAnalyticsClient = textAnalyticsClient;
        }


        [HttpPost]
        public async Task<ActionResult<DocumentSentiment>> PostAndGetOpinion(OpinionMiningDTO theData)
        {
            // connect to the opinion minning sdk and return the result

            try
            {
                DocumentSentiment sentimentResult = await _textAnalyticsClient.AnalyzeSentimentAsync(theData.Text, language: theData.Language, options: new AnalyzeSentimentOptions()
                {
                    IncludeOpinionMining = true
                });

                return Ok(sentimentResult);
            }
            catch (Exception)
            {

                throw;
            }





        }

    }
}