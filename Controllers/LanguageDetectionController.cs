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
    public class LanguageDetectionController : ControllerBase
    {
        private readonly TextAnalyticsClient _textAnalyticsClient;


        public LanguageDetectionController(TextAnalyticsClient textAnalyticsClient)
        {
            _textAnalyticsClient = textAnalyticsClient;
        }

        [HttpPost]
        public async Task<ActionResult<DetectedLanguage>> PostAndCheckLanguage(LanguageDetectionDTO theData)
        {
            // Connect to the language detector sdk and return the detected language

            try
            {
                DetectedLanguage detectedLanguage = await _textAnalyticsClient.DetectLanguageAsync(theData.Text);

                return Ok(detectedLanguage);


            }
            catch (Exception)
            {
                throw;

            }



        }


    }
}