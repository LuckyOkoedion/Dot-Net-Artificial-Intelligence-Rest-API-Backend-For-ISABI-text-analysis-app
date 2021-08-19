using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Azure;
using System.Globalization;
using Azure.AI.TextAnalytics;
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
        public async Task<ActionResult<AnalyzeSentimentResult>> PostAndGetOpinion(OpinionMiningDTO theData)
        {
            // connect to the opinion minning sdk and return the result

            try
            {
                AnalyzeSentimentResult sentimentResult = await _textAnalyticsClient.SentimentAsync(inputText: theData.Text, language: theData.Language, options: new AnalyzeSentimentOptions()
                {
                    IncludeOpinionMining = true
                });

                if (sentimentResult == null)
                {
                    return Problem(detail: "The api returned null", statusCode: 503);
                }
                else
                {
                    return Ok(sentimentResult);
                }
            }
            catch (Exception e)
            {

                return Problem("Internal Server Error", statusCode: 501);
            }





        }

    }
}